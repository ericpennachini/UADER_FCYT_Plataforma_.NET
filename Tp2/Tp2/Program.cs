using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tp2
{
    class Program
    {
        #region Metodos definidos por nosotros

        public static List<Caracteristica> AgregarCaracteristicas(string carac1, string carac2, string carac3)
        {
            List<Caracteristica> listaCarac = new List<Caracteristica>();
            listaCarac.Add(new Caracteristica { denominacion = carac1, valor = 0 });
            listaCarac.Add(new Caracteristica { denominacion = carac2, valor = 1 });
            listaCarac.Add(new Caracteristica { denominacion = carac3, valor = 2 });
            return listaCarac;
        }

        public static void MostrarFactores()
        {
            //codigo para listar los factores junto a su id
            try
            {
                using (var contexto = new Modelo1Container())
                {
                    var _repFactor = new Repositorio<Factor>(contexto);
                    var factores = _repFactor.DevolverTodos();
                    var factoresQ = from fac in factores select fac;
                    Console.WriteLine("FACTORES DISPONIBLES Y SUS CARACTERISTICAS:");
                    Console.WriteLine("ID | Nombre de factor");
                    foreach (Factor f in factoresQ)
                    {
                        Console.WriteLine(f.idFactor + " | " + f.nombreFactor + " ");
                        MostrarCaracteristicas(f);
                    }
                };
            }
            catch (Exception ex)
            {
                Console.WriteLine("Ocurrió un error al intentar mostrar los factores.");
                Console.WriteLine(ex.StackTrace);

            }
        }

        public static void MostrarCaracteristicas(Factor fact)
        {
            //código para listar las caracteristicas de un factor determinado
            try
            {
                using (var contexto = new Modelo1Container())
                {
                    var _repCaracteristica = new Repositorio<Caracteristica>(contexto);
                    var caracteristicas = _repCaracteristica.DevolverTodos();
                    var caracQ = from c in caracteristicas where c.Factor.idFactor == fact.idFactor select c;
                    foreach (Caracteristica c in caracQ)
                    {
                        Console.WriteLine("---- " + c.valor + " | " + c.denominacion);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Ocurrió un error al intentar mostrar las características para este factor");
                Console.WriteLine(ex.StackTrace);
            }
        }

        public static void AgregarNuevoFactor(string factor, string carac1, string carac2, string carac3)
        {
            //codigo para agregar un nuevo factor al conjunto de factores junto con sus características
            try
            {
                using (var contexto = new Modelo1Container())
                {
                    var _repFactor = new Repositorio<Factor>(contexto);
                    var factorNuevo = new Factor
                    {
                        nombreFactor = factor,
                        Caracteristica = AgregarCaracteristicas(carac1, carac2, carac3),
                    };
                    _repFactor.Guardar(factorNuevo);
                    contexto.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Ocurrió un error al intentar guardar un factor.");
                Console.WriteLine(ex.StackTrace);
            }
        }

        public static void AgregarFactorProyecto(int idFactor)
        {
            //código para asociar un factor  a un proyecto
        }

        public static void NuevoGerente(string nombre, string apellido)
        {
            //código para dar de alta un nuevo gerente
            try
            {
                using (var contexto = new Modelo1Container())
                {
                    var _repGerente = new Repositorio<Gerente>(contexto);
                    var nuevoGerente = new Gerente
                    {
                        nombre = nombre,
                        apellido = apellido,
                    };
                    _repGerente.Guardar(nuevoGerente);
                    contexto.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Ocurrió un error al intentar guardar los datos del gerente");
                Console.WriteLine(ex.StackTrace);
            }
        }

        public static void MostrarGerentes()
        {
            try
            {
                using (var contexto = new Modelo1Container())
                {
                    var _repGerente = new Repositorio<Gerente>(contexto);
                    var gerentes = _repGerente.DevolverTodos();
                    Console.WriteLine("GERENTES DISPONIBLES:");
                    Console.WriteLine("ID | Nombre y apellido");
                    foreach (Gerente g in gerentes)
                    {
                        Console.WriteLine("{0} | {1}", g.idGerente, g.nombre + " " + g.apellido);
                    }
                };
            }
            catch (Exception ex)
            {
                Console.WriteLine("Ocurrió un error al intentar mostrar los gerentes.");
                Console.WriteLine(ex.StackTrace);
            }
        }

        public static void AgregarProyecto(string nombreProy, string descripcion, DateTime fecha, int idGerente)
        {
            try
            {
                using (var contexto = new Modelo1Container())
                {
                    var _repProyecto = new Repositorio<Proyecto>(contexto);
                    var nuevoProyecto = new Proyecto
                    {
                        nombre = nombreProy,
                        descripcion = descripcion,
                        fecha = fecha,
                        Gerente = BuscarGerente(idGerente),
                    };
                    _repProyecto.Guardar(nuevoProyecto);
                    contexto.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Ocurrió un error al intentar dar de alta un proyecto nuevo");
                Console.WriteLine(ex.StackTrace);
            }
        }

        public static void MostrarProyectos()

        {
            try
            {
                using (var contexto = new Modelo1Container())
                {
                    var _repProyectos = new Repositorio<Proyecto>(contexto);
                    var proyectos = _repProyectos.DevolverTodos();
                    Console.WriteLine("PROYECTOS DISPONIBLES: ");
                    Console.WriteLine("------------------------");
                    foreach (Proyecto p in proyectos)
                    {
                        Console.WriteLine("ID: " + p.idProyecto);
                        Console.WriteLine("NOMBRE: " + p.nombre);
                        Console.WriteLine("DESCRIPCION: " + p.descripcion);
                        Console.WriteLine("FECHA DE CARACTERIZACION: " + p.fecha);
                    }
                }
            }
            catch (Exception ex)
            {

            }
        }

        public static Gerente BuscarGerente(int id)
        {
            Gerente gerente = new Gerente();
            try
            {
                using (var contexto = new Modelo1Container())
                {
                    var _repGerente = new Repositorio<Gerente>(contexto);
                    gerente = _repGerente.GetPorId(id);
                };
            }
            catch(Exception ex)
            {
                Console.WriteLine("Ocurrio un error al querer encontrar el gerente por el ID");
                Console.WriteLine(ex.StackTrace);
            }
            return gerente;
        }

        #endregion

        #region Main
        static void Main(string[] args)
        {
            int valor;
            do
            {
                try
                {
                    Console.Clear();
                    Console.WriteLine("Seleccione un número de opción");
                    Console.WriteLine("1 - Listar todos los factores con sus caracteríticas");
                    Console.WriteLine("2 - Crear un nuevo factor con sus caracteríticas");
                    Console.WriteLine("3 - Agregar un proyecto");
                    Console.WriteLine("4 - Agregar un gerente");
                    Console.WriteLine("5 - Listar proyectos");
                    Console.WriteLine("6 - Listar gerentes");
                    Console.WriteLine("0 - Salir");
                    valor = Convert.ToInt32(Console.ReadLine());
                    switch (valor)
                    {
                        case 1:
                            {
                                Console.Clear();
                                MostrarFactores();
                                Console.ReadKey();
                                break;
                            }
                        case 2:
                            {
                                Console.Clear();
                                string nombreFactor, carac1, carac2, carac3;
                                Console.WriteLine("Ingrese un nombre para el factor:");
                                nombreFactor = Console.ReadLine();
                                Console.WriteLine("Ingrese un nombre para la característica con valor 0:");
                                carac1 = Console.ReadLine();
                                Console.WriteLine("Ingrese un nombre para la característica con valor 1:");
                                carac2 = Console.ReadLine();
                                Console.WriteLine("Ingrese un nombre para la característica con valor 2:");
                                carac3 = Console.ReadLine();
                                AgregarNuevoFactor(nombreFactor, carac1, carac2, carac3);
                                break;
                            }
                        case 3:
                            {
                                Console.Clear();
                                string nombreProyecto, descProyecto, diaString, mesString, añoString, idGerenteString;
                                DateTime fecProyecto;

                                Console.WriteLine("Ingrese un nombre para el proyecto: ");
                                nombreProyecto = Console.ReadLine();

                                Console.WriteLine("Ingrese una decripcion: ");
                                descProyecto = Console.ReadLine();

                                Console.WriteLine("Ingrese la fecha del proyecto: ");
                                Console.WriteLine("DIA: ");
                                diaString = Console.ReadLine();
                                Int32 dia = Convert.ToInt32(diaString);
                                Console.WriteLine("MES: ");
                                mesString = Console.ReadLine();
                                Int32 mes = Convert.ToInt32(mesString);
                                Console.WriteLine("AÑO: ");
                                añoString = Console.ReadLine();
                                Int32 año = Convert.ToInt32(añoString);
                                fecProyecto = new DateTime(año, mes, dia);

                                Console.WriteLine("\n Asigne un gerente al proyecto. Si no aparece en la lista," 
                                                    + " vuelva al menu principal e ingrese el gerente en cuestión. ");
                                MostrarGerentes();
                                Console.WriteLine("Ingrese el ID del gerente que quiere asignar al proyecto: ");
                                idGerenteString = Console.ReadLine();
                                Int32 idGerente = Convert.ToInt32(idGerenteString);

                                AgregarProyecto(nombreProyecto,descProyecto,fecProyecto,idGerente);
                                break;
                            }
                        case 4:
                            {
                                Console.Clear();
                                string nombre, apellido;
                                Console.WriteLine("Ingrese los datos del nuevo gerente: ");
                                Console.WriteLine("NOMBRE: ");
                                nombre = Console.ReadLine();
                                Console.WriteLine("APELLIDO: ");
                                apellido = Console.ReadLine();
                                NuevoGerente(nombre, apellido);
                                break;
                            }
                        case 5:
                            {
                                Console.Clear();
                                MostrarProyectos();
                                Console.ReadLine();
                                break;
                            }
                        case 6:
                            {
                                Console.Clear();
                                MostrarGerentes();
                                Console.ReadLine();
                                break;
                            }
                        case 0:
                            {
                                System.Environment.Exit(0);
                                break;
                            }
                        default:
                            { break; }
                    }
                }
                catch (FormatException)
                {
                    Console.WriteLine("(!) HAY UN PROBLEMA");
                    Console.WriteLine("-El valor ingresado no es un número válido, vuelva a intentarlo." + '\n');
                }

            } while (true);

            /// DESCOMENTAR las lineas inferiores si no hay registros en la BD y se quiere
            /// empezar desde cero.
            /// COMENTAR si ya hay informacion.


            /*
            try
            {
                using (var contexto = new Modelo1Container())
                {
                    // creamos un respositorio para Factores
                    var _repFactor = new Repositorio<Factor>(contexto);

                    //definimos factores con sus caracteristicas
                    var factorDuracion = new Factor
                    {
                        nombreFactor = "Duración estimada en la oferta",
                        Caracteristica = AgregarCaracteristicas("Hasta 1 mes", "Entre 1 y 6 meses", "Más de 6 meses"),

                    };

                    var factorCalidad = new Factor
                    {
                        nombreFactor = "Calidad",
                        Caracteristica = AgregarCaracteristicas("Baja", "Normal", "Alta"),

                    };

                    var factorRecurso = new Factor
                    {
                        nombreFactor = "Recurso",
                        Caracteristica = AgregarCaracteristicas("Hasta 5 personas", "Entre 5 y 10 personase", "Mas de 10 personas"),

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

            /* try 
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
             }*/

        }


        #endregion

    }
}
