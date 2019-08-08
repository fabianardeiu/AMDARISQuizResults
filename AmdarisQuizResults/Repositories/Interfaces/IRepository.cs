using AmdarisQuizResults.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AmdarisQuizResultsApi.Repositories.Interfaces
{
    public interface IRepository<T> where T : IBaseModel
    {
        T AddEntity(T obj);
        IEnumerable<T> GetAll();
        T GetById(int id);
        void DeleteById(int id);
        void Update(T entity);
    }
}
