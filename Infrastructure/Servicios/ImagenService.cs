using Domain.Interfaces;
using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Threading.Tasks;
using System.Web;

namespace Infrastructure.Servicios
{
    public class ImagenService : IImagenService
    {
        private readonly string _rutaBase;
        private readonly string[] _extensionesPermitidas = { ".jpg", ".jpeg", ".png", ".gif" };
        private readonly long _tamañoMaximo = 5 * 1024 * 1024; // 5MB

        public ImagenService()
        {
            // Ruta base para guardar imágenes
            _rutaBase = HttpContext.Current.Server.MapPath("~/Content/Images/");

            // Crear directorios si no existen
            CrearDirectorios();
        }

        private void CrearDirectorios()
        {
            string[] directorios = { "Libros", "Usuarios", "Categorias", "Autores"};

            foreach (var dir in directorios)
            {
                string rutaCompleta = Path.Combine(_rutaBase, dir);
                if (!Directory.Exists(rutaCompleta))
                {
                    Directory.CreateDirectory(rutaCompleta);
                }
            }
        }

        public async Task<string> GuardarImagenLibroAsync(HttpPostedFile archivo, int libroId)
        {
            return await GuardarImagenAsync(archivo, "Libros", $"libro_{libroId}");
        }

        public async Task<string> GuardarImagenUsuarioAsync(HttpPostedFile archivo, int usuarioId)
        {
            return await GuardarImagenAsync(archivo, "Usuarios", $"usuario_{usuarioId}");
        }
        public async Task<string> GuardarImagenAutorAsync(HttpPostedFile archivo, int autorId)
        {
            return await GuardarImagenAsync(archivo, "Autores", $"autores_{autorId}");
        }

        public async Task<string> GuardarImagenCategoriaAsync(HttpPostedFile archivo, int categoriaId)
        {
            return await GuardarImagenAsync(archivo, "Categorias", $"categoria_{categoriaId}");
        }

        private async Task<string> GuardarImagenAsync(HttpPostedFile archivo, string carpeta, string prefijo)
        {
            try
            {
                // Validaciones
                if (archivo == null || archivo.ContentLength == 0)
                    throw new ArgumentException("No se ha seleccionado ningún archivo");

                if (archivo.ContentLength > _tamañoMaximo)
                    throw new ArgumentException($"El archivo es demasiado grande. Máximo permitido: {_tamañoMaximo / (1024 * 1024)}MB");

                string extension = Path.GetExtension(archivo.FileName).ToLower();
                if (Array.IndexOf(_extensionesPermitidas, extension) == -1)
                    throw new ArgumentException("Formato de archivo no permitido. Use: " + string.Join(", ", _extensionesPermitidas));

                // Generar nombre único
                string nombreArchivo = $"{prefijo}_{DateTime.Now:yyyyMMddHHmmss}{extension}";
                string rutaCarpeta = Path.Combine(_rutaBase, carpeta);
                string rutaCompleta = Path.Combine(rutaCarpeta, nombreArchivo);

                // Leer el stream del archivo de forma asíncrona
                byte[] archivoBytes = new byte[archivo.ContentLength];
                await Task.Run(() => archivo.InputStream.Read(archivoBytes, 0, archivo.ContentLength));

                // Procesar imagen de forma asíncrona
                await Task.Run(() =>
                {
                    using (var memoryStream = new MemoryStream(archivoBytes))
                    using (var imagen = Image.FromStream(memoryStream))
                    {
                        var imagenRedimensionada = RedimensionarImagen(imagen, 800, 600);
                        imagenRedimensionada.Save(rutaCompleta, ObtenerFormatoImagen(extension));
                        imagenRedimensionada.Dispose();
                    }
                });

                // Retornar ruta relativa para guardar en BD
                return $"/Content/Images/{carpeta}/{nombreArchivo}";
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al guardar la imagen: {ex.Message}");
            }
        }

        private Image RedimensionarImagen(Image imagenOriginal, int anchoMaximo, int altoMaximo)
        {
            int nuevoAncho = imagenOriginal.Width;
            int nuevoAlto = imagenOriginal.Height;

            // Calcular nuevas dimensiones manteniendo proporción
            if (imagenOriginal.Width > anchoMaximo || imagenOriginal.Height > altoMaximo)
            {
                double ratioAncho = (double)anchoMaximo / imagenOriginal.Width;
                double ratioAlto = (double)altoMaximo / imagenOriginal.Height;
                double ratio = Math.Min(ratioAncho, ratioAlto);

                nuevoAncho = (int)(imagenOriginal.Width * ratio);
                nuevoAlto = (int)(imagenOriginal.Height * ratio);
            }

            var imagenRedimensionada = new Bitmap(nuevoAncho, nuevoAlto);
            using (var graphics = Graphics.FromImage(imagenRedimensionada))
            {
                graphics.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                graphics.DrawImage(imagenOriginal, 0, 0, nuevoAncho, nuevoAlto);
            }

            return imagenRedimensionada;
        }

        private ImageFormat ObtenerFormatoImagen(string extension)
        {
            switch (extension.ToLower())
            {
                case ".jpg":
                case ".jpeg":
                    return ImageFormat.Jpeg;
                case ".png":
                    return ImageFormat.Png;
                case ".gif":
                    return ImageFormat.Gif;
                default:
                    return ImageFormat.Jpeg;
            }
        }

        public async Task<bool> EliminarImagenAsync(string rutaImagen)
        {
            try
            {
                if (string.IsNullOrEmpty(rutaImagen)) return true;

                return await Task.Run(() =>
                {
                    string rutaCompleta = HttpContext.Current.Server.MapPath(rutaImagen);
                    if (File.Exists(rutaCompleta))
                    {
                        File.Delete(rutaCompleta);
                        return true;
                    }
                    return false;
                });
            }
            catch
            {
                return false;
            }
        }

        public bool ValidarArchivo(HttpPostedFile archivo, out string mensaje)
        {
            mensaje = "";

            if (archivo == null || archivo.ContentLength == 0)
            {
                mensaje = "No se ha seleccionado ningún archivo";
                return false;
            }

            if (archivo.ContentLength > _tamañoMaximo)
            {
                mensaje = $"El archivo es demasiado grande. Máximo permitido: {_tamañoMaximo / (1024 * 1024)}MB";
                return false;
            }

            string extension = Path.GetExtension(archivo.FileName).ToLower();
            if (Array.IndexOf(_extensionesPermitidas, extension) == -1)
            {
                mensaje = "Formato de archivo no permitido. Use: " + string.Join(", ", _extensionesPermitidas);
                return false;
            }

            return true;
        }
    }

}

