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
    public class ProfilsController  : SuperController<Profil>
    {
        public ProfilsController(AdminContext context): base(context) { }
    }
}
