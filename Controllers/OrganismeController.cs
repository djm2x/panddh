using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Models;
using Microsoft.Data.SqlClient;
using System.Security.Cryptography;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;

namespace Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class OrganismeController : SuperController<Organisme>
    {
        public OrganismeController(AdminContext context) : base(context)
        { }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetByForeignKey(int id)
        {
            var model = await _context.Organismes.Where(e => e.Partenariats.Any(o => o.IdMesure == id))
            .ToListAsync();

            return Ok(model);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByType(int id)
        {
            var model = await _context.Organismes.Where(e => e.Type == id)
                    .Select(e => new { id = e.Id, label = e.Label })
                    .ToListAsync()
                    ;

            return Ok(model);
        }
    }
}