using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using KeuzeWijzerApi.DAL.DataContext;
using KeuzeWijzerApi.DAL.DataEntities;

namespace KeuzeWijzerApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EntryRequirementModulesController : ControllerBase
    {
        private readonly KeuzeWijzerContext _context;

        public EntryRequirementModulesController(KeuzeWijzerContext context)
        {
            _context = context;
        }

        // GET: api/EntryRequirementModules
        [HttpGet]
        public async Task<ActionResult<IEnumerable<EntryRequirementModule>>> GetEntryRequirementModules()
        {
            return await _context.EntryRequirementModules.ToListAsync();
        }

        // GET: api/EntryRequirementModules/5
        [HttpGet("{id}")]
        public async Task<ActionResult<EntryRequirementModule>> GetEntryRequirementModule(int id)
        {
            var entryRequirementModule = await _context.EntryRequirementModules.FindAsync(id);

            if (entryRequirementModule == null)
            {
                return NotFound();
            }

            return entryRequirementModule;
        }

        // PUT: api/EntryRequirementModules/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEntryRequirementModule(int id, EntryRequirementModule entryRequirementModule)
        {
            if (id != entryRequirementModule.Id)
            {
                return BadRequest();
            }

            _context.Entry(entryRequirementModule).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EntryRequirementModuleExists(id))
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

        // POST: api/EntryRequirementModules
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<EntryRequirementModule>> PostEntryRequirementModule(EntryRequirementModule entryRequirementModule)
        {
            _context.EntryRequirementModules.Add(entryRequirementModule);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetEntryRequirementModule", new { id = entryRequirementModule.Id }, entryRequirementModule);
        }

        // DELETE: api/EntryRequirementModules/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEntryRequirementModule(int id)
        {
            var entryRequirementModule = await _context.EntryRequirementModules.FindAsync(id);
            if (entryRequirementModule == null)
            {
                return NotFound();
            }

            _context.EntryRequirementModules.Remove(entryRequirementModule);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool EntryRequirementModuleExists(int id)
        {
            return _context.EntryRequirementModules.Any(e => e.Id == id);
        }
    }
}
