using BusinessLayer.Abstract;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class AIService : IAIService
    {
        public async Task<string> ParsePdfContent(string filePath)
        {
            // TODO: Implement PDF parsing logic
            // Şimdilik basit bir implementasyon
            return await Task.FromResult("Parsed content will be here");
        }
    }
} 