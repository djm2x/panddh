using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
namespace Providers
{
    public static class RetrieveTokken
    {

        public static int GetIdUser(this HttpContext context)
        {
            return int.Parse(RetrieveTokken.GetClaim("unique_name", context));
        }

        public static int GetRoleUser(this HttpContext context)
        {
            return int.Parse(RetrieveTokken.GetClaim("role", context));
        }

        private static string GetClaim(string type, HttpContext context)
        {
            JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();
            // var token0 = await context.GetTokenAsync("name");
            // var me = HttpContext.au;
            var user = context.User.Identity;

            string tokenString = context.Request.Headers["Authorization"].ToString().Replace("Bearer ", "");
            JwtSecurityToken  token = tokenHandler.ReadJwtToken(tokenString);
            Claim claim = token.Claims.SingleOrDefault(e => e.Type == type);

            return claim?.Value;
        }



    }
}