using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FoodHub.Data;
using FoodHub.Models;
using Microsoft.AspNetCore.Authorization;
using System.Data;
using Microsoft.AspNetCore.Identity;
using FoodHub.Data.Migrations;

namespace FoodHub.Controllers
{
    [Route("api/[controller]")]
    [Authorize(Roles = "trenier")]
    [ApiController]
    public class BodyCircumferencesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<User> _userManager;

        public BodyCircumferencesController(ApplicationDbContext context, UserManager<User> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        // GET: api/BodyCircumferences
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BodyCircumferences>>> GetBodyCircumferences()
        {
          if (_context.BodyCircumferences == null)
          {
              return NotFound();
          }
            return await _context.BodyCircumferences.ToListAsync();
        }

        // GET: api/BodyCircumferences/5
        [HttpGet("id/{id}/page/{page}/pageSize/{pageSize}")]
        public async Task<ActionResult<BodyCircumferences>> GetBodyCircumferences(string id, int page, int pageSize)
        {
          if (_context.BodyCircumferences == null)
          {
              return NotFound();
          }
            var totalSkip = page * pageSize;
            var bodyCircumferences = await _context.BodyCircumferences.Where(x=>x.User.Id==id).Skip(totalSkip).Take(pageSize).Select(dto => new
            {
                QuailCircumference = dto.QuailCircumference,
                ThighCircumference = dto.ThighCircumference,
                ShoulderCircumference = dto.ShoulderCircumference,
                Name = dto.Name,
                ArmCircumference = dto.ArmCircumference,
                WaistCircumference = dto.WaistCircumference,
                Id = dto.Id,
                ClientId = dto.User.Id
            }).ToListAsync();

            if (bodyCircumferences == null)
            {
                return NotFound();
            }

            return Ok(new
            {
                Data = new {list = bodyCircumferences ,
                total = bodyCircumferences.Count},
                Status = true,
                Message = "Success"
            }); ;
        }

        // PUT: api/BodyCircumferences/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBodyCircumferences(int id, BodyCircumferences bodyCircumferences)
        {
            if (id != bodyCircumferences.Id)
            {
                return BadRequest();
            }

            _context.Entry(bodyCircumferences).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BodyCircumferencesExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/BodyCircumferences
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<BodyCircumferences>> PostBodyCircumferences(BodyCircumferencesDto dto)
        {
          if (_context.BodyCircumferences == null)
          {
              return Problem("Entity set 'ApplicationDbContext.BodyCircumferences'  is null.");
          }
            var user = await _userManager.FindByIdAsync(dto.ClientId);
            var bodyCircumferences = new BodyCircumferences { 
            QuailCircumference = dto.QuailCircumference,
            ThighCircumference = dto.ThighCircumference,
            ShoulderCircumference = dto.ShoulderCircumference,
            Name = dto.Name,
            ArmCircumference = dto.ArmCircumference,
            WaistCircumference = dto.WaistCircumference,
            User = user,
            };
            _context.BodyCircumferences.Add(bodyCircumferences);
            await _context.SaveChangesAsync();

            return Ok(new
            {
                Data = new { id = bodyCircumferences.Id },
                Status = true,
                Message = "Success"
            });
        }

        // DELETE: api/BodyCircumferences/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBodyCircumferences(int id)
        {
            if (_context.BodyCircumferences == null)
            {
                return NotFound();
            }
            var bodyCircumferences = await _context.BodyCircumferences.FindAsync(id);
            if (bodyCircumferences == null)
            {
                return NotFound();
            }

            _context.BodyCircumferences.Remove(bodyCircumferences);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool BodyCircumferencesExists(int id)
        {
            return (_context.BodyCircumferences?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
