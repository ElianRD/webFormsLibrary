<%@ Page Title="" Async="true" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Autores.aspx.cs" Inherits="CRUDOnboarding.Autores.Autores" %>


<asp:Content ID="HeadCrearAutor" ContentPlaceHolderID="head" runat="server">
    <title>Gestión de Autores</title>
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.1.3/dist/css/bootstrap.min.css" rel="stylesheet" />
    <style>
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

                .tab-menu a:hover {
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
<asp:Content ID="ContentAutores" ContentPlaceHolderID="MainContent1" runat="server">



    <h1>Panel de Autores</h1>
    <div class="tab-menu">
        <a href="#" class="active">Lista de autores</a>
        <a href="/Autores/CrearAutor">crear autores</a>
    </div>
    <%-- <div class="row my-4">
        <div class="col-md-3">
            <div class="card text-white bg-primary mb-3">
                <div class="card-body">
                    <h5 class="card-title">Total Libros</h5>
                    <p class="card-text">1,250</p>
                </div>
            </div>
        </div>
        <div class="col-md-3">
            <div class="card text-white bg-success mb-3">
                <div class="card-body">
                    <h5 class="card-title">Ventas Hoy</h5>
                    <p class="card-text">$345</p>
                </div>
            </div>
        </div>
        <div class="col-md-3">
            <div class="card text-white bg-warning mb-3">
                <div class="card-body">
                    <h5 class="card-title">Clientes</h5>
                    <p class="card-text">320</p>
                </div>
            </div>
        </div>
    </div>--%>

    <h2>Autores recientes</h2>
    <form runat="server">

        <div class="table-responsive">
            <asp:GridView ID="gvAutores" runat="server"
                OnRowCommand="gvAutores_RowCommand"
                CssClass="table table-striped table-bordered table-hover"
                ShowHeaderWhenEmpty="True"
                EmptyDataText="No hay autores registrados." AutoGenerateColumns="False">
                <Columns>
                    <asp:BoundField DataField="Id" HeaderText="ID" />
                    <asp:BoundField DataField="Nombre" HeaderText="Nombre" />
                    <asp:BoundField DataField="Apellido" HeaderText="Apellido" />
                    <asp:BoundField DataField="Biografia" HeaderText="Biografía" />
                    <asp:BoundField DataField="FechaNacimiento" HeaderText="Fecha de nacimiento" />
                    <asp:BoundField DataField="Nacionalidad" HeaderText="Nacionalidad" />
                    <asp:TemplateField ShowHeader="False">
                        <ItemTemplate>
                            <asp:LinkButton ID="lnkVerDetalle" runat="server"
                                CommandName="Actualizar"
                                CommandArgument='<%# Eval("Id") %>'
                                Text="Actualizar"
                                CssClass="btn btn-success" />
                            <%--<asp:LinkButton ID="lnkVerDetalle" runat="server" CausesValidation="False" CommandName="Actualizar" Text="Actualizar" CssClass="btn btn-success"></asp:LinkButton>--%>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField ShowHeader="False">
                        <ItemTemplate>


                            <asp:LinkButton ID="lnkEliminar" runat="server" CausesValidation="False" CommandName="Eliminar" CommandArgument='<%# Eval("Id") %>' Text="Eliminar" CssClass="btn btn-danger" OnClientClick="return confirm('¿Estás seguro de que deseas eliminar este libro?');" /></asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </div>
        <%--<asp:Button ID="btnLoad" runat="server" Text="Cargar Autores" OnClick="BtnLoad_Click" />--%>
    </form>



</asp:Content>
