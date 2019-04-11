using HealthOS.Models;
using HealthOS.Repositories.Interfaces;
using Microsoft.AspNet.Identity;
using Microsoft.AspNetCore.Mvc;

namespace HealthOS.Controllers.API
{
    [Route("api/Allergy")]
    public class AllergyController : Controller
    {
        #region Properties
        private readonly IUserRepository _userRepository;
        private readonly IAllergyRepository _allergyRepository;
        #endregion
        public AllergyController(IUserRepository userRepository, IAllergyRepository allergyRepository)
        {
            _userRepository = userRepository;
            _allergyRepository = allergyRepository;
        }
        
        // POST: api/Allergy
        [HttpPost]
        public IActionResult Post([FromBody]Allergy value)
        {
            value.ApplicationUser = _userRepository.GetWithDiseasesAndAllergies(User.Identity.GetUserId());
            _allergyRepository.Add(value);
            return Ok(value);
        }
        
        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _allergyRepository.Remove(id);
            return Ok();
        }
    }
}
