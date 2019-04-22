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
    public class osiguranjeController : Controller
    {
        private RKBankDBModel db = new RKBankDBModel();

        // GET: osiguranje
        public ActionResult Index()
        {
            if (!User.Identity.IsAuthenticated)
            {
                Response.Redirect("~/Login.aspx");
            }
            var osiguranje = db.osiguranje.Include(o => o.klijent);
            if (!User.Identity.Name.Equals("Admin")) {
                return View("Index403", osiguranje.ToList());
            }
            return View(osiguranje.ToList());
        }

        // GET: osiguranje/Details/5
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
            osiguranje osiguranje = db.osiguranje.Find(id);
            if (osiguranje == null)
            {
                return HttpNotFound();
            }
            if (!User.Identity.Name.Equals("Admin"))
            {
                return View("Details403", osiguranje);
            }
            return View(osiguranje);
        }

        // GET: osiguranje/Create
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

        // POST: osiguranje/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,JMBG,BrojAktivnih,BrojRizicnih,BrojZavrsenih")] osiguranje osiguranje)
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
                db.osiguranje.Add(osiguranje);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.JMBG = new SelectList(db.klijent, "JMBG", "Ime", osiguranje.JMBG);
            return View(osiguranje);
        }

        // GET: osiguranje/Edit/5
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
            osiguranje osiguranje = db.osiguranje.Find(id);
            if (osiguranje == null)
            {
                return HttpNotFound();
            }
            ViewBag.JMBG = new SelectList(db.klijent, "JMBG", "Ime", osiguranje.JMBG);
            return View(osiguranje);
        }

        // POST: osiguranje/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,JMBG,BrojAktivnih,BrojRizicnih,BrojZavrsenih")] osiguranje osiguranje)
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
                db.Entry(osiguranje).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.JMBG = new SelectList(db.klijent, "JMBG", "Ime", osiguranje.JMBG);
            return View(osiguranje);
        }

        // GET: osiguranje/Delete/5
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
            osiguranje osiguranje = db.osiguranje.Find(id);
            if (osiguranje == null)
            {
                return HttpNotFound();
            }
            return View(osiguranje);
        }

        // POST: osiguranje/Delete/5
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
            osiguranje osiguranje = db.osiguranje.Find(id);
            db.osiguranje.Remove(osiguranje);
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
