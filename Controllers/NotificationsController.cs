using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Models;
using Providers;
using System.Linq;

namespace Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class NotificationsController : SuperController<Notification>
    {
        public NotificationsController(AdminContext context) : base(context)
        { }


        [HttpGet("{startIndex}/{pageSize}/{sortBy}/{sortDir}/{idOrganisme}")]
        public async Task<IActionResult> GetAll(int startIndex, int pageSize, string sortBy, string sortDir, int idOrganisme)
        {
            int idUser = HttpContext.GetIdUser();
            int role = HttpContext.GetRoleUser();
            bool hasAcess = (role == 1 /*|| role == 2*/) ? true : false;
            // var b = (e.User.Id == idUser || e.User.IdOrganisme == idOrganisme);
            var q = _context.Notifications
                .Where(e => hasAcess ? true : (e.IdOrganisme == idOrganisme/* || e.User.Id == idUser*/))
                .OrderByName<Notification>(sortBy, sortDir == "desc")
                ;

            int count = await q.CountAsync();

            var list =await q.Skip(startIndex)
                .Take(pageSize)
                .ToListAsync()
                ;

            return Ok(new { list = list, count = count });
        }
        
    }
}
