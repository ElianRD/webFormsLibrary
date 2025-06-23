<%@ Page Title="CrearAutores" Language="C#" Async="true" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="CrearAutor.aspx.cs" Inherits="CRUDOnboarding.Autores.CrearAutor" %>

<asp:Content ID="HeadCrearAutor" ContentPlaceHolderID="head" runat="server">
    <title>Gestión de Autores</title>
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

        .tab-menu {
            display: flex;
            border-bottom: 1px solid #ddd;
            margin: 20px 0;
        }

            .tab-menu a {
                padding: 10px 20px;
                text-decoration: none;
                color: #1d4ed8;
                font-weight: bold;
                border-bottom: 3px solid transparent;
                transition: 0.3s;
            }

                .tab-menu a.active {
                    color: #000;
                    border-bottom: 3px solid #1d4ed8;
                }

            .tab-menu :hover {
                color: #1d4ed8;
            }

            .tab-menu a:hover {
                color: black;
            }

            .tab-menu .active:hover {
                color: #1d4ed8;
            }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent1" runat="server">



    <h1>Crear Autor</h1>
    <div class="tab-menu">
        <a href="/Autores/Autores" >Lista de autores</a>
        <a href="#" class="active">crear autor</a>
    </div>
 
    <form id="form1" runat="server">
        <div class="container mt-4">
            <div class="row">
                <div class="col-md-8">
                    <div class="card">
                        <div class="card-header">
                            <h3>Información del Autor</h3>
                        </div>
                        <div class="card-body">
                            <asp:Label ID="lblMensaje" runat="server" Visible="false"></asp:Label>

                            <asp:HiddenField ID="hfAutorId" runat="server" />

                            <div class="mb-3">
                                <label for="txtNombre" class="form-label">Nombre *</label>
                                <asp:TextBox ID="txtNombre" runat="server" CssClass="form-control" MaxLength="100"></asp:TextBox>
                            </div>

                            <div class="mb-3">
                                <label for="txtApellido" class="form-label">Apellido *</label>
                                <asp:TextBox ID="txtApellido" runat="server" CssClass="form-control" MaxLength="100"></asp:TextBox>
                            </div>

                            <div class="mb-3">
                                <label for="txtBiografia" class="form-label">Biografía</label>
                                <asp:TextBox ID="txtBiografia" runat="server" CssClass="form-control" TextMode="MultiLine" Rows="4" MaxLength="1000"></asp:TextBox>
                            </div>

                            <div class="row">
                                <div class="col-md-6">
                                    <div class="mb-3">
                                        <label for="txtFechaNacimiento" class="form-label">Fecha de Nacimiento</label>
                                        <asp:TextBox ID="txtFechaNacimiento" runat="server" CssClass="form-control" TextMode="Date"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="col-md-6">
                                    <div class="mb-3">
                                        <label for="txtNacionalidad" class="form-label">Nacionalidad</label>
                                        <asp:TextBox ID="txtNacionalidad" runat="server" CssClass="form-control" MaxLength="100"></asp:TextBox>
                                    </div>
                                </div>
                            </div>

                            <div class="d-grid gap-2 d-md-flex justify-content-md-end">
                                <asp:Button ID="btnGuardarAutor" runat="server" Text="Guardar Autor" CssClass="btn btn-primary" OnClick="btnGuardarAutor_Click" />
                                <asp:Button ID="btnActualizarAutor" runat="server" Text="Actualizar Autor" CssClass="btn btn-warning" OnClick="btnActualizarAutor_Click" Visible="false" />
                                <button type="button" class="btn btn-secondary" onclick="limpiarFormulario()">Limpiar</button>
                            </div>
                        </div>
                    </div>
                </div>

                <div class="col-md-4">
                    <div class="card">
                        <div class="card-header">
                            <h5>Foto de Perfil del Autor</h5>
                        </div>
                        <div class="card-body">
                            <div class="file-upload-container">
                                <asp:FileUpload ID="fileUploadFotoPerfil" runat="server" CssClass="form-control" accept=".jpg,.jpeg,.png,.gif" />
                                <small class="form-text text-muted mt-2">Formatos permitidos: JPG, PNG, GIF<br />
                                    Tamaño máximo: 5MB
                                </small>
                            </div>

                            <div class="text-center">
                                <asp:Image ID="imgPreview" runat="server" CssClass="image-preview" Visible="false" />
                            </div>

                            <div class="d-grid mt-2">
                                <asp:Button ID="btnPreview" runat="server" Text="Vista Previa" CssClass="btn btn-outline-secondary btn-sm" OnClick="fileUploadFotoPerfil_FileUploaded" />
                            </div>
                        </div>
                    </div>
                </div>
            </div>

        </div>

        <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.1.3/dist/js/bootstrap.bundle.min.js"></script>
        <script>
            // Función para limpiar formulario
            function limpiarFormulario() {
                document.getElementById('<%= txtNombre.ClientID %>').value = '';
                document.getElementById('<%= txtApellido.ClientID %>').value = '';
                document.getElementById('<%= txtBiografia.ClientID %>').value = '';
                document.getElementById('<%= txtFechaNacimiento.ClientID %>').value = '';
                document.getElementById('<%= txtNacionalidad.ClientID %>').value = '';
                document.getElementById('<%= fileUploadFotoPerfil.ClientID %>').value = '';

                // Ocultar imagen preview
                var imgPreview = document.getElementById('<%= imgPreview.ClientID %>');
                if (imgPreview) imgPreview.style.display = 'none';

                // Limpiar mensaje
                var lblMensaje = document.getElementById('<%= lblMensaje.ClientID %>');
                if (lblMensaje) lblMensaje.style.display = 'none';
            }

            // Preview de imagen en cliente (opcional)
            document.getElementById('<%= fileUploadFotoPerfil.ClientID %>').addEventListener('change', function (e) {
                var file = e.target.files[0];
                if (file) {
                    var reader = new FileReader();
                    reader.onload = function (e) {
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
                setTimeout(function () {
                    lblMensaje.style.display = 'none';
                }, 5000);
            }
        </script>
    </form>
</asp:Content>
