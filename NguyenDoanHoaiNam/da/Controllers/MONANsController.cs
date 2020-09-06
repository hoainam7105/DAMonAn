using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using da.Models;

namespace da.Controllers
{
    public class MONANsController : Controller
    {
        private DAamthucEntities db = new DAamthucEntities();

        // GET: MONANs
        public ActionResult Index()
        {
            var mONANs = db.MONANs.Include(m => m.TINH_THANH);
            return View(mONANs.ToList());
        }

        // GET: MONANs/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MONAN mONAN = db.MONANs.Find(id);
            if (mONAN == null)
            {
                return HttpNotFound();
            }
            return View(mONAN);
        }

        // GET: MONANs/Create
        public ActionResult Create()
        {
            ViewBag.Mã_tỉnh_thành = new SelectList(db.TINH_THANH, "Mã_tỉnh_thành", "Tên_tỉnh_thành");
            return View();
        }

        // POST: MONANs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Mã_món,Tên_món_ăn,công_thức,Mã_tỉnh_thành")] MONAN mONAN)
        {
            if (ModelState.IsValid)
            {
                db.MONANs.Add(mONAN);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Mã_tỉnh_thành = new SelectList(db.TINH_THANH, "Mã_tỉnh_thành", "Tên_tỉnh_thành", mONAN.Mã_tỉnh_thành);
            return View(mONAN);
        }

        // GET: MONANs/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MONAN mONAN = db.MONANs.Find(id);
            if (mONAN == null)
            {
                return HttpNotFound();
            }
            ViewBag.Mã_tỉnh_thành = new SelectList(db.TINH_THANH, "Mã_tỉnh_thành", "Tên_tỉnh_thành", mONAN.Mã_tỉnh_thành);
            return View(mONAN);
        }

        // POST: MONANs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Mã_món,Tên_món_ăn,công_thức,Mã_tỉnh_thành")] MONAN mONAN)
        {
            if (ModelState.IsValid)
            {
                db.Entry(mONAN).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Mã_tỉnh_thành = new SelectList(db.TINH_THANH, "Mã_tỉnh_thành", "Tên_tỉnh_thành", mONAN.Mã_tỉnh_thành);
            return View(mONAN);
        }

        // GET: MONANs/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MONAN mONAN = db.MONANs.Find(id);
            if (mONAN == null)
            {
                return HttpNotFound();
            }
            return View(mONAN);
        }

        // POST: MONANs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            MONAN mONAN = db.MONANs.Find(id);
            db.MONANs.Remove(mONAN);
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
