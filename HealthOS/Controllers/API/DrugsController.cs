using System.Collections.Generic;
using HealthOS.Models;
using HealthOS.Repositories.Interfaces;
using Microsoft.AspNet.Identity;
using Microsoft.AspNetCore.Mvc;

namespace HealthOS.Controllers.API
{
    [Produces("application/json")]
    [Route("api/Drugs")]
    public class DrugsController : Controller
    {
        #region Properties
        private ApplicationUser _user;
        private readonly IUserRepository _userRepository;
        private readonly IDrugsRepository _drugsRepository;
        #endregion
        public DrugsController(IUserRepository userRepository, IDrugsRepository drugsRepository)
        {
            _userRepository = userRepository;
            _drugsRepository = drugsRepository;
        }
        // GET: api/Drugs
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Drugs/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Drugs
        [HttpPost]
        public IActionResult Post([FromBody]Drug value)
        {
            if (_user == null) _user = _userRepository.Get(User.Identity.GetUserId());
            value.ApplicationUser = _user;
            _drugsRepository.Add(value);
            return Ok(value);
        }
        
        // PUT: api/Drugs/5
        [HttpPut("{id}")]
        public void Put([FromBody]DrugUpdateViewModel value, int id)
        {
            if (_user == null) _user = _userRepository.Get(User.Identity.GetUserId());
            _drugsRepository.Update(value, id);
        }
        
        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _drugsRepository.Delete(id);
        }
    }
}
