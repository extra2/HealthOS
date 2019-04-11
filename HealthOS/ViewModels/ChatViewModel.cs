using System.Collections.Generic;
using HealthOS.Models;
using HealthOS.Models.HelperModels;

namespace HealthOS.ViewModels
{
    public class ChatMainInboxViewModel
    {
        public List<ChatMainInboxModel> ChatMainInbox { get; set; }
        public List<SendToModel> Users { get; set; }
        public ApplicationUser ApplicationUser { get; set; }
    }
}