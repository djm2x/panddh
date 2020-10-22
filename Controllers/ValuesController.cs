using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Models;
using System.Collections.Generic;

namespace Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ValuesController : SuperController<Axe>
    {
        public ValuesController(AdminContext context) : base(context)
        { }

        [HttpGet]
        public IActionResult GetValues()
        {
            return Ok(new List<string>() {"me ", "you"});
        }
        
    }
}
