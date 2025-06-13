using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IGenericRepo<T>
    {
        /// <summary>
        /// Obtiene todos los elementos de forma asíncrona.
        /// </summary>
        Task<IEnumerable<T>> ObtenerTodos();

        /// <summary>
        /// Obtiene un elemento por su identificador de forma asíncrona.
        /// </summary>
        Task<T> ObtenerPorId(int id);

        /// <summary>
        /// Agrega un nuevo elemento de forma asíncrona.
        /// </summary>
        Task Agregar(T entidad);

        /// <summary>
        /// Edita un elemento existente de forma asíncrona.
        /// </summary>
        Task Editar(T entidad);

        /// <summary>
        /// Elimina un elemento por su identificador de forma asíncrona.
        /// </summary>
        Task Eliminar(int id);
    }
}
