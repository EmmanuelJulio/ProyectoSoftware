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
        public static MenuUsuario instans=null;
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

        public int menuInicial()
        {
            Console.WriteLine("Bienvenido ,Como decea ingresar?");
            Console.WriteLine("1 Ingresar como cliente");
            Console.WriteLine("2 ingresar como vendedor");
            int opcion;
            try
            {
                int.TryParse(Console.ReadLine(), out (opcion));
                return opcion;

            }
            catch (Exception)
            {
                Console.Clear();
                Console.WriteLine("Debe ingresar un numero");
                menuInicial();
                throw new ArgumentException();
            }

           
        }
        public void SeleccionDeModo(int opcion)
        {
            switch (opcion)
            {
                case 1:
                    MenuCliente();
                    break;
                case 2:
                    MenuAdministrador();
                    break;
            }
        }

        private void MenuAdministrador()
        {
            throw new NotImplementedException();
        }

        public void MenuCliente()
        {
            Clienteseleccionado = QuienEselCliente();
            Console.WriteLine("Bienvenido ,Señor " + Clienteseleccionado.Nombre+" "+Clienteseleccionado.Apellido);
            Console.WriteLine("1 Comprar Productos");
            Console.WriteLine("2 VerProductosComprados");
            int opcion;
            opcion = Convert.ToInt32(Console.ReadLine());
            ComparMAsOVerCarrito(opcion);
           


        }
        public void ComparMAsOVerCarrito(int op=1)
        {
            switch (op)
            {
                case 1:
                    Console.WriteLine("--------Añada cuantos productos quiera comprar (para finalizar ingrese 0)--------");
                    if (ComprarProductos(ListarProductos()))
                        Console.WriteLine("su compra fue realizada");
                    else
                        Console.WriteLine("este codigo es una verga....");
                    break;
                case 2:
                    if (ProductosSeleccionadosParaComprar.Count>0)
                    {
                        Console.WriteLine("Actualmente tiene estos productos en el carrito");
                        decimal total = 0;
                        foreach (Producto pr in ProductosSeleccionadosParaComprar)
                        {
                            total += pr.Precio;
                            Console.WriteLine(pr.Nombre + " " + pr.Marca + " " + pr.Precio);

                        }
                        Console.Write("Total " + total);
                       
                    }
                    else
                    {
                        Console.WriteLine("No tiene productos en el carrito");
                    }

                    Console.WriteLine("Seguir comprando y/n");
                    string op2 = Console.ReadLine();

                    if (op2 == "y")
                        ComparMAsOVerCarrito(1);
                    else
                        ComparMAsOVerCarrito(3);


                    break;
                case 3:
                    ComprarProductos(ProductosSeleccionadosParaComprar);
                    break;
            }
        }

        private bool ComprarProductos(List<Producto> list)
        {
            Repositorio<Venta> RepVenta = new Repositorio<Venta>();
            try
            {
                foreach (Producto pro in list)
                {
                    Venta vent = new Venta()
                    {
                        ClienteNavigator = Clienteseleccionado,
                        ProductoNavigator = pro,
                    };
                    RepVenta.Agregar(vent);
                }
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        private List<Producto> ListarProductos()
        {
            var RepProd = new Repositorio<Producto>();
            List<Producto> ProductosAgregados = new List<Producto>();
            List<Producto> LisProd = RepProd.OptenerTodos();
            for(int i=0;i< LisProd.Count; i++)
            {
                
                Console.WriteLine(i + ")_ " + LisProd[i].Nombre + " " + LisProd[i].Marca + " " + LisProd[i].Precio);
            }
            int opcion = Convert.ToInt32(Console.ReadLine());
            do
            {
                int opcion2 = Convert.ToInt32(Console.ReadLine());
                ProductosSeleccionadosParaComprar.Add(LisProd[opcion]);
                Console.WriteLine("Se Agrego el producto "+LisProd[opcion].Nombre);
             } while (opcion<LisProd.Count);
            return ProductosAgregados;

             }

        private Cliente QuienEselCliente()
        {
            var _RepCli = new Repositorio<Cliente>();
           List<Cliente> clientes = _RepCli.OptenerTodos();
            Console.WriteLine("quien es usted");
          for(int i = 1; i < clientes.Count; i++)
            {
                Console.WriteLine(i + ")_ " +clientes[i].Nombre + " " + clientes[i].Apellido);
            }

            int intcli;

            int.TryParse(Console.ReadLine(),out intcli);
           if (intcli> clientes.Count)
            {
                Console.WriteLine("solo tenias que apretar un numerito ....");
                QuienEselCliente();
                throw new ArgumentException();
            }
            else
            {
                return clientes[intcli];
            }
        
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
