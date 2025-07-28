using BusinessLayer.Abstract;
using EntityLayer;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using System.Threading.Tasks;

public class HomeController : Controller
{
    private readonly IChatMessageService _chatMessageService;
    private readonly IResumeService _resumeService;
    private readonly IJobPostingService _jobPostingService;
    private readonly IChatbotService _chatbotService;

    public HomeController(
        IChatMessageService chatMessageService,
        IResumeService resumeService,
        IJobPostingService jobPostingService,
        IChatbotService chatbotService)
    {
        _chatMessageService = chatMessageService;
        _resumeService = resumeService;
        _jobPostingService = jobPostingService;
        _chatbotService = chatbotService;
    }

    public IActionResult Index()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> SendMessage([FromBody] ChatMessage message)
    {
        if (string.IsNullOrEmpty(message.Content))
            return BadRequest("Mesaj boş olamaz.");

        // Gemini'den yanıt al
        var response = await _chatbotService.GetResponseAsync(message.Content);

        // Kullanıcı mesajını kaydet
        await _chatMessageService.AddAsync(new ChatMessage
        {
            Content = message.Content,
            IsFromBot = false,
            CreatedDate = System.DateTime.Now
        });

        // Bot yanıtını kaydet
        await _chatMessageService.AddAsync(new ChatMessage
        {
            Content = response,
            IsFromBot = true,
            CreatedDate = System.DateTime.Now
        });

        return Json(new { success = true, response });
    }
}