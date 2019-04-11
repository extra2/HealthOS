using HealthOS.Models;
using HealthOS.Models.Statistics;
using HealthOS.Repositories.Interfaces;
using Microsoft.AspNet.Identity;
using Microsoft.AspNetCore.Mvc;

namespace HealthOS.Controllers.API
{
    [Produces("application/json")]
    [Route("api/Weight")]
    public class WeightController : Controller
    {
        #region Properties
        private ApplicationUser _user;
        private readonly IUserRepository _userRepository;
        private readonly IWeightRepository _weightRepository;
        #endregion
        public WeightController(IUserRepository userRepository, IWeightRepository weightRepository)
        {
            _userRepository = userRepository;
            _weightRepository = weightRepository;
        }
        //// GET: api/Weight
        //[HttpGet]
        //public IEnumerable<string> Get()
        //{
        //    return new string[] { "value1", "value2" };
        //}

        //// GET: api/Weight/5
        //[HttpGet("{id}", Name = "Get")]
        //public string Get(int id)
        //{
        //    return "value";
        //}

        // POST: api/Weight
        [HttpPost]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        public IActionResult Post([FromBody]WeightStatistics value)
        {
            if (_user == null) _user = _userRepository.Get(User.Identity.GetUserId());
            value.ApplicationUser = _user;
            _weightRepository.Add(value);
            return Ok(value);
        }
        
        // PUT: api/Weight/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }
        
        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _weightRepository.Remove(id);
        }
    }
}
