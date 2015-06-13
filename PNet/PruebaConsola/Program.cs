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
          /*  GerenteDTO _gDTO = new GerenteDTO();
            _gDTO.apellido = "Sigura";
            _gDTO.nombre = "Aldo";
            gGest.Guardar(_gDTO);*/
            

            IList<GerenteDTO> lista = gGest.Listar();
            foreach (GerenteDTO g in lista)
            {
                Console.WriteLine(g);
            } 
            Console.ReadKey();
            Console.WriteLine();


            //HABILITAR PARA DAR DE ALTA UN PROYECTO
           /* ProyectoDTO _pDTO = new ProyectoDTO();
            _pDTO.nombre = "PNetV2";
            _pDTO.descripcion = "Proyecto para .NET version 2, con ABM";
            _pDTO.fecha = new DateTime(2015, 6, 10);
            _pDTO.Gerente_idGerente = 1;
            pGest.Guardar(_pDTO);*/

            IList<ProyectoDTO> listaP = pGest.Listar();
            foreach (ProyectoDTO p in listaP)
            {
                Console.WriteLine(p);
            }
            Console.ReadKey();

            Console.WriteLine("Lista de proyecto modificado \n");
            //Modificar un proyecto
            ProyectoDTO _pDTO2 = pGest.DevolverUltimo();
            _pDTO2.nombre = _pDTO2.nombre + " Modificado";
            pGest.Guardar(_pDTO2);

            listaP = pGest.Listar();
            foreach (ProyectoDTO p in listaP)
            {
                Console.WriteLine(p);
            }
            Console.ReadKey();

            Console.WriteLine("Eliminar proyecto...");
            pGest.Eliminar(pGest.DevolverUltimo());

            listaP = pGest.Listar();
            foreach (ProyectoDTO p in listaP)
            {
                Console.WriteLine(p);
            }
            Console.ReadKey();

        }
    }
}
