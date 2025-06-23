<%@ Page Title="Dashboard" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Dashboard.aspx.cs" Inherits="CRUDOnboarding.Dashboard" %>

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
     <form id="form1" runat="server">
        <div class="header">
            <div class="header-content">
                <div class="logo">Mi Sistema</div>
                <div class="user-info">
                    <span>Bienvenido, <asp:Label ID="lblUsuario" runat="server"></asp:Label></span>
                    <asp:Button ID="btnLogout" runat="server" Text="Cerrar Sesión" CssClass="btn-logout" OnClick="btnLogout_Click" />
                </div>
            </div>
        </div>
        
        <div class="container">
            <div class="welcome-card">
                <h2>¡Bienvenido al Dashboard!</h2>
                <p>Has iniciado sesión exitosamente el <asp:Label ID="lblFechaLogin" runat="server"></asp:Label></p>
                <p>Tu sesión está activa desde hace <asp:Label ID="lblTiempoSesion" runat="server"></asp:Label></p>
            </div>
            
            <div class="stats-grid">
                <div class="stat-card">
                    <div class="stat-number">150</div>
                    <div class="stat-label">Usuarios Activos</div>
                </div>
                <div class="stat-card">
                    <div class="stat-number">48</div>
                    <div class="stat-label">Pedidos Hoy</div>
                </div>
                <div class="stat-card">
                    <div class="stat-number">92%</div>
                    <div class="stat-label">Rendimiento</div>
                </div>
                <div class="stat-card">
                    <div class="stat-number">$15,890</div>
                    <div class="stat-label">Ventas del Mes</div>
                </div>
            </div>
            
            <div class="content-section">
                <h3 class="section-title">Actividad Reciente</h3>
                <p>Esta es el área principal donde puedes mostrar el contenido de tu aplicación.</p>
                <p>Solo los usuarios autenticados pueden acceder a esta página.</p>
                
                <h4>Información de la Sesión:</h4>
                <ul>
                    <li>Usuario: <asp:Label ID="lblUsuarioInfo" runat="server"></asp:Label></li>
                    <li>Fecha de Login: <asp:Label ID="lblFechaLoginInfo" runat="server"></asp:Label></li>
                    <li>IP del Cliente: <asp:Label ID="lblIP" runat="server"></asp:Label></li>
                    <li>Navegador: <asp:Label ID="lblUserAgent" runat="server"></asp:Label></li>
                </ul>
            </div>
        </div>
    </form>
    </div>
</asp:Content>
