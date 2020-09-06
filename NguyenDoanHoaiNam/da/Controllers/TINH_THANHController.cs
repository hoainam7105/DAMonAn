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
    public class TINH_THANHController : Controller
    {
        private DAamthucEntities db = new DAamthucEntities();

        // GET: TINH_THANH
        public ActionResult Index()
        {
            var tINH_THANH = db.TINH_THANH.Include(t => t.KHUVUC);
            return View(tINH_THANH.ToList());
        }

        // GET: TINH_THANH/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TINH_THANH tINH_THANH = db.TINH_THANH.Find(id);
            if (tINH_THANH == null)
            {
                return HttpNotFound();
            }
            return View(tINH_THANH);
        }

        // GET: TINH_THANH/Create
        public ActionResult Create()
        {
            ViewBag.Mã_khu_vực = new SelectList(db.KHUVUCs, "Mã_khu_vực", "Tên_khu_vực");
            return View();
        }

        // POST: TINH_THANH/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Mã_tỉnh_thành,Tên_tỉnh_thành,Mã_khu_vực")] TINH_THANH tINH_THANH)
        {
            if (ModelState.IsValid)
            {
                db.TINH_THANH.Add(tINH_THANH);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Mã_khu_vực = new SelectList(db.KHUVUCs, "Mã_khu_vực", "Tên_khu_vực", tINH_THANH.Mã_khu_vực);
            return View(tINH_THANH);
        }

        // GET: TINH_THANH/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TINH_THANH tINH_THANH = db.TINH_THANH.Find(id);
            if (tINH_THANH == null)
            {
                return HttpNotFound();
            }
            ViewBag.Mã_khu_vực = new SelectList(db.KHUVUCs, "Mã_khu_vực", "Tên_khu_vực", tINH_THANH.Mã_khu_vực);
            return View(tINH_THANH);
        }

        // POST: TINH_THANH/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Mã_tỉnh_thành,Tên_tỉnh_thành,Mã_khu_vực")] TINH_THANH tINH_THANH)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tINH_THANH).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Mã_khu_vực = new SelectList(db.KHUVUCs, "Mã_khu_vực", "Tên_khu_vực", tINH_THANH.Mã_khu_vực);
            return View(tINH_THANH);
        }

        // GET: TINH_THANH/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TINH_THANH tINH_THANH = db.TINH_THANH.Find(id);
            if (tINH_THANH == null)
            {
                return HttpNotFound();
            }
            return View(tINH_THANH);
        }

        // POST: TINH_THANH/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            TINH_THANH tINH_THANH = db.TINH_THANH.Find(id);
            db.TINH_THANH.Remove(tINH_THANH);
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
