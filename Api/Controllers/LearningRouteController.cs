using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using KeuzeWijzerApi.DAL.DataContext;
using KeuzeWijzerApi.DAL.Repository;
using KeuzeWijzerApi.Models;

namespace KeuzeWijzerApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LearningRouteController : ControllerBase
    {
        private readonly KeuzeWijzerContext _context;
        private readonly IGenericRepository<LearningRoute> _repository;

        public LearningRouteController(KeuzeWijzerContext context)
        {
            _context = context;
            _repository = new GenericRepository<LearningRoute>(_context);
        }

        // GET: api/LearningRoute
        [HttpGet]
        public async Task<ActionResult<IEnumerable<LearningRoute>>> GetLeerroutes()
        {
            //TODO: Not working at the moment, needs checkup!
            return await _repository.GetAll().ToListAsync();
        }

        // GET: api/LearningRoute/5
        [HttpGet("{id}")]
        public async Task<ActionResult<LearningRoute>> GetLearningRoute(int id)
        {
            var learningRoute = await _context.Leerroutes.FindAsync(id);

            if (learningRoute == null)
            {
                return NotFound();
            }

            return learningRoute;
        }

        // PUT: api/LearningRoute/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutLearningRoute(int id, LearningRoute learningRoute)
        {
            if (id != learningRoute.Id)
            {
                return BadRequest();
            }

            _context.Entry(learningRoute).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LearningRouteExists(id))
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

        // POST: api/LearningRoute
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<LearningRoute>> PostLearningRoute(LearningRoute learningRoute)
        {
            _context.Leerroutes.Add(learningRoute);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetLearningRoute", new { id = learningRoute.Id }, learningRoute);
        }

        // DELETE: api/LearningRoute/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLearningRoute(int id)
        {
            var learningRoute = await _context.Leerroutes.FindAsync(id);
            if (learningRoute == null)
            {
                return NotFound();
            }

            _context.Leerroutes.Remove(learningRoute);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool LearningRouteExists(int id)
        {
            return _context.Leerroutes.Any(e => e.Id == id);
        }
    }
}
