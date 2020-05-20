using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Models;
using Providers;

namespace Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class IndicateurMesuresController  : SuperController<IndicateurMesure>
    {
        public IndicateurMesuresController(AdminContext context): base(context) { }

        [HttpGet("{startIndex}/{pageSize}/{sortBy}/{sortDir}/{id}")]
        public virtual async Task<IActionResult> GetAll(int startIndex, int pageSize, string sortBy, string sortDir, int id)
        {
            // int i = typeof(T).FullName.LastIndexOf('.');
            // string tableName = typeof(T).FullName.Substring(i + 1) + "s";

            var list = await _context.IndicateurMesures
                .Where(e => e.IdMesure == id)
                .OrderByName<IndicateurMesure>(sortBy, sortDir == "desc")
                .Skip(startIndex)
                .Take(pageSize)
                .Include(e => e.Indicateur)
                .ToListAsync()
                ;
            int count = await _context.IndicateurMesures.CountAsync();

            return Ok(new { list = list, count = count });
        }

        [HttpPost]
        public async Task<ActionResult> PutRange(ModelList<IndicateurMesure> model)
        {
            try
            {
                _context.IndicateurMesures.RemoveRange(model.modelsToDelete);
                
                await _context.IndicateurMesures.AddRangeAsync(model.modelsToAdd);
                
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                return Ok(new { message = ex.Message });
            }

            return Ok();
        }

        [HttpPost]
        public async Task<IActionResult> PutIndicateurMesure(IndicateurMesure model)
        {
            _context.Entry(model).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                return BadRequest(new { message = ex.Message });
            }

            return NoContent();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByForeignKey(int id)
        {
            var list = await _context.IndicateurMesures.Where(e => e.IdMesure == id)
                .Include(e => e.Indicateur)
                .Select(e => e.Indicateur)
                .ToListAsync()
                ;

            return Ok(list);
        }
    }
}
