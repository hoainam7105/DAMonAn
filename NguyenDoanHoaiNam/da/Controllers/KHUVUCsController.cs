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
    public class KHUVUCsController : Controller
    {
        private DAamthucEntities db = new DAamthucEntities();

        // GET: KHUVUCs
        public ActionResult Index()
        {
            return View(db.KHUVUCs.ToList());
        }

        // GET: KHUVUCs/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            KHUVUC kHUVUC = db.KHUVUCs.Find(id);
            if (kHUVUC == null)
            {
                return HttpNotFound();
            }
            return View(kHUVUC);
        }

        // GET: KHUVUCs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: KHUVUCs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Mã_khu_vực,Tên_khu_vực")] KHUVUC kHUVUC)
        {
            if (ModelState.IsValid)
            {
                db.KHUVUCs.Add(kHUVUC);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(kHUVUC);
        }

        // GET: KHUVUCs/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            KHUVUC kHUVUC = db.KHUVUCs.Find(id);
            if (kHUVUC == null)
            {
                return HttpNotFound();
            }
            return View(kHUVUC);
        }

        // POST: KHUVUCs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Mã_khu_vực,Tên_khu_vực")] KHUVUC kHUVUC)
        {
            if (ModelState.IsValid)
            {
                db.Entry(kHUVUC).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(kHUVUC);
        }

        // GET: KHUVUCs/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            KHUVUC kHUVUC = db.KHUVUCs.Find(id);
            if (kHUVUC == null)
            {
                return HttpNotFound();
            }
            return View(kHUVUC);
        }

        // POST: KHUVUCs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            KHUVUC kHUVUC = db.KHUVUCs.Find(id);
            db.KHUVUCs.Remove(kHUVUC);
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
