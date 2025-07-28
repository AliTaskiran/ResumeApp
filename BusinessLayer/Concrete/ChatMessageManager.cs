using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class ChatMessageManager : IChatMessageService
    {
        private readonly IChatMessageDal _chatMessageDal;

        public ChatMessageManager(IChatMessageDal chatMessageDal)
        {
            _chatMessageDal = chatMessageDal;
        }

        public async Task<ChatMessage> AddAsync(ChatMessage chatMessage)
        {
            await _chatMessageDal.AddAsync(chatMessage);
            return chatMessage;
        }

        public void TAdd(ChatMessage t)
        {
            _chatMessageDal.Insert(t);
        }

        public void TDelete(ChatMessage t)
        {
            _chatMessageDal.Delete(t);
        }

        public ChatMessage TGetById(int id)
        {
            return _chatMessageDal.GetById(id);
        }

        public List<ChatMessage> TGetList()
        {
            return _chatMessageDal.GetList();
        }

        public void TUpdate(ChatMessage t)
        {
            _chatMessageDal.Update(t);
        }
    }
}
