using Negocio.Contrasenias;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using Negocio.Excepciones;

namespace Negocio.Persistencia.EntityFramework
{
    public class RepositorioContraseniasEntity : IRepositorio<Contrasenia>
    {
        public int Alta(Contrasenia entity)
        {
            using (Contexto context = new Contexto())
            {
                Existe(entity);
                entity.Categoria = context.Categorias.FirstOrDefault(c => c.Nombre == entity.Categoria.Nombre);
                context.Categorias.Attach(entity.Categoria);
                context.Contrasenias.Add(entity);
                context.SaveChanges();
                return entity.ContraseniaId;
               
           
            }
        }

        public void Baja(Contrasenia entity)
        {
            using (Contexto context = new Contexto())
            {
                Contrasenia aEliminar = context.Contrasenias.FirstOrDefault(c => c.ContraseniaId == entity.ContraseniaId);

                if (aEliminar != null) 
                { 
                    context.Passwords.Remove(aEliminar.Password);
                    context.Contrasenias.Remove(aEliminar);
                    context.SaveChanges();
                }
                else throw new ExcepcionElementoNoExiste("Error: Contraseña No Existe !!!");
            }
        }

        public Contrasenia Buscar(Contrasenia entity)
        {
            using (Contexto context = new Contexto())
            {
                Contrasenia existe = context.Contrasenias.Include(t => t.Categoria).Include(t => t.Password).FirstOrDefault(t => t.ContraseniaId == entity.ContraseniaId);
                if (existe != null) return existe;
                throw new ExcepcionElementoNoExiste("No existe Contrasenia!");
            }
        }

        public void Existe(Contrasenia entity)
        {
            using (Contexto context = new Contexto())
            {
               Contrasenia existe = context.Contrasenias.FirstOrDefault(c => c.Sitio == entity.Sitio && c.Usuario == entity.Usuario);
               if (existe != null)
                    throw new ExcepcionElementoYaExiste("Ya existe Contraseña con ese Sitio y Usuario.");
            }
        }

        public void Modificar(Contrasenia entity)
        {
            using (Contexto context = new Contexto())
            {
                Contrasenia aModificar = context.Contrasenias.Include(t => t.Categoria).Include(t => t.Password).FirstOrDefault(t => t.ContraseniaId == entity.ContraseniaId);
                aModificar.ContraseniaId = entity.ContraseniaId;
                
                if(aModificar.Sitio != entity.Sitio || aModificar.Usuario != entity.Usuario) Existe(entity);

                aModificar.Sitio = entity.Sitio;
                aModificar.Usuario = entity.Usuario;

                if (!aModificar.Password.Equals(entity.Password))
                {
                    aModificar.Password = entity.Password;
                    aModificar.FechaUltimaModificacion = DateTime.Now;
                }

                aModificar.Categoria = context.Categorias.FirstOrDefault(c => c.Nombre == entity.Categoria.Nombre);
                aModificar.CantidadVecesEncontradaVulnerable = entity.CantidadVecesEncontradaVulnerable;
                aModificar.Notas = entity.Notas;
                context.Categorias.Attach(aModificar.Categoria);
                context.SaveChanges();
               
              
            }
        }

        public IEnumerable<Contrasenia> ObtenerTodas()
        {
            using (Contexto context = new Contexto())
            {
                List<Contrasenia> retorno;
                retorno = context.Contrasenias.Include(c => c.Password).Include(c => c.Categoria).ToList();
                retorno.Sort();
                return retorno;
            }
        }

        public void TestClear()
        {
               using (Contexto context = new Contexto())
                {
                    context.Tarjetas.RemoveRange(context.Tarjetas);
                    context.Passwords.RemoveRange(context.Passwords);
                    context.Contrasenias.RemoveRange(context.Contrasenias);
                    context.Categorias.RemoveRange(context.Categorias);
                    context.HistorialTarjeta.RemoveRange(context.HistorialTarjeta);
                    context.HistorialContrasenia.RemoveRange(context.HistorialContrasenia);
                    context.Historials.RemoveRange(context.Historials);
                    context.SaveChanges();
                }
   
        }
    }
}
