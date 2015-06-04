using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PNet.Dominio;
using PNet.Repositorio;
using PNet.Gestores;
using PNet.DTO;

namespace PruebaConsola
{
    class Program
    {
        static void Main(string[] args)
        {
            GestorProyecto pGest = new GestorProyecto();
            ProyectoDTO _pDTO=new ProyectoDTO();
           /* Console.WriteLine("Ingrese los datos para un nuevo proyecto");
            _pDTO.nombre = "Proyecto de taller santa lucia";
            _pDTO.descripcion = "Este es el enésimo proyecto";
            _pDTO.fecha = new DateTime(2015, 06, 04);
            pGest.Guardar(_pDTO);*/

            Console.WriteLine("Listando proyectos");
            pGest.Listar();
        }
    }
}
