using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MovieCat_HTML2.Models;

namespace MovieCat_HTML2.Controllers
{
    public class KatalogsController : Controller
    {
        private KatalogDb db = new KatalogDb();

        // GET: Katalogs
        public ActionResult Index(string searchTerm=null)
        {
            var model =
                db.Katalogs
                .Where(r => searchTerm == null|| r.Name.StartsWith(searchTerm)|| r.Genere.StartsWith(searchTerm))
                .Select(r => new KatalogListV
                {
                    Id = r.Id,
                    Name = r.Name,
                    Genere = r.Genere,
                    Director = r.Director,
                    RealeseDate = r.RealeseDate.ToString()
                }
                );







            return View(model);
        }

        // GET: Katalogs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Katalog katalog = db.Katalogs.Find(id);
            if (katalog == null)
            {
                return HttpNotFound();
            }
            return View(katalog);
        }

        // GET: Katalogs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Katalogs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Genere,Director,RealeseDate")] Katalog katalog)
        {
            if (ModelState.IsValid)
            {
                db.Katalogs.Add(katalog);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(katalog);
        }

        // GET: Katalogs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Katalog katalog = db.Katalogs.Find(id);
            if (katalog == null)
            {
                return HttpNotFound();
            }
            return View(katalog);
        }

        // POST: Katalogs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Genere,Director,RealeseDate")] Katalog katalog)
        {
            if (ModelState.IsValid)
            {
                db.Entry(katalog).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(katalog);
        }

        // GET: Katalogs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Katalog katalog = db.Katalogs.Find(id);
            if (katalog == null)
            {
                return HttpNotFound();
            }
            return View(katalog);
        }

        // POST: Katalogs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Katalog katalog = db.Katalogs.Find(id);
            db.Katalogs.Remove(katalog);
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

    internal class KataloglistV
    {
        public string Director { get; set; }
        public string Genere { get; set; }
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime RealeseDate { get; set; }
    }
}
