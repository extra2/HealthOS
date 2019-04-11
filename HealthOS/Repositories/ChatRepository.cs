using System.Collections.Generic;
using System.Linq;
using HealthOS.Data;
using HealthOS.Models;
using HealthOS.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace HealthOS.Repositories
{
    public class ChatRepository : IChatRepository
    {
        private ApplicationDbContext _context;

        public ChatRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public List<ChatMessage> Chats(string id)
        {
            var chatMessages = _context.ChatMessages.Where(u => u.UserTo.Id == id || u.UserFrom.Id == id).Include(u=>u.UserFrom).Include(u=>u.UserTo).ToList();
            return chatMessages;
        }

        public void Add(ChatMessage message)
        {
            _context.ChatMessages.Add(message);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var message = _context.ChatMessages.FirstOrDefault(c => c.Id == id);
            if (message == null) return;
            _context.ChatMessages.Remove(message);
            _context.SaveChanges();
        }
        public List<ChatMessage> GetChat(string id, string id2)
        {
            return _context.ChatMessages
                .Where(c => (c.UserFrom.Id == id && c.UserTo.Id == id2) || (c.UserFrom.Id == id2 && c.UserTo.Id == id))
                .OrderByDescending(m=>m.SentDate)
                .ToList();
        }

        public void SetSeen(string from, string to)
        {
            var messages = _context.ChatMessages.Where(m => m.UserFrom.Id == @from && m.UserTo.Id == to).ToList();  
            messages.ForEach(m => m.Seen = true);
            _context.SaveChanges();
        }
    }
}
