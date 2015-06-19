using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PNet.Dominio.Modelo;

namespace PNet.DTO
{
    public class GerenteDTO: Gerente
    {
        public GerenteDTO()
            : base()
        {
            //nombreCompleto = apellido + ", " + nombre;
        }

        //private String nombreCompleto;

        //public String NombreCompleto
        //{
        //    get { return nombreCompleto; }
        //    set { nombreCompleto = value; }
        //}
    }
}
