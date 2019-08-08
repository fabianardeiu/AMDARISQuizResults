using AmdarisQuizResults;
using AmdarisQuizResults.Models;
using AmdarisQuizResultsApi.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AmdarisQuizResultsApi.Repositories
{
    public class BaseRepository<T> : IRepository<T> where T : class, IBaseModel
    {
        private readonly AmdarisQuizContext _context = null;
        public IQueryable<T> Table => _context.Set<T>();
        public BaseRepository(AmdarisQuizContext context)
        {
            _context = context;
        }
        public async virtual Task<T> AddEntity(T obj)
        {
            await _context.AddAsync(obj);
            await _context.SaveChangesAsync();
            return obj;
        }

        public void DeleteById(int id)
        {
            var objToDelete = Table.ToList().FirstOrDefault(o => o.Id == id);
            _context.Remove(objToDelete);
            _context.SaveChanges();
        }

        public virtual IEnumerable<T> GetAll()
        {
            return Table.ToList();
        }

        public T GetById(int id)
        {
            var obj = Table.FirstOrDefault(o => o.Id == id);
            return obj;
        }

        public virtual void Update(T entity)
        {
            _context.Attach(entity);
            var entry = _context.Entry(entity);
            entry.State = EntityState.Modified;
            _context.SaveChanges();
        }


    }
}
