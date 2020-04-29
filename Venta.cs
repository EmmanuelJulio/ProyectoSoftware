using System;
using System.Collections.Generic;
using System.Text;

namespace ProyectoSoftware
{
    class Venta : Entidad
    {
        private int id1;
        private DateTime fechadeactualizaion2;
        private int clienteID;
        private int productoId;

        public virtual Producto Producto { get; set; }
        public virtual Cliente Cliente { get; set; }
     

        public int Id1 { get => id1; set => id1 = value; }
        public DateTime Fechadeactualizaion2 { get => fechadeactualizaion2; set => fechadeactualizaion2 = DateTime.Today; }
        public int ClienteID { get => clienteID; set => clienteID = value; }
        public int ProductoId { get => productoId; set => productoId = value; }
    }
}
