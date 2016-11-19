using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CoffeShop.Models;

namespace CoffeShop.Controllers
{
    public class CoffeController : Controller
    {
        private CoffeshopContext db = new CoffeshopContext();

        // GET: /Coffe/
        public ActionResult Index()
        {
            var coffes = db.Coffes.Include(c => c.Company);
            return View(coffes.ToList());
        }

        // GET: /Coffe/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Coffe coffe = db.Coffes.Find(id);
            if (coffe == null)
            {
                return HttpNotFound();
            }
            return View(coffe);
        }

        // GET: /Coffe/Create
        public ActionResult Create()
        {
            ViewBag.CompanyId = new SelectList(db.Companies, "Id", "CompanyName");
            return View();
        }

        // POST: /Coffe/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="Id,Name,Volume,CompanyId")] Coffe coffe)
        {
            if (ModelState.IsValid)
            {
                db.Coffes.Add(coffe);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CompanyId = new SelectList(db.Companies, "Id", "CompanyName", coffe.CompanyId);
            return View(coffe);
        }

        // GET: /Coffe/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Coffe coffe = db.Coffes.Find(id);
            if (coffe == null)
            {
                return HttpNotFound();
            }
            ViewBag.CompanyId = new SelectList(db.Companies, "Id", "CompanyName", coffe.CompanyId);
            return View(coffe);
        }

        // POST: /Coffe/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="Id,Name,Volume,CompanyId")] Coffe coffe)
        {
            if (ModelState.IsValid)
            {
                db.Entry(coffe).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CompanyId = new SelectList(db.Companies, "Id", "CompanyName", coffe.CompanyId);
            return View(coffe);
        }

        // GET: /Coffe/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Coffe coffe = db.Coffes.Find(id);
            if (coffe == null)
            {
                return HttpNotFound();
            }
            return View(coffe);
        }

        // POST: /Coffe/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Coffe coffe = db.Coffes.Find(id);
            db.Coffes.Remove(coffe);
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
