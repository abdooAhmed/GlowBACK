using FoodHub.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace FoodHub.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class BreakController : Controller
    {
        [HttpGet]
        public async Task<IActionResult> Break()
        {
            return Ok(new
            {
                Status = true,
                Message = "Success"
            });
        }
    }
}
