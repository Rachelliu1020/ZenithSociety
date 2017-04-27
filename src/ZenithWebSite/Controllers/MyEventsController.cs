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
    public class MyEventsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public MyEventsController(ApplicationDbContext context)
        {
            _context = context;    
        }

        // GET: MyEvents
        public async Task<IActionResult> Index()
        {
            IOrderedQueryable<MyEvent> applicationDbContext;
            if (User.Identity.IsAuthenticated)
            {
                applicationDbContext = _context.MyEvents.Include(m => m.MyActivity).OrderBy(m => m.DateTimeFrom);
            }
            else
            {
                applicationDbContext = _context.MyEvents.Where(e => e.IsActive == true).Include(m => m.MyActivity).OrderBy(m => m.DateTimeFrom);
            }
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: MyEvents/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var myEvent = await _context.MyEvents.Include(m => m.MyActivity).SingleOrDefaultAsync(m => m.MyEventId == id);
            if (myEvent == null)
            {
                return NotFound();
            }

            return View(myEvent);
        }

        // GET: MyEvents/Create
        public IActionResult Create()
        {
            ViewData["MyActivityId"] = new SelectList(_context.MyActivities, "MyActivityId", "ActivityDesp");
            return View();
        }

        // POST: MyEvents/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MyEventId,CreationDate,Creator,DateTimeFrom,DateTimeTo,IsActive,MyActivityId")] MyEvent myEvent)
        {
            if (ModelState.IsValid)
            {
                myEvent.CreationDate = DateTime.Now;
                myEvent.Creator = User.Identity.Name;
                _context.Add(myEvent);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewData["MyActivityId"] = new SelectList(_context.MyActivities, "MyActivityId", "ActivityDesp", myEvent.MyActivityId);
            return View(myEvent);
        }

        // GET: MyEvents/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var myEvent = await _context.MyEvents.SingleOrDefaultAsync(m => m.MyEventId == id);
            if (myEvent == null)
            {
                return NotFound();
            }
            ViewData["MyActivityId"] = new SelectList(_context.MyActivities, "MyActivityId", "ActivityDesp", myEvent.MyActivityId);
            return View(myEvent);
        }

        // POST: MyEvents/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("MyEventId,CreationDate,Creator,DateTimeFrom,DateTimeTo,IsActive,MyActivityId")] MyEvent myEvent)
        {
            if (id != myEvent.MyEventId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(myEvent);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MyEventExists(myEvent.MyEventId))
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
            ViewData["MyActivityId"] = new SelectList(_context.MyActivities, "MyActivityId", "ActivityDesp", myEvent.MyActivityId);
            return View(myEvent);
        }

        // GET: MyEvents/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var myEvent = await _context.MyEvents.Include(m => m.MyActivity).SingleOrDefaultAsync(m => m.MyEventId == id);
            if (myEvent == null)
            {
                return NotFound();
            }

            return View(myEvent);
        }

        // POST: MyEvents/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var myEvent = await _context.MyEvents.Include(m => m.MyActivity).SingleOrDefaultAsync(m => m.MyEventId == id);
            _context.MyEvents.Remove(myEvent);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool MyEventExists(int id)
        {
            return _context.MyEvents.Any(e => e.MyEventId == id);
        }
    }
}
