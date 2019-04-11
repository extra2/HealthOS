using HealthOS.Models.HelperModels;
using HealthOS.Repositories.Interfaces;
using Microsoft.AspNet.Identity;
using Microsoft.AspNetCore.Mvc;

namespace HealthOS.Controllers.API
{
    [Route("api/Relations")]
    public class RelationsController : Controller
    {
        private readonly IUserRepository _userRepository;
        public RelationsController( IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        // POST: api/Relations
        [HttpPost]
        public IActionResult Post([FromBody]RelationsModel value)
        {
            var success = _userRepository.AddRelation(value, User.Identity.GetUserId());
            return Ok();
        }

        // DELETE: api/Relations
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _userRepository.DeleteRelation(id);
            return Ok();
        }
    }
}
