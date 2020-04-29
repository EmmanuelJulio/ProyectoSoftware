using System;
using System.Collections.Generic;
using System.Text;

namespace ProyectoSoftware
{
     public  class Entidad
    {
        public int id;
        public DateTime Fechadeactualizaion;

        public int Id { get => id; set => id = value; }
        public DateTime Fechadeactualizaion1 { get => Fechadeactualizaion; set => Fechadeactualizaion = value; }
    }
}
