using CRUDOnboarding.Libros;
using Domain.Entities;
using Domain.Interfaces;
using Infrastructure.Context;
using Infrastructure.Repositories;
using Application.UseCases;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CRUDOnboarding.Autores
{
    public partial class Autores : System.Web.UI.Page
    {
        protected async void Page_Load(object sender, EventArgs e)
        {

            try
            {
                var useCase = CrearAutoresUseCase();
                var autores = await useCase.ObtenerAutores();
                gvAutores.DataSource = autores;
                gvAutores.DataBind();
            }
            catch (Exception ex)
            {
                //lblMensaje.Text = "Error al cargar autores: " + ex.Message;
            }

        }
        private AutoresUseCase CrearAutoresUseCase()
        {
            var context = new LibreriaDbContext();
            var repo = new AutorRepository(context);
            return new AutoresUseCase(repo);
        }

       
        protected void gvAutores_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Actualizar")
            {
                int autorId = Convert.ToInt32(e.CommandArgument);
                Session["AutorSeleccionadoId"] = autorId;
                Response.Redirect($"ActualizarAutor.aspx?id={autorId}", false);
                //Response.Redirect("DetalleLibro.aspx?id=5", false);
                Context.ApplicationInstance.CompleteRequest();
            }

            if (e.CommandName == "Eliminar")
            {
                int autorId = Convert.ToInt32(e.CommandArgument);
                EliminarAutor(autorId);
                CargarAutores(); 
            }
        }
        protected async void CargarAutores()
        {
            try
            {
                var useCase = CrearAutoresUseCase();
                var autores = await useCase.ObtenerAutores();
                gvAutores.DataSource = autores;
                gvAutores.DataBind();
            }
            catch (Exception ex)
            {
                //lblMensaje.Text = "Error al cargar autores: " + ex.Message;
            }
        }

        private void EliminarAutor(int autorId)
        {
            using (var context = new LibreriaDbContext())
            {
                var autor = context.Autores.FirstOrDefault(a => a.Id == autorId);
                if (autor != null)
                {
                    context.Autores.Remove(autor);
                    context.SaveChanges();
                }
            }
        }
    }
}