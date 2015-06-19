using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PNet.AccesoDatos;
using PNet.Gestores;
using PNet.DTO;
using System.Net;

namespace PNetAspMvc.Controllers
{
    public class GerenteController : Controller
    {
        private Modelo1Container dbCont = new Modelo1Container();
        private GestorGerente _gGest = new GestorGerente();
        
        #region Métodoso pre definidos
        //
        // GET: /Gerente/

        public ActionResult Index()
        {
            return View(_gGest.Listar().ToList());
        }

        //
        // GET: /Gerente/Details/5

        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /Gerente/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Gerente/Create

        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Gerente/Edit/5

        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /Gerente/Edit/5

        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Gerente/Delete/5

        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /Gerente/Delete/5

        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        #endregion

        #region Crear

        public ActionResult Crear() 
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Crear([Bind(Include = "idGerente, nombre, apellido")] GerenteDTO gerente)
        {
            if (ModelState.IsValid)
            {
                _gGest.Guardar(gerente);
                return RedirectToAction("Index");
            }
            return View(gerente);
        }
        #endregion

        #region Editar

        public ActionResult Editar(int id) 
        {
            if (id == 0) 
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GerenteDTO gerente = _gGest.Obtener(id);
            if (gerente == null) 
            {
                return HttpNotFound();
            }
            return View(gerente);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Editar([Bind(Include = "idGerente,nombre,apellido")] GerenteDTO gerente)
        {
            if (ModelState.IsValid)
            {
                _gGest.Modificar(gerente);
                return RedirectToAction("Index");
            }
            return View(gerente);
        }

        #endregion

        #region Eliminar

        public ActionResult Eliminar(int id) 
        {
            if (id == 0) 
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GerenteDTO gerente = _gGest.Obtener(id);
            if (gerente == null) 
            {
                return HttpNotFound();
            }
            return View(gerente);
        }

        [HttpPost, ActionName("Eliminar")]
        [ValidateAntiForgeryToken]
        public ActionResult EliminarConfirmed(int id) 
        {
            GerenteDTO gerente = _gGest.Obtener(id);
            _gGest.Eliminar(gerente);
            return RedirectToAction("Index");
        }

        #endregion

    }
}
