﻿
namespace Negocio.Categorias
{
    public class Categoria
    {
        
        public int Id { get; set; }
        public string Nombre { get; set; }
        
        public Categoria(string nombre)
        {
            this.Nombre = nombre;
        }
        public Categoria(string nombre, int id) :this(nombre)
        {
            this.Id = id;
        }
        
        public override string ToString()
        {
            return this.Nombre;
        }

    }
}
