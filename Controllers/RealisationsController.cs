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
    public class RealisationsController  : SuperController<Realisation>
    {
        public RealisationsController(AdminContext context): base(context) { }

        [HttpPost]
        public async Task<IActionResult> SearchAndGet(Model model)
        {
            int idUser = HttpContext.GetIdUser();
            int role = HttpContext.GetRoleUser();
            bool hasAcess = (role == 1 || role == 2) ? true : false;

            var query = _context.Realisations
                .Where(e => hasAcess ? true : (e.Activite.Mesure.IdResponsable == idUser))
                // .Where(e => e.Responsable.Organisme.Type == model.TypeOrganisme)
                .Where(e => model.IdCycle == 0 ? true : e.Activite.Mesure.IdCycle == model.IdCycle)
                .Where(e => model.IdMesure == 0 ? true : e.Activite.IdMesure == model.IdMesure)
                .Where(e => model.IdResponsable == 0 ? true : e.Activite.Mesure.IdResponsable == model.IdResponsable)
                .Where(e => model.IdAxe == 0 ? true : e.Activite.Mesure.IdAxe == model.IdAxe)
                .Where(e => model.IdSousAxe == 0 ? true : e.Activite.Mesure.IdSousAxe == model.IdSousAxe)
                // .Where(e => model.IdOrganisme == 0 ? true : e.Activite.Mesure.IdOrganisme == model.IdOrganisme)
                // .Where(e => model.IdOrganisme == 0 ? true : e.Partenariats.Any(p => p.IdOrganisme == model.IdOrganisme))
                ;

            int count = model.IsAllEmpty() ? await _context.Realisations.CountAsync() : await query.CountAsync();

            var list = await query.OrderByName<Realisation>(model.SortBy, model.SortDir == "desc")
                .Skip(model.StartIndex)
                .Take(model.PageSize)
                // .Include(e => e.Responsable)
                // .ThenInclude(e => e.Organisme)
                .Include(e => e.Activite)
                .Select(e => new
                {
                    id = e.Id,
                    mesure = e.Activite.Mesure.Nom,
                    activite = e.Activite.Nom,
                    annee = e.Annee,
                    nom = e.Nom,
                    situation = e.Situation,
                    taux = e.Taux,
                })
                .ToListAsync();
            ;

            return Ok(new { list = list, count = count });
        }

         [HttpPost]
        public async Task<IActionResult> GetRapportLiterary(Model model)
        {
            int idUser = HttpContext.GetIdUser();
            int role = HttpContext.GetRoleUser();
            bool hasAcess = (role == 1 || role == 2) ? true : false;

            var query = _context.Realisations
                .Where(e => hasAcess ? true : (e.Activite.Mesure.IdResponsable == idUser))
                // .Where(e => e.Responsable.Organisme.Type == model.TypeOrganisme)
                .Where(e => model.IdCycle == 0 ? true : e.Activite.Mesure.IdCycle == model.IdCycle)
                .Where(e => model.IdMesure == 0 ? true : e.Activite.IdMesure == model.IdMesure)
                .Where(e => model.IdResponsable == 0 ? true : e.Activite.Mesure.IdResponsable == model.IdResponsable)
                ;

            int count = model.IsAllEmpty() ? await _context.Realisations.CountAsync() : await query.CountAsync();

            var list = await query.OrderByName<Realisation>(model.SortBy, model.SortDir == "desc")
                .Skip(model.StartIndex)
                .Take(model.PageSize)
                // .Include(e => e.Responsable)
                // .ThenInclude(e => e.Organisme)
                .Include(e => e.Activite)
                .Select(e => new
                {
                    id = e.Id,
                    organisme = e.Activite.Mesure.Responsable.Organisme.Label,
                    mesure = e.Activite.Mesure.Nom,
                    activite = e.Activite.Nom,
                    annee = e.Annee,
                    situation = e.Situation,
                    taux = e.Taux,
                    effet = e.Effet,
                })
                .ToListAsync();
            ;

            return Ok(new { list = list, count = count });
        }

         [HttpPost]
        public async Task<IActionResult> GetRapportQualitative(Model model)
        {
            int idUser = HttpContext.GetIdUser();
            int role = HttpContext.GetRoleUser();
            bool hasAcess = (role == 1 || role == 2) ? true : false;

            var query = _context.Mesures
                .Where(e => hasAcess ? true : (e.IdResponsable == idUser))
                // .Where(e => e.Responsable.Organisme.Type == model.TypeOrganisme)
                .Where(e => model.IdCycle == 0 ? true : e.IdCycle == model.IdCycle)
                .Where(e => model.IdMesure == 0 ? true : e.Id == model.IdMesure)
                .Where(e => model.IdResponsable == 0 ? true : e.IdResponsable == model.IdResponsable)
                .Where(e => model.IdAxe == 0 ? true : e.IdAxe == model.IdAxe)
                .Where(e => model.IdSousAxe == 0 ? true : e.IdSousAxe == model.IdSousAxe)
                // .Where(e => model.IdOrganisme == 0 ? true : e.Activite.Mesure.IdOrganisme == model.IdOrganisme)
                // .Where(e => model.IdOrganisme == 0 ? true : e.Partenariats.Any(p => p.IdOrganisme == model.IdOrganisme))
                ;

            int count = model.IsAllEmpty() ? await _context.Realisations.CountAsync() : await query.CountAsync();

            var list = await query.OrderByName<Mesure>(model.SortBy, model.SortDir == "desc")
                .Skip(model.StartIndex)
                .Take(model.PageSize)
                // .Include(e => e.Responsable)
                // .ThenInclude(e => e.Organisme)
                // .Include(e => e.Activite)
                .Select(e => new
                {
                    id = e.Id,
                    organisme = e.Responsable.Organisme.Label,
                    mesure = e.Nom,
                    realisations = e.Activites.SelectMany(a => a.Realisations.Select(r => r.Nom)),
                    taux = e.Activites.SelectMany(a => a.Realisations.Select(r => r.Taux)),
                    // taux = e.ac,
                    indicateurs = e.IndicateurMesures.Select(i => i.Indicateur.Nom),
                })
                .ToListAsync();
            ;

            return Ok(new { list = list, count = count });
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetOneWithInclude(int id)
        {
            var model = await _context.Realisations.Where(e => e.Id == id)
                .Include(e => e.Activite)
                .ThenInclude(e => e.Mesure)
                // .ThenInclude(e => e.Cycle)
                .FirstOrDefaultAsync();
                ;

            return Ok(model);
        }
    }
}
