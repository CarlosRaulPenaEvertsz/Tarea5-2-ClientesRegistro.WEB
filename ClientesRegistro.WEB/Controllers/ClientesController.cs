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
    public class ClientesController : Controller
    {
        private ClientesDBEntities db = new ClientesDBEntities();

        // GET: Clientes
        public ActionResult Index()
        {
            var clientes = db.Clientes.Include(c => c.TipoNCF1);
            return View(clientes.ToList());
        }

        // GET: Clientes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cliente cliente = db.Clientes.Find(id);
            if (cliente == null)
            {
                return HttpNotFound();
            }
            return View(cliente);
        }

        // GET: Clientes/Create
        public ActionResult Create()
        {
            ViewBag.TipoNCF = new SelectList(db.TipoNCFs, "TipoNCF_Id", "NombreComprobanteFiscal");
            
            return View();
        }

        // POST: Clientes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Nombre_Comercial,Nombres,Apellidos,Sexo,Fecha_Nacimiento,Cedula_RNC,Direccion,Telefono,Email,TipoNCF")] Cliente cliente, DateTime fecha)
        {
            if (fecha == null)
                fecha = DateTime.Now;
            cliente.Fecha_Nacimiento = fecha;
            if (ModelState.IsValid)
            {
                db.Clientes.Add(cliente);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.TipoNCF = new SelectList(db.TipoNCFs, "TipoNCF_Id", "NombreComprobanteFiscal", cliente.TipoNCF);
            return View(cliente);
        }

        // GET: Clientes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cliente cliente = db.Clientes.Find(id);
            if (cliente == null)
            {
                return HttpNotFound();
            }
            ViewBag.TipoNCF = new SelectList(db.TipoNCFs, "TipoNCF_Id", "NombreComprobanteFiscal", cliente.TipoNCF);
            return View(cliente);
        }

        // POST: Clientes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Nombre_Comercial,Nombres,Apellidos,Sexo,Fecha_Nacimiento,Cedula_RNC,Direccion,Telefono,Email,TipoNCF")] Cliente cliente, DateTime fecha)
        {
            if (fecha == null)
                fecha = DateTime.Now;
            cliente.Fecha_Nacimiento = fecha;

            if (ModelState.IsValid)
            {
                db.Entry(cliente).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.TipoNCF = new SelectList(db.TipoNCFs, "TipoNCF_Id", "NombreComprobanteFiscal", cliente.TipoNCF);
            return View(cliente);
        }

        // GET: Clientes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cliente cliente = db.Clientes.Find(id);
            if (cliente == null)
            {
                return HttpNotFound();
            }
            return View(cliente);
        }

        // POST: Clientes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Cliente cliente = db.Clientes.Find(id);
            db.Clientes.Remove(cliente);
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
