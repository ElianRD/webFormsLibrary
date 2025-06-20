
using Domain.Entities;
using Infrastructure.Context;
using Infrastructure.Repositories;
using Application.UseCases;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CRUDOnboarding
{
    public partial class About : Page
    {
        private AutoresUseCase _autoresUseCase;

        protected void Page_Init(object sender, EventArgs e)
        {
            _autoresUseCase = new AutoresUseCase(new AutorRepository(new LibreriaDbContext()));
        }
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

        //protected async void BtnCargar_Click(object sender, EventArgs e)
        //{
        //    var autores = await _autoresUseCase.ObtenerAutores();
        //    gvAutores.DataSource = autores;
        //    gvAutores.DataBind();
        //}

        //protected async void BtnBuscar_Click(object sender, EventArgs e)
        //{
        //    if (int.TryParse(txtAutorId.Text, out int id))
        //    {
        //        var autor = await _autoresUseCase.ObtenerAutorPorId(id);
        //        lblMensaje.Text = autor != null
        //            ? $"Autor encontrado: {autor.Nombre} - {autor.Nacionalidad}"
        //            : "Autor no encontrado.";
        //    }
        //    else
        //    {
        //        lblMensaje.Text = "ID inválido.";
        //    }
        //}

        protected async void BtnAgregar_Click(object sender, EventArgs e)
        {
            var autor = new Autor
            {
               

                 Nombre = txtNombre.Text,
                 Apellido = txtApellido.Text,
                 Biografia = txtBiografia.Text,
                Nacionalidad = txtNacionalidad.Text,
            };
            DateTime FechaNacimiento;

            if (DateTime.TryParse(txtFechaNacimiento.Text, out FechaNacimiento))
            {
                // Aquí puedes hacer lo que necesites con los datos, por ejemplo:
                // Guardar en base de datos

                lblError.ForeColor = System.Drawing.Color.Green;
                lblError.Text = "Datos guardados correctamente.";
            }
            else
            {
                lblError.Text = "La fecha de nacimiento no es válida.";
                lblError.ForeColor = System.Drawing.Color.Red;
            }

            await _autoresUseCase.AgregarAutor(autor);
            lblMensaje.Text = "Autor agregado exitosamente.";
        }

        //protected async void BtnEditar_Click(object sender, EventArgs e)
        //{
        //    if (int.TryParse(txtAutorId.Text, out int id))
        //    {
        //        var autor = await _autoresUseCase.ObtenerAutorPorId(id);
        //        if (autor != null)
        //        {
        //            autor.Nombre = txtNombre.Text;
        //            autor.Nacionalidad = txtNacionalidad.Text;

        //            await _autoresUseCase.EditarAutor(autor);
        //            lblMensaje.Text = "Autor actualizado correctamente.";
        //        }
        //        else
        //        {
        //            lblMensaje.Text = "Autor no encontrado.";
        //        }
        //    }
        //    else
        //    {
        //        lblMensaje.Text = "ID inválido.";
        //    }
        //}

        //protected async void BtnEliminar_Click(object sender, EventArgs e)
        //{
        //    if (int.TryParse(txtAutorId.Text, out int id))
        //    {
        //        try
        //        {
        //            await _autoresUseCase.EliminarAutor(id);
        //            lblMensaje.Text = "Autor eliminado exitosamente.";
        //        }
        //        catch (KeyNotFoundException ex)
        //        {
        //            lblMensaje.Text = ex.Message;
        //        }
        //    }
        //    else
        //    {
        //        lblMensaje.Text = "ID inválido.";
        //    }
        //}
    }
}