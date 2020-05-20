using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Models;

namespace Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class NaturesController : SuperController<Nature>
    {
        public NaturesController(AdminContext context) : base(context)
        { }


        
        
    }
}
