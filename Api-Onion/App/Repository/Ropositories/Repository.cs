using Domain.Common;
using Microsoft.EntityFrameworkCore;
using Repository.Data;
using Repository.Ropositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Ropositories
{
    public class Repository<T> : IRepository<T> where T : BaseEntity
    {
        private readonly AppDbContext _context;
        private readonly DbSet<T> _entities;

        public Repository(AppDbContext context)
        {
            _entities = _context.Set<T>();
        }


        public async Task CreateAsync(T entity)
        { 
            if (entity == null) { throw new ArgumentNullException(nameof(entity)); }  //Gelen argument null olacaq.Api-terefe,server terefe null qayidacaq
          await  _entities.AddAsync(entity);       //eger null deyilse entity-i elave etsin bazaya  
           await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(T entity)
        {
            if (entity == null) { throw new NullReferenceException(nameof(entity)); }
             _entities.Remove(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _entities.ToListAsync();   
           
        }

        public async Task<T> GetByIdAsync(int? id)
        {
            if (id == null) {throw new ArgumentNullException();}
           T entity = await _entities.FindAsync(id);
           if(entity == null) { throw new NullReferenceException(nameof(entity)); }
           return entity;
        }

        public Task UpdateAsync(T entity)
        {
            throw new NotImplementedException();
        }
    }
}
