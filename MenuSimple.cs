using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Linq.Expressions;
using ProyectoSoftware.Date;

namespace ProyectoSoftware
{
    class MenuSimple
    {
        Repositorio<Venta> ventRep = new Repositorio<Venta>();
        Repositorio<Producto> prodRep = new Repositorio<Producto>();
        Repositorio<Cliente> cliRep = new Repositorio<Cliente>();
        public void Menu()
        {
            string opcion;
            do
            {
                Console.WriteLine("Ingrese una opcion");
                Console.WriteLine("1 Ver ventas ");
                Console.WriteLine("2 Reporte de las ventas del dia");
                Console.WriteLine("3 Buscar en las ventas");
                Console.WriteLine("4 Registrar Clientes");
                opcion = Console.ReadLine();
                switch (opcion)
                {
                    case "1":
                        Console.Clear();
                        RegistrarVentasTotales();
                        break;
                    case "2":
                        Console.Clear();
                        ReporteVentasDehoy();
                        break;
                    case "3":
                        BuscarEnVentas();
                        return;

                    case "4":
                        RegistrarClientes();
                        break;
                    default:
                        Console.Clear();
                        Console.WriteLine("Opcion invalida");
                        final();
                        break;
                }

            } while (opcion == "3");
        }

       

        public void RegistrarVentasTotales()
        {
            Repositorio<Venta> ventRep = new Repositorio<Venta>();
            Repositorio<Producto> prodRep = new Repositorio<Producto>();
            Repositorio<Cliente> cliRep = new Repositorio<Cliente>();
            foreach(Venta vent in ventRep.OptenerTodos())
            {
                var producto = prodRep.ObtenerPorId(vent.ProductoId);
                var cliente = cliRep.ObtenerPorId(vent.ClienteID);
                Console.WriteLine("Producto:    /////" + producto.Nombre + " " + producto.Nombre + " " + producto.Precio +"Cliente que lo compro //" + cliente.Nombre + " " + cliente.Apellido + " ////////" + String.Format("{0:y yy yyy yyyy}", vent.FechaIncercion));
            }
            Console.WriteLine("Precione una tecla para continuar...");
            Console.ReadKey();
            Console.Clear();
            Menu();
        }
        public void ReporteVentasDehoy()
        {
            
            foreach (Venta vent in ventRep.TraerIncertadosHoy())
            {
                var producto = prodRep.ObtenerPorId(vent.ProductoId);
                var cliente = cliRep.ObtenerPorId(vent.ClienteID);
                Console.WriteLine("Producto:    /////" + producto.Nombre + " " + producto.Nombre + " " + producto.Precio + "Cliente que lo compro //" + cliente.Nombre + " " + cliente.Apellido + " ////////" + string.Format("dd/mm/yyyy", vent.FechaIncercion));
            }
            final();

        }
        public void BuscarEnVentas()
        {
            Console.WriteLine("1 buscar por nombre de producto ");

            Console.WriteLine("Ingrese el nombre del producto o alguna palabra en el");
            string text = Console.ReadLine();
            using (VentaContext db = new VentaContext())
            {
                List<Producto> lista = (from t1 in db.Venta
                                        join t2 in db.Productos
                                        on t1.ProductoId equals t2.id
                                        where t2.Nombre.Contains(text)
                                        select t2).ToList();
                if (lista.Count!=0)
                {
                    foreach (Producto ob in lista)
                    {
                        Console.WriteLine(ob.Nombre + " " + ob.Precio);
                    }
                }
                else
                {
                    Console.WriteLine("No existen coincidencias...");

                }
                final();
            }
        }

        public void RegistrarClientes()
        {
            Console.WriteLine("Ingrese el nombre");
            string nom = Console.ReadLine();
            Console.WriteLine("Ingrese el apellido");
            string ape = Console.ReadLine();
            Console.WriteLine("Ingrese el numero de telefono");
            string tel = Console.ReadLine();
            Console.WriteLine("Ingrese el numero de dni");
            string dni = Console.ReadLine();
            Console.WriteLine("Ingrese la direccion del cliente");
            string dir = Console.ReadLine();
            Cliente clien = new Cliente()
            {
                Nombre = nom,
                Apellido = ape,
                Direccion = dir,
                Telefono = tel,
                Dni = dni
            };
            try
            {
                cliRep.Agregar(clien);
                Console.WriteLine("El cliente se agrego con exito");

            }
            catch (Exception er)
            {
                Console.WriteLine("hubo un problema .."+er.Message);
            }
            final();

        }
        public void final()
        {
            Console.WriteLine("Precione una tecla para continuar...");
            Console.ReadKey();
            Console.Clear();
           
            Menu();
        }
        public void final2()
        {
            Console.WriteLine("Precione una tecla para continuar...");
            Console.ReadKey();
            Console.Clear();

            BuscarEnVentas();
        }
    }
}
