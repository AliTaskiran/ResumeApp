using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DataAccessLayer.Repositories;
using EntityLayer;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace DataAccessLayer.EntityFramework
{
    public class EfChatMessageDal : GenericRepository<ChatMessage>, IChatMessageDal
    {
        public async Task<ChatMessage> AddAsync(ChatMessage chatMessage)
        {
            using var context = new Context();
            await context.ChatMessages.AddAsync(chatMessage);
            await context.SaveChangesAsync();
            return chatMessage;
        }
    }
}
