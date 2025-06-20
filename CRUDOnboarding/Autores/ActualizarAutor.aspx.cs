using Application.UseCases;
using Domain.Entities;
using Domain.Interfaces;
using Infrastructure.Context;
using Infrastructure.Repositories;
using Infrastructure.Servicios;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CRUDOnboarding.Autores
{
     public partial class ActualizarAutor : System.Web.UI.Page
    {
        private readonly IImagenService _imagenService;
        private LibreriaDbContext _context;

        public ActualizarAutor()
        {

            _imagenService = new ImagenService();
        }




        // Evento para guardar un nuevo libro
        //protected async void btnGuardarLibro_Click(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        var libro = new Libro
        //        {
        //            Titulo = txtTitulo.Text.Trim(),
        //            ISBN = txtISBN.Text.Trim(),
        //            Descripcion = txtDescripcion.Text.Trim(),
        //            Precio = decimal.Parse(txtPrecio.Text),
        //            Stock = int.Parse(txtStock.Text),
        //            EditorialId = int.Parse(ddlEditorial.SelectedValue),
        //            // ... otras propiedades
        //        };

        //        _context.Libros.Add(libro);
        //        _context.SaveChanges();

        //        if (fileUploadPortada.HasFile)
        //        {
        //            // Convertir a HttpPostedFileBase
        //            HttpPostedFileBase archivoBase = new HttpPostedFileWrapper(fileUploadPortada.PostedFile);

        //            string rutaImagen = await _imagenService.GuardarImagenLibroAsync(archivoBase, libro.Id);
        //            libro.ImagenPortada = rutaImagen;

        //            _context.Entry(libro).State = System.Data.Entity.EntityState.Modified;
        //            _context.SaveChanges();

        //            imgPreview.ImageUrl = ResolveUrl(rutaImagen);
        //            imgPreview.Visible = true;
        //        }

        //        lblMensaje.Text = "Libro guardado exitosamente";
        //        lblMensaje.CssClass = "alert alert-success";
        //        LimpiarFormulario();
        //    }
        //    catch (Exception ex)
        //    {
        //        lblMensaje.Text = "Error al guardar: " + ex.Message;
        //        lblMensaje.CssClass = "alert alert-danger";
        //    }
        //}

        private AutoresUseCase CrearAutoresUseCase()
        {
            var context = new LibreriaDbContext();
            var repo = new AutorRepository(context);
            return new AutoresUseCase(repo);
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            _context = new LibreriaDbContext(); // Initialize your DbContext

            if (!IsPostBack)
            {
                // If you have any initial data to load for dropdowns or fields (e.g., for editing an existing author)
                // you would do it here. For a new author, these fields would typically be empty.
                if (Request.QueryString["id"] != null)
                {
                    int autorId = int.Parse(Request.QueryString["id"]);
                    CargarAutorParaEdicion(autorId);
                }
            }
            if (!IsPostBack)
            {
                if (Session["AutorSeleccionadoId"] != null)
                {
                    int id = (int)Session["AutorSeleccionadoId"];

                    
                        var autor = _context.Autores.FirstOrDefault(l => l.Id == id);
                        if (autor != null)
                        {
                        CargarAutorParaEdicion(id);
                    }
                        else
                        {
                            lblMensaje.Text = "autor no encontrado.";
                        }
                    
                }
                else
                {
                    lblMensaje.Text = "No se seleccionó ningún autor.";
                }
            }

        }

        private void CargarAutorParaEdicion(int autorId)
        {
            var autor = _context.Autores.Find(autorId);
            if (autor != null)
            {
                hfAutorId.Value = autor.Id.ToString();
                txtNombre.Text = autor.Nombre;
                txtApellido.Text = autor.Apellido;
                txtBiografia.Text = autor.Biografia;
                if (autor.FechaNacimiento.HasValue)
                {
                    txtFechaNacimiento.Text = autor.FechaNacimiento.Value.ToString("yyyy-MM-dd");
                }
                txtNacionalidad.Text = autor.Nacionalidad;

                if (!string.IsNullOrEmpty(autor.FotoPerfil))
                {
                    imgPreview.ImageUrl = ResolveUrl(autor.FotoPerfil);
                    imgPreview.Visible = true;
                }

                btnGuardarAutor.Visible = false;
                btnActualizarAutor.Visible = true;
            }
            else
            {
                lblMensaje.Text = "Autor no encontrado.";
                lblMensaje.CssClass = "alert alert-danger";
            }
        }

        // Evento para guardar un nuevo autor
        protected async void btnGuardarAutor_Click(object sender, EventArgs e)
        {
            try
            {
                var autor = new Autor
                {
                    Nombre = txtNombre.Text.Trim(),
                    Apellido = txtApellido.Text.Trim(),
                    Biografia = txtBiografia.Text.Trim(),
                    Nacionalidad = txtNacionalidad.Text.Trim()
                };

                // Parse FechaNacimiento if provided
                if (!string.IsNullOrWhiteSpace(txtFechaNacimiento.Text))
                {
                    if (DateTime.TryParse(txtFechaNacimiento.Text, out DateTime fechaNacimiento))
                    {
                        autor.FechaNacimiento = fechaNacimiento;
                    }
                    else
                    {
                        lblMensaje.Text = "Formato de fecha de nacimiento inválido.";
                        lblMensaje.CssClass = "alert alert-danger";
                        return;
                    }
                }

                // Save the author first to get the ID for image association
                _context.Autores.Add(autor);
                _context.SaveChanges();

                // Handle the image if one was uploaded
                if (fileUploadFotoPerfil.HasFile)
                {
                    HttpPostedFile archivo = fileUploadFotoPerfil.PostedFile;
                    string mensaje;
                    // Assuming GuardarImagenAutor is similar to GuardarImagenUsuario or GuardarImagenLibro
                    // You might need to adjust the ImagenService method signature if it's strictly for "Libro" or "Usuario".
                    // Here, I'm assuming you have a generic or adapted method.
                    if (_imagenService.ValidarArchivo(archivo, out mensaje))
                    {
                        // Pass a meaningful identifier for the folder, e.g., "Autores" and the author's ID
                        string rutaImagen = await _imagenService.GuardarImagenAutorAsync(archivo, autor.Id);
                        autor.FotoPerfil = rutaImagen;

                        // Update the author with the image path
                        _context.Entry(autor).State = System.Data.Entity.EntityState.Modified;
                        _context.SaveChanges();

                        // Show the image in the preview
                        imgPreview.ImageUrl = ResolveUrl(rutaImagen);
                        imgPreview.Visible = true;
                    }
                    else
                    {
                        lblMensaje.Text = "Error en la imagen: " + mensaje;
                        lblMensaje.CssClass = "alert alert-danger";
                        return;
                    }
                }

                lblMensaje.Text = "Autor guardado exitosamente";
                lblMensaje.CssClass = "alert alert-success";
                LimpiarFormulario();
            }
            catch (Exception ex)
            {
                lblMensaje.Text = "Error al guardar: " + ex.Message;
                lblMensaje.CssClass = "alert alert-danger";
            }
        }

        // Evento para actualizar autor existente
        protected async void btnActualizarAutor_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(hfAutorId.Value))
                {
                    lblMensaje.Text = "ID del autor no proporcionado para la actualización.";
                    lblMensaje.CssClass = "alert alert-danger";
                    return;
                }

                int autorId = int.Parse(hfAutorId.Value);
                var autor = _context.Autores.Find(autorId);

                if (autor == null)
                {
                    lblMensaje.Text = "Autor no encontrado";
                    lblMensaje.CssClass = "alert alert-danger";
                    return;
                }

                // Update properties
                autor.Nombre = txtNombre.Text.Trim();
                autor.Apellido = txtApellido.Text.Trim();
                autor.Biografia = txtBiografia.Text.Trim();
                autor.Nacionalidad = txtNacionalidad.Text.Trim();

                // Parse FechaNacimiento if provided
                //if (!string.IsNullOrWhiteSpace(txtFechaNacimiento.Text))
                //{
                //    if (DateTime.TryParse(txtFechaNacimiento.Text, out DateTime fechaNacimiento))
                //    {
                //        autor.FechaNacimiento = fechaNacimiento;
                //    }
                //    else
                //    {
                //        lblMensaje.Text = "Formato de fecha de nacimiento inválido.";
                //        lblMensaje.CssClass = "alert alert-danger";
                //        return;
                //    }
                //}
                //else
                //{
                //    autor.FechaNacimiento = null; // Clear if empty
                //}

                //Handle new image if one was uploaded
                if (fileUploadFotoPerfil.HasFile)
                {
                    HttpPostedFile archivo = fileUploadFotoPerfil.PostedFile;
                    string mensaje;
                    if (_imagenService.ValidarArchivo(archivo, out mensaje))
                    {
                        // Delete previous image
                        //if (!string.IsNullOrEmpty(autor.FotoPerfil))
                        //{
                        //    await _imagenService.EliminarImagen(autor.FotoPerfil);
                        //}
                        string rutaImagen = await _imagenService.GuardarImagenAutorAsync(archivo, autor.Id);
                        //autor.FotoPerfil = rutaImagen;

                        // Save new image
                        //string rutaImagen = _imagenService.GuardarImagen("Autores", fileUploadFotoPerfil.PostedFile, autor.Id);
                        autor.FotoPerfil = rutaImagen;

                        // Update preview
                        imgPreview.ImageUrl = ResolveUrl(rutaImagen);
                        imgPreview.Visible = true;
                    }
                    else
                    {
                        lblMensaje.Text = "Error en la imagen: " + mensaje;
                        lblMensaje.CssClass = "alert alert-danger";
                        return;
                    }
                }

                _context.Entry(autor).State = EntityState.Modified;
                await _context.SaveChangesAsync();

                lblMensaje.Text = "Autor actualizado exitosamente";
                lblMensaje.Visible = true;
                lblMensaje.CssClass = "alert alert-success";
            }
            catch (Exception ex)
            {
                lblMensaje.Text = "Error al actualizar: " + ex.Message;
                lblMensaje.CssClass = "alert alert-danger";
            }
        }

        // Event to preview image before saving (client-side preview is also handled by JS)
        protected void fileUploadFotoPerfil_FileUploaded(object sender, EventArgs e)
        {
            if (fileUploadFotoPerfil.HasFile)
            {
                string mensaje;
                if (_imagenService.ValidarArchivo(fileUploadFotoPerfil.PostedFile, out mensaje))
                {
                    // Create temporary preview
                    string tempPath = "~/Temp/" + Guid.NewGuid().ToString() + Path.GetExtension(fileUploadFotoPerfil.FileName);
                    string serverPath = Server.MapPath(tempPath);

                    // Create temp directory if it doesn't exist
                    Directory.CreateDirectory(Path.GetDirectoryName(serverPath));

                    fileUploadFotoPerfil.SaveAs(serverPath);
                    imgPreview.ImageUrl = ResolveUrl(tempPath);
                    imgPreview.Visible = true;

                    lblMensaje.Text = "Imagen cargada. Recuerde guardar el autor.";
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

        private void LimpiarFormulario()
        {
            txtNombre.Text = "";
            txtApellido.Text = "";
            txtBiografia.Text = "";
            txtFechaNacimiento.Text = "";
            txtNacionalidad.Text = "";
            hfAutorId.Value = ""; // Clear hidden field for new entries
            imgPreview.Visible = false;
            // Additional cleanup if needed for message labels or buttons visibility
            btnGuardarAutor.Visible = true;
            btnActualizarAutor.Visible = false;
            lblMensaje.Visible = false;
        }

        protected void Page_Unload(object sender, EventArgs e)
        {
            _context?.Dispose();
        }

    }
}