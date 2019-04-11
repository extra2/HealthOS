using System.Linq;
using Microsoft.AspNetCore.Mvc;
using HealthOS.Data;
using HealthOS.Models.Statistics;
using HealthOS.Repositories.Interfaces;
using Microsoft.AspNet.Identity;

namespace HealthOS.Controllers.API
{
    [Route("api/CustomStatistics")]
    public class CustomStatisticsController : Controller
    {
        #region Properties
        private readonly ApplicationDbContext _context;
        private readonly ICustomStatisticsRepository _customStatisticsRepository;
        #endregion

        public CustomStatisticsController(ApplicationDbContext context, ICustomStatisticsRepository statistics)
        {
            _customStatisticsRepository = statistics;
            _context = context;
        }

        // POST: api/CustomStatistics
        [HttpPost]
        public IActionResult PostCustomStatistics([FromBody] CustomStatistics customStatistics)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var currentUser = _context.Users.First(u => u.Id == User.Identity.GetUserId());
            customStatistics.ApplicationUser = currentUser;
            _customStatisticsRepository.AddNewStatistic(customStatistics);
            return Ok();
        }

        // DELETE: api/CustomStatistics/5
        [HttpDelete("{id}")]
        public IActionResult DeleteCustomStatistics([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _customStatisticsRepository.RemoveStatistic(id);

            return Ok();
        }
    }
}