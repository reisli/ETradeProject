using ETradeProject.Application.Repositories;
using ETradeProject.Domain.Entities.Common;
using ETradeProject.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ETradeProject.Persistence.Repositories
{
    public class ReadRepository<T> : IReadRepository<T> where T : BaseEntity
    {
        private readonly ETradeProjectDbContext _context;

        public ReadRepository(ETradeProjectDbContext context)
        {
            _context = context;
        }

        public DbSet<T> Table => _context.Set<T>();

        public IQueryable<T> GetAll()
            => Table;

        public IQueryable<T> GetWhere(Expression<Func<T, bool>> method)
           => Table.Where(method);


        public Task<T> GetSingleAsync(Expression<Func<T, bool>> method)
            => Table.FirstOrDefaultAsync(method);


        public Task<T> GetByIdAsync(string id)
            => Table.FirstOrDefaultAsync(data => data.Id == Guid.Parse(id));

       
        
    }
}
