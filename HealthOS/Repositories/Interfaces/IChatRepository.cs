using System.Collections.Generic;
using HealthOS.Models;

namespace HealthOS.Repositories.Interfaces
{
    public interface IChatRepository
    {
        List<ChatMessage> Chats(string id);
        void Add(ChatMessage message);
        void Delete(int id);
        List<ChatMessage> GetChat(string id, string id2);
        void SetSeen(string from, string to);
    }
}