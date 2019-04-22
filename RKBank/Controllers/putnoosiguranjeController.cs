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
    public class putnoosiguranjeController : Controller
    {
        private RKBankDBModel db = new RKBankDBModel();

        // GET: putnoosiguranje
        public ActionResult Index()
        {
            if (!User.Identity.IsAuthenticated)
            {
                Response.Redirect("~/Login.aspx");
            }
            var putnoosiguranje = db.putnoosiguranje.Include(p => p.klijent).Include(p => p.osiguranje);
            if (!User.Identity.Name.Equals("Admin")) {
                return View("Index403", putnoosiguranje.ToList());
            }
            return View(putnoosiguranje.ToList());
        }

        // GET: putnoosiguranje/Details/5
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
            putnoosiguranje putnoosiguranje = db.putnoosiguranje.Find(id);
            if (putnoosiguranje == null)
            {
                return HttpNotFound();
            }
            if (!User.Identity.Name.Equals("Admin"))
            {
                return View("Details403", putnoosiguranje);
            }
            return View(putnoosiguranje);
        }

        // GET: putnoosiguranje/Create
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

        // POST: putnoosiguranje/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,OsiguranjeID,JMBG,DatumPocetka,DatumZavrsetka,Status,Izlozenost")] putnoosiguranje putnoosiguranje)
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
                db.putnoosiguranje.Add(putnoosiguranje);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.JMBG = new SelectList(db.klijent, "JMBG", "Ime", putnoosiguranje.JMBG);
            ViewBag.OsiguranjeID = new SelectList(db.osiguranje, "ID", "JMBG", putnoosiguranje.OsiguranjeID);
            return View(putnoosiguranje);
        }

        // GET: putnoosiguranje/Edit/5
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
            putnoosiguranje putnoosiguranje = db.putnoosiguranje.Find(id);
            if (putnoosiguranje == null)
            {
                return HttpNotFound();
            }
            ViewBag.JMBG = new SelectList(db.klijent, "JMBG", "Ime", putnoosiguranje.JMBG);
            ViewBag.OsiguranjeID = new SelectList(db.osiguranje, "ID", "JMBG", putnoosiguranje.OsiguranjeID);
            return View(putnoosiguranje);
        }

        // POST: putnoosiguranje/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,OsiguranjeID,JMBG,DatumPocetka,DatumZavrsetka,Status,Izlozenost")] putnoosiguranje putnoosiguranje)
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
                db.Entry(putnoosiguranje).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.JMBG = new SelectList(db.klijent, "JMBG", "Ime", putnoosiguranje.JMBG);
            ViewBag.OsiguranjeID = new SelectList(db.osiguranje, "ID", "JMBG", putnoosiguranje.OsiguranjeID);
            return View(putnoosiguranje);
        }

        // GET: putnoosiguranje/Delete/5
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
            putnoosiguranje putnoosiguranje = db.putnoosiguranje.Find(id);
            if (putnoosiguranje == null)
            {
                return HttpNotFound();
            }
            return View(putnoosiguranje);
        }

        // POST: putnoosiguranje/Delete/5
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
            putnoosiguranje putnoosiguranje = db.putnoosiguranje.Find(id);
            db.putnoosiguranje.Remove(putnoosiguranje);
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
