using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Models;
using System.Linq;

namespace Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CyclesController : SuperController<Cycle>
    {
        public CyclesController(AdminContext context) : base(context)
        { }


        

    }
}
