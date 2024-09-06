using Microsoft.AspNetCore.Mvc;
using WorkShiftPlanningService.Models;
using WorkShiftPlanningService.Models.Services;

namespace WorkShiftPlanningService.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class WorkShiftsController : ControllerBase
    {
        private IWorkShiftService _workShiftService;

        public WorkShiftsController(IWorkShiftService workShiftService)
        {
            _workShiftService = workShiftService;
        }

        [HttpGet]
        public async Task<ActionResult<List<WorkShift>>> GetWorkShifts(DateTime dateFirst, DateTime dateSecond, int restaurantId = 0)
        {
            if (!ModelState.IsValid || dateFirst == DateTime.MinValue || dateSecond == DateTime.MinValue) return BadRequest();

            var r = await _workShiftService.GetWorkShiftsAsync(dateFirst, dateSecond, restaurantId).ConfigureAwait(false);

            return Ok(r);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<WorkShift>> Get(int id)
        {
            if (!ModelState.IsValid || id == 0) return BadRequest();

            return Ok(await _workShiftService.GetWorkShiftAsync(id).ConfigureAwait(false));
        }

        [HttpPost]
        public async Task<ActionResult> Add(WorkShift workShift)
        {
            if (!ModelState.IsValid || workShift == null) return BadRequest();
            await _workShiftService.AddWorkShiftAsync(workShift).ConfigureAwait(false);

            return Ok(workShift);
        }

        [HttpPut]
        public async Task<ActionResult> Update(WorkShift workShift)
        {
            if (!ModelState.IsValid ||workShift == null) return BadRequest();
            await _workShiftService.UpdateWorkShiftAsync(workShift).ConfigureAwait(false);

            return Ok(workShift);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            if (!ModelState.IsValid ||id == 0) return BadRequest();
            await _workShiftService.DeleteWorkShiftAsync(id).ConfigureAwait(false);

            return Ok();
        }
    }
}
