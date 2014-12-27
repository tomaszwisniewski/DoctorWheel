using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DoctorWheel.Models;
using DoctorWheel.DAL;

namespace DoctorWheel.Controllers
{
    public class CarController : Controller
    {
        private DataBaseContext db = new DataBaseContext();

        // GET: /Car/
        public ActionResult Index()
        {
            var cars = db.Cars.Include(c => c.Client).Include(c => c.Department);
            return View(cars.ToList());
        }

        // GET: /Car/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Car car = db.Cars.Find(id);
            if (car == null)
            {
                return HttpNotFound();
            }
            return View(car);
        }

        // GET: /Car/Create
        public ActionResult Create()
        {
            ViewBag.ClientID = new SelectList(db.Clients, "ClientID", "FirstName");
            ViewBag.DepartmentID = new SelectList(db.Departments, "ID", "TownName");
            return View();
        }

        // POST: /Car/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="ID,DepartmentID,ClientID,Make,Model,Year,LicensePlate,Color,InService,ToSell,FaultName,RepairPrecentage,Price,IsOrdered")] Car car)
        {
            if (ModelState.IsValid)
            {
                db.Cars.Add(car);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ClientID = new SelectList(db.Clients, "ClientID", "FirstName", car.ClientID);
            ViewBag.DepartmentID = new SelectList(db.Departments, "ID", "TownName", car.DepartmentID);
            return View(car);
        }

        // GET: /Car/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Car car = db.Cars.Find(id);
            if (car == null)
            {
                return HttpNotFound();
            }
            ViewBag.ClientID = new SelectList(db.Clients, "ClientID", "FirstName", car.ClientID);
            ViewBag.DepartmentID = new SelectList(db.Departments, "ID", "TownName", car.DepartmentID);
            return View(car);
        }

        // POST: /Car/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="ID,DepartmentID,ClientID,Make,Model,Year,LicensePlate,Color,InService,ToSell,FaultName,RepairPrecentage,Price,IsOrdered")] Car car)
        {
            if (ModelState.IsValid)
            {
                db.Entry(car).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ClientID = new SelectList(db.Clients, "ClientID", "FirstName", car.ClientID);
            ViewBag.DepartmentID = new SelectList(db.Departments, "ID", "TownName", car.DepartmentID);
            return View(car);
        }

        // GET: /Car/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Car car = db.Cars.Find(id);
            if (car == null)
            {
                return HttpNotFound();
            }
            return View(car);
        }

        // POST: /Car/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Car car = db.Cars.Find(id);
            db.Cars.Remove(car);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
