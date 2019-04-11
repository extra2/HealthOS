using System;

namespace HealthOS.Models.HelperModels
{
    public class ChatMainInboxModel
    {
        public string Title { get; set; }
        public string UserName { get; set; }
        public string UserId { get; set; }
        public DateTime SentDate { get; set; }
        public bool Seen { get; set; }
    }
}
