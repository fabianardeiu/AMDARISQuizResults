using AmdarisQuizResultsApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AmdarisQuizResultsApi.Repositories.Interfaces
{
    public interface IQuestionRepository : IRepository<Question>
    {
        IEnumerable<Answer> GetAnswers(int questionId);

    }
}
