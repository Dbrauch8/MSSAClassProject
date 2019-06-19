using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CourseProjectReboot2.Models;

namespace CourseProjectReboot2.Controllers
{
    public class CatchDatasController : Controller
    {
        private CourseProjectEntities db = new CourseProjectEntities();

        // GET: CatchDatas
        public ActionResult Index()
        {
            return View(db.CatchDatas.ToList());
        }

        // GET: CatchDatas/Details/5
        public ActionResult Details(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CatchData catchData = db.CatchDatas.Find(id);
            if (catchData == null)
            {
                return HttpNotFound();
            }
            return View(catchData);
        }

        // GET: CatchDatas/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CatchDatas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Date,FishName,weight,Bait,BaitColor")] CatchData catchData)
        {
            if (ModelState.IsValid)
            {
                db.CatchDatas.Add(catchData);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(catchData);
        }

        // GET: CatchDatas/Edit/5
        public ActionResult Edit(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CatchData catchData = db.CatchDatas.Find(id);
            if (catchData == null)
            {
                return HttpNotFound();
            }
            return View(catchData);
        }

        // POST: CatchDatas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Date,FishName,weight,Bait,BaitColor")] CatchData catchData)
        {
            if (ModelState.IsValid)
            {
                db.Entry(catchData).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(catchData);
        }

        // GET: CatchDatas/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CatchData catchData = db.CatchDatas.Find(id);
            if (catchData == null)
            {
                return HttpNotFound();
            }
            return View(catchData);
        }

        // POST: CatchDatas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CatchData catchData = db.CatchDatas.Find(id);
            db.CatchDatas.Remove(catchData);
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
