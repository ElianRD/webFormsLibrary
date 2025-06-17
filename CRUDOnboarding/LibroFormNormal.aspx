<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LibroForm.aspx.cs" Inherits="LibreriaApp.LibroForm" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Gestión de Libros</title>
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.1.3/dist/css/bootstrap.min.css" rel="stylesheet" />
    <style>
        .image-preview {
            max-width: 200px;
            max-height: 300px;
            border: 1px solid #ddd;
            padding: 5px;
            margin: 10px 0;
        }
        .file-upload-container {
            border: 2px dashed #ccc;
            border-radius: 10px;
            padding: 20px;
            text-align: center;
            margin: 10px 0;
        }
        .file-upload-container:hover {
            border-color: #007bff;
            background-color: #f8f9fa;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="container mt-4">
            <div class="row">
                <div class="col-md-8">
                    <div class="card">
                        <div class="card-header">
                            <h3>Información del Libro</h3>
                        </div>
                        <div class="card-body">
                            <!-- Mensaje de estado -->
                            <asp:Label ID="lblMensaje" runat="server" Visible="false"></asp:Label>
                            
                            <!-- Campo oculto para ID del libro (para edición) -->
                            <asp:HiddenField ID="hfLibroId" runat="server" />
                            
                            <!-- Título -->
                            <div class="mb-3">
                                <label for="txtTitulo" class="form-label">Título *</label>
                                <asp:TextBox ID="txtTitulo" runat="server" CssClass="form-control" MaxLength="200" required></asp:TextBox>
                            </div>
                            
                            <!-- ISBN -->
                            <div class="mb-3">
                                <label for="txtISBN" class="form-label">ISBN</label>
                                <asp:TextBox ID="txtISBN" runat="server" CssClass="form-control" MaxLength="13"></asp:TextBox>
                            </div>
                            
                            <!-- Descripción -->
                            <div class="mb-3">
                                <label for="txtDescripcion" class="form-label">Descripción</label>
                                <asp:TextBox ID="txtDescripcion" runat="server" CssClass="form-control" TextMode="MultiLine" Rows="4" MaxLength="1000"></asp:TextBox>
                            </div>
                            
                            <!-- Precio y Stock -->
                            <div class="row">
                                <div class="col-md-6">
                                    <div class="mb-3">
                                        <label for="txtPrecio" class="form-label">Precio *</label>
                                        <asp:TextBox ID="txtPrecio" runat="server" CssClass="form-control" TextMode="Number" step="0.01" required></asp:TextBox>
                                    </div>
                                </div>
                                <div class="col-md-6">
                                    <div class="mb-3">
                                        <label for="txtStock" class="form-label">Stock *</label>
                                        <asp:TextBox ID="txtStock" runat="server" CssClass="form-control" TextMode="Number" required></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                            
                            <!-- Editorial -->
                            <div class="mb-3">
                                <label for="ddlEditorial" class="form-label">Editorial *</label>
                                <asp:DropDownList ID="ddlEditorial" runat="server" CssClass="form-select" required>
                                    <asp:ListItem Text="Seleccione una editorial" Value="" />
                                </asp:DropDownList>
                            </div>
                            
                            <!-- Botones -->
                            <div class="d-grid gap-2 d-md-flex justify-content-md-end">
                                <asp:Button ID="btnGuardarLibro" runat="server" Text="Guardar Libro" CssClass="btn btn-primary" OnClick="btnGuardarLibro_Click" />
                                <asp:Button ID="btnActualizarLibro" runat="server" Text="Actualizar Libro" CssClass="btn btn-warning" OnClick="btnActualizarLibro_Click" Visible="false" />
                                <button type="button" class="btn btn-secondary" onclick="limpiarFormulario()">Limpiar</button>
                            </div>
                        </div>
                    </div>
                </div>
                
                <!-- Panel de imagen -->
                <div class="col-md-4">
                    <div class="card">
                        <div class="card-header">
                            <h5>Imagen de Portada</h5>
                        </div>
                        <div class="card-body">
                            <!-- Upload de imagen -->
                            <div class="file-upload-container">
                                <asp:FileUpload ID="fileUploadPortada" runat="server" CssClass="form-control" accept=".jpg,.jpeg,.png,.gif" />
                                <small class="form-text text-muted mt-2">
                                    Formatos permitidos: JPG, PNG, GIF<br/>
                                    Tamaño máximo: 5MB
                                </small>
                            </div>
                            
                            <!-- Preview de imagen -->
                            <div class="text-center">
                                <asp:Image ID="imgPreview" runat="server" CssClass="image-preview" Visible="false" />
                            </div>
                            
                            <!-- Botón para preview -->
                            <div class="d-grid mt-2">
                                <asp:Button ID="btnPreview" runat="server" Text="Vista Previa" CssClass="btn btn-outline-secondary btn-sm" OnClick="fileUploadPortada_FileUploaded" />
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            
            <!-- Panel para foto de perfil de cliente (ejemplo adicional) -->
            <div class="row mt-4">
                <div class="col-md-6">
                    <div class="card">
                        <div class="card-header">
                            <h5>Actualizar Foto de Perfil</h5>
                        </div>
                        <div class="card-body">
                            <asp:HiddenField ID="hfClienteId" runat="server" />
                            
                            <div class="mb-3">
                                <asp:FileUpload ID="fileUploadFotoPerfil" runat="server" CssClass="form-control" accept=".jpg,.jpeg,.png,.gif" />
                            </div>
                            
                            <div class="d-grid">
                                <asp:Button ID="btnSubirFotoPerfil" runat="server" Text="Actualizar Foto" CssClass="btn btn-success" OnClick="btnSubirFotoPerfil_Click" />
                            </div>
                            
                            <!-- Preview de foto de perfil -->
                            <div class="text-center mt-3">
                                <asp:Image ID="imgFotoPerfil" runat="server" CssClass="rounded-circle" Width="100" Height="100" Visible="false" />
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        
        <!-- Scripts -->
        <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.1.3/dist/js/bootstrap.bundle.min.js"></script>
        <script>
            // Función para limpiar formulario
            function limpiarFormulario() {
                document.getElementById('<%= txtTitulo.ClientID %>').value = '';
                document.getElementById('<%= txtISBN.ClientID %>').value = '';
                document.getElementById('<%= txtDescripcion.ClientID %>').value = '';
                document.getElementById('<%= txtPrecio.ClientID %>').value = '';
                document.getElementById('<%= txtStock.ClientID %>').value = '';
                document.getElementById('<%= ddlEditorial.ClientID %>').selectedIndex = 0;
                document.getElementById('<%= fileUploadPortada.ClientID %>').value = '';
                
                // Ocultar imagen preview
                var imgPreview = document.getElementById('<%= imgPreview.ClientID %>');
                if (imgPreview) imgPreview.style.display = 'none';
                
                // Limpiar mensaje
                var lblMensaje = document.getElementById('<%= lblMensaje.ClientID %>');
                if (lblMensaje) lblMensaje.style.display = 'none';
            }
            
            // Preview de imagen en cliente (opcional)
            document.getElementById('<%= fileUploadPortada.ClientID %>').addEventListener('change', function(e) {
                var file = e.target.files[0];
                if (file) {
                    var reader = new FileReader();
                    reader.onload = function(e) {
                        var imgPreview = document.getElementById('<%= imgPreview.ClientID %>');
                        imgPreview.src = e.target.result;
                        imgPreview.style.display = 'block';
                    }
                    reader.readAsDataURL(file);
                }
            });
            
            // Función para mostrar mensajes con auto-hide
            function mostrarMensaje(mensaje, tipo) {
                var lblMensaje = document.getElementById('<%= lblMensaje.ClientID %>');
                lblMensaje.innerText = mensaje;
                lblMensaje.className = 'alert alert-' + tipo;
                lblMensaje.style.display = 'block';
                
                // Auto-hide después de 5 segundos
                setTimeout(function() {
                    lblMensaje.style.display = 'none';
                }, 5000);
            }
        </script>
    </form>
</body>
</html>