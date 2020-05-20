using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Models;
using System.Collections.Generic;
using System.Linq;

namespace Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class SousAxesController : SuperController<SousAxe>
    {
        public SousAxesController(AdminContext context) : base(context)
        {
        }

        [HttpGet("{startIndex}/{pageSize}/{sortBy}/{sortDir}")]
        public override async Task<IActionResult> GetAll(int startIndex, int pageSize, string sortBy, string sortDir)
        {
            var tableName = "SousAxes";
            var list = await _context.SousAxes
                .FromSqlRaw($"SELECT * FROM dbo.[{tableName}] order by {sortBy} {sortDir} OFFSET {startIndex} ROWS FETCH NEXT {pageSize} ROWS ONLY")
                // .FromSqlRaw(@"SELECT * FROM dbo.[{0}] ORDER BY {1} '{2}' OFFSET {3} ROWS FETCH NEXT {4} ROWS ONLY"
                // , tableName, sortBy, sortDir, startIndex, pageSize)
                // .Skip(startIndex)
                // .Take(pageSize)
                .Include(e => e.Axe)
                .ToListAsync();

            int count = await _context.SousAxes.CountAsync();


            return Ok(new { list = list, count = count });
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<SousAxe>>> GetByIdAxe(int id)
        {
            return Ok(await _context.SousAxes.Where(e => e.IdAxe == id).ToListAsync());
        }
    }
}
