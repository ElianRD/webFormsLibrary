<%@ Page Title="" Async="true" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Autores.aspx.cs" Inherits="CRUDOnboarding.Autores.Autores" %>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent1" runat="server">
    <div id="main-content" class="content">


        <h1>Panel de Autores</h1>
        <div class="row my-4">
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
        </div>

        <h2>Libros recientes</h2>
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
            <asp:Button ID="btnLoad" runat="server" Text="Cargar Autores" OnClick="BtnLoad_Click" />
        </form>


    </div>
</asp:Content>
