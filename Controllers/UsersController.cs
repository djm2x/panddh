using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Models;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using System.Linq.Expressions;
using System.Reflection;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication;
using Providers;
using Microsoft.Extensions.Options;
using Helpers;

namespace Controllers
{
    
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class UsersController : SuperController<User>
    {
        private readonly AppSettings _appSettings;
        public UsersController(AdminContext context, IOptions<AppSettings> appSettings) : base(context)
        {
            _appSettings = appSettings.Value;
        }

        [HttpGet("{startIndex}/{pageSize}/{sortBy}/{sortDir}/{nom}/{prenom}/{organisme}")]
        public async Task<IActionResult> GetAll(
            int startIndex,
            int pageSize,
            string sortBy,
            string sortDir,
            string nom,
            string prenom,
            int organisme
        )
        {

            IQueryable<User> query = _context.Users
            // .FromSqlRaw($"SELECT * FROM dbo.[Users] order by {sortBy} {sortDir} OFFSET {startIndex} ROWS FETCH NEXT {pageSize} ROWS ONLY")
            // ;

            // q = nom == "*" ? q : q.Where(u => u.Nom.Contains(nom));
            // q = prenom == "*" ? q : q.Where(u => u.Prenom.Contains(prenom));
            // q = organisme == 0 ? q : q.Where(u => u.IdOrganisme == organisme);



            .Where(u => nom == "*" ? true : u.Nom.Contains(nom))
            .Where(u => prenom == "*" ? true : u.Prenom.Contains(prenom))
            .Where(u => organisme == 0 ? true : u.IdOrganisme == organisme)
            // .FromSqlRaw($"SELECT * FROM dbo.[User] order by {sortBy} {sortDir} OFFSET {startIndex} ROWS FETCH NEXT {pageSize} ROWS ONLY;")
            // .Skip(startIndex)
            // .Take(pageSize)
            // q.Include(u => u.Organisme).Include(u => u.Profil);
            // .ToListAsync()
            ;


            int count = 0;
            var list = new List<User>();
            if (nom != "*" || prenom != "*" || organisme != 0)
            {
                count = await query.CountAsync();

                list = await query.OrderByName<User>(sortBy, sortDir == "desc")
                    .Skip(startIndex)
                    .Take(pageSize)
                    .Include(e => e.Organisme)
                    .Include(e => e.Profil)
                    .ToListAsync()
                ;
            }
            else
            {
                count = await _context.Users.CountAsync();

                list = await query.OrderByName<User>(sortBy, sortDir == "desc")
                    .Skip(startIndex)
                    .Take(pageSize)
                    .Include(e => e.Organisme)
                    .Include(e => e.Profil)
                    .ToListAsync()
                ;
            }

            return Ok(new { list = list, count = count });
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetOne(int id)
        {
            var user = await _context.Users.Where(e => e.Id == id)
                .Include(e => e.Profil)
                .Include(e => e.Organisme)
                .FirstOrDefaultAsync()
                ;

            return Ok(user);
        }

        [HttpPost]
        public async Task<ActionResult<User>> LogIn(UserDTO model)
        {
            if (string.IsNullOrEmpty(model.Email) || string.IsNullOrEmpty(model.Password))
                return BadRequest("Email ou mot pass sont vide");

            var user = await _context.Users
                .Include(u => u.Organisme)
                .SingleOrDefaultAsync(x => x.Email == model.Email)
                ;

            Profil role = null;
            // check if username exists
            if (user == null)
                return BadRequest("Email est pas correct");

            if (user.Password == model.Password)
            {
                role = await _context.Profils.FirstOrDefaultAsync(e => e.Id == user.IdProfil);
                // authentication successful so generate jwt token
                var tokenHandler = new JwtSecurityTokenHandler();
                // var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
                // var key = Encoding.ASCII.GetBytes("this is the secret phrase");
                var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
                var claims = new Claim[]
                    {
                        new Claim(ClaimTypes.Name, user.Id.ToString()),
                        new Claim(ClaimTypes.Email, user.Email),
                        new Claim(ClaimTypes.Role, role.Id.ToString())
                    };

                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(claims),
                    Expires = DateTime.UtcNow.AddDays(7),
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
                };
                var createToken = tokenHandler.CreateToken(tokenDescriptor);
                var token = tokenHandler.WriteToken(createToken);
                // var token = tokenHandler.ReadJwtToken(createToken);

                // remove password before returning
                user.Password = "";
                user.Profil = role;
                return Ok(new { user, token, idRole = role.Id });
            }

            return BadRequest("Mot pass est pas correct");
        }

        [HttpGet]
        // [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<ActionResult<string>> GetTokken()
        {
            var token = await HttpContext.GetTokenAsync("access_token");
            return token;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByForeignKey(int id)
        {
            var model = await _context.Users.Where(e => e.Mesures.Any(m => m.Id  == id))
                .ToListAsync();
                ;

            return Ok(model);
        }

        [HttpGet]
        public async Task<IActionResult> GetForTest()
        {
            var model = await _context.Users.Select(e => new {
                email = e.Email,
                password = e.Password,
                profil = e.Profil.Label,
            })
                .ToListAsync();
                ;

            return Ok(model);
        }

    }

    public class UserDTO
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}