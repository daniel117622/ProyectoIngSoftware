using System;
using System.Collections.Generic;
using System.Text;

namespace BlankApp
{
    public class Platillo
    {
        public int Id 
        { get; set; }
        public string Nombre
        { get; set; }
        public string Descripcion
        { get; set; }
        public string Costo
        { get; set; }

        public Platillo(int Id, string Nombre, string Descripcion, string Costo)
        {  
            this.Id = Id;
            this.Nombre = Nombre;
            this.Descripcion = Descripcion;
            this.Costo = Costo;
        }  
    };
}
