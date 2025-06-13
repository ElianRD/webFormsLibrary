using Domain.Entities;
using Domain.Interfaces;
using Infrastructure.Context;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class AutorRepository : IGenericRepo<Autor>
    {
        private readonly LibreriaDbContext _context;

        public AutorRepository(LibreriaDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<IEnumerable<Autor>> ObtenerTodos()
        {
            return await _context.Autores.ToListAsync();
        }

        public async Task<Autor> ObtenerPorId(int id)
        {
            return await _context.Autores.FindAsync(id);
        }

        public async Task Agregar(Autor autor)
        {
            if (autor == null) throw new ArgumentNullException(nameof(autor));
            _context.Autores.Add(autor);
            await _context.SaveChangesAsync();
        }

        public async Task Editar(Autor autor)
        {
            if (autor == null) throw new ArgumentNullException(nameof(autor));
            _context.Entry(autor).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task Eliminar(int id)
        {
            var autor = await _context.Autores.FindAsync(id);
            if (autor == null) throw new KeyNotFoundException($"Autor with id {id} not found.");
            _context.Autores.Remove(autor);
            await _context.SaveChangesAsync();
        }
    }
}
