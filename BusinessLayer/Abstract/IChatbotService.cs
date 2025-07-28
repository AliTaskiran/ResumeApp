using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IChatbotService
    {
        Task<string> GetResponseAsync(string userMessage, string context = "");
    }
} 