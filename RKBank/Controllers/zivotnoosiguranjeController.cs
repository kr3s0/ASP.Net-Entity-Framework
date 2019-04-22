using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using RKBank;

namespace RKBank.Controllers
{
    public class zivotnoosiguranjeController : Controller
    {
        private RKBankDBModel db = new RKBankDBModel();

        // GET: zivotnoosiguranje
        public ActionResult Index()
        {
            if (!User.Identity.IsAuthenticated)
            {
                Response.Redirect("~/Login.aspx");
            }
            var zivotnoosiguranje = db.zivotnoosiguranje.Include(z => z.klijent).Include(z => z.osiguranje);
            if (!User.Identity.Name.Equals("Admin")) {
                return View("Index403", zivotnoosiguranje.ToList());
            }
            return View(zivotnoosiguranje.ToList());
        }

        // GET: zivotnoosiguranje/Details/5
        public ActionResult Details(int? id)
        {
            if (!User.Identity.IsAuthenticated)
            {
                Response.Redirect("~/Login.aspx");
            }
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            zivotnoosiguranje zivotnoosiguranje = db.zivotnoosiguranje.Find(id);
            if (zivotnoosiguranje == null)
            {
                return HttpNotFound();
            }
            if (!User.Identity.Name.Equals("Admin"))
            {
                return View("Details403", zivotnoosiguranje);
            }
            return View(zivotnoosiguranje);
        }

        // GET: zivotnoosiguranje/Create
        public ActionResult Create()
        {
            if (!User.Identity.IsAuthenticated)
            {
                Response.Redirect("~/Login.aspx");
            }
            if (!User.Identity.Name.Equals("Admin"))
            {
                return new HttpStatusCodeResult(HttpStatusCode.Forbidden);
            }
            ViewBag.JMBG = new SelectList(db.klijent, "JMBG", "Ime");
            ViewBag.OsiguranjeID = new SelectList(db.osiguranje, "ID", "JMBG");
            return View();
        }

        // POST: zivotnoosiguranje/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,OsiguranjeID,JMBG,DatumPocetka,DatumZavrsetka,Status,Izlozenost")] zivotnoosiguranje zivotnoosiguranje)
        {
            if (!User.Identity.IsAuthenticated)
            {
                Response.Redirect("~/Login.aspx");
            }
            if (!User.Identity.Name.Equals("Admin"))
            {
                return new HttpStatusCodeResult(HttpStatusCode.Forbidden);
            }
            if (ModelState.IsValid)
            {
                db.zivotnoosiguranje.Add(zivotnoosiguranje);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.JMBG = new SelectList(db.klijent, "JMBG", "Ime", zivotnoosiguranje.JMBG);
            ViewBag.OsiguranjeID = new SelectList(db.osiguranje, "ID", "JMBG", zivotnoosiguranje.OsiguranjeID);
            return View(zivotnoosiguranje);
        }

        // GET: zivotnoosiguranje/Edit/5
        public ActionResult Edit(int? id)
        {
            if (!User.Identity.IsAuthenticated)
            {
                Response.Redirect("~/Login.aspx");
            }
            if (!User.Identity.Name.Equals("Admin"))
            {
                return new HttpStatusCodeResult(HttpStatusCode.Forbidden);
            }
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            zivotnoosiguranje zivotnoosiguranje = db.zivotnoosiguranje.Find(id);
            if (zivotnoosiguranje == null)
            {
                return HttpNotFound();
            }
            ViewBag.JMBG = new SelectList(db.klijent, "JMBG", "Ime", zivotnoosiguranje.JMBG);
            ViewBag.OsiguranjeID = new SelectList(db.osiguranje, "ID", "JMBG", zivotnoosiguranje.OsiguranjeID);
            return View(zivotnoosiguranje);
        }

        // POST: zivotnoosiguranje/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,OsiguranjeID,JMBG,DatumPocetka,DatumZavrsetka,Status,Izlozenost")] zivotnoosiguranje zivotnoosiguranje)
        {
            if (!User.Identity.IsAuthenticated)
            {
                Response.Redirect("~/Login.aspx");
            }
            if (!User.Identity.Name.Equals("Admin"))
            {
                return new HttpStatusCodeResult(HttpStatusCode.Forbidden);
            }
            if (ModelState.IsValid)
            {
                db.Entry(zivotnoosiguranje).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.JMBG = new SelectList(db.klijent, "JMBG", "Ime", zivotnoosiguranje.JMBG);
            ViewBag.OsiguranjeID = new SelectList(db.osiguranje, "ID", "JMBG", zivotnoosiguranje.OsiguranjeID);
            return View(zivotnoosiguranje);
        }

        // GET: zivotnoosiguranje/Delete/5
        public ActionResult Delete(int? id)
        {
            if (!User.Identity.IsAuthenticated)
            {
                Response.Redirect("~/Login.aspx");
            }
            if (!User.Identity.Name.Equals("Admin"))
            {
                return new HttpStatusCodeResult(HttpStatusCode.Forbidden);
            }
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            zivotnoosiguranje zivotnoosiguranje = db.zivotnoosiguranje.Find(id);
            if (zivotnoosiguranje == null)
            {
                return HttpNotFound();
            }
            return View(zivotnoosiguranje);
        }

        // POST: zivotnoosiguranje/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            if (!User.Identity.IsAuthenticated)
            {
                Response.Redirect("~/Login.aspx");
            }
            if (!User.Identity.Name.Equals("Admin"))
            {
                return new HttpStatusCodeResult(HttpStatusCode.Forbidden);
            }
            zivotnoosiguranje zivotnoosiguranje = db.zivotnoosiguranje.Find(id);
            db.zivotnoosiguranje.Remove(zivotnoosiguranje);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (!User.Identity.IsAuthenticated)
            {
                Response.Redirect("~/Login.aspx");
            }
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
