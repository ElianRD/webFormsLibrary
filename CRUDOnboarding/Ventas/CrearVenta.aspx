<%@ Page Title="Crear Ventas" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="CrearVenta.aspx.cs" Inherits="CRUDOnboarding.Ventas.CrearVentas" %>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent1" runat="server">
    <h1>Crear Ventas</h1>
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
<table class="table table-striped">
    <thead>
        <tr>
            <th>Título</th>
            <th>Autor</th>
            <th>Categoría</th>
            <th>Precio</th>
            <th>Stock</th>
        </tr>
    </thead>
    <tbody>
        <tr>
            <td>El Quijote</td>
            <td>Miguel de Cervantes</td>
            <td>Clásico</td>
            <td>$20</td>
            <td>35</td>
        </tr>
        <tr>
            <td>Cien años de soledad</td>
            <td>Gabriel García Márquez</td>
            <td>Realismo mágico</td>
            <td>$25</td>
            <td>20</td>
        </tr>
        <tr>
            <td>1984</td>
            <td>George Orwell</td>
            <td>Distopía</td>
            <td>$18</td>
            <td>50</td>
        </tr>
    </tbody>
</table>
</asp:Content>
