using BusinessLayer.Abstract;
using System.Threading.Tasks;
using System.IO;
using System.Linq;
using UglyToad.PdfPig;

namespace BusinessLayer.Concrete
{
    public class AIService : IAIService
    {
        public async Task<string> ParsePdfContent(string filePath)
        {
            if (!File.Exists(filePath))
                return "PDF dosyası bulunamadı.";

            using (var pdf = PdfDocument.Open(filePath))
            {
                var text = string.Join("\n", pdf.GetPages().Select(p => p.Text));
                return await Task.FromResult(text);
            }
        }
    }
} 