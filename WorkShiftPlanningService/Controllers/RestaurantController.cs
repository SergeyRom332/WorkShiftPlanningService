using Microsoft.AspNetCore.Mvc;
using WorkShiftPlanningService.Models.Services;
using WorkShiftPlanningService.Models;

namespace WorkShiftPlanningService.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RestaurantController : ControllerBase
    {
        private IRestaurantService _restaurantService;

        public RestaurantController(IRestaurantService restaurantService)
        {
            _restaurantService = restaurantService;
        }

        [HttpGet]
        public async Task<ActionResult<List<Restaurant>>> GetRestaurants()
        {
            return Ok(await _restaurantService.GetRestaurantAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Restaurant>> Get(int id)
        {
            if (id == 0) return BadRequest();

            return Ok(await _restaurantService.GetRestaurantAsync(id));
        }
    }
}
