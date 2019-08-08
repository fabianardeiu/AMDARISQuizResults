using AmdarisQuizResults.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AmdarisQuizResultsApi.Repositories.Interfaces
{
    public interface IRepository<T> where T : IBaseModel
    {
        Task<T> AddEntity(T obj);
        IEnumerable<T> GetAll();
        T GetById(int id);
        void DeleteById(int id);
        void Update(T entity);
    }
}
