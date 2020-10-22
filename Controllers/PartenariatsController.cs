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
    public class PartenariatsController  : SuperController<Partenariat>
    {
        public PartenariatsController(AdminContext context): base(context) { }

        [HttpPost]
        public async Task<ActionResult> PutRange(ModelList<Partenariat> model)
        {
            try
            {
                _context.Partenariats.RemoveRange(model.modelsToDelete);
                
                await _context.Partenariats.AddRangeAsync(model.modelsToAdd);
                
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                return Ok(new { message = ex.Message });
            }

            return Ok();
        }
    }

    public class ModelList<T> {
        public List<T> modelsToDelete { get; set; }
        public List<T> modelsToAdd { get; set; }
    }
}
