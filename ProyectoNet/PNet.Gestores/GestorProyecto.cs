using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PNet.Dominio;
using PNet.DTO;
using PNet.Repositorio;
using PNet.AccesoDatos;
using System.Data.Entity;

namespace PNet.Gestores
{
    public class GestorProyecto : IGestor<ProyectoDTO>, IDisposable
    {
        RepositorioProyecto _repProyecto;
        Modelo1Container _contexto;
        ProyectoD _proyecto;

        public GestorProyecto()
        {
            try
            {
                var contexto = new Modelo1Container();
                _contexto = contexto;
                _repProyecto = new RepositorioProyecto(_contexto);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
                throw;
            }
        }

        //Preguntar funcionamiento
        public void Guardar(ProyectoDTO p)
        {
            if (p.idProyecto > 0)
            {
                ProyectoD _pMod = DTOaModelo(p);
                _proyecto = _repProyecto.GetPorId(p.idProyecto);
                this.ActualizaProyecto(_pMod, _proyecto);
            }
            else
            {
                _proyecto = DTOaModelo(p);
            }
            _repProyecto.Guardar(_proyecto, _proyecto.idProyecto);
            _contexto.SaveChanges();
            
            //ProyectoD pDom = DTOaModelo(p);
            //_proyecto = _repProyecto.GetPorId(p.idProyecto);
            //_repProyecto.Guardar(_proyecto, _proyecto.idProyecto);
            //_contexto.SaveChanges();
        }

        private void ActualizaProyecto(ProyectoD _pMod, ProyectoD _proyecto)
        {
            _proyecto.idProyecto = _pMod.idProyecto;
            _proyecto.nombre = _pMod.nombre;
            _proyecto.descripcion = _pMod.descripcion;
            _proyecto.fecha = _pMod.fecha;
            _proyecto.Gerente = _pMod.Gerente;
            _proyecto.Caracterizacion = _pMod.Caracterizacion;
        }

        private ProyectoD DTOaModelo(ProyectoDTO p)
        {
            ProyectoD proyecto = new ProyectoD();
            proyecto.idProyecto = p.idProyecto;
            proyecto.nombre = p.nombre;
            proyecto.descripcion = p.descripcion;
            proyecto.Gerente = p.Gerente;
            proyecto.fecha = p.fecha;
            proyecto.Caracterizacion = p.Caracterizacion;
            return proyecto;
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }


        public ProyectoDTO Obtener(int id)
        {
            throw new NotImplementedException();
        }

        public IList<ProyectoDTO> Listar()
        {
            throw new NotImplementedException();
        }
    }
}
