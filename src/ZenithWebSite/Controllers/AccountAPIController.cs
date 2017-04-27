using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using ZenithWebSite.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace ZenithWebSite.Controllers
{
    [Produces("application/json")]
    [Route("api/AccountAPI")]
    public class AccountAPIController : Controller
    {
      
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public AccountAPIController(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }


        // POST api/AccountAPI/Register
        [AllowAnonymous]
        [Route("Register")]
        [HttpPost]
        public async Task<IActionResult> Register(string userName, string firstName, string lastName, string email, string password)
        {
            if (userName == null || firstName == null || lastName == null || email == null || password == null)
            {
                return BadRequest(new { msg = "error" });
            }

            var user = new ApplicationUser() { UserName = userName, Email = email, FirstName = firstName, LastName = lastName };

            IdentityResult result = await _userManager.CreateAsync(user, password);

            if (!result.Succeeded)
            {
                return BadRequest(result);
            }

            string roleName = "Member";
            bool hasMemberRole = await _roleManager.RoleExistsAsync(roleName);
            if (!hasMemberRole)
            {
                var newRole = new IdentityRole { Name = roleName, NormalizedName = roleName.ToUpper() };
                await _roleManager.CreateAsync(newRole);
            }
            await _userManager.AddToRoleAsync(user, "Member");
            return Ok(new { code = "success" });
        }

        // GET: api/AccountAPI/UserRoleInfo
        [HttpGet]
        [Route("UserRoleInfo")]
        [Authorize]
        public async Task<JsonResult> GetUserRoleInfo()
        {
            var user = await _userManager.GetUserAsync(HttpContext.User);
            bool isMember = await _userManager.IsInRoleAsync(user, "Member");
            bool isAdmin = await _userManager.IsInRoleAsync(user, "Admin");
            object result;
            if (isMember || isAdmin) {
                result = new
                {
                    isMemberOrAdmin = true
                };
            }
            else{
                result = new
                {
                    isMemberOrAdmin = false
                };
            }

            return Json(result);
        }
    }
}