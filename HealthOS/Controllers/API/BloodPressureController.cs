using HealthOS.Models;
using HealthOS.Models.Statistics;
using HealthOS.Repositories.Interfaces;
using Microsoft.AspNet.Identity;
using Microsoft.AspNetCore.Mvc;

namespace HealthOS.Controllers.API
{
    [Route("api/BloodPressure")]
    public class BloodPressureController : Controller
    {
        #region Properties
        private ApplicationUser _user;
        private readonly IUserRepository _userRepository;
        private readonly IBloodPressureRepository _bloodPressureRepository;
        #endregion
        public BloodPressureController(IUserRepository userRepository, IBloodPressureRepository bloodPressureRepository)
        {
            _userRepository = userRepository;
            _bloodPressureRepository = bloodPressureRepository;
        }

       
        //// GET: api/BloodPressure
        //[HttpGet]
        //public IEnumerable<string> Get()
        //{
        //    return new string[] { "value1", "value2" };
        //}

        //// GET: api/BloodPressure/5
        //[HttpGet("{id}", Name = "Get")]
        //public string Get(int id)
        //{
        //    return "value";
        //}

        // POST: api/BloodPressure
        [HttpPost]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        public IActionResult Post([FromBody]BloodPressureStatistics value)
        {
            if (_user == null) _user = _userRepository.Get(User.Identity.GetUserId());
            value.ApplicationUser = _user;
            _bloodPressureRepository.Add(value);
            return Ok(value);
        }

        // PUT: api/BloodPressure/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]BloodPressureStatistics value)
        {
        }

        // DELETE: api/BloodPressure/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _bloodPressureRepository.Remove(id);
        }
    }
}
