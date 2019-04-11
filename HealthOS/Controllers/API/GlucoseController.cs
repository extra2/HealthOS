using HealthOS.Models;
using HealthOS.Models.Statistics;
using HealthOS.Repositories.Interfaces;
using Microsoft.AspNet.Identity;
using Microsoft.AspNetCore.Mvc;

namespace HealthOS.Controllers.API
{
    [Route("api/Glucose")]
    public class GlucoseController : Controller
    {
        #region Properties
        private ApplicationUser _user;
        private readonly IUserRepository _userRepository;
        private readonly IGlucoseLevelRepository _glucoseRepository;
        #endregion
        public GlucoseController(IUserRepository userRepository, IGlucoseLevelRepository glucoseRepository)
        {
            _userRepository = userRepository;
            _glucoseRepository = glucoseRepository;
        }

        // POST: api/Glucose
        [HttpPost]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        public IActionResult Post([FromBody]GlucoseLevelStatistics value)
        {
            if (_user == null) _user = _userRepository.Get(User.Identity.GetUserId());
            value.ApplicationUser = _user;
            _glucoseRepository.Add(value);
            return Ok(value);
        }
        
        // PUT: api/Glucose/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }
        
        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _glucoseRepository.Remove(id);
        }
    }
}
