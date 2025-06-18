using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Domain.Interfaces
{
    public interface IImagenService
    {
        Task<string> GuardarImagenLibroAsync(HttpPostedFile archivo, int libroId);
        Task<string> GuardarImagenUsuarioAsync(HttpPostedFile archivo, int usuarioId);
        Task<string> GuardarImagenCategoriaAsync(HttpPostedFile archivo, int categoriaId);

        Task<string> GuardarImagenAutorAsync(HttpPostedFile archivo, int autorId);

        Task<bool> EliminarImagenAsync(string rutaImagen);
        bool ValidarArchivo(HttpPostedFile archivo, out string mensaje);

    }

}
