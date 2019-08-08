using AmdarisQuizResultsApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AmdarisQuizResultsApi.Repositories.Interfaces
{
    public interface IQuizRepository : IRepository<Quiz>
    {
        Quiz GenerateQuiz(Quiz quiz, int questionsCount);
    }
}
