using PNet.AccesoDatos;
using PNet.Dominio;
using PNet.DTO;
using PNet.Repositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using PNet.Dominio.Modelo;

namespace PNet.Gestores
{
    public class GestorGerente :IGestor<GerenteDTO>,IDisposable
    {
        RepositorioGerente _repGerente;
        Modelo1Container _contexto;
        Gerente _gerente;

        public GestorGerente() 
        {
            try 
            { 
                _contexto = new Modelo1Container();
                _repGerente = new RepositorioGerente(_contexto);

            }
            catch (Exception ex) 
            {
                Console.WriteLine(ex.StackTrace);
            }
        }
        
        //Implementación de la interface IGestor

        public void Guardar(GerenteDTO entidad)
        {
            try 
            {
                if (entidad.idGerente > 0)
                {
                    Gerente _gMod = DTOaModelo(entidad);
                    _gerente = _repGerente.GetPorId(entidad.idGerente);
                    this.ActualizarEvento(_gMod, _gerente);
                }
                else 
                {
                    _gerente = DTOaModelo(entidad);
                }
                _repGerente.Guardar(_gerente, _gerente.idGerente);
            }
            catch (Exception ex) 
            {
                Console.WriteLine(ex.InnerException);
            }
        }

        public void Habilitar()
        {
            throw new NotImplementedException();
        }

        public void Deshabilitar()
        {
            throw new NotImplementedException();
        }

        public GerenteDTO Obtener(int id)
        {
            GerenteDTO _gDTO=new GerenteDTO();
            try
            {
                _gDTO = ModeloaDTO(_repGerente.GetPorId(id));
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.InnerException);
            }
            return _gDTO;
        }

        public IList<GerenteDTO> Listar()
        {
            IList<GerenteDTO> _gDTOLista = new List<GerenteDTO>();
     
            try
            {
                IQueryable<Gerente> _gLista=_repGerente.DevolverTodos();
                foreach(Gerente g in _gLista)
                {
                    _gDTOLista.Add(ModeloaDTO(g));
                }
            }
            catch (Exception ex) 
            {
                Console.WriteLine(ex.InnerException);
            }

            return _gDTOLista;
        }

        public Gerente DevolverGerente(GerenteDTO g)
        {
            return DTOaModelo(g);
        }

        //Implementación de la interface IDispose

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    
        //Métodos propios

        private void ActualizarEvento(Gerente _gMod, Gerente _gerente)
        {
            throw new NotImplementedException();
        }

        private Gerente DTOaModelo(GerenteDTO g) 
        {
            Gerente gerente = new Gerente();
            gerente.idGerente = g.idGerente;
            gerente.apellido = g.apellido;
            gerente.nombre = g.nombre;
            gerente.Proyecto = g.Proyecto;
            return gerente;
        }

        private GerenteDTO ModeloaDTO(Gerente g) 
        {
            var _gerenteDTO = new GerenteDTO();
            _gerenteDTO.idGerente = g.idGerente;
            _gerenteDTO.apellido = g.apellido;
            _gerenteDTO.nombre = g.nombre;
           // _gerenteDTO.Proyecto = g.Proyecto;
            return _gerenteDTO;
        }

    }
}
