using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace CRUDOnboarding.Login
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // Verificar si el usuario ya está autenticado
            if (User.Identity.IsAuthenticated)
            {
                Response.Redirect("~/Dashboard");
            }
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                string usuario = txtUsuario.Text.Trim();
                string password = txtPassword.Text.Trim();

                // Validar credenciales
                if (ValidarCredenciales(usuario, password))
                {
                    // Crear ticket de autenticación
                    FormsAuthenticationTicket ticket = new FormsAuthenticationTicket(
                        1, // Versión
                        usuario, // Nombre de usuario
                        DateTime.Now, // Fecha de emisión
                        DateTime.Now.AddMinutes(30), // Fecha de expiración
                        chkRecordar.Checked, // Persistente
                        "Usuario", // Datos adicionales (rol)
                        FormsAuthentication.FormsCookiePath
                    );

                    // Encriptar el ticket
                    string encryptedTicket = FormsAuthentication.Encrypt(ticket);

                    // Crear cookie
                    HttpCookie authCookie = new HttpCookie(FormsAuthentication.FormsCookieName, encryptedTicket);

                    if (chkRecordar.Checked)
                    {
                        authCookie.Expires = ticket.Expiration;
                    }

                    Response.Cookies.Add(authCookie);

                    // Guardar información en sesión
                    Session["Usuario"] = usuario;
                    Session["FechaLogin"] = DateTime.Now;

                    // Mostrar mensaje de éxito
                    MostrarMensaje("Login exitoso. Redirigiendo...", "success");

                    // Redirigir después de un breve delay usando JavaScript
                    string redirectUrl = ResolveUrl("~/Dashboard");
                    ClientScript.RegisterStartupScript(this.GetType(), "redirect",
                        $"setTimeout(function(){{ window.location.href='{redirectUrl}'; }}, 1000);", true);

                }
                else
                {
                    MostrarMensaje("Usuario o contraseña incorrectos", "error");
                    LimpiarCampos();
                }
            }
        }

        private bool ValidarCredenciales(string usuario, string password)
        {
            // Opción 1: Validación simple (para pruebas)
            if (usuario.ToLower() == "admin" && password == "123456")
                return true;
            if (usuario.ToLower() == "usuario" && password == "password")
                return true;

            // Opción 2: Validación con base de datos (descomenta para usar)
            /*
            try
            {
                string connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    string query = "SELECT COUNT(*) FROM Usuarios WHERE Usuario = @usuario AND Password = @password AND Activo = 1";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@usuario", usuario);
                        cmd.Parameters.AddWithValue("@password", HashPassword(password)); // Usar hash para passwords
                        
                        conn.Open();
                        int count = (int)cmd.ExecuteScalar();
                        return count > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                // Log del error
                System.Diagnostics.Debug.WriteLine("Error en validación: " + ex.Message);
                return false;
            }
            */

            return false;
        }

        private void MostrarMensaje(string mensaje, string tipo)
        {
            lblMensaje.Text = mensaje;
            lblMensaje.Visible = true;

            if (tipo == "error")
            {
                lblMensaje.CssClass = "error-message";
            }
            else if (tipo == "success")
            {
                lblMensaje.CssClass = "success-message";
            }
        }

        private void LimpiarCampos()
        {
            txtPassword.Text = "";
            txtUsuario.Focus();
        }

        // Método para hash de passwords (recomendado para producción)
        private string HashPassword(string password)
        {
            using (var sha256 = System.Security.Cryptography.SHA256.Create())
            {
                byte[] hashedBytes = sha256.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                return Convert.ToBase64String(hashedBytes);
            }
        }
    }
}