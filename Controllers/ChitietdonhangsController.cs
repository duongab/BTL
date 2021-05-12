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
    public class ChitietdonhangsController : Controller
    {
        private QLBSDBcontext db = new QLBSDBcontext();

        [AllowAnonymous]
        // GET: Chitietdonhangs
        public ActionResult Index()
        {
            var chitietdonhangs = db.Chitietdonhangs.Include(c => c.Donhang).Include(c => c.Sach);
            return View(chitietdonhangs.ToList());
        }

        // GET: Chitietdonhangs/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Chitietdonhang chitietdonhang = db.Chitietdonhangs.Find(id);
            if (chitietdonhang == null)
            {
                return HttpNotFound();
            }
            return View(chitietdonhang);
        }

        [Authorize(Roles ="Chitietdonhang1,Chitietdonhang2")]
        // GET: Chitietdonhangs/Create
        public ActionResult Create()
        {
            ViewBag.madh = new SelectList(db.Donhangs, "madh", "tinhtrangdonhang");
            ViewBag.masach = new SelectList(db.Sachs, "masach", "tensach");
            return View();
        }

        // POST: Chitietdonhangs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "soluong,dongia,madh,masach")] Chitietdonhang chitietdonhang)
        {
            if (ModelState.IsValid)
            {
                db.Chitietdonhangs.Add(chitietdonhang);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.madh = new SelectList(db.Donhangs, "madh", "tinhtrangdonhang", chitietdonhang.madh);
            ViewBag.masach = new SelectList(db.Sachs, "masach", "tensach", chitietdonhang.masach);
            return View(chitietdonhang);
        }

        // GET: Chitietdonhangs/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Chitietdonhang chitietdonhang = db.Chitietdonhangs.Find(id);
            if (chitietdonhang == null)
            {
                return HttpNotFound();
            }
            ViewBag.madh = new SelectList(db.Donhangs, "madh", "tinhtrangdonhang", chitietdonhang.madh);
            ViewBag.masach = new SelectList(db.Sachs, "masach", "tensach", chitietdonhang.masach);
            return View(chitietdonhang);
        }

        // POST: Chitietdonhangs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "soluong,dongia,madh,masach")] Chitietdonhang chitietdonhang)
        {
            if (ModelState.IsValid)
            {
                db.Entry(chitietdonhang).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.madh = new SelectList(db.Donhangs, "madh", "tinhtrangdonhang", chitietdonhang.madh);
            ViewBag.masach = new SelectList(db.Sachs, "masach", "tensach", chitietdonhang.masach);
            return View(chitietdonhang);
        }

        // GET: Chitietdonhangs/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Chitietdonhang chitietdonhang = db.Chitietdonhangs.Find(id);
            if (chitietdonhang == null)
            {
                return HttpNotFound();
            }
            return View(chitietdonhang);
        }

        // POST: Chitietdonhangs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Chitietdonhang chitietdonhang = db.Chitietdonhangs.Find(id);
            db.Chitietdonhangs.Remove(chitietdonhang);
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
