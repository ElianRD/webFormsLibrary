using Domain.Entities;
using Domain.Interfaces;
using Infrastructure.Context;
using Infrastructure.Servicios;
using System;
using System.IO;
using System.Threading.Tasks;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LibreriaApp
{
    public partial class LibroForm : System.Web.UI.Page
    {
        private readonly IImagenService _imagenService;
        private LibreriaDbContext _context;

        public LibroForm()
        {
            // Fix: Explicitly cast ImagenService to IImagenService
            //_imagenService = (IImagenService)new ImagenService();
            _imagenService = new ImagenService();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            _context = new LibreriaDbContext();

            if (!IsPostBack)
            {
                CargarDatos();
            }
        }

        private void CargarDatos()
        {
            // Cargar dropdowns, etc.
        }

        // Evento para guardar un nuevo libro
        protected async void btnGuardarLibro_Click(object sender, EventArgs e)
        {
            try
            {
                var libro = new Libro
                {
                    Titulo = txtTitulo.Text.Trim(),
                    ISBN = txtISBN.Text.Trim(),
                    Descripcion = txtDescripcion.Text.Trim(),
                    Precio = decimal.Parse(txtPrecio.Text),
                    Stock = int.Parse(txtStock.Text),
                    EditorialId = int.Parse(ddlEditorial.SelectedValue),
                    // ... otras propiedades
                };

                _context.Libros.Add(libro);
                _context.SaveChanges();

                if (fileUploadPortada.HasFile)
                {
                    // Ya es un HttpPostedFile
                    HttpPostedFile archivo = fileUploadPortada.PostedFile;

                    // Aquí debes modificar tu método `GuardarImagenLibroAsync`
                    // para que acepte `HttpPostedFile` en lugar de `HttpPostedFileBase`
                    string rutaImagen = await _imagenService.GuardarImagenLibroAsync(archivo, libro.Id);

                    libro.ImagenPortada = rutaImagen;

                    _context.Entry(libro).State = System.Data.Entity.EntityState.Modified;
                    _context.SaveChanges();

                    imgPreview.ImageUrl = ResolveUrl(rutaImagen);
                    imgPreview.Visible = true;
                }

                lblMensaje.Text = "Libro guardado exitosamente";
                lblMensaje.CssClass = "alert alert-success";
                LimpiarFormulario();
            }
            catch (Exception ex)
            {
                lblMensaje.Text = "Error al guardar: " + ex.Message;
                lblMensaje.CssClass = "alert alert-danger";
            }
        }

     
        // Evento para actualizar libro existente
        protected async void btnActualizarLibro_Click(object sender, EventArgs e)
        {
            try
            {
                int libroId = int.Parse(hfLibroId.Value);
                var libro = _context.Libros.Find(libroId);

                if (libro == null)
                {
                    lblMensaje.Text = "Libro no encontrado";
                    lblMensaje.CssClass = "alert alert-danger";
                    return;
                }

                libro.Titulo = txtTitulo.Text.Trim();
                libro.ISBN = txtISBN.Text.Trim();
                libro.Descripcion = txtDescripcion.Text.Trim();
                libro.Precio = decimal.Parse(txtPrecio.Text);
                libro.Stock = int.Parse(txtStock.Text);
                // ... otras propiedades

                if (fileUploadPortada.HasFile)
                {
                    
                    HttpPostedFile archivoBase = fileUploadPortada.PostedFile;

                    // Eliminar imagen anterior si existe
                    if (!string.IsNullOrEmpty(libro.ImagenPortada))
                    {
                        await _imagenService.EliminarImagenAsync(libro.ImagenPortada);
                    }

                    string rutaImagen = await _imagenService.GuardarImagenLibroAsync(archivoBase, libro.Id);
                    libro.ImagenPortada = rutaImagen;

                    imgPreview.ImageUrl = ResolveUrl(rutaImagen);
                    imgPreview.Visible = true;
                }

                _context.Entry(libro).State = System.Data.Entity.EntityState.Modified;
                _context.SaveChanges();

                lblMensaje.Text = "Libro actualizado exitosamente";
                lblMensaje.CssClass = "alert alert-success";
            }
            catch (Exception ex)
            {
                lblMensaje.Text = "Error al actualizar: " + ex.Message;
                lblMensaje.CssClass = "alert alert-danger";
            }
        }

        // Evento para subir foto de perfil (Ajax)

        protected void fileUploadPortada_FileUploaded(object sender, EventArgs e)
        {
            if (fileUploadPortada.HasFile)
            {
                string mensaje;
                if (_imagenService.ValidarArchivo(fileUploadPortada.PostedFile, out mensaje))
                {
                    // Crear preview temporal
                    string tempPath = "~/Temp/" + Guid.NewGuid().ToString() + Path.GetExtension(fileUploadPortada.FileName);
                    string serverPath = Server.MapPath(tempPath);

                    // Crear directorio temp si no existe
                    Directory.CreateDirectory(Path.GetDirectoryName(serverPath));

                    fileUploadPortada.SaveAs(serverPath);
                    imgPreview.ImageUrl = ResolveUrl(tempPath);
                    imgPreview.Visible = true;

                    lblMensaje.Text = "Imagen cargada. Recuerde guardar el libro.";
                    lblMensaje.CssClass = "alert alert-info";
                }
                else
                {
                    lblMensaje.Text = mensaje;
                    lblMensaje.CssClass = "alert alert-danger";
                    imgPreview.Visible = false;
                }
            }
        }
        protected async void btnSubirFotoPerfil_Click(object sender, EventArgs e)
        {
            try
            {
                int clienteId = int.Parse(hfClienteId.Value);
                var cliente = _context.Clientes.Find(clienteId);

                if (cliente == null)
                {
                    Response.Write("Cliente no encontrado");
                    return;
                }

                if (fileUploadFotoPerfil.HasFile)
                {
                    
                    HttpPostedFile archivoBase = fileUploadPortada.PostedFile;


                    if (!string.IsNullOrEmpty(cliente.FotoPerfil))
                    {
                        await _imagenService.EliminarImagenAsync(cliente.FotoPerfil);
                    }

                    string rutaImagen = await _imagenService.GuardarImagenUsuarioAsync(archivoBase, clienteId);
                    cliente.FotoPerfil = rutaImagen;

                    _context.Entry(cliente).State = System.Data.Entity.EntityState.Modified;
                    _context.SaveChanges();

                    Response.Clear();
                    Response.ContentType = "application/json";
                    Response.Write("{\"success\": true, \"message\": \"Foto actualizada\", \"rutaImagen\": \"" + ResolveUrl(rutaImagen) + "\"}");
                    Response.End();
                }
            }
            catch (Exception ex)
            {
                Response.Clear();
                Response.ContentType = "application/json";
                Response.Write("{\"success\": false, \"message\": \"" + ex.Message + "\"}");
                Response.End();
            }
        }

        private void LimpiarFormulario()
        {
            txtTitulo.Text = "";
            txtISBN.Text = "";
            txtDescripcion.Text = "";
            txtPrecio.Text = "";
            txtStock.Text = "";
            imgPreview.Visible = false;
            // ... limpiar otros campos
        }

        protected void Page_Unload(object sender, EventArgs e)
        {
            _context?.Dispose();
        }
    }
}