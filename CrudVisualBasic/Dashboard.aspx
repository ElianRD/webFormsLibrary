<%@ Page Title="Dashboard" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site1.Master" CodeBehind="Dashboard.aspx.vb" Inherits="CrudVisualBasic.Dashboard" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent1" runat="server">
    <div id="main-content" class="content">
       

        <h1>Panel de Control</h1>
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
    
    </div>
</asp:Content>
