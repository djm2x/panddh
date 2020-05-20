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
    public class IndicateursController  : SuperController<Indicateur>
    {
        public IndicateursController(AdminContext context): base(context) { }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByForeignKey(int id)
        {
            var model = await _context.Indicateurs.Where(e => e.IndicateurMesures.Any(o => o.IdMesure == id ) )
            .ToListAsync();

            return Ok(model);
        }
    }
}
