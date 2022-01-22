using Microsoft.EntityFrameworkCore;
using PassengerApp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PassengerApp.Storage
{
    public class CrudRepository<T> where T : CrudBase
    {
        private readonly CrudContext _context;

        public CrudRepository()
        {
            _context = new CrudContext();
        }

        public CrudRepository(string connectionString)
        {
            _context = new CrudContext(connectionString);
        }

        public async Task<bool> Insert(T entity)
        {
            _context.Set<T>().Add(entity);

            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> Update(T entity)
        {
            _context.Attach(entity);
            _context.Entry(entity).State = EntityState.Modified;

            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> Delete(T entity)
        {
            entity.IsDeleted = true;
            _context.Attach(entity);
            _context.Entry(entity).State = EntityState.Modified;

            return await _context.SaveChangesAsync() > 0;
        }
    }
}
