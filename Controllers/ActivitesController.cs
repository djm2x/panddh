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
    public class ActivitesController : SuperController<Activite>
    {
        public ActivitesController(AdminContext context) : base(context) { }

        [HttpGet("{startIndex}/{pageSize}/{sortBy}/{sortDir}/{id}")]
        public virtual async Task<IActionResult> GetAll(int startIndex, int pageSize, string sortBy, string sortDir, int id)
        {
            // int i = typeof(T).FullName.LastIndexOf('.');
            // string tableName = typeof(T).FullName.Substring(i + 1) + "s";

            var list = await _context.Activites
                .Where(e => e.IdMesure == id)
                .OrderByName<Activite>(sortBy, sortDir == "desc")
                .Skip(startIndex)
                .Take(pageSize)
                .ToListAsync()
                ;
            int count = await _context.Activites.CountAsync();

            return Ok(new { list = list, count = count });
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByForeignKey(int id)
        {
            var model = await _context.Activites.Where(e => e.IdMesure == id)
            .ToListAsync();

            return Ok(model);
        }
    }
}
