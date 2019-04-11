using System;
using HealthOS.Models;
using HealthOS.Models.HelperModels;
using HealthOS.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace HealthOS.Controllers.API
{
    [Route("api/Chat")]
    public class ChatController : Controller
    {
        private IUserRepository _userRepository;
        private IChatRepository _chatRepository;
        public ChatController(IUserRepository userRepository, IChatRepository chatRepository)
        {
            _userRepository = userRepository;
            _chatRepository = chatRepository;
        }
        //// GET: api/Chat
        //[HttpGet]
        //public IEnumerable<string> Get()
        //{
        //    return new string[] { "value1", "value2" };
        //}

        //// GET: api/Chat/5
        //[HttpGet("{id}", Name = "Get")]
        //public string Get(int id)
        //{
        //    return "value";
        //}
        
        // POST: api/Chat
        [HttpPost]
        public IActionResult Post([FromBody]ChatMessageModel value)
        {
            var message = new ChatMessage
            {
                Body = value.Body,
                Seen = false,
                SentDate = DateTime.Now.ToUniversalTime(),
                Title = value.Title,
                UserFrom = _userRepository.Get(value.UserFrom),
                UserTo = _userRepository.Get(value.UserTo)
            };
            _chatRepository.Add(message);
            return Ok();
        }
        
        // PUT: api/Chat/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }
        
        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _chatRepository.Delete(id);
        }
    }
}
