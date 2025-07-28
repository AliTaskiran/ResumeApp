using EntityLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IChatMessageService : IGenericService<ChatMessage>
    {
        Task<ChatMessage> AddAsync(ChatMessage chatMessage);
    }
}
