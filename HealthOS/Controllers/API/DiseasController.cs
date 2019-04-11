using HealthOS.Models;
using HealthOS.Repositories.Interfaces;
using Microsoft.AspNet.Identity;
using Microsoft.AspNetCore.Mvc;

namespace HealthOS.Controllers.API
{
    [Route("api/Diseas")]
    public class DiseasController : Controller
    {
        #region Properties
        private readonly IUserRepository _userRepository;
        private readonly IDiseaseRepository _diseaseRepository;
        #endregion
        public DiseasController(IUserRepository userRepository, IDiseaseRepository diseaseRepository)
        {
            _userRepository = userRepository;
            _diseaseRepository = diseaseRepository;
        }
        // GET: api/Diseas/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var diseas = _diseaseRepository.Get(id);
            if (diseas != null) return Ok(diseas);
            return StatusCode(404);
        }

        // GET: api/Diseas
        [HttpGet("{id}")]
        public IActionResult Get()
        {
            var diseases = _diseaseRepository.Get();
            if (diseases != null) return Ok(diseases);
            return StatusCode(404);
        }

        // POST: api/Diseas
        [HttpPost]
        public IActionResult Post([FromBody]Disease value)
        {
            value.ApplicationUser = _userRepository.GetWithDiseasesAndAllergies(User.Identity.GetUserId());
            _diseaseRepository.Add(value);
            return Ok(value);
        }
        
        // PUT: api/Diseas/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody]Disease value)
        {
            _diseaseRepository.Update(value, id);
            return Ok(value);
        }
        
        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _diseaseRepository.Remove(id);
            return Ok();
        }
    }
}
