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
    public class NhaxuatbansController : Controller
    {
        private QLBSDBcontext db = new QLBSDBcontext();

        // GET: Nhaxuatbans
        public ActionResult Index()
        {
            return View(db.Nhaxuatbans.ToList());
        }

        // GET: Nhaxuatbans/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Nhaxuatban nhaxuatban = db.Nhaxuatbans.Find(id);
            if (nhaxuatban == null)
            {
                return HttpNotFound();
            }
            return View(nhaxuatban);
        }

        // GET: Nhaxuatbans/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Nhaxuatbans/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "manxb,tennxb,diachi,dienthoai")] Nhaxuatban nhaxuatban)
        {
            if (ModelState.IsValid)
            {
                db.Nhaxuatbans.Add(nhaxuatban);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(nhaxuatban);
        }

        // GET: Nhaxuatbans/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Nhaxuatban nhaxuatban = db.Nhaxuatbans.Find(id);
            if (nhaxuatban == null)
            {
                return HttpNotFound();
            }
            return View(nhaxuatban);
        }

        // POST: Nhaxuatbans/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "manxb,tennxb,diachi,dienthoai")] Nhaxuatban nhaxuatban)
        {
            if (ModelState.IsValid)
            {
                db.Entry(nhaxuatban).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(nhaxuatban);
        }

        // GET: Nhaxuatbans/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Nhaxuatban nhaxuatban = db.Nhaxuatbans.Find(id);
            if (nhaxuatban == null)
            {
                return HttpNotFound();
            }
            return View(nhaxuatban);
        }

        // POST: Nhaxuatbans/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Nhaxuatban nhaxuatban = db.Nhaxuatbans.Find(id);
            db.Nhaxuatbans.Remove(nhaxuatban);
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
