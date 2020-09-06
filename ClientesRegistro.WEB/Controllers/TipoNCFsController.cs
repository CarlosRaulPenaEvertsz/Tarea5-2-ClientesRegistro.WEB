using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ClientesRegistro.MODELS.Models;

namespace ClientesRegistro.WEB.Controllers
{
    public class TipoNCFsController : Controller
    {
        private ClientesDBEntities db = new ClientesDBEntities();

        // GET: TipoNCFs
        public ActionResult Index()
        {
            return View(db.TipoNCFs.ToList());
        }

        // GET: TipoNCFs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoNCF tipoNCF = db.TipoNCFs.Find(id);
            if (tipoNCF == null)
            {
                return HttpNotFound();
            }
            return View(tipoNCF);
        }

        // GET: TipoNCFs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TipoNCFs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "TipoNCF_Id,NombreComprobanteFiscal,NCF_Actual,NCF_Hasta")] TipoNCF tipoNCF)
        {
            if (ModelState.IsValid)
            {
                db.TipoNCFs.Add(tipoNCF);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tipoNCF);
        }

        // GET: TipoNCFs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoNCF tipoNCF = db.TipoNCFs.Find(id);
            if (tipoNCF == null)
            {
                return HttpNotFound();
            }
            return View(tipoNCF);
        }

        // POST: TipoNCFs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "TipoNCF_Id,NombreComprobanteFiscal,NCF_Actual,NCF_Hasta")] TipoNCF tipoNCF)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tipoNCF).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tipoNCF);
        }

        // GET: TipoNCFs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoNCF tipoNCF = db.TipoNCFs.Find(id);
            if (tipoNCF == null)
            {
                return HttpNotFound();
            }
            return View(tipoNCF);
        }

        // POST: TipoNCFs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TipoNCF tipoNCF = db.TipoNCFs.Find(id);
            db.TipoNCFs.Remove(tipoNCF);
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
