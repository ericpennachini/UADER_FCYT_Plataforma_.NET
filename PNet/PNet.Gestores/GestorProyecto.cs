﻿using System;
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

        //Implementación de la interface IGestor

        //Preguntar funcionamiento
        public void Guardar(ProyectoDTO p)
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

        public ProyectoDTO Obtener(int id)
        {
            var _p = _repProyecto.GetPorId(id);
            return ModeloaDTO(_p);
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
            catch (Exception ex) 
            {
                Console.WriteLine(ex.StackTrace);
                Console.ReadKey();
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

        public void AsignarGerente(GerenteDTO _gerente) 
        {
            //

        }

        //Implementación de la interface IDisposable
       
        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        //Métodos propios

        private void ActualizaProyecto(Proyecto _pMod, Proyecto _proyecto)
        {
            _proyecto.idProyecto = _pMod.idProyecto;
            _proyecto.nombre = _pMod.nombre;
            _proyecto.descripcion = _pMod.descripcion;
            _proyecto.fecha = _pMod.fecha;
            _proyecto.Gerente = _pMod.Gerente;
            _proyecto.Caracterizacion = _pMod.Caracterizacion;
        }

        private Proyecto DTOaModelo(ProyectoDTO p)
        {
            Proyecto proyecto = new Proyecto();
            proyecto.idProyecto = p.idProyecto;
            proyecto.nombre = p.nombre;
            proyecto.descripcion = p.descripcion;
           // proyecto.Gerente = p.Gerente;
            proyecto.fecha = p.fecha;
           // proyecto.Caracterizacion = p.Caracterizacion;
            return proyecto;
        }

        private ProyectoDTO ModeloaDTO(Proyecto p)
        {
            var _pDTO = new ProyectoDTO();
            _pDTO.idProyecto = p.idProyecto;
            _pDTO.nombre = p.nombre;
            _pDTO.fecha = p.fecha;
            _pDTO.descripcion = p.descripcion;
           // _pDTO.Caracterizacion = p.Caracterizacion;
            //_pDTO.Gerente = p.Gerente;
            return _pDTO;
        }

   

    }
}
