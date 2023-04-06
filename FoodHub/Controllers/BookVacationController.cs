using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FoodHub.Controllers
{
    [Route("api/[controller]")]
    [Authorize]
    [ApiController]
    public class BookVacationController : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> AddBookVacation()
        {
            return Ok(new
            {
                Status = true,
                Message = "Success"
            });
        }
    }
    public class Token
    {
        public string token { get; set; }
    }
}
