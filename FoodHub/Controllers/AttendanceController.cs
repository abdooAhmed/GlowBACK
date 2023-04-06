using FoodHub.Data;
using FoodHub.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FoodHub.Controllers
{
    [Route("api/[controller]")]
    [Authorize(Roles = "reception")]
    [ApiController]
    public class AttendanceController : Controller
    {
        private readonly SignInManager<User> _signInManager;
        private readonly UserManager<User> _userManager;
        private readonly ApplicationDbContext _context;

        public AttendanceController(
            SignInManager<User> signInManager,
            UserManager<User> userManager,
            ApplicationDbContext dbContext
            )
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _context = dbContext;
            
        }
        [HttpPost]
        public async Task<IActionResult> AddAttendance(TokenDto dto)
        {
            var email = "ayman.omara551@gmail.com";
            var user = await _userManager.FindByEmailAsync(email);
            return Ok(new
            {
                Status = false,
                Message = "User not found"
            });
            var attendance = new Attendance
            {
                From = DateTime.Now.ToString("HH:mm"),
                Date = DateTime.Today,
                User = user,
                Status = false
            };
            await _context.Attendances.AddAsync(attendance);
            await _context.SaveChangesAsync();
            return Ok(new
            {
                Status = true,
                Message = "Success"
            });
        }
        [HttpGet("end/{email}")]
        public async Task<IActionResult> EndAttendance(string email)
        {
            var attendance = _context.Attendances.Where(x => x.User.Email == email && x.Status == false).FirstOrDefault();
            attendance.Status = true;
            attendance.To = DateTime.Now.ToString("HH:mm");
            _context.Entry(attendance).State = EntityState.Modified;
            try
            {
                await _context.SaveChangesAsync();
                return Ok();
            }
            catch (DbUpdateConcurrencyException)
            {
                    return NotFound();
            }
            return Ok(new
            {
                Status = true,
                Message = "Success"
            });
        }
        public IActionResult Index()
        {
            return View();
        }
    }
    public class TokenDto
    { 
        public string token { get; set; }
    }
}
