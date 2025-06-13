using Domain.Entities;
using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.UseCases
{
    public class AutoresUseCase
    {
        private readonly IGenericRepo<Autor> _repository;

        public AutoresUseCase(IGenericRepo<Autor> repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<Autor>> ObtenerAutores()
        {
            return await _repository.ObtenerTodos();
        }

        public async Task<Autor> ObtenerAutorPorId(int id)
        {
            return await _repository.ObtenerPorId(id);
        }

        public async Task AgregarAutor(Autor autor)
        {
            await _repository.Agregar(autor);
        }

        public async Task EditarAutor(Autor autor)
        {
            await _repository.Editar(autor);
        }

        public async Task EliminarAutor(int id)
        {
            await _repository.Eliminar(id);
        }
    }
}
