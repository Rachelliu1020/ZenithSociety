using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ZenithWebSite.Data;
using ZenithWebSite.Models.ZenithModels;
using ZenithWebSite.Models;
using Microsoft.AspNetCore.Authorization;

namespace ZenithWebSite.Controllers
{
    [Produces("application/json")]
    [Route("api/MyEventsAPI")]
    public class MyEventsAPIController : Controller
    {
        private readonly ApplicationDbContext _context;
        private static DateTime mondayDate;
        private static DateTime sundayDate;

        public MyEventsAPIController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/MyEventsAPI
        [HttpGet]
        public JsonResult GetCurrentMyEvents()
        {
            //return _context.MyEvents;
            mondayDate = DateTime.Today.AddDays(DateTime.Today.DayOfWeek == 0 ? -6 : (-1 * (int)(DateTime.Today.DayOfWeek) + 1));
            sundayDate = mondayDate.AddDays(7);

            return Json(getResultEvents(mondayDate, sundayDate));
        }

        [HttpGet]
        [Route("Previous")]
        [Authorize(Roles = "Admin, Member")]
        public JsonResult Previous()
        {
            DateTime tempMondayDate;
            List<DateTime> boundaryDates = getBoundaryDates();
            DateTime firstMonday = boundaryDates.First();
            var homeEvents = getResultEvents(mondayDate, sundayDate);
            do
            {
                tempMondayDate = mondayDate.AddDays(-7);
                if (tempMondayDate.Date >= firstMonday.Date)
                {
                    mondayDate = tempMondayDate;
                    sundayDate = mondayDate.AddDays(7);
                    homeEvents = getResultEvents(mondayDate, sundayDate);
                }
                else
                {
                    break;
                }
            } while (homeEvents.Count() == 0);

            return Json(homeEvents);
        }

        [HttpGet]
        [Route("Next")]
        [Authorize(Roles = "Admin, Member")]
        public JsonResult Next()
        {
            DateTime tempSundayDate;
            List<DateTime> boundaryDates = getBoundaryDates();
            DateTime lastSunday = boundaryDates.Last();
            var homeEvents = getResultEvents(mondayDate, sundayDate);

            do
            {
                tempSundayDate = sundayDate.AddDays(7);
                if (tempSundayDate.Date <= lastSunday.Date)
                {
                    sundayDate = tempSundayDate;
                    mondayDate = sundayDate.AddDays(-7);
                    homeEvents = getResultEvents(mondayDate, sundayDate);
                }
                else
                {
                    break;
                }
            } while (homeEvents.Count() == 0);


            return Json(homeEvents);
        }

        private List<DateTime> getBoundaryDates()
        {
            List<MyEvent> myEvents;
            if (User.Identity.IsAuthenticated)
            {
                myEvents = _context.MyEvents
                                .OrderBy(e => e.DateTimeFrom)
                                .ToList();



            }
            else
            {
                myEvents = _context.MyEvents
                            .Where(e => e.IsActive == true)
                            .OrderBy(e => e.DateTimeFrom)
                            .ToList();
            }
            DateTime firstEvenDate = myEvents.First().DateTimeFrom;
            DateTime lastEventDate = myEvents.Last().DateTimeFrom;
            DateTime firstMonday = firstEvenDate.AddDays(firstEvenDate.DayOfWeek == 0 ? -6 : (-1 * (int)(firstEvenDate.DayOfWeek) + 1));
            DateTime LastSunday = lastEventDate.AddDays(lastEventDate.DayOfWeek == 0 ? -6 : (-1 * (int)(lastEventDate.DayOfWeek) + 1)).AddDays(7);
            return new List<DateTime> { firstMonday, LastSunday };
        }

        private IEnumerable<HomeEventModel> getResultEvents(DateTime mondayDate, DateTime sundayDate)
        {

            List<MyEvent> myEvents;

            if (User.Identity.IsAuthenticated)
            {
                myEvents = _context.MyEvents
                                .Where(e => DateTime.Compare(e.DateTimeFrom, mondayDate) >= 0 &&
                                    DateTime.Compare(e.DateTimeFrom, sundayDate) <= 0)
                                .Include(m => m.MyActivity)
                                .OrderBy(e => e.DateTimeFrom)
                                .ToList();



            }
            else
            {
                myEvents = _context.MyEvents
                            .Where(e => e.IsActive == true &&
                                DateTime.Compare(e.DateTimeFrom, mondayDate) >= 0 &&
                                DateTime.Compare(e.DateTimeFrom, sundayDate) <= 0)
                            .Include(m => m.MyActivity)
                            .OrderBy(e => e.DateTimeFrom)
                            .ToList();
            }

            List<EventJsonModel> MonList = new List<EventJsonModel>();
            List<EventJsonModel> TueList = new List<EventJsonModel>();
            List<EventJsonModel> WedList = new List<EventJsonModel>();
            List<EventJsonModel> ThuList = new List<EventJsonModel>();
            List<EventJsonModel> FriList = new List<EventJsonModel>();
            List<EventJsonModel> SatList = new List<EventJsonModel>();
            List<EventJsonModel> SunList = new List<EventJsonModel>();

            
            foreach (var e in myEvents)
            {
                switch (e.DateTimeFrom.DayOfWeek)
                {
                    case DayOfWeek.Monday:
                        MonList.Add(new EventJsonModel {
                            EventId = e.MyEventId,
                            DateTimeFrom=e.DateTimeFrom,
                            DateTimeTo =e.DateTimeTo,
                            IsActive= e.IsActive,
                            ActivityDesp= e.MyActivity.ActivityDesp,
                            dateTimeFromStr = e.DateTimeFrom.ToString("h:mm tt"),
                            dateTimeToStr = e.DateTimeTo.ToString("h:mm tt")
                        });
                        break;
                    case DayOfWeek.Tuesday:
                        TueList.Add(new EventJsonModel
                        {
                            EventId = e.MyEventId,
                            DateTimeFrom = e.DateTimeFrom,
                            DateTimeTo = e.DateTimeTo,
                            IsActive = e.IsActive,
                            ActivityDesp = e.MyActivity.ActivityDesp,
                            dateTimeFromStr = e.DateTimeFrom.ToString("h:mm tt"),
                            dateTimeToStr = e.DateTimeTo.ToString("h:mm tt")
                        });
                        break;
                    case DayOfWeek.Wednesday:
                        WedList.Add(new EventJsonModel
                        {
                            EventId = e.MyEventId,
                            DateTimeFrom = e.DateTimeFrom,
                            DateTimeTo = e.DateTimeTo,
                            IsActive = e.IsActive,
                            ActivityDesp = e.MyActivity.ActivityDesp,
                            dateTimeFromStr = e.DateTimeFrom.ToString("h:mm tt"),
                            dateTimeToStr = e.DateTimeTo.ToString("h:mm tt")
                        });
                        break;
                    case DayOfWeek.Thursday:
                        ThuList.Add(new EventJsonModel
                        {
                            EventId = e.MyEventId,
                            DateTimeFrom = e.DateTimeFrom,
                            DateTimeTo = e.DateTimeTo,
                            IsActive = e.IsActive,
                            ActivityDesp = e.MyActivity.ActivityDesp,
                            dateTimeFromStr = e.DateTimeFrom.ToString("h:mm tt"),
                            dateTimeToStr = e.DateTimeTo.ToString("h:mm tt")
                        });
                        break;
                    case DayOfWeek.Friday:
                        FriList.Add(new EventJsonModel
                        {
                            EventId = e.MyEventId,
                            DateTimeFrom = e.DateTimeFrom,
                            DateTimeTo = e.DateTimeTo,
                            IsActive = e.IsActive,
                            ActivityDesp = e.MyActivity.ActivityDesp,
                            dateTimeFromStr = e.DateTimeFrom.ToString("h:mm tt"),
                            dateTimeToStr = e.DateTimeTo.ToString("h:mm tt")
                        });
                        break;
                    case DayOfWeek.Saturday:
                        SatList.Add(new EventJsonModel
                        {
                            EventId = e.MyEventId,
                            DateTimeFrom = e.DateTimeFrom,
                            DateTimeTo = e.DateTimeTo,
                            IsActive = e.IsActive,
                            ActivityDesp = e.MyActivity.ActivityDesp,
                            dateTimeFromStr = e.DateTimeFrom.ToString("h:mm tt"),
                            dateTimeToStr = e.DateTimeTo.ToString("h:mm tt")
                        });
                        break;
                    case DayOfWeek.Sunday:
                        SunList.Add(new EventJsonModel
                        {
                            EventId = e.MyEventId,
                            DateTimeFrom = e.DateTimeFrom,
                            DateTimeTo = e.DateTimeTo,
                            IsActive = e.IsActive,
                            ActivityDesp = e.MyActivity.ActivityDesp,
                            dateTimeFromStr = e.DateTimeFrom.ToString("h:mm tt"),
                            dateTimeToStr = e.DateTimeTo.ToString("h:mm tt")
                        });
                        break;

                }

            }
            List<HomeEventModel> displayEventsList = new List<HomeEventModel>();

            if (MonList.Count != 0)
            {
                displayEventsList.Add(new HomeEventModel
                {
                    Displaydate = mondayDate,
                    Events = MonList
                });
            }
            if (TueList.Count != 0)
            {
                displayEventsList.Add(new HomeEventModel
                {
                    Displaydate = mondayDate.AddDays(1),
                    Events = TueList
                });
            }
            if (WedList.Count != 0)
            {
                displayEventsList.Add(new HomeEventModel
                {
                    Displaydate = mondayDate.AddDays(2),
                    Events = WedList
                });
            }
            if (ThuList.Count != 0)
            {
                displayEventsList.Add(new HomeEventModel
                {
                    Displaydate = mondayDate.AddDays(3),
                    Events = ThuList
                });
            }
            if (FriList.Count != 0)
            {
                displayEventsList.Add(new HomeEventModel
                {
                    Displaydate = mondayDate.AddDays(4),
                    Events = FriList
                });
            }
            if (SatList.Count != 0)
            {
                displayEventsList.Add(new HomeEventModel
                {
                    Displaydate = mondayDate.AddDays(5),
                    Events = SatList
                });
            }
            if (SunList.Count != 0)
            {
                displayEventsList.Add(new HomeEventModel
                {
                    Displaydate = mondayDate.AddDays(6),
                    Events = SunList
                });
            }
            return displayEventsList;
        }

        // GET: api/MyEventsAPI/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetMyEvent([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            MyEvent myEvent = await _context.MyEvents.SingleOrDefaultAsync(m => m.MyEventId == id);

            if (myEvent == null)
            {
                return NotFound();
            }

            return Ok(myEvent);
        }

        // PUT: api/MyEventsAPI/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMyEvent([FromRoute] int id, [FromBody] MyEvent myEvent)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != myEvent.MyEventId)
            {
                return BadRequest();
            }

            _context.Entry(myEvent).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MyEventExists(id))
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

        // POST: api/MyEventsAPI
        [HttpPost]
        public async Task<IActionResult> PostMyEvent([FromBody] MyEvent myEvent)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.MyEvents.Add(myEvent);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (MyEventExists(myEvent.MyEventId))
                {
                    return new StatusCodeResult(StatusCodes.Status409Conflict);
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetMyEvent", new { id = myEvent.MyEventId }, myEvent);
        }

        // DELETE: api/MyEventsAPI/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMyEvent([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            MyEvent myEvent = await _context.MyEvents.SingleOrDefaultAsync(m => m.MyEventId == id);
            if (myEvent == null)
            {
                return NotFound();
            }

            _context.MyEvents.Remove(myEvent);
            await _context.SaveChangesAsync();

            return Ok(myEvent);
        }

        private bool MyEventExists(int id)
        {
            return _context.MyEvents.Any(e => e.MyEventId == id);
        }
    }
}