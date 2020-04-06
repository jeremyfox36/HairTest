using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using HairTest.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HairTest.Controllers
{
    [AllowAnonymous]
    [Route("[controller]")]
    [ApiController]
    
    public class UsersController : ControllerBase
    {
        private readonly IBarberRepository barberRepository;

        public UsersController(IBarberRepository _barberRepository)
        {
            barberRepository = _barberRepository;
        }
        public async Task<IActionResult> Get(string token, string userId, string returnUrl = "/")
        {
            var user = barberRepository.GetBarberById(userId);
            if (user == null)
                return Unauthorized();

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, user.id.ToString()),
                new Claim(ClaimTypes.Name, user.Name),
                new Claim(ClaimTypes.Role, user.Role)
            };

            var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            var principal = new ClaimsPrincipal(identity);

            await HttpContext.SignInAsync(
                CookieAuthenticationDefaults.AuthenticationScheme,
                principal,
                new AuthenticationProperties { IsPersistent = false });

            return LocalRedirect(returnUrl);
        }
    }
}