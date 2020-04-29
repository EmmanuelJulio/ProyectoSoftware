using System;
using System.Collections.Generic;
using System.Text;

namespace ProyectoSoftware
{
    public class Producto : Entidad
    {
        int id;
        DateTime Fechadeactualizaion;
        string codigo;
        string marca;
        string nombre;
        decimal precio;

        public int Id { get => id; set => id = value; }
        public DateTime Fechadeactualizaion1 { get => Fechadeactualizaion; set => Fechadeactualizaion = value; }
        public string Codigo { get => codigo; set => codigo = value; }
        public string Marca { get => marca; set => marca = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public decimal Precio { get => precio; set => precio = value; }
    }
}
