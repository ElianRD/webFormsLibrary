using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CRUDOnboarding
{
    public partial class Contact : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void btnSaludar_Click(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Label2.Text = "¡Bienvenido por primera vez!";
            }
            else
            {
                Label2.Text = "ya haz entrado antes";
                lblMensaje.Text = "¡Hola! Presionaste el botón." + txtNombre.Text;

            }

        }

    }
}