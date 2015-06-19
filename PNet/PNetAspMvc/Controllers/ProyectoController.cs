using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PNet.AccesoDatos;
using PNet.Gestores;
using PNet.DTO;
using System.Net;
using PNetAspMvc.Models;
using PNet.Dominio.Modelo;

namespace PNetAspMvc.Controllers
{
    public class ProyectoController : Controller
    {
        private Modelo1Container dbCont = new Modelo1Container();
        private GestorProyecto _pGest = new GestorProyecto();
        private GestorGerente _gGest = new GestorGerente();


        public ActionResult Index()
        {
            return View(_pGest.Listar().ToList());
        }

        #region Métodos pre definidos
        //
        // GET: /Proyecto/

        

        //
        // GET: /Proyecto/Details/5

        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /Proyecto/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Proyecto/Create

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
        // GET: /Proyecto/Edit/5

        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /Proyecto/Edit/5

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
        // GET: /Proyecto/Delete/5

        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /Proyecto/Delete/5

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

        #region - Crear
        public ActionResult Crear()
        {
            ProyectoModels modelo = new ProyectoModels()
            {
                DropGerentes = new SelectList(_gGest.Listar(),"idGerente","apellido")
            };
            return View(modelo);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Crear([Bind(Include = "idProyecto,nombre,descripcion,fecha,Gerente_idGerente")] ProyectoDTO proyecto)
        {
            if (ModelState.IsValid)
            {
                _pGest.Guardar(proyecto);
                return RedirectToAction("Index");
            }
            return View(proyecto);
        }
        #endregion

        #region - Detalles
        public ActionResult Detalles(int id)
        {
            ProyectoDTO _pDTO = new ProyectoDTO();
            try
            {
                if (id == 0)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                _pDTO = _pGest.Obtener(id);
                if (_pDTO == null)
                {
                    return HttpNotFound();
                }

                ProyectoModels modelo = new ProyectoModels()
                {
                    idProyecto=_pDTO.idProyecto,
                    nombre=_pDTO.nombre,
                    fecha=_pDTO.fecha,
                    nombreGerente=_gGest.Obtener(_pDTO.Gerente_idGerente).ToString()
                };
                return View(modelo);
            }
            catch (Exception)
            {
                
            }
            return RedirectToAction("Index");
        }

        #endregion

        #region - Listar
        public ActionResult Listar()
        {
            return View();
        }
        #endregion

        #region - Eliminar
        public ActionResult Eliminar(int id)
        {
            if (id == 0)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            ProyectoDTO proyecto = _pGest.Obtener(id); ;
            if (proyecto == null)
            {
                return HttpNotFound();
            }
            return View(proyecto);
        }

        // POST: /Proyecto/Eliminar/id
        [HttpPost, ActionName("Eliminar")]
        [ValidateAntiForgeryToken]
        public ActionResult EliminarConfirmed(int id)
        {
            ProyectoDTO proyecto = _pGest.Obtener(id);
            _pGest.Eliminar(proyecto);
            return RedirectToAction("Index");
        }
        #endregion

    }

}
