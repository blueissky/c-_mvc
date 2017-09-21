using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Mvc_db.Models;

namespace WebApplication8.Controllers
{
    public class GirlsController : Controller
    {
        private GirlDbContext db = new GirlDbContext();

        // GET: Girls
        public ActionResult Index()
        {
            return View(db.girls.ToList());
        }

        // GET: Girls/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Girl girl = db.girls.Find(id);
            if (girl == null)
            {
                return HttpNotFound();
            }
            return View(girl);
        }

        // GET: Girls/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Girls/Create
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性，有关 
        // 详细信息，请参阅 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Name,Gender,Major,EntranceDate")] Girl girl)
        {
            if (ModelState.IsValid)
            {
                db.girls.Add(girl);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(girl);
        }

        // GET: Girls/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Girl girl = db.girls.Find(id);
            if (girl == null)
            {
                return HttpNotFound();
            }
            return View(girl);
        }

        // POST: Girls/Edit/5
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性，有关 
        // 详细信息，请参阅 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Name,Gender,Major,EntranceDate")] Girl girl)
        {
            if (ModelState.IsValid)
            {
                db.Entry(girl).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(girl);
        }

        // GET: Girls/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Girl girl = db.girls.Find(id);
            if (girl == null)
            {
                return HttpNotFound();
            }
            return View(girl);
        }

        // POST: Girls/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Girl girl = db.girls.Find(id);
            db.girls.Remove(girl);
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
