using System;
using ProyectoSoftware.Date;

namespace ProyectoSoftware
{
    class Program
    {
        static void Main(string[] args)
        {
            
            MenuUsuario Menu = MenuUsuario.GetMenu();
     //       Menu.CargarClientesyProductos();
           Menu.SeleccionDeModo(Menu.menuInicial());
        }
    }
}
