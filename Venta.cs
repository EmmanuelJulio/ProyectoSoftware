using System;
using System.Collections.Generic;
using System.Text;

namespace ProyectoSoftware
{
    class Venta : Entidad
    {
        private int id1;
        private DateTime fechadeactualizaion2;
     

        public virtual Producto ProductoNavigator { get; set; }
        public virtual Cliente ClienteNavigator { get; set; }
     

        public int Id1 { get => id1; set => id1 = value; }
        public DateTime Fechadeactualizaion2 { get => fechadeactualizaion2; set => fechadeactualizaion2 = value; }
      
    }
}
