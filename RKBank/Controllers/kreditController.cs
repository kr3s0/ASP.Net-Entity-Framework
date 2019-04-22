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
    public class kreditController : Controller
    {
        private RKBankDBModel db = new RKBankDBModel();

        // GET: kredit
        public ActionResult Index()
        {
            if (!User.Identity.IsAuthenticated)
            {
                Response.Redirect("~/Login.aspx");
            }
            var kredit = db.kredit.Include(k => k.kartica).Include(k => k.klijent);
            if (!User.Identity.Name.Equals("Admin")) {
                return View("Index403", kredit.ToList());
            }
            return View(kredit.ToList());
        }

        // GET: kredit/Details/5
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
            kredit kredit = db.kredit.Find(id);
            if (kredit == null)
            {
                return HttpNotFound();
            }
            if (!User.Identity.Name.Equals("Admin"))
            {
                return View("Details403", kredit);
            }
            return View(kredit);
        }

        // GET: kredit/Create
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
            ViewBag.KarticaID = new SelectList(db.kartica, "ID", "JMBG");
            ViewBag.JMBG = new SelectList(db.klijent, "JMBG", "Ime");
            return View();
        }

        // POST: kredit/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,KarticaID,JMBG,DatumIzdavanja,DatumPovratka,Izlozenost,Rizik")] kredit kredit)
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
                db.kredit.Add(kredit);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.KarticaID = new SelectList(db.kartica, "ID", "JMBG", kredit.KarticaID);
            ViewBag.JMBG = new SelectList(db.klijent, "JMBG", "Ime", kredit.JMBG);
            return View(kredit);
        }

        // GET: kredit/Edit/5
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
            kredit kredit = db.kredit.Find(id);
            if (kredit == null)
            {
                return HttpNotFound();
            }
            ViewBag.KarticaID = new SelectList(db.kartica, "ID", "JMBG", kredit.KarticaID);
            ViewBag.JMBG = new SelectList(db.klijent, "JMBG", "Ime", kredit.JMBG);
            return View(kredit);
        }

        // POST: kredit/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,KarticaID,JMBG,DatumIzdavanja,DatumPovratka,Izlozenost,Rizik")] kredit kredit)
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
                db.Entry(kredit).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.KarticaID = new SelectList(db.kartica, "ID", "JMBG", kredit.KarticaID);
            ViewBag.JMBG = new SelectList(db.klijent, "JMBG", "Ime", kredit.JMBG);
            return View(kredit);
        }

        // GET: kredit/Delete/5
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
            kredit kredit = db.kredit.Find(id);
            if (kredit == null)
            {
                return HttpNotFound();
            }
            return View(kredit);
        }

        // POST: kredit/Delete/5
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
            kredit kredit = db.kredit.Find(id);
            db.kredit.Remove(kredit);
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
