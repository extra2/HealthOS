using HealthOS.Models;
using HealthOS.Repositories.Interfaces;
using Microsoft.AspNet.Identity;
using Microsoft.AspNetCore.Mvc;

namespace HealthOS.Controllers.API
{
    [Route("api/Visit")]
    public class VisitController : Controller
    {
        private IVisitsRepository _visitRepository;
        public VisitController(IVisitsRepository visitRepository)
        {
            _visitRepository = visitRepository;
        }

        // POST: api/Visit
        [HttpPost]
        public IActionResult Post([FromBody]NextDoctorVisit value)
        {
            _visitRepository.Add(value, User.Identity.GetUserId());
            return Ok();
        }
        
        // PUT: api/Visit/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody]NextDoctorVisit value)
        {
            _visitRepository.Update(value, id);
            return Ok();
        }
        
        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _visitRepository.DeleteVisit(id);
            return Ok();
        }
    }
}
