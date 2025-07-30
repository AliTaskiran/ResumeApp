using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IChatbotService
    {
        Task<string> GetResponseAsync(string userMessage, int userId = 0, string context = "");
    }
} 