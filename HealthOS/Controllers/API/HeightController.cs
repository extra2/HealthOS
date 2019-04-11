using HealthOS.Models;
using HealthOS.Models.Statistics;
using HealthOS.Repositories.Interfaces;
using Microsoft.AspNet.Identity;
using Microsoft.AspNetCore.Mvc;

namespace HealthOS.Controllers.API
{
    [Produces("application/json")]
    [Route("api/Height")]
    public class HeightController : Controller
    {
        #region Properties
        private ApplicationUser _user;
        private readonly IUserRepository _userRepository;
        private readonly IHeightRepository _heightRepository;
        #endregion
        public HeightController(IUserRepository userRepository, IHeightRepository heightRepository)
        {
            _userRepository = userRepository;
            _heightRepository = heightRepository;
        }
        //// GET: api/Height
        //[HttpGet]
        //public IEnumerable<string> Get()
        //{
        //    return new string[] { "value1", "value2" };
        //}

        //// GET: api/Height/5
        //[HttpGet("{id}", Name = "Get")]
        //public string Get(int id)
        //{
        //    return "value";
        //}

        // POST: api/Height
        [HttpPost]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        public IActionResult Post([FromBody]HeightStatistics value)
        {
            if (_user == null) _user = _userRepository.Get(User.Identity.GetUserId());
            value.ApplicationUser = _user;
            _heightRepository.Add(value);
            return Ok(value);
        }
        
        // PUT: api/Height/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }
        
        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _heightRepository.Remove(id);
        }
    }
}
