using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RailwayReservationSystem.Models;

namespace RailwayReservationSystem.Controllers
{
    public class BookingController : Controller
    {
        // GET: Booking
        public ActionResult Search()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Search(Search model)
        {
            using (var context = new RailwayReservationSystemEntities())
            {
                /* var validation = from t in context.Train_Details
                                  join s in context.Station on t.Train_No equals s.Train_No
                                  select new { t.Source, s.Stn_Name };*/
                if (context.Train_Details.Any(x => x.Source == model.Source && x.Destination == model.Destination && x.Start_Date == model.Doj) || context.Station.Any(y => y.Stn_Name == model.Source && y.Stn_Name==model.Destination))
                {

                    return RedirectToAction("PassengerDetails", "Book Now");
                }
                else
                {
                    ModelState.AddModelError("", "Enter Correct Details");
                        return View();
                    
                }
            }
        }
    }
}