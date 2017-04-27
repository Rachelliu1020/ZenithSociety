using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ZenithWebSite.Models;
using ZenithWebSite.Models.ZenithModels;


namespace ZenithWebSite.Data
{
    public class ZenithDummyData
    {
        public static async void Initialize(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            //seed activities table
            if (!context.MyActivities.Any())
            {
                context.MyActivities.Add(new MyActivity() { ActivityDesp = "Senior Golf Tournament", CreationDate = DateTime.Now });
                context.MyActivities.Add(new MyActivity() { ActivityDesp = "Leadership Meeting", CreationDate = DateTime.Now });
                context.MyActivities.Add(new MyActivity() { ActivityDesp = "Youth Bowling Tournament", CreationDate = DateTime.Now });

                context.MyActivities.Add(new MyActivity() { ActivityDesp = "Young ladies cooking lessons", CreationDate = DateTime.Now });
                context.MyActivities.Add(new MyActivity() { ActivityDesp = "Youth craft lessons", CreationDate = DateTime.Now });
                context.MyActivities.Add(new MyActivity() { ActivityDesp = "Youth choir practice", CreationDate = DateTime.Now });

                context.MyActivities.Add(new MyActivity() { ActivityDesp = "Lunch", CreationDate = DateTime.Now });
                context.MyActivities.Add(new MyActivity() { ActivityDesp = "Pancake Breakfast", CreationDate = DateTime.Now });
                context.MyActivities.Add(new MyActivity() { ActivityDesp = "Swimming Lessons for the youth", CreationDate = DateTime.Now });
                context.MyActivities.Add(new MyActivity() { ActivityDesp = "Swimming Exercise for parents", CreationDate = DateTime.Now });

                context.MyActivities.Add(new MyActivity() { ActivityDesp = "Bingo Tournament", CreationDate = DateTime.Now });
                context.MyActivities.Add(new MyActivity() { ActivityDesp = "BBQ Lunch", CreationDate = DateTime.Now });
                context.MyActivities.Add(new MyActivity() { ActivityDesp = "Garage Sale", CreationDate = DateTime.Now });

                context.SaveChanges();
            }

            //seed events table
            if (!context.MyEvents.Any())
            {
                //current event data
                context.MyEvents.Add(new MyEvent()
                {
                    Creator = "a",
                    CreationDate = DateTime.Now,
                    DateTimeFrom = new DateTime(2017, 3, 21, 8, 30, 0),
                    DateTimeTo = new DateTime(2017, 3, 21, 10, 30, 0),
                    IsActive = true,
                    MyActivity = context.MyActivities.FirstOrDefault(a => a.ActivityDesp == "Senior Golf Tournament")
                });

                context.MyEvents.Add(new MyEvent()
                {
                    Creator = "a",
                    CreationDate = DateTime.Now,
                    DateTimeFrom = new DateTime(2017, 3, 22, 8, 30, 0),
                    DateTimeTo = new DateTime(2017, 2, 22, 10, 30, 0),
                    IsActive = false,
                    MyActivity = context.MyActivities.FirstOrDefault(a => a.ActivityDesp == "Leadership Meeting")
                });
                context.MyEvents.Add(new MyEvent()
                {
                    Creator = "m",
                    CreationDate = DateTime.Now,
                    DateTimeFrom = new DateTime(2017, 3, 24, 17, 30, 0),
                    DateTimeTo = new DateTime(2017, 3, 24, 19, 15, 0),
                    IsActive = true,
                    MyActivity = context.MyActivities.FirstOrDefault(a => a.ActivityDesp == "Youth Bowling Tournament")
                });

                context.MyEvents.Add(new MyEvent()
                {
                    Creator = "m",
                    CreationDate = DateTime.Now,
                    DateTimeFrom = new DateTime(2017, 3, 24, 19, 00, 0),
                    DateTimeTo = new DateTime(2017, 3, 24, 20, 00, 0),
                    IsActive = true,
                    MyActivity = context.MyActivities.FirstOrDefault(a => a.ActivityDesp == "Young ladies cooking lessons")
                });

                context.MyEvents.Add(new MyEvent()
                {
                    Creator = "a",
                    CreationDate = DateTime.Now,
                    DateTimeFrom = new DateTime(2017, 3, 25, 8, 30, 0),
                    DateTimeTo = new DateTime(2017, 3, 25, 10, 30, 0),
                    IsActive = true,
                    MyActivity = context.MyActivities.FirstOrDefault(a => a.ActivityDesp == "Youth craft lessons")
                });
                context.MyEvents.Add(new MyEvent()
                {
                    Creator = "a",
                    CreationDate = DateTime.Now,
                    DateTimeFrom = new DateTime(2017, 3, 25, 10, 30, 0),
                    DateTimeTo = new DateTime(2017, 3, 25, 12, 00, 0),
                    IsActive = false,
                    MyActivity = context.MyActivities.FirstOrDefault(a => a.ActivityDesp == "Youth choir practice")
                });

                context.MyEvents.Add(new MyEvent()
                {
                    Creator = "m",
                    CreationDate = DateTime.Now,
                    DateTimeFrom = new DateTime(2017, 3, 25, 12, 00, 0),
                    DateTimeTo = new DateTime(2017, 3, 25, 13, 00, 0),
                    IsActive = true,
                    MyActivity = context.MyActivities.FirstOrDefault(a => a.ActivityDesp == "Lunch")
                });


                context.MyEvents.Add(new MyEvent()
                {
                    Creator = "a",
                    CreationDate = DateTime.Now,
                    DateTimeFrom = new DateTime(2017, 3, 26, 7, 30, 0),
                    DateTimeTo = new DateTime(2017, 3, 26, 8, 30, 0),
                    IsActive = true,
                    MyActivity = context.MyActivities.FirstOrDefault(a => a.ActivityDesp == "Pancake Breakfast")
                });
                context.MyEvents.Add(new MyEvent()
                {
                    Creator = "a",
                    CreationDate = DateTime.Now,
                    DateTimeFrom = new DateTime(2017, 3, 26, 8, 30, 0),
                    DateTimeTo = new DateTime(2017, 3, 26, 10, 30, 0),
                    IsActive = false,
                    MyActivity = context.MyActivities.FirstOrDefault(a => a.ActivityDesp == "Swimming Lessons for the youth")
                });

                context.MyEvents.Add(new MyEvent()
                {
                    Creator = "m",
                    CreationDate = DateTime.Now,
                    DateTimeFrom = new DateTime(2017, 3, 26, 08, 40, 0),
                    DateTimeTo = new DateTime(2017, 3, 26, 10, 40, 0),
                    IsActive = true,
                    MyActivity = context.MyActivities.FirstOrDefault(a => a.ActivityDesp == "Swimming Exercise for parents")
                });

                context.MyEvents.Add(new MyEvent()
                {
                    Creator = "a",
                    CreationDate = DateTime.Now,
                    DateTimeFrom = new DateTime(2017, 3, 26, 10, 30, 0),
                    DateTimeTo = new DateTime(2017, 3, 26, 12, 00, 0),
                    IsActive = true,
                    MyActivity = context.MyActivities.FirstOrDefault(a => a.ActivityDesp == "Bingo Tournament")
                });
                context.MyEvents.Add(new MyEvent()
                {
                    Creator = "a",
                    CreationDate = DateTime.Now,
                    DateTimeFrom = new DateTime(2017, 3, 26, 12, 00, 0),
                    DateTimeTo = new DateTime(2017, 3, 26, 13, 00, 0),
                    IsActive = false,
                    MyActivity = context.MyActivities.FirstOrDefault(a => a.ActivityDesp == "BBQ Lunch")
                });

                context.MyEvents.Add(new MyEvent()
                {
                    Creator = "m",
                    CreationDate = DateTime.Now,
                    DateTimeFrom = new DateTime(2017, 3, 26, 13, 00, 0),
                    DateTimeTo = new DateTime(2017, 3, 26, 18, 00, 0),
                    IsActive = true,
                    MyActivity = context.MyActivities.FirstOrDefault(a => a.ActivityDesp == "Garage Sale")
                });

                //next week
                context.MyEvents.Add(new MyEvent()
                {
                    Creator = "a",
                    CreationDate = DateTime.Now,
                    DateTimeFrom = new DateTime(2017, 3, 28, 8, 30, 0),
                    DateTimeTo = new DateTime(2017, 3, 28, 10, 30, 0),
                    IsActive = true,
                    MyActivity = context.MyActivities.FirstOrDefault(a => a.ActivityDesp == "Senior Golf Tournament")
                });

                context.MyEvents.Add(new MyEvent()
                {
                    Creator = "a",
                    CreationDate = DateTime.Now,
                    DateTimeFrom = new DateTime(2017, 3, 29, 8, 30, 0),
                    DateTimeTo = new DateTime(2017, 3, 29, 10, 30, 0),
                    IsActive = false,
                    MyActivity = context.MyActivities.FirstOrDefault(a => a.ActivityDesp == "Leadership Meeting")
                });
                context.MyEvents.Add(new MyEvent()
                {
                    Creator = "m",
                    CreationDate = DateTime.Now,
                    DateTimeFrom = new DateTime(2017, 3, 31, 17, 30, 0),
                    DateTimeTo = new DateTime(2017, 3, 31, 19, 15, 0),
                    IsActive = true,
                    MyActivity = context.MyActivities.FirstOrDefault(a => a.ActivityDesp == "Youth Bowling Tournament")
                });

                context.MyEvents.Add(new MyEvent()
                {
                    Creator = "m",
                    CreationDate = DateTime.Now,
                    DateTimeFrom = new DateTime(2017, 3, 31, 19, 00, 0),
                    DateTimeTo = new DateTime(2017, 3, 31, 20, 00, 0),
                    IsActive = true,
                    MyActivity = context.MyActivities.FirstOrDefault(a => a.ActivityDesp == "Young ladies cooking lessons")
                });

                context.MyEvents.Add(new MyEvent()
                {
                    Creator = "a",
                    CreationDate = DateTime.Now,
                    DateTimeFrom = new DateTime(2017, 4, 1, 8, 30, 0),
                    DateTimeTo = new DateTime(2017, 4, 1, 10, 30, 0),
                    IsActive = true,
                    MyActivity = context.MyActivities.FirstOrDefault(a => a.ActivityDesp == "Youth craft lessons")
                });
                context.MyEvents.Add(new MyEvent()
                {
                    Creator = "a",
                    CreationDate = DateTime.Now,
                    DateTimeFrom = new DateTime(2017, 4, 1, 10, 30, 0),
                    DateTimeTo = new DateTime(2017, 4, 1, 12, 00, 0),
                    IsActive = false,
                    MyActivity = context.MyActivities.FirstOrDefault(a => a.ActivityDesp == "Youth choir practice")
                });

                context.MyEvents.Add(new MyEvent()
                {
                    Creator = "m",
                    CreationDate = DateTime.Now,
                    DateTimeFrom = new DateTime(2017, 4, 1, 12, 00, 0),
                    DateTimeTo = new DateTime(2017, 4, 1, 13, 00, 0),
                    IsActive = true,
                    MyActivity = context.MyActivities.FirstOrDefault(a => a.ActivityDesp == "Lunch")
                });


                context.MyEvents.Add(new MyEvent()
                {
                    Creator = "a",
                    CreationDate = DateTime.Now,
                    DateTimeFrom = new DateTime(2017, 4, 2, 7, 30, 0),
                    DateTimeTo = new DateTime(2017, 4, 2, 8, 30, 0),
                    IsActive = true,
                    MyActivity = context.MyActivities.FirstOrDefault(a => a.ActivityDesp == "Pancake Breakfast")
                });

                context.MyEvents.Add(new MyEvent()
                {
                    Creator = "a",
                    CreationDate = DateTime.Now,
                    DateTimeFrom = new DateTime(2017, 4, 2, 8, 30, 0),
                    DateTimeTo = new DateTime(2017, 4, 2, 10, 30, 0),
                    IsActive = false,
                    MyActivity = context.MyActivities.FirstOrDefault(a => a.ActivityDesp == "Swimming Lessons for the youth")
                });

                context.MyEvents.Add(new MyEvent()
                {
                    Creator = "m",
                    CreationDate = DateTime.Now,
                    DateTimeFrom = new DateTime(2017, 4, 2, 08, 40, 0),
                    DateTimeTo = new DateTime(2017, 4, 2, 10, 40, 0),
                    IsActive = true,
                    MyActivity = context.MyActivities.FirstOrDefault(a => a.ActivityDesp == "Swimming Exercise for parents")
                });

                context.MyEvents.Add(new MyEvent()
                {
                    Creator = "a",
                    CreationDate = DateTime.Now,
                    DateTimeFrom = new DateTime(2017, 4, 2, 10, 30, 0),
                    DateTimeTo = new DateTime(2017, 4, 2, 12, 00, 0),
                    IsActive = true,
                    MyActivity = context.MyActivities.FirstOrDefault(a => a.ActivityDesp == "Bingo Tournament")
                });
                context.MyEvents.Add(new MyEvent()
                {
                    Creator = "a",
                    CreationDate = DateTime.Now,
                    DateTimeFrom = new DateTime(2017, 4, 2, 12, 00, 0),
                    DateTimeTo = new DateTime(2017, 4, 2, 13, 00, 0),
                    IsActive = false,
                    MyActivity = context.MyActivities.FirstOrDefault(a => a.ActivityDesp == "BBQ Lunch")
                });

                context.MyEvents.Add(new MyEvent()
                {
                    Creator = "m",
                    CreationDate = DateTime.Now,
                    DateTimeFrom = new DateTime(2017, 4, 2, 13, 00, 0),
                    DateTimeTo = new DateTime(2017, 4, 2, 18, 00, 0),
                    IsActive = true,
                    MyActivity = context.MyActivities.FirstOrDefault(a => a.ActivityDesp == "Garage Sale")
                });

                //next next week
                context.MyEvents.Add(new MyEvent()
                {
                    Creator = "a",
                    CreationDate = DateTime.Now,
                    DateTimeFrom = new DateTime(2017, 4, 4, 8, 30, 0),
                    DateTimeTo = new DateTime(2017, 4, 4, 10, 30, 0),
                    IsActive = true,
                    MyActivity = context.MyActivities.FirstOrDefault(a => a.ActivityDesp == "Senior Golf Tournament")
                });

                context.MyEvents.Add(new MyEvent()
                {
                    Creator = "a",
                    CreationDate = DateTime.Now,
                    DateTimeFrom = new DateTime(2017, 4, 5, 8, 30, 0),
                    DateTimeTo = new DateTime(2017, 4, 5, 10, 30, 0),
                    IsActive = false,
                    MyActivity = context.MyActivities.FirstOrDefault(a => a.ActivityDesp == "Leadership Meeting")
                });
                context.MyEvents.Add(new MyEvent()
                {
                    Creator = "m",
                    CreationDate = DateTime.Now,
                    DateTimeFrom = new DateTime(2017, 4, 7, 17, 30, 0),
                    DateTimeTo = new DateTime(2017, 4, 7, 19, 15, 0),
                    IsActive = true,
                    MyActivity = context.MyActivities.FirstOrDefault(a => a.ActivityDesp == "Youth Bowling Tournament")
                });

                context.MyEvents.Add(new MyEvent()
                {
                    Creator = "m",
                    CreationDate = DateTime.Now,
                    DateTimeFrom = new DateTime(2017, 4, 7, 19, 00, 0),
                    DateTimeTo = new DateTime(2017, 4, 7, 20, 00, 0),
                    IsActive = true,
                    MyActivity = context.MyActivities.FirstOrDefault(a => a.ActivityDesp == "Young ladies cooking lessons")
                });

                context.MyEvents.Add(new MyEvent()
                {
                    Creator = "a",
                    CreationDate = DateTime.Now,
                    DateTimeFrom = new DateTime(2017, 4, 8, 8, 30, 0),
                    DateTimeTo = new DateTime(2017, 4, 8, 10, 30, 0),
                    IsActive = true,
                    MyActivity = context.MyActivities.FirstOrDefault(a => a.ActivityDesp == "Youth craft lessons")
                });
                context.MyEvents.Add(new MyEvent()
                {
                    Creator = "a",
                    CreationDate = DateTime.Now,
                    DateTimeFrom = new DateTime(2017, 4, 8, 10, 30, 0),
                    DateTimeTo = new DateTime(2017, 4, 8, 12, 00, 0),
                    IsActive = false,
                    MyActivity = context.MyActivities.FirstOrDefault(a => a.ActivityDesp == "Youth choir practice")
                });

                context.MyEvents.Add(new MyEvent()
                {
                    Creator = "m",
                    CreationDate = DateTime.Now,
                    DateTimeFrom = new DateTime(2017, 4, 8, 12, 00, 0),
                    DateTimeTo = new DateTime(2017, 4, 8, 13, 00, 0),
                    IsActive = true,
                    MyActivity = context.MyActivities.FirstOrDefault(a => a.ActivityDesp == "Lunch")
                });


                context.MyEvents.Add(new MyEvent()
                {
                    Creator = "a",
                    CreationDate = DateTime.Now,
                    DateTimeFrom = new DateTime(2017, 4, 9, 7, 30, 0),
                    DateTimeTo = new DateTime(2017, 4, 9, 8, 30, 0),
                    IsActive = true,
                    MyActivity = context.MyActivities.FirstOrDefault(a => a.ActivityDesp == "Pancake Breakfast")
                });

                context.MyEvents.Add(new MyEvent()
                {
                    Creator = "a",
                    CreationDate = DateTime.Now,
                    DateTimeFrom = new DateTime(2017, 4, 9, 8, 30, 0),
                    DateTimeTo = new DateTime(2017, 4, 9, 10, 30, 0),
                    IsActive = false,
                    MyActivity = context.MyActivities.FirstOrDefault(a => a.ActivityDesp == "Swimming Lessons for the youth")
                });

                context.MyEvents.Add(new MyEvent()
                {
                    Creator = "m",
                    CreationDate = DateTime.Now,
                    DateTimeFrom = new DateTime(2017, 4, 9, 08, 40, 0),
                    DateTimeTo = new DateTime(2017, 4, 9, 10, 40, 0),
                    IsActive = true,
                    MyActivity = context.MyActivities.FirstOrDefault(a => a.ActivityDesp == "Swimming Exercise for parents")
                });

                context.MyEvents.Add(new MyEvent()
                {
                    Creator = "a",
                    CreationDate = DateTime.Now,
                    DateTimeFrom = new DateTime(2017, 4, 9, 10, 30, 0),
                    DateTimeTo = new DateTime(2017, 4, 9, 12, 00, 0),
                    IsActive = true,
                    MyActivity = context.MyActivities.FirstOrDefault(a => a.ActivityDesp == "Bingo Tournament")
                });
                context.MyEvents.Add(new MyEvent()
                {
                    Creator = "a",
                    CreationDate = DateTime.Now,
                    DateTimeFrom = new DateTime(2017, 4, 9, 12, 00, 0),
                    DateTimeTo = new DateTime(2017, 4, 9, 13, 00, 0),
                    IsActive = false,
                    MyActivity = context.MyActivities.FirstOrDefault(a => a.ActivityDesp == "BBQ Lunch")
                });

                context.MyEvents.Add(new MyEvent()
                {
                    Creator = "m",
                    CreationDate = DateTime.Now,
                    DateTimeFrom = new DateTime(2017, 4, 9, 13, 00, 0),
                    DateTimeTo = new DateTime(2017, 4, 9, 18, 00, 0),
                    IsActive = true,
                    MyActivity = context.MyActivities.FirstOrDefault(a => a.ActivityDesp == "Garage Sale")
                });


                //for privious next week
                context.MyEvents.Add(new MyEvent()
                {
                    Creator = "a",
                    CreationDate = DateTime.Now,
                    DateTimeFrom = new DateTime(2017, 3, 14, 8, 30, 0),
                    DateTimeTo = new DateTime(2017, 3, 14, 10, 30, 0),
                    IsActive = true,
                    MyActivity = context.MyActivities.FirstOrDefault(a => a.ActivityDesp == "Senior Golf Tournament")
                });
                context.MyEvents.Add(new MyEvent()
                {
                    Creator = "a",
                    CreationDate = DateTime.Now,
                    DateTimeFrom = new DateTime(2017, 3, 15, 8, 30, 0),
                    DateTimeTo = new DateTime(2017, 3, 15, 10, 30, 0),
                    IsActive = false,
                    MyActivity = context.MyActivities.FirstOrDefault(a => a.ActivityDesp == "Leadership Meeting")
                });
                context.MyEvents.Add(new MyEvent()
                {
                    Creator = "m",
                    CreationDate = DateTime.Now,
                    DateTimeFrom = new DateTime(2017, 3, 17, 17, 30, 0),
                    DateTimeTo = new DateTime(2017, 3, 17, 19, 15, 0),
                    IsActive = true,
                    MyActivity = context.MyActivities.FirstOrDefault(a => a.ActivityDesp == "Youth Bowling Tournament")
                });

                context.MyEvents.Add(new MyEvent()
                {
                    Creator = "m",
                    CreationDate = DateTime.Now,
                    DateTimeFrom = new DateTime(2017, 3, 17, 19, 00, 0),
                    DateTimeTo = new DateTime(2017, 3, 17, 20, 00, 0),
                    IsActive = true,
                    MyActivity = context.MyActivities.FirstOrDefault(a => a.ActivityDesp == "Young ladies cooking lessons")
                });

                context.MyEvents.Add(new MyEvent()
                {
                    Creator = "a",
                    CreationDate = DateTime.Now,
                    DateTimeFrom = new DateTime(2017, 3, 18, 8, 30, 0),
                    DateTimeTo = new DateTime(2017, 3, 18, 10, 30, 0),
                    IsActive = true,
                    MyActivity = context.MyActivities.FirstOrDefault(a => a.ActivityDesp == "Youth craft lessons")
                });
                context.MyEvents.Add(new MyEvent()
                {
                    Creator = "a",
                    CreationDate = DateTime.Now,
                    DateTimeFrom = new DateTime(2017, 3, 18, 10, 30, 0),
                    DateTimeTo = new DateTime(2017, 3, 18, 12, 00, 0),
                    IsActive = false,
                    MyActivity = context.MyActivities.FirstOrDefault(a => a.ActivityDesp == "Youth choir practice")
                });

                context.MyEvents.Add(new MyEvent()
                {
                    Creator = "m",
                    CreationDate = DateTime.Now,
                    DateTimeFrom = new DateTime(2017, 3, 18, 12, 00, 0),
                    DateTimeTo = new DateTime(2017, 3, 18, 13, 00, 0),
                    IsActive = true,
                    MyActivity = context.MyActivities.FirstOrDefault(a => a.ActivityDesp == "Lunch")
                });


                context.MyEvents.Add(new MyEvent()
                {
                    Creator = "a",
                    CreationDate = DateTime.Now,
                    DateTimeFrom = new DateTime(2017, 3, 19, 7, 30, 0),
                    DateTimeTo = new DateTime(2017, 3, 19, 8, 30, 0),
                    IsActive = true,
                    MyActivity = context.MyActivities.FirstOrDefault(a => a.ActivityDesp == "Pancake Breakfast")
                });
                context.MyEvents.Add(new MyEvent()
                {
                    Creator = "a",
                    CreationDate = DateTime.Now,
                    DateTimeFrom = new DateTime(2017, 3, 19, 8, 30, 0),
                    DateTimeTo = new DateTime(2017, 3, 19, 10, 30, 0),
                    IsActive = false,
                    MyActivity = context.MyActivities.FirstOrDefault(a => a.ActivityDesp == "Swimming Lessons for the youth")
                });

                context.MyEvents.Add(new MyEvent()
                {
                    Creator = "m",
                    CreationDate = DateTime.Now,
                    DateTimeFrom = new DateTime(2017, 3, 19, 08, 40, 0),
                    DateTimeTo = new DateTime(2017, 3, 19, 10, 40, 0),
                    IsActive = true,
                    MyActivity = context.MyActivities.FirstOrDefault(a => a.ActivityDesp == "Swimming Exercise for parents")
                });

                context.MyEvents.Add(new MyEvent()
                {
                    Creator = "a",
                    CreationDate = DateTime.Now,
                    DateTimeFrom = new DateTime(2017, 3, 19, 10, 30, 0),
                    DateTimeTo = new DateTime(2017, 3, 19, 12, 00, 0),
                    IsActive = true,
                    MyActivity = context.MyActivities.FirstOrDefault(a => a.ActivityDesp == "Bingo Tournament")
                });
                context.MyEvents.Add(new MyEvent()
                {
                    Creator = "a",
                    CreationDate = DateTime.Now,
                    DateTimeFrom = new DateTime(2017, 3, 19, 12, 00, 0),
                    DateTimeTo = new DateTime(2017, 3, 19, 13, 00, 0),
                    IsActive = false,
                    MyActivity = context.MyActivities.FirstOrDefault(a => a.ActivityDesp == "BBQ Lunch")
                });

                context.MyEvents.Add(new MyEvent()
                {
                    Creator = "m",
                    CreationDate = DateTime.Now,
                    DateTimeFrom = new DateTime(2017, 3, 19, 13, 00, 0),
                    DateTimeTo = new DateTime(2017, 3, 19, 18, 00, 0),
                    IsActive = true,
                    MyActivity = context.MyActivities.FirstOrDefault(a => a.ActivityDesp == "Garage Sale")
                });

                //for next next next week
                context.MyEvents.Add(new MyEvent()
                {
                    Creator = "a",
                    CreationDate = DateTime.Now,
                    DateTimeFrom = new DateTime(2017, 4, 14, 8, 30, 0),
                    DateTimeTo = new DateTime(2017, 4, 14, 10, 30, 0),
                    IsActive = true,
                    MyActivity = context.MyActivities.FirstOrDefault(a => a.ActivityDesp == "Senior Golf Tournament")
                });
                context.MyEvents.Add(new MyEvent()
                {
                    Creator = "a",
                    CreationDate = DateTime.Now,
                    DateTimeFrom = new DateTime(2017, 4, 15, 8, 30, 0),
                    DateTimeTo = new DateTime(2017, 4, 15, 10, 30, 0),
                    IsActive = false,
                    MyActivity = context.MyActivities.FirstOrDefault(a => a.ActivityDesp == "Leadership Meeting")
                });
                context.MyEvents.Add(new MyEvent()
                {
                    Creator = "m",
                    CreationDate = DateTime.Now,
                    DateTimeFrom = new DateTime(2017, 4, 17, 17, 30, 0),
                    DateTimeTo = new DateTime(2017, 4, 17, 19, 15, 0),
                    IsActive = true,
                    MyActivity = context.MyActivities.FirstOrDefault(a => a.ActivityDesp == "Youth Bowling Tournament")
                });

                context.MyEvents.Add(new MyEvent()
                {
                    Creator = "m",
                    CreationDate = DateTime.Now,
                    DateTimeFrom = new DateTime(2017, 4, 17, 19, 00, 0),
                    DateTimeTo = new DateTime(2017, 4, 17, 20, 00, 0),
                    IsActive = true,
                    MyActivity = context.MyActivities.FirstOrDefault(a => a.ActivityDesp == "Young ladies cooking lessons")
                });

                context.MyEvents.Add(new MyEvent()
                {
                    Creator = "a",
                    CreationDate = DateTime.Now,
                    DateTimeFrom = new DateTime(2017, 4, 18, 8, 30, 0),
                    DateTimeTo = new DateTime(2017, 4, 18, 10, 30, 0),
                    IsActive = true,
                    MyActivity = context.MyActivities.FirstOrDefault(a => a.ActivityDesp == "Youth craft lessons")
                });
                context.MyEvents.Add(new MyEvent()
                {
                    Creator = "a",
                    CreationDate = DateTime.Now,
                    DateTimeFrom = new DateTime(2017, 4, 18, 10, 30, 0),
                    DateTimeTo = new DateTime(2017, 4, 18, 12, 00, 0),
                    IsActive = false,
                    MyActivity = context.MyActivities.FirstOrDefault(a => a.ActivityDesp == "Youth choir practice")
                });

                context.MyEvents.Add(new MyEvent()
                {
                    Creator = "m",
                    CreationDate = DateTime.Now,
                    DateTimeFrom = new DateTime(2017, 4, 18, 12, 00, 0),
                    DateTimeTo = new DateTime(2017, 4, 18, 13, 00, 0),
                    IsActive = true,
                    MyActivity = context.MyActivities.FirstOrDefault(a => a.ActivityDesp == "Lunch")
                });


                context.MyEvents.Add(new MyEvent()
                {
                    Creator = "a",
                    CreationDate = DateTime.Now,
                    DateTimeFrom = new DateTime(2017, 4, 19, 7, 30, 0),
                    DateTimeTo = new DateTime(2017, 4, 19, 8, 30, 0),
                    IsActive = true,
                    MyActivity = context.MyActivities.FirstOrDefault(a => a.ActivityDesp == "Pancake Breakfast")
                });
                context.MyEvents.Add(new MyEvent()
                {
                    Creator = "a",
                    CreationDate = DateTime.Now,
                    DateTimeFrom = new DateTime(2017, 4, 19, 8, 30, 0),
                    DateTimeTo = new DateTime(2017, 4, 19, 10, 30, 0),
                    IsActive = false,
                    MyActivity = context.MyActivities.FirstOrDefault(a => a.ActivityDesp == "Swimming Lessons for the youth")
                });

                context.MyEvents.Add(new MyEvent()
                {
                    Creator = "m",
                    CreationDate = DateTime.Now,
                    DateTimeFrom = new DateTime(2017, 4, 19, 08, 40, 0),
                    DateTimeTo = new DateTime(2017, 4, 19, 10, 40, 0),
                    IsActive = true,
                    MyActivity = context.MyActivities.FirstOrDefault(a => a.ActivityDesp == "Swimming Exercise for parents")
                });

                context.MyEvents.Add(new MyEvent()
                {
                    Creator = "a",
                    CreationDate = DateTime.Now,
                    DateTimeFrom = new DateTime(2017, 4, 19, 10, 30, 0),
                    DateTimeTo = new DateTime(2017, 4, 19, 12, 00, 0),
                    IsActive = true,
                    MyActivity = context.MyActivities.FirstOrDefault(a => a.ActivityDesp == "Bingo Tournament")
                });
                context.MyEvents.Add(new MyEvent()
                {
                    Creator = "a",
                    CreationDate = DateTime.Now,
                    DateTimeFrom = new DateTime(2017, 4, 19, 12, 00, 0),
                    DateTimeTo = new DateTime(2017, 4, 19, 13, 00, 0),
                    IsActive = false,
                    MyActivity = context.MyActivities.FirstOrDefault(a => a.ActivityDesp == "BBQ Lunch")
                });

                context.MyEvents.Add(new MyEvent()
                {
                    Creator = "m",
                    CreationDate = DateTime.Now,
                    DateTimeFrom = new DateTime(2017, 4, 19, 13, 00, 0),
                    DateTimeTo = new DateTime(2017, 4, 19, 18, 00, 0),
                    IsActive = true,
                    MyActivity = context.MyActivities.FirstOrDefault(a => a.ActivityDesp == "Garage Sale")
                });

                context.SaveChanges();
            }

            //create roles seed data
            var roleStore = new RoleStore<IdentityRole>(context);

            string roleName = "Admin";
            if (!context.Roles.Any(role => role.Name == roleName)) {
                var newRole = new IdentityRole{Name = roleName, NormalizedName = roleName.ToUpper()};
                await roleStore.CreateAsync(newRole);
            }

            roleName = "Member";
            if (!context.Roles.Any(role => role.Name == roleName)) {
                var newRole = new IdentityRole { Name = roleName, NormalizedName = roleName.ToUpper() };
                await roleStore.CreateAsync(newRole);
            }
                
            //create users and assign user with roles
            // Add a user with username & uid of a@a.a then add to admin role
            if (!context.Users.Any(user => user.UserName == "a"))
            {
                var user = new ApplicationUser
                {
                    Email = "a@a.a",
                    UserName = "a",
                    FirstName = "a",
                    LastName = "a"
                };

                var result = await userManager.CreateAsync(user, "P@$$w0rd");
                if (result.Succeeded) {
                    var newUser = await userManager.FindByNameAsync(user.UserName);
                    if (newUser != null)
                    {
                        //add user to role
                        string[] roles = new string[] { "Admin" };
                        await AssignRoles(userManager, newUser, roles);
                    }

                }
                await context.SaveChangesAsync();
            }
            // Add a user with username & uid of am@am.am then add to admin and member roles
            if (!context.Users.Any(user => user.UserName == "am"))
            {
                var user = new ApplicationUser
                {
                    Email = "am@am.am",
                    UserName = "am",
                    FirstName = "am",
                    LastName = "am"
                };

                var result = await userManager.CreateAsync(user, "P@$$w0rd");
                if (result.Succeeded)
                {
                    var newUser = await userManager.FindByNameAsync(user.UserName);
                    if (newUser != null)
                    {
                        //add user to role
                        string[] roles = new string[] { "Admin", "Member" };
                        await AssignRoles(userManager, newUser, roles);
                    }

                }
                await context.SaveChangesAsync();
            }

            // Add a user with username & uid of m@m.m then add to member role
            if (!context.Users.Any(user => user.UserName == "m"))
            {
                var user = new ApplicationUser
                {
                    Email = "m@m.m",
                    UserName = "m",
                    FirstName = "m",
                    LastName = "m"
                };
                
                var result = await userManager.CreateAsync(user, "P@$$w0rd");
                if (result.Succeeded)
                {
                    var newUser = await userManager.FindByNameAsync(user.UserName);
                    if (newUser != null)
                    {
                        string[] roles = new string[] { "Member" };
                        await AssignRoles(userManager, newUser, roles);
                    }
                }
                await context.SaveChangesAsync();
            }

        }

        public static async Task<IdentityResult> AssignRoles(UserManager<ApplicationUser> userManager, ApplicationUser user, string[] roles)
        {
            var result = await userManager.AddToRolesAsync(user, roles);
            return result;
        }

    }
}
