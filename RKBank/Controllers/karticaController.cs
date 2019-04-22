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
    public class karticaController : Controller
    {
        private RKBankDBModel db = new RKBankDBModel();

        // GET: kartica
        public ActionResult Index()
        {
            if (!User.Identity.IsAuthenticated)
            {
                Response.Redirect("~/Login.aspx");
            }
            var kartica = db.kartica.Include(k => k.klijent);
            if (!User.Identity.Name.Equals("Admin")) {
                return View("Index403", kartica.ToList());
            }
            return View(kartica.ToList());
        }

        // GET: kartica/Details/5
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
            kartica kartica = db.kartica.Find(id);
            if (kartica == null)
            {
                return HttpNotFound();
            }
            if (!User.Identity.Name.Equals("Admin"))
            {
                return View("Details403", kartica);
            }
            return View(kartica);
        }

        // GET: kartica/Create
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
            return View();
        }

        // POST: kartica/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,JMBG,DatumIzdavanja,Stanje,DatumIsteka")] kartica kartica)
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
                db.kartica.Add(kartica);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.JMBG = new SelectList(db.klijent, "JMBG", "Ime", kartica.JMBG);
            return View(kartica);
        }

        // GET: kartica/Edit/5
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
            kartica kartica = db.kartica.Find(id);
            if (kartica == null)
            {
                return HttpNotFound();
            }
            ViewBag.JMBG = new SelectList(db.klijent, "JMBG", "Ime", kartica.JMBG);
            return View(kartica);
        }

        // POST: kartica/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,JMBG,DatumIzdavanja,Stanje,DatumIsteka")] kartica kartica)
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
                db.Entry(kartica).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.JMBG = new SelectList(db.klijent, "JMBG", "Ime", kartica.JMBG);
            return View(kartica);
        }

        // GET: kartica/Delete/5
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
            kartica kartica = db.kartica.Find(id);
            if (kartica == null)
            {
                return HttpNotFound();
            }
            return View(kartica);
        }

        // POST: kartica/Delete/5
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
            kartica kartica = db.kartica.Find(id);
            db.kartica.Remove(kartica);
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
