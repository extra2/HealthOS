using HealthOS.Models;
using HealthOS.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace HealthOS.Controllers.API
{
    [Route("api/PersonalData")]
    public class PersonalDataController : Controller
    {
        private readonly IUserRepository _userRepository;
        public PersonalDataController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        // PUT: api/PersonalData/5
        [HttpPut("{id}")]
        public IActionResult Put(string id, [FromBody]ApplicationUserUpdateModel value)
        {
            _userRepository.Update(id, value);
            return Ok();
        }
    }
}
