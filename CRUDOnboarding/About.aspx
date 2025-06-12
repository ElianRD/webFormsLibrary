
<%@ Page Title="About" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="About.aspx.cs" Inherits="CRUDOnboarding.About" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
      <main aria-labelledby="title">
      <h2 id="title"><%: Title %>.</h2>
      <h3>Your application description page.xxx</h3>
      <p>Use this area to provide additional information.</p>
  </main>
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

    <asp:Button ID="btnLoad" runat="server" Text="Cargar Autores" OnClick="btnLoad_Click" />




</asp:Content>
<%--<asp:GridView ID="gvProducts" runat="server" AutoGenerateColumns="false">
    <Columns>
        <asp:BoundField DataField="ProductId" HeaderText="ID" />
        <asp:BoundField DataField="Name" HeaderText="Nombre" />
        <asp:BoundField DataField="Price" HeaderText="Precio" />
    </Columns>
</asp:GridView>
<asp:Button ID="btnLoad" runat="server" Text="Cargar Productos" OnClick="btnLoad_Click" />--%>
