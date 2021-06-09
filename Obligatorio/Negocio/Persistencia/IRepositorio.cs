using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio.Persistencia
{
    public interface IRepositorio<T>
    {

        //T Get(int id);
        T Buscar(T entity);
        IEnumerable<T> ObtenerTodas();
        int Alta(T entity);
        void Baja(T entity);
        void Modificar(T entity);
        void Existe(T entity);
        void TestClear();

    }
}
