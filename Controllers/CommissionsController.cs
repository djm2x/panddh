using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Models;

namespace Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CommissionsController  : SuperController<Commission>
    {
        public CommissionsController(AdminContext context): base(context) { }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetOneWithInclude(int id)
        {
            var model = await _context.Commissions.Where(e => e.Id == id)
                .Include(e => e.MembreCommissions)
                .FirstOrDefaultAsync();
                ;

            return Ok(model);
        }
    }
}
