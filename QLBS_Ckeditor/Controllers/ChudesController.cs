using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Quanlybansach.Models;

namespace Quanlybansach.Controllers
{
    public class ChudesController : Controller
    {
        private QLBSDBcontext db = new QLBSDBcontext();

        // GET: Chudes
        public ActionResult Index()
        {
            return View(db.Chudes.ToList());
        }

        // GET: Chudes/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Chude chude = db.Chudes.Find(id);
            if (chude == null)
            {
                return HttpNotFound();
            }
            return View(chude);
        }

        // GET: Chudes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Chudes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "machude,tenchude")] Chude chude)
        {
            if (ModelState.IsValid)
            {
                db.Chudes.Add(chude);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(chude);
        }

        // GET: Chudes/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Chude chude = db.Chudes.Find(id);
            if (chude == null)
            {
                return HttpNotFound();
            }
            return View(chude);
        }

        // POST: Chudes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "machude,tenchude")] Chude chude)
        {
            if (ModelState.IsValid)
            {
                db.Entry(chude).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(chude);
        }

        // GET: Chudes/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Chude chude = db.Chudes.Find(id);
            if (chude == null)
            {
                return HttpNotFound();
            }
            return View(chude);
        }

        // POST: Chudes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Chude chude = db.Chudes.Find(id);
            db.Chudes.Remove(chude);
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
