using System;
using System.Collections.Generic;
using System.Text;
using ProyectoSoftware.Date;
using System.Linq;
using System.Linq.Expressions;

namespace ProyectoSoftware
{
    public class MenuUsuario
    {
        public static MenuUsuario instans = null;
        public Cliente Clienteseleccionado;
        private List<Producto> ProductosSeleccionadosParaComprar = new List<Producto>();
        public static MenuUsuario GetMenu()
        {
            if (instans == null)
            {
                instans = new MenuUsuario();
            }
            return instans;
        }
        private MenuUsuario()
        {
        }

        public void menuInicial()
        {

            int opcion;
            do
            {
                Console.WriteLine("Bienvenido ,Como decea ingresar?");
                Console.WriteLine("1 Ingresar como cliente");
                Console.WriteLine("2 ingresar como vendedor");
                opcion = int.Parse(Console.ReadLine());
                switch (opcion)
                {
                    case 1:
                        Console.Clear();
                        MenuCliente();
                        break;
                    case 2:
                        Console.Clear();

                        Console.Clear();
                        MenuAdministrador();
                        break;
                    case 3:
                        return;
                }

            } while (opcion == 3);
        }

        public void MenuCliente()
        {
            Console.Clear();
            Clienteseleccionado = QuienEselCliente();
            Console.Clear();
            Console.WriteLine("Bienvenido ,Señor " + Clienteseleccionado.Nombre + " " + Clienteseleccionado.Apellido);
            Console.WriteLine("1 Comprar Productos");
            Console.WriteLine("2 VerProductosComprados");
            Console.WriteLine("3.Salir de comprador");
            int opcion;
            var RepProd = new Repositorio<Producto>();
            List<Producto> ProductosAgregados = new List<Producto>();
            List<Producto> LisProd = RepProd.OptenerTodos();
            opcion = Convert.ToInt32(Console.ReadLine());
            Console.Clear();
            Console.WriteLine("");
            int VariableParaSalir = LisProd.Count + 1;
            int opcionCompra;
           
            do
            {
               

                switch (opcion)
                {
                    case 1:

                        Console.WriteLine("-----------Comprando (Modo Cliente)---------- Usuario " + Clienteseleccionado.Nombre + " " + Clienteseleccionado.Apellido + "--------------------------");
                        Console.WriteLine("");
                        Console.WriteLine("ingrese Todos los productos que quiera ,para Finalizar la seleccion y realizar la compra precione " + VariableParaSalir);
                        
                        for (int i = 0; i < LisProd.Count; i++)
                        {
                            int numeroCorrecto = i + 1;
                            Console.WriteLine(numeroCorrecto + ")_ " + LisProd[i].Nombre + " " + LisProd[i].Marca + " " + LisProd[i].Precio);
                        }
                        opcionCompra = Convert.ToInt32(Console.ReadLine()) - 1;
                        Console.WriteLine();

                        do
                        {

                            ProductosSeleccionadosParaComprar.Add(LisProd[opcionCompra]);
                            Console.WriteLine("");
                            Console.WriteLine();
                            Console.WriteLine("Se Agrego el producto " + LisProd[opcionCompra].Nombre);
                            Console.WriteLine();
                            opcionCompra = Convert.ToInt32(Console.ReadLine()) - 1;
                        } while (opcionCompra + 1 != VariableParaSalir);
                        ComprarProductos(ProductosSeleccionadosParaComprar);
                        Console.Clear();
                        MenuCliente();
                        break;

                    case 2:
                        VerCarrito();
                        break;
                    case 3:
                        continue;
                }

            } while (opcion != 3);
        }
        //private void ListarProductos()
        // {
        //     var RepProd = new Repositorio<Producto>();
        //     List<Producto> ProductosAgregados = new List<Producto>();
        //     List<Producto> LisProd = RepProd.OptenerTodos();
        //     int VariableParaSalir = LisProd.Count + 1;
        //     int opcion;
        //     Console.WriteLine("-----------Comprando (Modo Cliente)---------- Usuario " + Clienteseleccionado.Nombre + " " + Clienteseleccionado.Apellido + "--------------------------");
        //     Console.WriteLine("");

        //     do

        //     {
        //         for (int i = 0; i < LisProd.Count; i++)
        //         {
        //             int numeroCorrecto = i + 1;
        //             Console.WriteLine(numeroCorrecto + ")_ " + LisProd[i].Nombre + " " + LisProd[i].Marca + " " + LisProd[i].Precio);
        //         }
        //         Console.WriteLine();

        //         if (opcion != VariableParaSalir)
        //         {

        //             ProductosSeleccionadosParaComprar.Add(LisProd[opcion]);
        //             Console.WriteLine("");
        //             Console.WriteLine();
        //             Console.WriteLine("Se Agrego el producto " + LisProd[opcion].Nombre);
        //             Console.WriteLine();
        //             Console.WriteLine("ingrese otro producto ,para Finalizar la seleccion y realizar la compra precione " + VariableParaSalir);
        //             opcion = Convert.ToInt32(Console.ReadLine()) - 1;
        //         }
        //         else
        //         {
        //             ComprarProductos(ProductosSeleccionadosParaComprar);

        //         }


        //     } while (opcion == VariableParaSalir);


        // }
        private void VerCarrito()
        {
            Console.WriteLine("Actualmente tiene estos productos en el carrito");
            decimal total = 0;
            foreach (Producto pr in ProductosSeleccionadosParaComprar)
            {
                total += pr.Precio;
                Console.WriteLine(pr.Nombre + " " + pr.Marca + " " + pr.Precio);
            }
            Console.Write("Total:---------  " + total + " ----------------");
        }
        private void VerCarritoDespuesDeCompra()
        {
            Console.WriteLine("Su compra fue realizada con exito Sr " + Clienteseleccionado.Nombre);
            Console.WriteLine("");
            decimal total = 0;

            foreach (Producto pr in ProductosSeleccionadosParaComprar)
            {
                
                total += pr.Precio;
                Console.WriteLine(pr.Nombre + " " + pr.Marca + " " + pr.Precio);
            }
            Console.WriteLine("");
            Console.Write("Total:---------  " + total + " ----------------");
            ProductosSeleccionadosParaComprar.Clear();
            Clienteseleccionado = null;
            Console.WriteLine("Precione una tecla para continuar...");
            Console.ReadKey();
        }

        private void MenuAdministrador()
        {
            int opcion;
            do
            {
                Console.Clear();

                Console.WriteLine("1 Listar Productos del dia");
               // Console.WriteLine("2 Agregar producto");
               // Console.WriteLine("3.Registrar cliente");

                opcion = Convert.ToInt32(Console.ReadLine());
                OpcionesDelAdministrador(opcion);
            } while (opcion != 3);
        }

        private void OpcionesDelAdministrador(int opcion)
        {
            var RepVentas = new Repositorio<Venta>();
            var repClientes = new Repositorio<Cliente>();
            var repProductos = new Repositorio<Producto>();
            List<Venta> Listventas = RepVentas.TraerIncertadosHoy();
            switch (opcion)
            {
                case 1:
                    Console.WriteLine("Ventas realizadas en el dia de hoy");
                    foreach (Venta vent in Listventas)
                    {
                        Console.WriteLine("Producto " + repProductos.ObtenerPorId(vent.ProductoId).Nombre + "////// Nombre cliente que lo compro " + repClientes.ObtenerPorId(vent.ClienteID).Nombre +" /////// Fecha exacta : " +vent.Fechadeactualizaion2.ToString());
                    }
                    Console.WriteLine("Oprima una tecla para continuar...");
                    Console.ReadLine();
                    Console.Clear();
                    MenuAdministrador();
                    break;
                case 2:
                    Console.WriteLine("Oprima una tecla para continuar...");
                    string a = Console.ReadLine();
                    Console.WriteLine("Oprima una tecla para continuar...");
                    string b = Console.ReadLine();
                    Console.WriteLine("Oprima una tecla para continuar...");
                    string c = Console.ReadLine();
                    Console.WriteLine("Oprima una tecla para continuar...");
                    string d = Console.ReadLine();
                    Console.WriteLine("Oprima una tecla para continuar...");
                    string e = Console.ReadLine();
                    Console.WriteLine("Oprima una tecla para continuar...");
                    Producto pr = new Producto()
                    {

                    };

                    break;
                case 3:

                    break;
            }
        }

        public void ComparMAsOVerCarrito(int op = 1)
        {

        }

        private bool ComprarProductos(List<Producto> ProductosSeleccionadosParaComprar)
        {
            Repositorio<Venta> RepVenta = new Repositorio<Venta>();
            try
            {
                foreach (Producto pro in ProductosSeleccionadosParaComprar)
                {
                    Venta vent = new Venta()
                    {
                        ClienteID = Clienteseleccionado.id,
                        ProductoId = pro.id,
                        Cliente = Clienteseleccionado,
                        Producto = pro,
                    };
                    RepVenta.Agregar(vent);
                }
                VerCarritoDespuesDeCompra();

                return true;
            }
            catch (Exception)
            {

                return false;
            }

        }

        private Cliente QuienEselCliente()
        {
            Console.Clear();
            int intcli;
            
            var _RepCli = new Repositorio<Cliente>();
            List<Cliente> clientes = _RepCli.OptenerTodos();
            Console.WriteLine("");
            do
            {

                Console.WriteLine("Buenos dias ,Como quien quiere loguearse");
                Console.WriteLine();
                for (int i = 1; i < clientes.Count; i++)
                {
                    Console.WriteLine(i + ") " + clientes[i].Nombre + " " + clientes[i].Apellido);
                }
                Console.WriteLine(clientes.Count + 1 + ") Volver");
                


                int.TryParse(Console.ReadLine(), out intcli);
                if (intcli > clientes.Count+1)
                {
                    Console.WriteLine("solo tenias que apretar un numerito ....");
                    QuienEselCliente();
                    throw new ArgumentException();
                }
                if(intcli<=clientes.Count)
                {
                    return clientes[intcli];
                }
                else
                {
                    Console.Clear();
                    menuInicial();
                    throw new ArgumentException();
                }
            } while (intcli > clientes.Count);

        }
        public void CargarClientesyProductos()
        {
            Cliente cliente1 = new Cliente()
            {
                Nombre = "David",
                Apellido = "Cataneo",
                Dni = "3698968",
                Direccion = "Calle falsa 1234",
                Telefono = "11457896",

            };
            Cliente cliente2 = new Cliente()
            {
                Nombre = "Alan",
                Apellido = "Marengo",
                Dni = "428946",
                Direccion = "Calle falsa 1234",
                Telefono = "11457896",

            };
            Cliente cliente3 = new Cliente()
            {
                Nombre = "Matias",
                Apellido = "TuTurritoDeVar",
                Dni = "3698968",
                Direccion = "Calle falsa 1234",
                Telefono = "11457896",

            };
            Cliente cliente4 = new Cliente()
            {
                Nombre = "Emmanuel",
                Apellido = "Julio",
                Dni = "3698968",
                Direccion = "Calle falsa 1234",
                Telefono = "11457896",

            };
            Repositorio<Cliente> RepCli = new Repositorio<Cliente>();
            RepCli.Agregar(cliente1);
            RepCli.Agregar(cliente2);
            RepCli.Agregar(cliente3);
            RepCli.Agregar(cliente4);


            Producto producto1 = new Producto()
            {
                Nombre = "gaceosa",
                Marca = "cocalola",
                Precio = 14,
                Codigo = Random.Equals(988, 118447).ToString()

            };
            Producto producto2 = new Producto()
            {
                Nombre = "Pantalones",
                Marca = "Vans",
                Precio = 5884,
                Codigo = Random.Equals(988, 118447).ToString()

            };
            Producto producto3 = new Producto()
            {
                Nombre = "Remera",
                Marca = "Adidas",
                Precio = 5884,
                Codigo = Random.Equals(988, 118447).ToString()

            };
            Producto producto4 = new Producto()
            {
                Nombre = "Yerba",
                Marca = "Marolio",
                Precio = 5884,
                Codigo = Random.Equals(988, 118447).ToString()

            };
            Repositorio<Producto> RepProd = new Repositorio<Producto>();
            RepProd.Agregar(producto1);
            RepProd.Agregar(producto2);
            RepProd.Agregar(producto3);
            RepProd.Agregar(producto4);
        }


    }



}
