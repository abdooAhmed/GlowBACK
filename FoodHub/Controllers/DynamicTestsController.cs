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
using Microsoft.AspNetCore.Identity;

namespace FoodHub.Controllers
{
    [Route("api/[controller]")]
    [Authorize(Roles = "trenier")]
    [ApiController]
    public class DynamicTestsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<User> _userManager;

        public DynamicTestsController(ApplicationDbContext context, UserManager<User> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        // GET: api/DynamicTests
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DynamicTest>>> GetDynamicTest()
        {
          if (_context.DynamicTest == null)
          {
              return NotFound();
          }
            return await _context.DynamicTest.ToListAsync();
        }

        // GET: api/DynamicTests/5
        [HttpGet("id/{id}/page/{page}/pageSize/{pageSize}")]
        public async Task<ActionResult> GetDynamicTest(string id, int page, int pageSize)
        {
          if (_context.DynamicTest == null)
          {
              return NotFound();
          }
            var totalSkip = page * pageSize;
            var dynamicTest = await _context.DynamicTest.Where(x => x.User.Id == id).Skip(totalSkip).Take(pageSize).Select(dto => new {
                Kyphosis = dto.Kyphosis,
                Circumduction = dto.Circumduction,
                Shulder = dto.Shulder,
                Lordosis = dto.Lordosis,
                Scoliosis = dto.Scoliosis,
                ClientId = dto.User.Id,
                Id = dto.Id,
            }).ToListAsync();

            if (dynamicTest == null)
            {
                return NotFound();
            }

            return Ok(new
            {
                Data = new {list = dynamicTest ,
                total = dynamicTest.Count},
                Status = true,
                Message = "Success"
            });
        }

        // PUT: api/DynamicTests/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDynamicTest(int id, DynamicTest dynamicTest)
        {
            if (id != dynamicTest.Id)
            {
                return BadRequest();
            }

            _context.Entry(dynamicTest).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DynamicTestExists(id))
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

        // POST: api/DynamicTests
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<DynamicTest>> PostDynamicTest(dynamicTestDto dto)
        {
          if (_context.DynamicTest == null)
          {
              return Problem("Entity set 'ApplicationDbContext.DynamicTest'  is null.");
          }
            var user = await _userManager.FindByIdAsync(dto.ClientId);
            var dynamicTest = new DynamicTest 
            {
                Circumduction = dto.Circumduction,
                Kyphosis = dto.Kyphosis,
                Lordosis = dto.Lordosis,
                Scoliosis = dto.Scoliosis,
                Shulder = dto.Shulder,
                User = user,
            };
          _context.DynamicTest.Add(dynamicTest);
          await _context.SaveChangesAsync();

            return Ok(new
            {
                Data = new {id=dynamicTest.Id},
                Status = true,
                Message = "Success"
            });
        }

        // DELETE: api/DynamicTests/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDynamicTest(int id)
        {
            if (_context.DynamicTest == null)
            {
                return NotFound();
            }
            var dynamicTest = await _context.DynamicTest.FindAsync(id);
            if (dynamicTest == null)
            {
                return NotFound();
            }

            _context.DynamicTest.Remove(dynamicTest);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool DynamicTestExists(int id)
        {
            return (_context.DynamicTest?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
