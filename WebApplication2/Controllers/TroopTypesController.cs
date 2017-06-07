using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DataAccess;

namespace WebApplication2.Controllers
{
    public class TroopTypesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: TroopTypes
        public ActionResult Index()
        {
            return View(db.TroopTypes.ToList());
        }

        // GET: TroopTypes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TroopType troopType = db.TroopTypes.Find(id);
            if (troopType == null)
            {
                return HttpNotFound();
            }
            return View(troopType);
        }

        // GET: TroopTypes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TroopTypes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "TroopTypeId,Name,Attack,Defence,CreationSpeed")] TroopType troopType)
        {
            if (ModelState.IsValid)
            {
                db.TroopTypes.Add(troopType);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(troopType);
        }

        // GET: TroopTypes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TroopType troopType = db.TroopTypes.Find(id);
            if (troopType == null)
            {
                return HttpNotFound();
            }
            return View(troopType);
        }

        // POST: TroopTypes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "TroopTypeId,Name,Attack,Defence,CreationSpeed")] TroopType troopType)
        {
            if (ModelState.IsValid)
            {
                db.Entry(troopType).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(troopType);
        }

        // GET: TroopTypes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TroopType troopType = db.TroopTypes.Find(id);
            if (troopType == null)
            {
                return HttpNotFound();
            }
            return View(troopType);
        }

        // POST: TroopTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TroopType troopType = db.TroopTypes.Find(id);
            db.TroopTypes.Remove(troopType);
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
