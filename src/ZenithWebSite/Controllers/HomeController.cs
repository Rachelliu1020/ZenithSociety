using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ZenithWebSite.Models.ZenithModels;
using ZenithWebSite.Data;
using Microsoft.EntityFrameworkCore;

namespace ZenithWebSite.Controllers
{
    public class HomeController : Controller
    {
        
        private readonly ApplicationDbContext db;
        private static DateTime mondayDate;
        private static DateTime sundayDate;
        

        public HomeController(ApplicationDbContext context)
        {
            db = context;
            //mondayDate = DateTime.Today.AddDays(DateTime.Today.DayOfWeek == 0 ? -6 : (-1 * (int)(DateTime.Today.DayOfWeek) + 1));
            //sundayDate = mondayDate.AddDays(7);
        }

        public IActionResult Index()
        {
            mondayDate = DateTime.Today.AddDays(DateTime.Today.DayOfWeek == 0 ? -6 : (-1 * (int)(DateTime.Today.DayOfWeek) + 1));
            sundayDate = mondayDate.AddDays(7);
            return View(getDisplayDictionary(mondayDate, sundayDate));
        }

        public IActionResult Previous()
        {
            DateTime tempMondayDate;
            List<DateTime> boundaryDates = getBoundaryDates();
            DateTime firstMonday = boundaryDates.First();
            Dictionary<DateTime, List<MyEvent>> dictiondary = getDisplayDictionary(mondayDate, sundayDate);
            do
            {
                tempMondayDate = mondayDate.AddDays(-7);
                if (tempMondayDate.Date >= firstMonday.Date) {
                    mondayDate = tempMondayDate; 
                    sundayDate = mondayDate.AddDays(7);
                    dictiondary = getDisplayDictionary(mondayDate, sundayDate);
                }
                else
                {
                    break;
                }
            } while (dictiondary.Count() == 0);

            return View("Index", dictiondary);
        }

        public IActionResult Next()
        {
            DateTime tempSundayDate;
            List<DateTime> boundaryDates = getBoundaryDates();
            DateTime lastSunday = boundaryDates.Last();
            Dictionary<DateTime, List<MyEvent>> dictiondary = getDisplayDictionary(mondayDate, sundayDate);

            do
            {
                tempSundayDate = sundayDate.AddDays(7);
                if (tempSundayDate.Date <= lastSunday.Date)
                {
                    sundayDate = tempSundayDate;
                    mondayDate = sundayDate.AddDays(-7);
                    dictiondary = getDisplayDictionary(mondayDate, sundayDate);
                }
                else {
                    break;
                }
            } while (dictiondary.Count() == 0);
            

            return View("Index", dictiondary);
        }

        private List<DateTime> getBoundaryDates() {
            List<MyEvent> myEvents;
            if (User.Identity.IsAuthenticated)
            {
                myEvents = db.MyEvents
                                .OrderBy(e => e.DateTimeFrom)
                                .ToList();



            }
            else
            {
                myEvents = db.MyEvents
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
        private Dictionary<DateTime, List<MyEvent>> getDisplayDictionary(DateTime mondayDate, DateTime sundayDate) {

            List<MyEvent> myEvents;

            if (User.Identity.IsAuthenticated)
            {
                myEvents = db.MyEvents
                                .Where(e => DateTime.Compare(e.DateTimeFrom, mondayDate) >= 0 &&
                                    DateTime.Compare(e.DateTimeFrom, sundayDate) <= 0)
                                .Include(m => m.MyActivity)
                                .OrderBy(e => e.DateTimeFrom)
                                .ToList();



            }
            else
            {
                myEvents = db.MyEvents
                            .Where(e => e.IsActive == true &&
                                DateTime.Compare(e.DateTimeFrom, mondayDate) >= 0 &&
                                DateTime.Compare(e.DateTimeFrom, sundayDate) <= 0)
                            .Include(m => m.MyActivity)
                            .OrderBy(e => e.DateTimeFrom)
                            .ToList();
            }

            List<MyEvent> MonList = new List<MyEvent>();
            List<MyEvent> TueList = new List<MyEvent>();
            List<MyEvent> WedList = new List<MyEvent>();
            List<MyEvent> ThuList = new List<MyEvent>();
            List<MyEvent> FriList = new List<MyEvent>();
            List<MyEvent> SatList = new List<MyEvent>();
            List<MyEvent> SunList = new List<MyEvent>();

            DateTime displaydate;
            foreach (var e in myEvents)
            {
                switch (e.DateTimeFrom.DayOfWeek)
                {
                    case DayOfWeek.Monday:
                        MonList.Add(e);
                        break;
                    case DayOfWeek.Tuesday:
                        TueList.Add(e);
                        break;
                    case DayOfWeek.Wednesday:
                        WedList.Add(e);
                        break;
                    case DayOfWeek.Thursday:
                        ThuList.Add(e);
                        break;
                    case DayOfWeek.Friday:
                        FriList.Add(e);
                        break;
                    case DayOfWeek.Saturday:
                        SatList.Add(e);
                        break;
                    case DayOfWeek.Sunday:
                        SunList.Add(e);
                        break;

                }

            }
            Dictionary<DateTime, List<MyEvent>> dictionary = new Dictionary<DateTime, List<MyEvent>>();

            if (MonList.Count != 0)
            {
                displaydate = mondayDate;
                dictionary.Add(displaydate, MonList);
            }
            if (TueList.Count != 0)
            {
                displaydate = mondayDate.AddDays(1);
                dictionary.Add(displaydate, TueList);
            }
            if (WedList.Count != 0)
            {
                displaydate = mondayDate.AddDays(2);
                dictionary.Add(displaydate, WedList);
            }
            if (ThuList.Count != 0)
            {
                displaydate = mondayDate.AddDays(3);
                dictionary.Add(displaydate, ThuList);
            }
            if (FriList.Count != 0)
            {
                displaydate = mondayDate.AddDays(4);
                dictionary.Add(displaydate, FriList);
            }
            if (SatList.Count != 0)
            {
                displaydate = mondayDate.AddDays(5);
                dictionary.Add(displaydate, SatList);
            }
            if (SunList.Count != 0)
            {
                displaydate = mondayDate.AddDays(6);
                dictionary.Add(displaydate, SunList);
            }
            return dictionary;
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}
