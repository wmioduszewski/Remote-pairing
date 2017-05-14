﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CodeMate.WebApp.Controllers
{
    using Models;

    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetEvents(DateTime start, DateTime end)
        {
            //var fromDate = ConvertFromUnixTimestamp(start);
            //var toDate = ConvertFromUnixTimestamp(end);

            //Get the events
            //You may get from the repository also
            var eventList = GetEvents();

            var rows = eventList.ToArray();
            return Json(rows, JsonRequestBehavior.AllowGet);
        }

        private List<CalendarEvent> GetEvents()
        {
            var eventList = new List<CalendarEvent>();

            for (int i = 1; i <= 2; i++)
            {
                CalendarEvent newEvent = new CalendarEvent
                {
                    Id = i.ToString(),
                    Title = $"Event {i}",
                    Start = DateTime.Now.AddDays(i).AddMinutes(i*30).ToString("s"),
                    End = DateTime.Now.AddDays(i).AddMinutes(i*30 + 30).ToString("s"),                    
                    AllDay = false
                };
                eventList.Add(newEvent);
            }
            
            return eventList;
        }

        private static DateTime ConvertFromUnixTimestamp(double timestamp)
        {
            var origin = new DateTime(1970, 1, 1, 0, 0, 0, 0);
            return origin.AddSeconds(timestamp);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}