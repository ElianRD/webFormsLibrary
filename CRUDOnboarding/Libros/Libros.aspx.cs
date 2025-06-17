using Infrastructure.Context;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CRUDOnboarding.Libros
{
    public partial class Libros : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected async void BtnLoad_Click(object sender, EventArgs e)
        {
            using (var db = new LibreriaDbContext())
            {
                var autores = await db.Autores.ToListAsync(); // usa EF Core o EF6 con Asynchronous NuGet Package
                gvAutores.DataSource = autores;
                gvAutores.DataBind();
            }
        }
    }
}