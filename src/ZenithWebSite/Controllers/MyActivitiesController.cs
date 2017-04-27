using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ZenithWebSite.Data;
using ZenithWebSite.Models.ZenithModels;
using Microsoft.AspNetCore.Authorization;

namespace ZenithWebSite.Controllers
{
    [Authorize(Roles = "Admin")]
    public class MyActivitiesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public MyActivitiesController(ApplicationDbContext context)
        {
            _context = context;    
        }

        // GET: MyActivities
        public async Task<IActionResult> Index()
        {
            return View(await _context.MyActivities.ToListAsync());
        }

        // GET: MyActivities/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var myActivity = await _context.MyActivities.SingleOrDefaultAsync(m => m.MyActivityId == id);
            if (myActivity == null)
            {
                return NotFound();
            }

            return View(myActivity);
        }

        // GET: MyActivities/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: MyActivities/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MyActivityId,ActivityDesp,CreationDate")] MyActivity myActivity)
        {
            if (ModelState.IsValid)
            {
                myActivity.CreationDate = DateTime.Now;
                _context.Add(myActivity);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(myActivity);
        }

        // GET: MyActivities/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var myActivity = await _context.MyActivities.SingleOrDefaultAsync(m => m.MyActivityId == id);
            if (myActivity == null)
            {
                return NotFound();
            }
            return View(myActivity);
        }

        // POST: MyActivities/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("MyActivityId,ActivityDesp,CreationDate")] MyActivity myActivity)
        {
            if (id != myActivity.MyActivityId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(myActivity);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MyActivityExists(myActivity.MyActivityId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Index");
            }
            return View(myActivity);
        }

        // GET: MyActivities/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var myActivity = await _context.MyActivities.SingleOrDefaultAsync(m => m.MyActivityId == id);
            if (myActivity == null)
            {
                return NotFound();
            }

            return View(myActivity);
        }

        // POST: MyActivities/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var myActivity = await _context.MyActivities.SingleOrDefaultAsync(m => m.MyActivityId == id);
            _context.MyActivities.Remove(myActivity);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool MyActivityExists(int id)
        {
            return _context.MyActivities.Any(e => e.MyActivityId == id);
        }
    }
}
