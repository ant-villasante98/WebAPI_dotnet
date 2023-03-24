using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Primer_proyecto.DataAcces;
using Primer_proyecto.Helpers;
using Primer_proyecto.Models.DataModels;

namespace Primer_proyecto.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly UniversityDBContext _context;
        private readonly JwtSettings _jwtSettings;
        public AccountController(JwtSettings jwtSettings, UniversityDBContext context)
        {
            _context = context;
            _jwtSettings = jwtSettings;
        }

        // Examples Users
        private IEnumerable<User> Logins = new List<User> {
            new User(){ Id= 1, Email = "martin@email.com", Name = "Admin", Password= "Admin"},
            new User(){ Id= 2, Email = "pepe@email.com", Name = "User 1", Password= "pepe"},
        };
        // [HttpPost]
        // public IActionResult GetToken(UserLogins userLogin)
        // {

        //     // Modificar para Acceder desde el contexto  con Linq
        //     try
        //     {
        //         var Token = new UserTokens();
        //         var Valid = Logins.Any(user => user.Name.Equals(userLogin.UserName, StringComparison.OrdinalIgnoreCase));

        //         // var searchUser = await _context.Users.FindAsync(userLogin.UserName);

        //         if (Valid)
        //         {
        //             var user = Logins.FirstOrDefault(user => user.Name.Equals(userLogin.UserName, StringComparison.OrdinalIgnoreCase));
        //             Token = JwtHelpers.GetTokenKey(new UserTokens()
        //             {
        //                 UserName = user.Name,
        //                 EmailId = user.Email,
        //                 Id = user.Id
        //             }, _jwtSettings);
        //         }
        //         else
        //         {
        //             return BadRequest("Wrong Password");
        //         }
        //         return Ok(Token);
        //     }
        //     catch (Exception ex)
        //     {
        //         throw new Exception("GetToken Error ", ex);
        //     }

        // }

        [HttpPost]
        public IActionResult GetToken(User user)
        {
            try
            {
                if (_context.Users == null) return NotFound();

                var token = new UserTokens();

                var result = _context.Users.Find(user.Id);

                if (result == null) return BadRequest("Wrong Password");

                token = JwtHelpers.GetTokenKey(new UserTokens
                {
                    UserName = result.Name,
                    EmailId = result.Email,
                    Id = result.Id
                }, _jwtSettings);

                return Ok(token);
            }
            catch (Exception ex)
            {
                throw new Exception("GetToken Error ", ex);
            }

        }

        [HttpGet]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Administrator")]
        public IActionResult GetUserList()
        {
            if (_context.Users == null) return NotFound();
            var lista = _context.Users.ToList();
            return Ok(lista);

        }
    }
}
