using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FoodHub.Data;
using FoodHub.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;
using System.Data;

namespace FoodHub.Controllers
{
    [Route("api/[controller]")]
    [Authorize(Roles = "trenier")]
    [ApiController]
    public class FitnessTestsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<User> _userManager;

        public FitnessTestsController(ApplicationDbContext context,UserManager<User> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        // GET: api/FitnessTests
        [HttpGet]
        public async Task<ActionResult<IEnumerable<FitnessTest>>> GetFitnessTests()
        {
          if (_context.FitnessTests == null)
          {
              return NotFound();
          }
            return await _context.FitnessTests.ToListAsync();
        }

        // GET: api/FitnessTests/5
        [HttpGet("id/{id}/page/{page}/pageSize/{pageSize}")]
        public async Task<ActionResult<FitnessTest>> GetFitnessTest(string id, int page, int pageSize)
        {
          if (_context.FitnessTests == null)
          {
              return NotFound();
          }
            var totalSkip = page * pageSize;
            var fitnessTest = await _context.FitnessTests.Where(x=>x.User.Id == id).Skip(totalSkip).Take(pageSize).Select(dto => new {
                PushUpFirstSit = dto.PushUpFirstSit,
                PushUpSecondSit = dto.PushUpSecondSit,
                PushUpThirdSit = dto.PushUpThirdSit,
                ArmFirstSit = dto.ArmFirstSit,
                ArmSecondSit = dto.ArmSecondSit,
                ArmThirdSit = dto.ArmThirdSit,
                CurlUpFirstSit = dto.CurlUpFirstSit,
                CurlUpSecondSit = dto.CurlUpSecondSit,
                CurlUpThirdSit = dto.CurlUpThirdSit,
                ModifiedFirstSit = dto.ModifiedFirstSit,
                ModifiedSecondSit = dto.ModifiedSecondSit,
                ModifiedThirdSit = dto.ModifiedThirdSit,
                PlankFirstSit = dto.PlankFirstSit,
                PlankSecondSit = dto.PlankSecondSit,
                PlankThirdSit = dto.PlankThirdSit,
                SidePlankFirstSit = dto.SidePlankFirstSit,
                SidePlankSecondSit = dto.SidePlankSecondSit,
                SidePlankThirdSit = dto.SidePlankThirdSit,
                WallSetFirstSit = dto.WallSetFirstSit,
                WallSetSecondSit = dto.WallSetSecondSit,
                WallSetThirdSit = dto.WallSetThirdSit,
                ClientId = dto.User.Id,
                Id = dto.Id,
            }).ToListAsync();

            if (fitnessTest == null)
            {
                return NotFound();
            }

            return Ok(new
            {
                Data= new {list = fitnessTest,
                total = fitnessTest.Count
                },
                Status = true,
                Message = "Success"
            });
        }

        // PUT: api/FitnessTests/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFitnessTest(int id, FitnessTest fitnessTest)
        {
            if (id != fitnessTest.Id)
            {
                return BadRequest();
            }

            _context.Entry(fitnessTest).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FitnessTestExists(id))
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

        // POST: api/FitnessTests
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<FitnessTest>> PostFitnessTest(FitnessTestDto dto)
        {
          if (_context.FitnessTests == null)
          {
              return Problem("Entity set 'ApplicationDbContext.FitnessTests'  is null.");
          }
            var user = await _userManager.FindByIdAsync(dto.ClientId);
            var fitnessTest = new FitnessTest { 
            PushUpFirstSit = dto.PushUpFirstSit,
            PushUpSecondSit = dto.PushUpSecondSit,
            PushUpThirdSit = dto.PushUpThirdSit,
            ArmFirstSit = dto.ArmFirstSit,
            ArmSecondSit = dto.ArmSecondSit,
            ArmThirdSit = dto.ArmThirdSit,
            CurlUpFirstSit = dto.CurlUpFirstSit,
            CurlUpSecondSit= dto.CurlUpSecondSit,
            CurlUpThirdSit= dto.CurlUpThirdSit,
            ModifiedFirstSit = dto.ModifiedFirstSit,
            ModifiedSecondSit = dto.ModifiedSecondSit,
            ModifiedThirdSit = dto.ModifiedThirdSit,
            PlankFirstSit = dto.PlankFirstSit,
            PlankSecondSit = dto.PlankSecondSit,
            PlankThirdSit = dto.PlankThirdSit,
            SidePlankFirstSit = dto.SidePlankFirstSit,
            SidePlankSecondSit = dto.SidePlankSecondSit,
            SidePlankThirdSit = dto.SidePlankThirdSit,
            WallSetFirstSit = dto.WallSetFirstSit,
            WallSetSecondSit = dto.WallSetSecondSit,
            WallSetThirdSit = dto.WallSetThirdSit,
            User = user
            };
            _context.FitnessTests.Add(fitnessTest);
            await _context.SaveChangesAsync();

            return Ok(new
            {
                Data = new { id = fitnessTest.Id },
                Status = true,
                Message = "Success"
            });
        }

        // DELETE: api/FitnessTests/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFitnessTest(int id)
        {
            if (_context.FitnessTests == null)
            {
                return NotFound();
            }
            var fitnessTest = await _context.FitnessTests.FindAsync(id);
            if (fitnessTest == null)
            {
                return NotFound();
            }

            _context.FitnessTests.Remove(fitnessTest);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool FitnessTestExists(int id)
        {
            return (_context.FitnessTests?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
