using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Models;
using Providers;

namespace Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class MesuresController : SuperController<Mesure>
    {
        public MesuresController(AdminContext context) : base(context) { }

        [HttpPost]
        public async Task<IActionResult> SearchAndGet(Model model)
        {
            // int idUser = HttpContext.GetIdUser();
            // int role = HttpContext.GetRoleUser();
            // bool hasAcess = (role == 1 || role == 4) ? true : false;

            var query = _context.Mesures
                // .Where(e => hasAcess ? true : (e.User.IdOrganisme == idOrganisme))
                // this filter = , المخطط التنفيدي   المخطط التنفيدي الترابي    برامج العمل
                .Where(e => e.Responsable.Organisme.Type == model.TypeOrganisme)

                .Where(e => model.IdCycle == 0 ? true : e.IdCycle == model.IdCycle)
                .Where(e => model.IdMesure == 0 ? true : e.Id == model.IdMesure)
                .Where(e => model.IdResponsable == 0 ? true : e.IdResponsable == model.IdResponsable)
                .Where(e => model.IdAxe == 0 ? true : e.IdAxe == model.IdAxe)
                .Where(e => model.IdSousAxe == 0 ? true : e.IdSousAxe == model.IdSousAxe)
                .Where(e => model.IdOrganisme == 0 ? true : e.Responsable.IdOrganisme == model.IdOrganisme)
                // .Where(e => model.IdOrganisme == 0 ? true : e.Partenariats.Any(p => p.IdOrganisme == model.IdOrganisme))
                ;

            int count = model.IsAllEmpty() ? await _context.Mesures.CountAsync() : await query.CountAsync();

            var list = await query.OrderByName<Mesure>(model.SortBy, model.SortDir == "desc")
                .Skip(model.StartIndex)
                .Take(model.PageSize)
                // .Include(e => e.Responsable)
                // .ThenInclude(e => e.Organisme)
                .Include(e => e.Cycle)
                .Select(e => new
                {
                    id = e.Id,
                    cycle = e.Cycle,
                    organisme = e.Responsable.Organisme,
                    nom = e.Nom,
                    responsable = e.Responsable,
                    resultatsAttendu = e.ResultatsAttendu,
                    type = e.Responsable.Organisme.Type
                })
                .ToListAsync();
            ;

            return Ok(new { list = list, count = count });
        }
        
        [HttpGet("{id}")]
        public async Task<IActionResult> GetOneWithInclude(int id)
        {
            var model = await _context.Mesures.Where(e => e.Id == id)
                .Include(e => e.Activites)
                .Include(e => e.IndicateurMesures)
                .ThenInclude(e => e.Indicateur)
                .Include(e => e.Responsable)
                .ThenInclude(e => e.Organisme)
                .Include(e => e.Cycle)
                .Include(e => e.Axe)
                .Include(e => e.SousAxe)
                .Include(e => e.Partenariats)
                .ThenInclude(e => e.Organisme)
                .FirstOrDefaultAsync();
                ;

            return Ok(model);
        }

         [HttpGet("{idCycle}/{name}")]
        public async Task<IActionResult> CustomAutocomplete([FromRoute] int idCycle,[FromRoute] string name)
        {

            return Ok(await _context.Mesures
                .Where(e => e.IdCycle == idCycle && e.Nom.Contains(name))
                .Take(10)
                .ToListAsync());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByForeignKey(int id)
        {
            int idUser = HttpContext.GetIdUser();
            int role = HttpContext.GetRoleUser();
            bool hasAcess = (role == 1 || role == 2) ? true : false;
            var model = await _context.Mesures
                .Where(e => hasAcess ? true : (e.IdResponsable == idUser))
                .Where(e => e.IdCycle == id)
                .ToListAsync();
                ;

            return Ok(model);
        }

        //  [HttpGet("{id}")]
        // public async Task<IActionResult> GetByTypeOrganisme(int id)
        // {
        //     var model = await _context.Mesures.Where(e => e.Responsable.Organisme.Type == id)
        //             .Select(e => new { id = e.Id, nom = e.Nom })
        //             .ToListAsync()
        //             ;

        //     return Ok(model);
        // }
    }

    public class Model
    {
        public int IdCycle { get; set; }
        public int IdMesure { get; set; }
        public int IdResponsable { get; set; }
        public int IdAxe { get; set; }
        public int IdSousAxe { get; set; }
        public int IdOrganisme { get; set; }
        public int TypeOrganisme { get; set; }
        public int StartIndex { get; set; }
        public int PageSize { get; set; }
        public string SortBy { get; set; }
        public string SortDir { get; set; }

        public bool IsAllEmpty()
        {
            if (IdSousAxe == 0 && IdMesure == 0 && IdAxe == 0 && IdCycle == 0 && IdResponsable == 0 && TypeOrganisme == 0 && IdOrganisme == 0)
            {
                return true;
            }

            return false;
        }
    }
}
