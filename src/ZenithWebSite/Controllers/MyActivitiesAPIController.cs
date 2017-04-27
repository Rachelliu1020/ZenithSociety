using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ZenithWebSite.Data;
using ZenithWebSite.Models.ZenithModels;
using Microsoft.AspNetCore.Authorization;

namespace ZenithWebSite.Controllers
{
    [Authorize(Roles = "Admin")]
    [Produces("application/json")]
    [Route("api/MyActivitiesAPI")]
    public class MyActivitiesAPIController : Controller
    {
        private readonly ApplicationDbContext _context;

        public MyActivitiesAPIController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/MyActivitiesAPI
        [HttpGet]
        public IEnumerable<MyActivity> GetAllMyActivities()
        {
            return _context.MyActivities;
        }

        // GET: api/MyActivitiesAPI/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetMyActivity([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            MyActivity myActivity = await _context.MyActivities.SingleOrDefaultAsync(m => m.MyActivityId == id);

            if (myActivity == null)
            {
                return NotFound();
            }

            return Ok(myActivity);
        }

        // PUT: api/MyActivitiesAPI/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMyActivity([FromRoute] int id, [FromBody] MyActivity myActivity)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != myActivity.MyActivityId)
            {
                return BadRequest();
            }

            _context.Entry(myActivity).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MyActivityExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/MyActivitiesAPI
        [HttpPost]
        public async Task<IActionResult> PostMyActivity([FromBody] MyActivity myActivity)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.MyActivities.Add(myActivity);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (MyActivityExists(myActivity.MyActivityId))
                {
                    return new StatusCodeResult(StatusCodes.Status409Conflict);
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetMyActivity", new { id = myActivity.MyActivityId }, myActivity);
        }

        // DELETE: api/MyActivitiesAPI/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMyActivity([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            MyActivity myActivity = await _context.MyActivities.SingleOrDefaultAsync(m => m.MyActivityId == id);
            if (myActivity == null)
            {
                return NotFound();
            }

            _context.MyActivities.Remove(myActivity);
            await _context.SaveChangesAsync();

            return Ok(myActivity);
        }

        private bool MyActivityExists(int id)
        {
            return _context.MyActivities.Any(e => e.MyActivityId == id);
        }
    }
}