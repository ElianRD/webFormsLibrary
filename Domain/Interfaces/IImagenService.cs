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
        Task<string> GuardarImagenLibroAsync(HttpPostedFileBase archivo, int libroId);
        Task<string> GuardarImagenUsuarioAsync(HttpPostedFileBase archivo, int usuarioId);
        Task<string> GuardarImagenCategoriaAsync(HttpPostedFileBase archivo, int categoriaId);
        Task<bool> EliminarImagenAsync(string rutaImagen);
        bool ValidarArchivo(HttpPostedFile archivo, out string mensaje);

    }

}
