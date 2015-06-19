using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PNet.Dominio.Modelo;
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
        Proyecto _proyecto;

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

        #region Implementacion de IGestor

        public void Guardar(ProyectoDTO p)
        {
            try
            {
                if (p.idProyecto > 0)
                {
                    Proyecto _pMod = DTOaModelo(p);
                    _proyecto = _repProyecto.GetPorId(p.idProyecto);
                    this.ActualizaProyecto(_pMod, _proyecto);
                }
                else
                {
                    _proyecto = DTOaModelo(p);
                }
                _repProyecto.Guardar(_proyecto, _proyecto.idProyecto);
                _contexto.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public ProyectoDTO Obtener(int id)
        {
            try
            {
                var _p = _repProyecto.GetPorId(id);
                return ModeloaDTO(_p);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public IList<ProyectoDTO> Listar()
        {
            IList<ProyectoDTO> _pDTOLista = new List<ProyectoDTO>();

            try
            {
                IQueryable<Proyecto> _pLista = _repProyecto.DevolverTodos();
                foreach (Proyecto p in _pLista)
                {
                    _pDTOLista.Add(ModeloaDTO(p));
                }
                
            }
            catch (Exception)
            {
                throw;
            }
            return _pDTOLista;
        }

        public void Habilitar()
        {
            throw new NotImplementedException();
        }

        public void Deshabilitar()
        {
            throw new NotImplementedException();
        }

        #endregion

        #region Implementacion de IDisposable
        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
        #endregion

        #region Metodos propios

        private void ActualizaProyecto(Proyecto _pMod, Proyecto _proyecto)
        {
            _proyecto.idProyecto = _pMod.idProyecto;
            _proyecto.nombre = _pMod.nombre;
            _proyecto.descripcion = _pMod.descripcion;
            _proyecto.fecha = _pMod.fecha;
            _proyecto.Gerente_idGerente = _pMod.Gerente_idGerente;
        }

        private Proyecto DTOaModelo(ProyectoDTO p)
        {
            Proyecto proyecto = new Proyecto();
            proyecto.idProyecto = p.idProyecto;
            proyecto.nombre = p.nombre;
            proyecto.descripcion = p.descripcion;
            proyecto.Gerente_idGerente = p.Gerente_idGerente;
            proyecto.fecha = p.fecha;
            return proyecto;
        }

        private ProyectoDTO ModeloaDTO(Proyecto p)
        {
            var _pDTO = new ProyectoDTO();
            _pDTO.idProyecto = p.idProyecto;
            _pDTO.nombre = p.nombre;
            _pDTO.fecha = p.fecha;
            _pDTO.descripcion = p.descripcion;
            _pDTO.Gerente_idGerente = p.Gerente_idGerente;
            return _pDTO;
        }

        public ProyectoDTO DevolverUltimo() 
        {
            return ModeloaDTO(_repProyecto.GetUltimoProyecto());
        }

        public void Modificar(ProyectoDTO entidad)
        {
            Guardar(entidad);
        }

        public void Eliminar(ProyectoDTO entidad)
        {
            //primero recupero la entidad a eliminar por el id y se guarda en entidadBorrar
            //luego se lo paso al repositorio para que haga tranqui el Remove y luego _contexto.SaveChanges()
            try
            {
                var entidadBorrar = _repProyecto.GetPorId(entidad.idProyecto);
                _repProyecto.Eliminar(entidadBorrar);
            }
            catch (Exception)
            {
                throw;
            }
        }

        #endregion
        
    }
}
