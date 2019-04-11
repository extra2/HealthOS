using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using HealthOS.Data;
using HealthOS.Models.Statistics;
using HealthOS.Repositories.Interfaces;

namespace HealthOS.Controllers.API
{
    [Route("api/CustomStatisticsDatas")]
    public class CustomStatisticsDatasController : Controller
    {
        #region Properties
        private readonly ApplicationDbContext _context;
        private readonly ICustomStatisticsRepository _customStatisticsRepository;
        #endregion

        public CustomStatisticsDatasController(ApplicationDbContext context, ICustomStatisticsRepository statistics)
        {
            _customStatisticsRepository = statistics;
            _context = context;
        }

        // POST: api/CustomStatisticsDatas
        [HttpPost("{id}")]
        public async Task<IActionResult> PostCustomStatisticsData([FromRoute] int id, [FromBody] CustomStatisticsData customStatisticsData)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            _customStatisticsRepository.AddMeasurement(customStatisticsData,id);

            return Ok();
        }

        // DELETE: api/CustomStatisticsDatas/5
        [HttpDelete("{id}")]
        public IActionResult DeleteCustomStatisticsData([FromRoute] int id)
        {
            _customStatisticsRepository.RemoveMeasurement(id);
            return Ok();
        }
    }
}