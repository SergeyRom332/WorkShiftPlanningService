using Microsoft.AspNetCore.Mvc;
using WorkShiftPlanningService.Models.Services;
using WorkShiftPlanningService.Models;

namespace WorkShiftPlanningService.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class StaffController : ControllerBase
    {
        private IStaffService _staffService;

        public StaffController(IStaffService staffService)
        {
            _staffService = staffService;
        }

        [HttpGet]
        public async Task<ActionResult<List<Staff>>> GetAllStaff(int departmentId)
        {
            if (departmentId == 0) return BadRequest();

            return Ok(await _staffService.GetAllStaffAsync(departmentId));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Staff>> Get(int id)
        {
            if (id == 0) return BadRequest();

            return Ok(await _staffService.GetStaffAsync(id));
        }

        [HttpPost]
        public async Task<ActionResult> Add(Staff staff)
        {
            if (staff == null) return BadRequest();
            await _staffService.AddStaffAsync(staff);

            return Ok();
        }

        [HttpPut]
        public async Task<ActionResult> Update(Staff staff)
        {
            if (staff == null) return BadRequest();
            await _staffService.UpdateStaffAsync(staff);

            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            if (id == 0) return BadRequest();
            await _staffService.DeleteStaffAsync(id);

            return Ok();
        }
    }
}
