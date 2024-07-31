using Microsoft.AspNetCore.Mvc;
using WorkShiftPlanningService.Models;
using WorkShiftPlanningService.Models.Services;

namespace WorkShiftPlanningService.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class WorkShiftController : ControllerBase
    {
        private IWorkShiftService _workShiftService;

        public WorkShiftController(IWorkShiftService workShiftService)
        {
            _workShiftService = workShiftService;
        }

        [HttpGet]
        public async Task<ActionResult<List<WorkShift>>> GetWorkShifts(int restaurantId, DateTime dateFirst, DateTime dateSecond)
        {
            if (restaurantId == 0 || dateFirst == DateTime.MinValue || dateSecond == DateTime.MinValue) return BadRequest();

            return Ok(await _workShiftService.GetWorkShiftsAsync(restaurantId, dateFirst, dateSecond));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<WorkShift>> Get(int id)
        {
            if (id == 0) return BadRequest();

            return Ok(await _workShiftService.GetWorkShiftAsync(id));
        }

        [HttpPost]
        public async Task<ActionResult> Add(WorkShift workShift)
        {
            if (workShift == null) return BadRequest();
            await _workShiftService.AddWorkShiftAsync(workShift);

            return Ok();
        }

        [HttpPut]
        public async Task<ActionResult> Update(WorkShift workShift)
        {
            if (workShift == null) return BadRequest();
            await _workShiftService.UpdateWorkShiftAsync(workShift);

            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            if (id == 0) return BadRequest();
            await _workShiftService.DeleteWorkShiftAsync(id);

            return Ok();
        }
    }
}
