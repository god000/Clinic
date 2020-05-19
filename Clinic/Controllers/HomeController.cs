using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ClinicStorage;
using ClinicStorage.Models;

namespace Clinic.Controllers
{
    public class HomeController : Controller
    {
        ClinicService service = new ClinicService();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult AddResult()
        {
            IEnumerable<Visitor> visitors = service.GetVisitors();
            return View(visitors);
        }

        public ActionResult Registration()
        {
            IEnumerable<Doctor> doctors = service.GetDoctors();
            return View(doctors);
        }

        [HttpGet]
        public ActionResult MakeAppointment(int? id)
        {
            Doctor doctor = service.GetDoctor(Convert.ToInt32(id));
            TimeTable sheldure = service.GetDoctorSheldure(Convert.ToInt32(id));


            List<Visitor> visitors = service.GetVisitors();
            string today = System.DateTime.Today.Date.ToString().Split(' ')[0];
            List<string> freeTimes = service.times;
            int begin = freeTimes.FindIndex(x => x == sheldure.TimeStart);
            int count = freeTimes.FindIndex(x=>x==sheldure.TimeEnd) - begin + 1;
            freeTimes = freeTimes.GetRange(begin, count);
            if(visitors.Count>0)
            {
                foreach(var v in visitors)
                {
                    if (v.Date == today) freeTimes.Remove(v.Time);
                }
            }

            SelectList times = new SelectList(freeTimes);

            Visitor newVisitor = new Visitor();
            newVisitor.Doctor = doctor;
            newVisitor.Date = today;

            ViewBag.FreeTimes = times;

            return View(newVisitor);
        }

        [HttpPost]
        public ActionResult MakeAppointment(Visitor visitor)
        {
            service.AddVisitor(visitor);
            return RedirectToAction("Index");
        }

        public ActionResult Sheldure()
        {
            List<TimeTable> list = service.GetTimeTable();
            return View(list);
        }
        [HttpGet]
        public ActionResult ChangeSheldure(int? id)
        {
            TimeTable sheldure = service.GetSheldure(Convert.ToInt32(id));

            List<string> freeTimes = service.times;
            SelectList times = new SelectList(freeTimes);
            SelectList visitTimes = new SelectList(ViewBag.VisitTimes = service.visitTimes);

            ViewBag.FreeTimes = times;
            ViewBag.VisitTimes = visitTimes;

            return View(sheldure);
        }
        [HttpPost]
        public ActionResult ChangeSheldure(TimeTable sheldure)
        {
            service.ChangeSheldure(sheldure);
            return RedirectToAction("Sheldure");
        }



        public ActionResult AddDoctor()
        {
            var p = service.GetPositions();
            SelectList positions = new SelectList(p, "Id", "Name");
            ViewBag.Positions = positions;

            return View();
        }
        [HttpPost]
        public ActionResult AddDoctor(Doctor doctor)
        {
            service.AddDoctor(doctor);
            return RedirectToAction("Index");
        }

        public ActionResult AddComment(int? id)
        {
            Visitor visitor = service.GetVisitor(Convert.ToInt32(id));

            return View(visitor);
        }
        [HttpPost]
        public ActionResult AddComment(Visitor visitor)
        {
            service.SetVisitorInfo(visitor);
            return RedirectToAction("Index");
        }
    }
}