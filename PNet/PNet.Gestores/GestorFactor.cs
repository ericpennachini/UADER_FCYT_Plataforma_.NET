using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PNet.Repositorio;
using PNet.AccesoDatos;
using PNet.Dominio;
using PNet.DTO;
using System.Data.Entity;


namespace PNet.Gestores
{
    public class GestorFactor : IGestor<FactorDTO>, IDisposable
    {
        RepositorioFactor _repfactor;
        Modelo1Container _contexto;
        FactorD _factor;

        public GestorFactor()
        {
            try
            {
                _contexto = new Modelo1Container();
                _repfactor = new RepositorioFactor(_contexto);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
                throw;
            }
        }


        public void Guardar(FactorDTO f)
        {
            if (f.idFactor > 0)
            {
                FactorD _fMod = DTOaModelo(f);
                _factor = _repfactor.GetPorId(f.idFactor);
                this.ActualizaFactor(_fMod, _factor);
            }
            else
            {
                _factor = DTOaModelo(p);
            }
            _repfactor.Guardar(_factor, _factor.idFactor);
            _contexto.SaveChanges();
        }

        public FactorDTO Obtener(int id)
        {
            FactorDTO _fDTO = new FactorDTO();
            try
            {
                _fDTO = ModeloaDTO(_repfactor.GetPorId(id));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.InnerException);
                throw;
            }
            return _fDTO;
        }

        public IList<FactorDTO> Listar()
        {
            IQueryable<FactorD> _fLista = _repfactor.DevolverTodos();
            IList<FactorDTO> _fDTOLista = new List<FactorDTO>();
            try
            {
                foreach (FactorD f in _fLista)
                {
                    _fDTOLista.Add(ModeloaDTO(f));
                };

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.InnerException);
                throw;
            }
            return _fDTOLista;
        }





        private void ActualizaFactor(FactorD _fMod, FactorD _factor)
        {
            _factor.idFactor = _fMod.idFactor;
            _factor.nombreFactor = _fMod.nombreFactor;

        }

        private FactorD DTOaModelo(FactorDTO f)
        {
            FactorD factor = new FactorD();
            factor.idFactor = f.idFactor;
            factor.nombreFactor = f.nombreFactor;
            return factor;
        }

         private FactorDTO ModeloaDTO(FactorD f)
        {
            var _factorDTO = new FactorDTO();
            _factorDTO.nombreFactor = f.nombreFactor;

            return _factorDTO;
        }
    }
}
