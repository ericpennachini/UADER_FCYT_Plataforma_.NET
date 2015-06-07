using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PNet.Gestores;
using PNet.Dominio.Modelo;
using PNet.DTO;

namespace PruebaConsola
{
    class Program
    {
        static void Main(string[] args)
        {
            //GestorProyecto pGest = new GestorProyecto();
            //ProyectoDTO _pDTO=new ProyectoDTO();
            //Console.WriteLine("Ingrese los datos para un nuevo proyecto");
            /*_pDTO.nombre = "Proyecto de taller santa lucia";
            _pDTO.descripcion = "Este es el enésimo proyecto";
            _pDTO.fecha = new DateTime(2015, 06, 04);
            _pDTO.Caracterizacion = null;
            pGest.Guardar(_pDTO);*/



            //Console.WriteLine("Listando proyectos");
            //pGest.Listar();

            GestorGerente gGest = new GestorGerente();
            GestorProyecto pGest = new GestorProyecto();

            //HABILITAR PARA DAR DE ALTA UN GERENTE
           /* GerenteDTO _gDTO = new GerenteDTO();
            _gDTO.apellido = "Sigura";
            _gDTO.nombre = "Aldo";
            gGest.Guardar(_gDTO);*/

           

            IList<GerenteDTO> lista = gGest.Listar();
            foreach (GerenteDTO g in lista)
            {
                Console.WriteLine(g);
            }
            Console.ReadKey();
        }
    }
}
