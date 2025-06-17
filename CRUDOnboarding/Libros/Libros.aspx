<%@ Page Title="" Async="true" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Libros.aspx.cs" Inherits="CRUDOnboarding.Libros.Libros" %>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent1" runat="server">



    <h1>Panel de Libros</h1>
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

    <form runat="server">
        <h2>Libros Existentes</h2>
        <div class="table-responsive">
            <asp:GridView ID="gvAutores" runat="server"
                CssClass="table table-striped table-bordered table-hover"
                ShowHeaderWhenEmpty="true"
                EmptyDataText="No hay autores registrados." AutoGenerateColumns="False">
                <Columns>
                    <asp:BoundField DataField="Id" HeaderText="ID" />
                    <asp:BoundField DataField="Nombre" HeaderText="Nombre" />
                    <asp:BoundField DataField="Apellido" HeaderText="Apellido" />
                    <asp:BoundField DataField="Biografia" HeaderText="Biografía" />
                    <asp:BoundField DataField="FechaNacimiento" HeaderText="Fecha de nacimiento" />
                    <asp:BoundField DataField="Nacionalidad" HeaderText="Nacionalidad" />
                </Columns>
            </asp:GridView>
        </div>
        <asp:Button ID="btnLoad" runat="server" Text="Cargar Autores" OnClick="BtnLoad_Click" />
    </form>






</asp:Content>
