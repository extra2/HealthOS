using System.Collections.Generic;
using HealthOS.Models;

namespace HealthOS.ViewModels
{
    public class ChatWithUserViewModel
    {
        public ApplicationUser CurreentUser { get; set; }
        public ApplicationUser ConversationUser { get; set; }
        public List<ChatMessage> ChatMessages { get; set; }
    }
}
