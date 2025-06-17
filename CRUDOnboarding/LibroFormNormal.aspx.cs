//using Domain.Entities;
//using Infrastructure.Context;

//using LibreriaApp.Services;
//using System;
//using System.IO;
//using System.Web.UI;
//using System.Web.UI.WebControls;

//namespace LibreriaApp
//{
//    public partial class LibroForm : System.Web.UI.Page
//    {
//        private readonly ImagenServiceNormal ImagenServiceNormalNormal;
//        private LibreriaContext _context;

//        public LibroForm()
//        {
//            ImagenServiceNormal = new ImagenServiceNormal();
//        }

//        protected void Page_Load(object sender, EventArgs e)
//        {
//            _context = new LibreriaContext();

//            if (!IsPostBack)
//            {
//                CargarDatos();
//            }
//        }

//        private void CargarDatos()
//        {
//            // Cargar dropdowns, etc.
//        }

//        // Evento para guardar un nuevo libro
//        protected void btnGuardarLibro_Click(object sender, EventArgs e)
//        {
//            try
//            {
//                var libro = new Libro
//                {
//                    Titulo = txtTitulo.Text.Trim(),
//                    ISBN = txtISBN.Text.Trim(),
//                    Descripcion = txtDescripcion.Text.Trim(),
//                    Precio = decimal.Parse(txtPrecio.Text),
//                    Stock = int.Parse(txtStock.Text),
//                    EditorialId = int.Parse(ddlEditorial.SelectedValue),
//                    // ... otras propiedades
//                };

//                // Guardar el libro primero para obtener el ID
//                _context.Libros.Add(libro);
//                _context.SaveChanges();

//                // Manejar la imagen si se subió una
//                if (fileUploadPortada.HasFile)
//                {
//                    string mensaje;
//                    if (ImagenServiceNormal.ValidarArchivo(fileUploadPortada.PostedFile, out mensaje))
//                    {
//                        string rutaImagen = ImagenServiceNormal.GuardarImagenLibro(fileUploadPortada.PostedFile, libro.Id);
//                        libro.ImagenPortada = rutaImagen;

//                        // Actualizar el libro con la ruta de la imagen
//                        _context.Entry(libro).State = System.Data.Entity.EntityState.Modified;
//                        _context.SaveChanges();

//                        // Mostrar la imagen en el preview
//                        imgPreview.ImageUrl = ResolveUrl(rutaImagen);
//                        imgPreview.Visible = true;
//                    }
//                    else
//                    {
//                        lblMensaje.Text = "Error en la imagen: " + mensaje;
//                        lblMensaje.CssClass = "alert alert-danger";
//                        return;
//                    }
//                }

//                lblMensaje.Text = "Libro guardado exitosamente";
//                lblMensaje.CssClass = "alert alert-success";
//                LimpiarFormulario();
//            }
//            catch (Exception ex)
//            {
//                lblMensaje.Text = "Error al guardar: " + ex.Message;
//                lblMensaje.CssClass = "alert alert-danger";
//            }
//        }

//        // Evento para actualizar libro existente
//        protected void btnActualizarLibro_Click(object sender, EventArgs e)
//        {
//            try
//            {
//                int libroId = int.Parse(hfLibroId.Value);
//                var libro = _context.Libros.Find(libroId);

//                if (libro == null)
//                {
//                    lblMensaje.Text = "Libro no encontrado";
//                    lblMensaje.CssClass = "alert alert-danger";
//                    return;
//                }

//                // Actualizar propiedades
//                libro.Titulo = txtTitulo.Text.Trim();
//                libro.ISBN = txtISBN.Text.Trim();
//                libro.Descripcion = txtDescripcion.Text.Trim();
//                libro.Precio = decimal.Parse(txtPrecio.Text);
//                libro.Stock = int.Parse(txtStock.Text);
//                // ... otras propiedades

//                // Manejar nueva imagen si se subió
//                if (fileUploadPortada.HasFile)
//                {
//                    string mensaje;
//                    if (ImagenServiceNormal.ValidarArchivo(fileUploadPortada.PostedFile, out mensaje))
//                    {
//                        // Eliminar imagen anterior
//                        if (!string.IsNullOrEmpty(libro.ImagenPortada))
//                        {
//                            ImagenServiceNormal.EliminarImagen(libro.ImagenPortada);
//                        }

//                        // Guardar nueva imagen
//                        string rutaImagen = ImagenServiceNormal.GuardarImagenLibro(fileUploadPortada.PostedFile, libro.Id);
//                        libro.ImagenPortada = rutaImagen;

//                        // Actualizar preview
//                        imgPreview.ImageUrl = ResolveUrl(rutaImagen);
//                        imgPreview.Visible = true;
//                    }
//                    else
//                    {
//                        lblMensaje.Text = "Error en la imagen: " + mensaje;
//                        lblMensaje.CssClass = "alert alert-danger";
//                        return;
//                    }
//                }

//                _context.Entry(libro).State = System.Data.Entity.EntityState.Modified;
//                _context.SaveChanges();

//                lblMensaje.Text = "Libro actualizado exitosamente";
//                lblMensaje.CssClass = "alert alert-success";
//            }
//            catch (Exception ex)
//            {
//                lblMensaje.Text = "Error al actualizar: " + ex.Message;
//                lblMensaje.CssClass = "alert alert-danger";
//            }
//        }

//        // Evento para preview de imagen antes de guardar
//        protected void fileUploadPortada_FileUploaded(object sender, EventArgs e)
//        {
//            if (fileUploadPortada.HasFile)
//            {
//                string mensaje;
//                if (ImagenServiceNormal.ValidarArchivo(fileUploadPortada.PostedFile, out mensaje))
//                {
//                    // Crear preview temporal
//                    string tempPath = "~/Temp/" + Guid.NewGuid().ToString() + Path.GetExtension(fileUploadPortada.FileName);
//                    string serverPath = Server.MapPath(tempPath);

//                    // Crear directorio temp si no existe
//                    Directory.CreateDirectory(Path.GetDirectoryName(serverPath));

//                    fileUploadPortada.SaveAs(serverPath);
//                    imgPreview.ImageUrl = ResolveUrl(tempPath);
//                    imgPreview.Visible = true;

//                    lblMensaje.Text = "Imagen cargada. Recuerde guardar el libro.";
//                    lblMensaje.CssClass = "alert alert-info";
//                }
//                else
//                {
//                    lblMensaje.Text = mensaje;
//                    lblMensaje.CssClass = "alert alert-danger";
//                    imgPreview.Visible = false;
//                }
//            }
//        }

//        // Evento para subir foto de perfil (Ajax)
//        protected void btnSubirFotoPerfil_Click(object sender, EventArgs e)
//        {
//            try
//            {
//                int clienteId = int.Parse(hfClienteId.Value);
//                var cliente = _context.Clientes.Find(clienteId);

//                if (cliente == null)
//                {
//                    Response.Write("Cliente no encontrado");
//                    return;
//                }

//                if (fileUploadFotoPerfil.HasFile)
//                {
//                    string mensaje;
//                    if (ImagenServiceNormal.ValidarArchivo(fileUploadFotoPerfil.PostedFile, out mensaje))
//                    {
//                        // Eliminar foto anterior
//                        if (!string.IsNullOrEmpty(cliente.FotoPerfil))
//                        {
//                            ImagenServiceNormal.EliminarImagen(cliente.FotoPerfil);
//                        }

//                        // Guardar nueva foto
//                        string rutaImagen = ImagenServiceNormal.GuardarImagenUsuario(fileUploadFotoPerfil.PostedFile, clienteId);
//                        cliente.FotoPerfil = rutaImagen;

//                        _context.Entry(cliente).State = System.Data.Entity.EntityState.Modified;
//                        _context.SaveChanges();

//                        // Para respuesta Ajax
//                        Response.Clear();
//                        Response.ContentType = "application/json";
//                        Response.Write("{\"success\": true, \"message\": \"Foto actualizada\", \"rutaImagen\": \"" + ResolveUrl(rutaImagen) + "\"}");
//                        Response.End();
//                    }
//                    else
//                    {
//                        Response.Clear();
//                        Response.ContentType = "application/json";
//                        Response.Write("{\"success\": false, \"message\": \"" + mensaje + "\"}");
//                        Response.End();
//                    }
//                }
//            }
//            catch (Exception ex)
//            {
//                Response.Clear();
//                Response.ContentType = "application/json";
//                Response.Write("{\"success\": false, \"message\": \"" + ex.Message + "\"}");
//                Response.End();
//            }
//        }

//        private void LimpiarFormulario()
//        {
//            txtTitulo.Text = "";
//            txtISBN.Text = "";
//            txtDescripcion.Text = "";
//            txtPrecio.Text = "";
//            txtStock.Text = "";
//            imgPreview.Visible = false;
//            // ... limpiar otros campos
//        }

//        protected void Page_Unload(object sender, EventArgs e)
//        {
//            _context?.Dispose();
//        }
//    }
//}