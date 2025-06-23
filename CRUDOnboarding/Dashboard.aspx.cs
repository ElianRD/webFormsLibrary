using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CRUDOnboarding
{
    public partial class Dashboard : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // Verificar si el usuario está autenticado
            if (!User.Identity.IsAuthenticated)
            {
                Response.Redirect("~/Login/Login.aspx");
                return;
            }

            if (!IsPostBack)
            {
                CargarInformacionUsuario();
            }
        }

        private void CargarInformacionUsuario()
        {
            // Obtener nombre de usuario del ticket de autenticación
            string nombreUsuario = User.Identity.Name;
            lblUsuario.Text = nombreUsuario;
            lblUsuarioInfo.Text = nombreUsuario;

            // Obtener información de la sesión
            if (Session["FechaLogin"] != null)
            {
                DateTime fechaLogin = (DateTime)Session["FechaLogin"];
                lblFechaLogin.Text = fechaLogin.ToString("dd/MM/yyyy HH:mm:ss");
                lblFechaLoginInfo.Text = fechaLogin.ToString("dd/MM/yyyy HH:mm:ss");

                // Calcular tiempo transcurrido
                TimeSpan tiempoTranscurrido = DateTime.Now - fechaLogin;
                lblTiempoSesion.Text = string.Format("{0} minutos", (int)tiempoTranscurrido.TotalMinutes);
            }

            // Información del cliente
            lblIP.Text = ObtenerDireccionIP();
            lblUserAgent.Text = Request.UserAgent;
        }

        private string ObtenerDireccionIP()
        {
            string ip = Request.ServerVariables["HTTP_X_FORWARDED_FOR"];

            if (string.IsNullOrEmpty(ip) || ip.ToLower() == "unknown")
            {
                ip = Request.ServerVariables["HTTP_X_REAL_IP"];
            }

            if (string.IsNullOrEmpty(ip) || ip.ToLower() == "unknown")
            {
                ip = Request.ServerVariables["REMOTE_ADDR"];
            }

            if (string.IsNullOrEmpty(ip))
            {
                ip = Request.UserHostAddress;
            }

            // Si hay múltiples IPs, tomar la primera
            if (!string.IsNullOrEmpty(ip) && ip.Contains(","))
            {
                ip = ip.Split(',')[0].Trim();
            }

            return ip ?? "No disponible";
        }

        protected void btnLogout_Click(object sender, EventArgs e)
        {
            // Limpiar la sesión
            Session.Clear();
            Session.Abandon();

            // Eliminar cookie de autenticación
            FormsAuthentication.SignOut();

            // Limpiar cookies manualmente por seguridad
            if (Request.Cookies[FormsAuthentication.FormsCookieName] != null)
            {
                HttpCookie authCookie = new HttpCookie(FormsAuthentication.FormsCookieName)
                {
                    Expires = DateTime.Now.AddDays(-1),
                    Value = ""
                };
                Response.Cookies.Add(authCookie);
            }

            // Redirigir a la página de login
            Response.Redirect("~/Login/Login.aspx");
        }

        protected void Page_PreRender(object sender, EventArgs e)
        {
            // Actualizar el tiempo de sesión cada vez que se carga la página
            if (Session["FechaLogin"] != null)
            {
                DateTime fechaLogin = (DateTime)Session["FechaLogin"];
                TimeSpan tiempoTranscurrido = DateTime.Now - fechaLogin;
                lblTiempoSesion.Text = string.Format("{0} minutos", (int)tiempoTranscurrido.TotalMinutes);
            }
        }
    }
}