using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IAIService
    {
        Task<string> ParsePdfContent(string filePath);
    }
} 