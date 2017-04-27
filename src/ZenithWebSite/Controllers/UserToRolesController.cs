using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ZenithWebSite.Data;
using ZenithWebSite.Models;
using Microsoft.AspNetCore.Identity;
using ZenithWebSite.Models.IdentityModels;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;


namespace ZenithWebSite.Controllers
{
    public class UserToRolesController : Controller
    {
        private readonly ApplicationDbContext _context;
        private UserManager<ApplicationUser> _userManager;
        private RoleManager<IdentityRole> _roleManager;

        public UserToRolesController(ApplicationDbContext context, UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _context = context;
            _userManager = userManager;
            _roleManager = roleManager;
        }

        // GET: UserToRoles
        public IActionResult Index()
        {
            
            var userRoleNames = (from ur in _context.UserRoles
                                 join r in _context.Roles on ur.RoleId equals r.Id
                                 join u in _context.Users on ur.UserId equals u.Id
                                 orderby u.UserName
                                 select new {UserId = ur.UserId, UserName = u.UserName, RoleId = ur.RoleId, RoleName = r.Name }
                                 );

            List<UserRoleModel> userRoleList = new List<UserRoleModel>();
            foreach (var userRoleName in userRoleNames) {
                userRoleList.Add(new UserRoleModel()
                {
                    UserId = userRoleName.UserId,
                    UserName = userRoleName.UserName,
                    RoleId = userRoleName.RoleId,
                    RoleName = userRoleName.RoleName
                });
            }
            
            return View(userRoleList);
        }

        // GET: UserToRoles/Create
        public IActionResult Create()
        {
            ViewBag.UserId = new SelectList(_context.Users, "Id", "UserName");
            ViewBag.RoleId = new SelectList(_context.Roles, "Id", "Name");
            return View();
        }

        // POST: UserToRoles/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("UserId,RoleId")] IdentityUserRole<string> userRole)
        {
           
            if (ModelState.IsValid)
            {
                var user = await _userManager.FindByIdAsync(userRole.UserId);
                var role = await _roleManager.FindByIdAsync(userRole.RoleId);
                if (user != null && role != null)
                {
                    var IsExistUserRole = await _userManager.IsInRoleAsync(user, role.Name);
                    if (IsExistUserRole) {
                        AddErrorsFromString("The match of the Role and the User has existing.");
                    } else {
                        // _context.Add(applicationUser);
                        var result = await _userManager.AddToRoleAsync(user, role.Name);
                        if (result.Succeeded)
                        {
                            await _context.SaveChangesAsync();
                            return RedirectToAction("Index");
                        }
                        AddErrors(result);
                    }                 
                }
                   
            }
            ViewBag.UserId = new SelectList(_context.Users, "Id", "UserName", userRole.UserId);
            ViewBag.RoleId = new SelectList(_context.Roles, "Id", "Name", userRole.RoleId);
            return View(userRole);
        }

        // GET: UserToRoles/Delete/5
        public async Task<IActionResult> Delete(string id = null, string roleId = null)
        {
            if (id == null || roleId == null)
            {
                return NotFound();
            }

            var user = await _context.Users.SingleOrDefaultAsync(u => u.Id == id);
            var role = await _context.Roles.SingleOrDefaultAsync(r => r.Id == roleId);
            if (user == null || role == null)
            {
                return NotFound();
            }
            
            var userRoleName = (from ur in _context.UserRoles
                                    join r in _context.Roles on ur.RoleId equals r.Id
                                    join u in _context.Users on ur.UserId equals u.Id
                                    where (ur.RoleId == roleId) && (ur.UserId == id)
                                    select new { UserId = ur.UserId, UserName = u.UserName, RoleId = ur.RoleId, RoleName = r.Name }
                                    ).FirstOrDefault();

            UserRoleModel userRole = new UserRoleModel()
            {
                UserId = userRoleName.UserId,
                UserName = userRoleName.UserName,
                RoleId = userRoleName.RoleId,
                RoleName = userRoleName.RoleName

            };
            return View(userRole);
        }

        // POST: UserToRoles/Delete/5
        [ActionName("Delete"), HttpPost()]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id, string roleId)
        {
            var user = await _context.Users.SingleOrDefaultAsync(u => u.Id == id);
            var role = await _context.Roles.SingleOrDefaultAsync(r => r.Id == roleId);
            if (user == null || role == null)
            {
                return NotFound();
            }
            if (user.UserName == "a" && role.Name == "Admin")
            {
                AddErrorsFromString("Cannot remove account 'a' from Admin role.");
            }
            else { 
                //var userRole = await _context.UserRoles.SingleOrDefaultAsync(ur => ur.UserId == id && ur.RoleId == roleId);
                //_context.UserRoles.Remove(userRole);
                IdentityResult result = await _userManager.RemoveFromRoleAsync(user, role.Name);
                if (result.Succeeded)
                {
                    await _context.SaveChangesAsync();
                    return RedirectToAction("Index");
                }
                AddErrors(result);
            }
            var userRoleName = (from ur in _context.UserRoles
                                join r in _context.Roles on ur.RoleId equals r.Id
                                join u in _context.Users on ur.UserId equals u.Id
                                where (ur.RoleId == roleId) && (ur.UserId == id)
                                select new { UserId = ur.UserId, UserName = u.UserName, RoleId = ur.RoleId, RoleName = r.Name }
                                    ).FirstOrDefault();

            UserRoleModel userRoleModel = new UserRoleModel()
            {
                UserId = userRoleName.UserId,
                UserName = userRoleName.UserName,
                RoleId = userRoleName.RoleId,
                RoleName = userRoleName.RoleName

            };
            return View(userRoleModel);
        }

        private bool ApplicationUserExists(string id, string roleId)
        {
            return _context.UserRoles.Any(ur => ur.UserId == id && ur.RoleId == roleId);
        }

        private void AddErrors(IdentityResult result)
        {
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError(string.Empty, error.Description);
            }
        }

        private void AddErrorsFromString(string error)
        {
            ModelState.AddModelError(string.Empty, error);
        }
    }
}
