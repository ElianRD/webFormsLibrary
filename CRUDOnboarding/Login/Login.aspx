<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="CRUDOnboarding.Login.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link rel="preconnect" href="https://fonts.gstatic.com/" crossorigin="" />
    <link rel="stylesheet" href="https://fonts.googleapis.com/css2?display=swap&amp;family=Newsreader:wght@400;500;700;800&amp;family=Noto+Sans:wght@400;500;700;900" />


    <title>Stitch Design</title>
    <link rel="icon" type="image/x-icon" href="data:image/x-icon;base64," />

    <script src="https://cdn.tailwindcss.com?plugins=forms,container-queries"></script>
    <link href="/Resources/css/StyleSheet1.css" rel="stylesheet" type="text/css" />
    <style>
         .checkbox-container {
            display: flex;
            align-items: center;
            margin-bottom: 20px;
        }
        
        .checkbox-container input[type="checkbox"] {
            margin-right: 8px;
        }
    </style>

</head>
<body>
    <form id="form1" runat="server">
        <div class="flex min-h-screen items-center justify-center bg-slate-50 px-4" style='font-family: Newsreader, "Noto Sans", sans-serif;'>
            <div class="flex max-w-5xl w-full bg-white shadow-md rounded-xl overflow-hidden" runat="server">

                <!-- Imagen (oculta en pantallas pequeñas) -->
                <div class="hidden md:block md:w-1/2 bg-cover bg-center"
                    style='background-image: url("https://lh3.googleusercontent.com/aida-public/AB6AXuASUqjYU7l7qcn3vC97hKzr9ZOpjW07DKDj4E4kbeJKrJz_xSWtMqKUR1aqphK1e7-_n076_ZrYKi1_qWr0oCiQhrgRxArgDWvDBp0vz-mGA7XhVzfyI9k4O_nLWAOB4PhzD1k3pfJbTKVKFnk62T7CUuuX0z7_6re6mY3OXccS46z7sTkC3oM5fF1-dtr99_58jxx_thsgOL6_JKroyc5JiBz-qF4UTTXsvlERM0Ev-2dMVt0854q61sblERko1Xe37C3qr7xi_L8"); min-height: 500px;'>
                </div>

                <!-- Login Form -->
                <div class="w-full md:w-1/2 p-8">
                    <div class="mb-6 text-center">
                        <h2 class="text-[#0d151c] text-2xl font-bold">Welcome Back</h2>
                    </div>

                    <div class="mb-4">
                        <label class="block text-[#0d151c] text-base font-medium mb-2">Username</label>
                        <asp:TextBox ID="txtUsuario" placeholder="Enter your username"
                            CssClass="w-full rounded-xl bg-[#e7edf4] text-[#0d151c] h-14 px-4 placeholder:text-[#49749c] focus:outline-none"
                            type="text" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvUser" runat="server" ControlToValidate="txtUsuario"
                            CssClass="mi-clase-error" ErrorMessage="el nombre de usuario es obligatorio." Display="Dynamic" ValidationGroup="validar"></asp:RequiredFieldValidator>

                    </div>
                    <div class="checkbox-container">
                        <asp:CheckBox ID="chkRecordar" runat="server" Text="Recordarme" />
                    </div>

                    <div class="mb-4" runat="server">
                        <label class="block text-[#0d151c] text-base font-medium mb-2">Password</label>
                        <asp:TextBox ID="txtPassword"
                            TextMode="Password"
                            CssClass="w-full rounded-xl bg-[#e7edf4] text-[#0d151c] h-14 px-4 placeholder:text-[#49749c] focus:outline-none"
                            placeholder="Enter your password"
                            runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvPassword" runat="server" ControlToValidate="txtPassword"
                            CssClass="mi-clase-error" ErrorMessage="La contraseña es obligatoria." Display="Dynamic" ValidationGroup="validar"></asp:RequiredFieldValidator>
                    </div>

                    <div class="mb-4">
                        <asp:Button ID="Button1" CssClass="w-full h-10 rounded-full bg-[#0b80ee] text-white font-bold text-sm" runat="server" ValidationGroup="validar" Text="Log In" OnClick="btnLogin_Click" />
                        <asp:Label ID="lblMensaje" runat="server" Visible="false"></asp:Label>
                    </div>

                    <%--<p class="text-center text-[#49749c] text-sm underline cursor-pointer">Forgot Password?</p>--%>
                </div>

            </div>

        </div>
    </form>
</body>


</html>
