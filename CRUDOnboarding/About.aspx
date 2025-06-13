<%@ Page Title="About" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="About.aspx.cs" Inherits="CRUDOnboarding.About" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <main aria-labelledby="title">
        <h2 id="title"><%: Title %>.</h2>
        <h3>Your application description page.xxx</h3>
        <p>Use this area to provide additional information.</p>
    </main>
<%--    <asp:TextBox ID="txtAutorId" runat="server" />
    <asp:TextBox ID="txtNombre" runat="server" />
    <asp:TextBox ID="txtNacionalidad" runat="server" />
    <asp:GridView ID="GridView1" runat="server" />
    <asp:Label ID="lblMensaje" runat="server" />
    <asp:Button ID="btnCargar" runat="server" Text="Cargar Autores" OnClick="BtnCargar_Click" />
    <asp:Button ID="btnBuscar" runat="server" Text="Buscar Autor" OnClick="BtnBuscar_Click" />
    <asp:Button ID="btnAgregar" runat="server" Text="Agregar Autor" OnClick="BtnAgregar_Click" />
    <asp:Button ID="btnEditar" runat="server" Text="Editar Autor" OnClick="BtnEditar_Click" />
    <asp:Button ID="btnEliminar" runat="server" Text="Eliminar Autor" OnClick="BtnEliminar_Click" />--%>




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
<%--    <asp:ScriptManager runat="server" />--%>

<form id="form1">
       <%-- <asp:ScriptManager runat="server" />--%>
        
        <asp:ValidationSummary ID="ValidationSummary1" runat="server" ForeColor="Red" />

        <asp:Panel ID="pnlFormulario" runat="server">

            <!-- Nombre -->
            <asp:Label ID="lblNombre" runat="server" Text="Nombre:" AssociatedControlID="txtNombre" />
            <asp:TextBox ID="txtNombre" runat="server" />
            <asp:RequiredFieldValidator 
                ID="rfvNombre" 
                runat="server" 
                ControlToValidate="txtNombre" 
                ErrorMessage="El nombre es requerido." 
                ForeColor="Red" 
                Display="Dynamic" />

            <br /><br />

            <!-- Apellido -->
            <asp:Label ID="lblApellido" runat="server" Text="Apellido:" AssociatedControlID="txtApellido" />
            <asp:TextBox ID="txtApellido" runat="server" />
            <asp:RequiredFieldValidator 
                ID="rfvApellido" 
                runat="server" 
                ControlToValidate="txtApellido" 
                ErrorMessage="El apellido es requerido." 
                ForeColor="Red" 
                Display="Dynamic" />

            <br /><br />

            <!-- Biografía -->
            <asp:Label ID="lblBiografia" runat="server" Text="Biografía:" AssociatedControlID="txtBiografia" />
            <asp:TextBox ID="txtBiografia" runat="server" TextMode="MultiLine" Rows="4" Columns="40" />

            <br /><br />

            <!-- Fecha de nacimiento -->
            <asp:Label ID="lblFechaNacimiento" runat="server" Text="Fecha de nacimiento:" AssociatedControlID="txtFechaNacimiento" />
            <asp:TextBox ID="txtFechaNacimiento" runat="server" TextMode="Date" />

            <br /><br />

            <!-- Nacionalidad -->
            <asp:Label ID="lblNacionalidad" runat="server" Text="Nacionalidad:" AssociatedControlID="txtNacionalidad" />
            <asp:TextBox ID="txtNacionalidad" runat="server" />

            <br /><br />

            <asp:Button ID="btnGuardar" runat="server" Text="Guardar" OnClick="BtnAgregar_Click" />
            
            <br /><br />

            <asp:Label ID="lblError" runat="server" ForeColor="Red" />

        </asp:Panel>
    </form>

</asp:Content>
