using Service.Context;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CRUDOnboarding
{
    public partial class About : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void btnLoad_Click(object sender, EventArgs e)
        {

            using (var db = new LibreriaDbContext())
            {
                gvAutores.DataSource = db.Autores.ToList();
                gvAutores.DataBind();
            }
            //DataTable datos = new DataTable();
            //    datos.Columns.Add("Id");
            //    datos.Columns.Add("Nombre");
            //    datos.Columns.Add("Apellido");
            //    datos.Columns.Add("Biografia");
            //    datos.Columns.Add("FechaNacimiento");
            //    datos.Columns.Add("Nacionalidad");
            //    datos.Columns.Add("Price");


            // gvAutores.DataSource = datos;
            //gvAutores.DataBind();
        }

    
    }
}