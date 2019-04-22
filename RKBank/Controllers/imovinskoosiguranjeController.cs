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
    public class imovinskoosiguranjeController : Controller
    {
        private RKBankDBModel db = new RKBankDBModel();

        // GET: imovinskoosiguranje
        public ActionResult Index()
        {
            if (!User.Identity.IsAuthenticated)
            {
                Response.Redirect("~/Login.aspx");
            }
            var imovinskoosiguranje = db.imovinskoosiguranje.Include(i => i.klijent).Include(i => i.osiguranje);
            if (!User.Identity.Name.Equals("Admin")) {
                return View("Index403", imovinskoosiguranje);
            }
            return View(imovinskoosiguranje.ToList());
        }

        // GET: imovinskoosiguranje/Details/5
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
            imovinskoosiguranje imovinskoosiguranje = db.imovinskoosiguranje.Find(id);
            if (imovinskoosiguranje == null)
            {
                return HttpNotFound();
            }
            if (!User.Identity.Name.Equals("Admin"))
            {
                return View("Details403", imovinskoosiguranje);
            }
            return View(imovinskoosiguranje);
        }

        // GET: imovinskoosiguranje/Create
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

        // POST: imovinskoosiguranje/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,OsiguranjeID,JMBG,DatumPocetka,DatumZavrsetka,Status,Izlozenos")] imovinskoosiguranje imovinskoosiguranje)
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
                db.imovinskoosiguranje.Add(imovinskoosiguranje);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.JMBG = new SelectList(db.klijent, "JMBG", "Ime", imovinskoosiguranje.JMBG);
            ViewBag.OsiguranjeID = new SelectList(db.osiguranje, "ID", "JMBG", imovinskoosiguranje.OsiguranjeID);
            return View(imovinskoosiguranje);
        }

        // GET: imovinskoosiguranje/Edit/5
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
            imovinskoosiguranje imovinskoosiguranje = db.imovinskoosiguranje.Find(id);
            if (imovinskoosiguranje == null)
            {
                return HttpNotFound();
            }
            ViewBag.JMBG = new SelectList(db.klijent, "JMBG", "Ime", imovinskoosiguranje.JMBG);
            ViewBag.OsiguranjeID = new SelectList(db.osiguranje, "ID", "JMBG", imovinskoosiguranje.OsiguranjeID);
            return View(imovinskoosiguranje);
        }

        // POST: imovinskoosiguranje/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,OsiguranjeID,JMBG,DatumPocetka,DatumZavrsetka,Status,Izlozenos")] imovinskoosiguranje imovinskoosiguranje)
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
                db.Entry(imovinskoosiguranje).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.JMBG = new SelectList(db.klijent, "JMBG", "Ime", imovinskoosiguranje.JMBG);
            ViewBag.OsiguranjeID = new SelectList(db.osiguranje, "ID", "JMBG", imovinskoosiguranje.OsiguranjeID);
            return View(imovinskoosiguranje);
        }

        // GET: imovinskoosiguranje/Delete/5
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
            imovinskoosiguranje imovinskoosiguranje = db.imovinskoosiguranje.Find(id);
            if (imovinskoosiguranje == null)
            {
                return HttpNotFound();
            }
            return View(imovinskoosiguranje);
        }

        // POST: imovinskoosiguranje/Delete/5
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
            imovinskoosiguranje imovinskoosiguranje = db.imovinskoosiguranje.Find(id);
            db.imovinskoosiguranje.Remove(imovinskoosiguranje);
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
