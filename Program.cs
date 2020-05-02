using System;
using ProyectoSoftware.Date;

namespace ProyectoSoftware
{
    class Program
    {
        static void Main(string[] args)
        {
            
            MenuUsuario Menu = MenuUsuario.GetMenu();
            // Menu.CargarClientesyProductos();
            MenuSimple menusimple = new MenuSimple();
            menusimple.Menu();
            //Menu.menuInicial();
        }
    }
}
