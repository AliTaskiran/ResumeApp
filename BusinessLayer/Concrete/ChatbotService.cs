using System.Text;
using System.Text.Json;
using BusinessLayer.Abstract;
using Microsoft.Extensions.Configuration;
using EntityLayer;
using System.Linq;

namespace BusinessLayer.Concrete
{
    public class ChatbotService : IChatbotService
    {
        private readonly IConfiguration _configuration;
        private readonly IResumeService _resumeService;
        private readonly IMatchingService _matchingService;
        private readonly HttpClient _httpClient;
        private const string GEMINI_API_URL = "https://generativelanguage.googleapis.com/v1beta/models/gemini-1.5-flash:generateContent";

        private const string SYSTEM_PROMPT = @"Sen bir CV-İş Eşleştirme asistanısın. Görevin:
1. Kullanıcıların CV'lerini analiz etmek
2. Mevcut iş ilanlarıyla eşleştirmek
3. Kullanıcılara kariyer tavsiyeleri vermek
4. CV'lerini geliştirmeleri için önerilerde bulunmak

Şu konularda yardımcı olabilirsin:
- CV analizi ve değerlendirmesi
- İş ilanlarıyla eşleştirme
- Kariyer tavsiyeleri
- CV geliştirme önerileri
- Mülakat tavsiyeleri

Cevaplarını Türkçe, profesyonel ve yardımsever bir tonda ver.";

        public ChatbotService(
            IConfiguration configuration,
            IResumeService resumeService,
            IMatchingService matchingService)
        {
            _configuration = configuration;
            _resumeService = resumeService;
            _matchingService = matchingService;
            _httpClient = new HttpClient();
        }

        public async Task<string> GetResponseAsync(string userMessage, string context = "")
        {
            try
            {
                Console.WriteLine($"ChatbotService.GetResponseAsync çağrıldı. Mesaj: {userMessage}");
                
                // API anahtarını kontrol et
                var apiKey = _configuration["Gemini:ApiKey"];
                Console.WriteLine($"API Key kontrol ediliyor: {!string.IsNullOrEmpty(apiKey)}");
                Console.WriteLine($"API Key ilk 10 karakteri: {apiKey?.Substring(0, Math.Min(10, apiKey?.Length ?? 0))}...");
                
                if (string.IsNullOrEmpty(apiKey))
                {
                    Console.WriteLine("API anahtarı bulunamadı!");
                    return "API anahtarı bulunamadı. Lütfen sistem yöneticisiyle iletişime geçin.";
                }

                // CV ID'sini kontrol et
                var cvIdMatch = System.Text.RegularExpressions.Regex.Match(userMessage, @"CV ID (\d+)");
                Resume selectedCV = null;

                if (cvIdMatch.Success && int.TryParse(cvIdMatch.Groups[1].Value, out int cvId))
                {
                    Console.WriteLine($"CV ID bulundu: {cvId}");
                    selectedCV = await _resumeService.GetByIdAsync(cvId);
                    if (selectedCV == null)
                    {
                        Console.WriteLine("Belirtilen CV bulunamadı");
                        return "Belirtilen CV bulunamadı.";
                    }
                }
                else
                {
                    // Kullanıcının ana CV'sini al
                    var userId = 1; // Şimdilik sabit
                    var allResumes = await _resumeService.GetListAsync();
                    selectedCV = allResumes.FirstOrDefault(r => r.UserId == userId && r.IsMainResume);
                    Console.WriteLine($"Ana CV bulundu: {selectedCV?.Title ?? "Yok"}");
                }

                var userContext = selectedCV != null
                    ? $@"Kullanıcının CV'si:
Başlık: {selectedCV.Title}
Yetenekler: {selectedCV.Skills}
Deneyim: {selectedCV.Experience}
Eğitim: {selectedCV.Education}
İçerik: {selectedCV.ParsedContent}

Lütfen bu CV için:
1. Güçlü yönleri
2. Geliştirilmesi gereken alanları
3. Öneriler
4. Uygun pozisyonlar
başlıkları altında detaylı bir analiz yap."
                    : "Kullanıcının henüz bir CV'si yok.";

                // İş eşleştirme özelliği
                string matchingJobsInfo = "";
                if (selectedCV != null && !string.IsNullOrEmpty(selectedCV.ParsedContent))
                {
                    try
                    {
                        matchingJobsInfo = await _matchingService.GetMatchingJobsSummary(selectedCV.ParsedContent);
                        Console.WriteLine("İş eşleştirme tamamlandı");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"İş eşleştirme hatası: {ex.Message}");
                        matchingJobsInfo = "İş eşleştirme sırasında bir hata oluştu.";
                    }
                }

                var fullContext = $"{SYSTEM_PROMPT}\n\n{userContext}\n\nKullanıcı Mesajı: {userMessage}";

                // Eğer iş eşleştirme bilgisi varsa ekle
                if (!string.IsNullOrEmpty(matchingJobsInfo))
                {
                    fullContext += $"\n\n📋 UYGUN İŞ İLANLARI:\n{matchingJobsInfo}";
                }

                Console.WriteLine($"Tam context hazırlandı. Uzunluk: {fullContext.Length}");

                var requestBody = new
                {
                    contents = new[]
                    {
                        new
                        {
                            parts = new[]
                            {
                                new { text = fullContext }
                            }
                        }
                    },
                    generationConfig = new
                    {
                        temperature = 0.7,
                        topK = 40,
                        topP = 0.95,
                        maxOutputTokens = 2048
                    },
                    safetySettings = new[]
                    {
                        new
                        {
                            category = "HARM_CATEGORY_HARASSMENT",
                            threshold = "BLOCK_MEDIUM_AND_ABOVE"
                        },
                        new
                        {
                            category = "HARM_CATEGORY_HATE_SPEECH",
                            threshold = "BLOCK_MEDIUM_AND_ABOVE"
                        },
                        new
                        {
                            category = "HARM_CATEGORY_SEXUALLY_EXPLICIT",
                            threshold = "BLOCK_MEDIUM_AND_ABOVE"
                        },
                        new
                        {
                            category = "HARM_CATEGORY_DANGEROUS_CONTENT",
                            threshold = "BLOCK_MEDIUM_AND_ABOVE"
                        }
                    }
                };

                var json = JsonSerializer.Serialize(requestBody, new JsonSerializerOptions
                {
                    PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                    WriteIndented = true
                });

                Console.WriteLine($"Request Body hazırlandı. Uzunluk: {json.Length}");
                Console.WriteLine($"Request Body: {json}");
                Console.WriteLine($"API URL: {GEMINI_API_URL}?key={apiKey.Substring(0, 10)}...");

                var content = new StringContent(json, Encoding.UTF8, "application/json");

                Console.WriteLine("API isteği gönderiliyor...");
                var response = await _httpClient.PostAsync(
                    $"{GEMINI_API_URL}?key={apiKey}",
                    content
                );

                var responseContent = await response.Content.ReadAsStringAsync();
                Console.WriteLine($"API Response Status: {response.StatusCode}");
                Console.WriteLine($"API Response Content Length: {responseContent.Length}");
                Console.WriteLine($"API Response Content: {responseContent}");

                if (response.IsSuccessStatusCode)
                {
                    try
                    {
                        // Önce JSON'ı dynamic olarak parse et
                        var jsonDoc = JsonDocument.Parse(responseContent);
                        var root = jsonDoc.RootElement;
                        
                        Console.WriteLine($"Root element type: {root.ValueKind}");
                        
                        // Candidates array'ini kontrol et
                        if (root.TryGetProperty("candidates", out var candidatesElement) && candidatesElement.ValueKind == JsonValueKind.Array)
                        {
                            var candidatesArray = candidatesElement.EnumerateArray().ToList();
                            Console.WriteLine($"Candidates count: {candidatesArray.Count}");
                            
                            if (candidatesArray.Count > 0)
                            {
                                var firstCandidate = candidatesArray[0];
                                Console.WriteLine($"First candidate type: {firstCandidate.ValueKind}");
                                
                                // Content'i kontrol et
                                if (firstCandidate.TryGetProperty("content", out var contentElement))
                                {
                                    Console.WriteLine($"Content type: {contentElement.ValueKind}");
                                    
                                    // Parts array'ini kontrol et
                                    if (contentElement.TryGetProperty("parts", out var partsElement) && partsElement.ValueKind == JsonValueKind.Array)
                                    {
                                        var partsArray = partsElement.EnumerateArray().ToList();
                                        Console.WriteLine($"Parts count: {partsArray.Count}");
                                        
                                        if (partsArray.Count > 0)
                                        {
                                            var firstPart = partsArray[0];
                                            Console.WriteLine($"First part type: {firstPart.ValueKind}");
                                            
                                            // Text'i kontrol et
                                            if (firstPart.TryGetProperty("text", out var textElement))
                                            {
                                                var text = textElement.GetString();
                                                Console.WriteLine($"Text found: {text != null}, Length: {text?.Length ?? 0}");
                                                
                                                if (!string.IsNullOrEmpty(text))
                                                {
                                                    Console.WriteLine($"Başarılı yanıt alındı. Uzunluk: {text.Length}");
                                                    return text;
                                                }
                                                else
                                                {
                                                    Console.WriteLine("Text boş");
                                                    return "API yanıtında text bulunamadı.";
                                                }
                                            }
                                            else
                                            {
                                                Console.WriteLine("Text property bulunamadı");
                                                return "API yanıtında text property bulunamadı.";
                                            }
                                        }
                                        else
                                        {
                                            Console.WriteLine("Parts array boş");
                                            return "API yanıtında parts array boş.";
                                        }
                                    }
                                    else
                                    {
                                        Console.WriteLine("Parts property bulunamadı");
                                        return "API yanıtında parts property bulunamadı.";
                                    }
                                }
                                else
                                {
                                    Console.WriteLine("Content property bulunamadı");
                                    return "API yanıtında content property bulunamadı.";
                                }
                            }
                            else
                            {
                                Console.WriteLine("Candidates array boş");
                                return "API yanıtında candidates array boş.";
                            }
                        }
                        else
                        {
                            Console.WriteLine("Candidates property bulunamadı");
                            return "API yanıtında candidates property bulunamadı.";
                        }
                    }
                    catch (JsonException ex)
                    {
                        Console.WriteLine($"JSON Deserialization Error: {ex.Message}");
                        Console.WriteLine($"Response Content: {responseContent}");
                        return $"API yanıtı işlenirken hata oluştu: {ex.Message}\nYanıt: {responseContent}";
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"General parsing error: {ex.Message}");
                        Console.WriteLine($"Response Content: {responseContent}");
                        return $"API yanıtı işlenirken genel hata oluştu: {ex.Message}\nYanıt: {responseContent}";
                    }
                }
                else
                {
                    Console.WriteLine($"API yanıt vermedi. Durum Kodu: {response.StatusCode}");
                    Console.WriteLine($"API Error Response: {responseContent}");
                    return $"API yanıt vermedi. Durum Kodu: {response.StatusCode}, Yanıt: {responseContent}";
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"General Error: {ex.Message}");
                Console.WriteLine($"Stack Trace: {ex.StackTrace}");
                return $"Bir hata oluştu: {ex.Message}";
            }
        }
    }

    // Gemini API response modelleri
    public class GeminiResponse
    {
        public Candidate[] candidates { get; set; }
        public PromptFeedback promptFeedback { get; set; }
    }

    public class Candidate
    {
        public Content content { get; set; }
        public string finishReason { get; set; }
        public int index { get; set; }
        public SafetyRating[] safetyRatings { get; set; }
    }

    public class Content
    {
        public Part[] parts { get; set; }
        public string role { get; set; }
    }

    public class Part
    {
        public string text { get; set; }
        public InlineData inlineData { get; set; }
    }

    public class InlineData
    {
        public string mimeType { get; set; }
        public string data { get; set; }
    }

    public class SafetyRating
    {
        public string category { get; set; }
        public string probability { get; set; }
    }

    public class PromptFeedback
    {
        public SafetyRating[] safetyRatings { get; set; }
    }
} 