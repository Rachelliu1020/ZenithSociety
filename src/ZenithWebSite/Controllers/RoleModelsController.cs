using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ZenithWebSite.Data;
using ZenithWebSite.Models.IdentityModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace ZenithWebSite.Controllers
{
    public class RoleModelsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private RoleManager<IdentityRole> _roleManager;


        public RoleModelsController(ApplicationDbContext context, RoleManager<IdentityRole> roleManager)
        {
            _context = context;
            _roleManager = roleManager;
        }

        // GET: RoleModels
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Roles;
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: RoleModels/Create
        public IActionResult Create()
        {
            ViewData["RoleId"] = new SelectList(_context.Roles, "Id", "Name");
            return View();
        }

        // POST: RoleModels/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name")] IdentityRole role)
        {
            if (ModelState.IsValid)
            {
                //_context.Roles.Add(role);
                var result = await _roleManager.CreateAsync(role);
                if (result.Succeeded) {
                    await _context.SaveChangesAsync();
                    return RedirectToAction("Index");
                }
                AddErrors(result);
            }
            ViewData["RoleId"] = new SelectList(_context.Roles, "Id", "Name", role.Id);
            return View(role);
        }
        
        // GET: RoleModels/Delete/5
        public async Task<IActionResult> Delete(string id = null)
        {
            if (id == null)
            {
                return NotFound();
            }

            var roleModel = await _context.Roles.SingleOrDefaultAsync(m => m.Id == id);
            if (roleModel == null)
            {
                return NotFound();
            }

            return View(roleModel);
        }

        // POST: RoleModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            
            var role = await _context.Roles.SingleOrDefaultAsync(m => m.Id == id);
            if (role.Name == "Admin"){
                AddErrorsFromString("Admin role cannot be deleted.");
            }
            else if(role.Name == "Member")
            {
                AddErrorsFromString("Member role cannot be deleted.");
            }
            else {
                _context.Roles.Remove(role);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            //ViewData["RoleId"] = new SelectList(_context.Roles, "Id", "Name", role.Id);
            return View(role);
        }

        private bool RoleExists(string id)
        {
            return _context.Roles.Any(e => e.Id == id);
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
