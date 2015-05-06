using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tp2
{
    class Program
    {
        //metodo para agregar caracteristicas
        public static List<Caracteristica> agregarCaracteristicas(string carac1, string carac2, string carac3)
        {
            List<Caracteristica> listaCarac=new List<Caracteristica>();
            listaCarac.Add(new Caracteristica{denominacion=carac1, valor=0});
            listaCarac.Add(new Caracteristica{denominacion=carac2, valor=1});
            listaCarac.Add(new Caracteristica{denominacion=carac3, valor=2});
            return listaCarac;
        }


        static void Main(string[] args)
        {


          /* try
            {
                using (var contexto = new Modelo1Container())
                {
                    // creamos un respositorio para Factores
                    var _repFactor = new Repositorio<Factor>(contexto);

                    //definimos factores con sus caracteristicas
                    var factorDuracion = new Factor
                    {
                        nombreFactor = "Duración estimada en la oferta",
                        Caracteristica = agregarCaracteristicas("Hasta 1 mes", "Entre 1 y 6 meses", "Más de 6 meses"),
                       
                    };

                    var factorCalidad = new Factor
                    {
                        nombreFactor = "Calidad",
                        Caracteristica = agregarCaracteristicas("Baja", "Normal", "Alta"),
                        
                    };

                    var factorRecurso = new Factor
                    {
                        nombreFactor = "Recurso",
                        Caracteristica = agregarCaracteristicas("Hasta 5 personas", "Entre 5 y 10 personase", "Mas de 10 personas"),
                       
                    };

                    _repFactor.Guardar(factorDuracion);
                    _repFactor.Guardar(factorCalidad);
                    _repFactor.Guardar(factorRecurso);
                    contexto.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Ocurrió un error al intentar guardar los factores y sus características.");
                Console.WriteLine(ex.StackTrace);
                Console.ReadKey();
            }*/

            //ahora creamos proyecto

            try 
            {
              using(var contexto = new Modelo1Container())
              {
                  //creamos un repositorio para proyecto y otro para levantar los factores
                  var _repProyecto = new Repositorio<Proyecto>(contexto);
                  var _repFactor = new Repositorio<Factor>(contexto);

                  var factores = _repFactor.DevolverTodos();

                  foreach (Factor f in factores) 
                  {
                      Console.WriteLine(f.nombreFactor);
                  }
                  Console.ReadKey();



                  var proyecto = new Proyecto
                  {
                      nombre = "Proyecto de .NET",
                      descripcion = "Nuestro primer proyecto",
                      Gerente = new Gerente { nombre = "Aldo", apellido = "Sigura" },
                      fecha = new DateTime(2015, 05, 06),
                      Factor=factores.ToList<Factor>(),
                  };
                  _repProyecto.Guardar(proyecto);
                  contexto.SaveChanges();

              }
            }
            catch (Exception ex) 
            {
                Console.WriteLine(ex.StackTrace);
                Console.ReadKey();
            }

        }

        private static ICollection<Ponderacion> ponderarFactores(Factor factor, int valor)
        {
            List<Ponderacion> ponderaciones=new List<Ponderacion>();
            ponderaciones.Add(new Ponderacion{Factor=factor,valor=valor});
            return ponderaciones;
        }



    }
}
