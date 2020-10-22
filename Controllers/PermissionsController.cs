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
    public class PermissionsController  : SuperController<Permission>
    {
        public PermissionsController(AdminContext context): base(context) { }

        [HttpGet("{startIndex}/{pageSize}/{sortBy}/{sortDir}/{id}")]
        public async Task<IActionResult> getAll(int startIndex, int pageSize, string sortBy, string sortDir, int id)
        {
            var list = await _context.Permissions
                .Where(e => id == 0 ? true : e.IdProfil == id)
                .OrderByName<Permission>(sortBy, sortDir == "desc")
                .Skip(startIndex)
                .Take(pageSize)
                .Include(e => e.Profil)
                .ToListAsync()
                ;
            int count = await _context.Permissions.CountAsync();

            return Ok(new { list = list, count = count });
        }


         [HttpPost]
        public override async Task<ActionResult<Permission>> Post(Permission model)
        {
            var per = await _context.Permissions
                .Where(e => e.IdProfil == model.IdProfil && e.RouteScreen == model.RouteScreen)
                .FirstOrDefaultAsync()
                ;

            if (per != null)
            {
                per.Action = model.Action;
                // _context.Entry(model).State = EntityState.Modified;
            }
            else
            {
                _context.Permissions.Add(model);
            }

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
        public async Task<IActionResult> GetByProfil(int id)
        {
            return Ok(await _context.Permissions
                .Where(e => e.IdProfil == id)
                .ToListAsync());
        }
    }
}
