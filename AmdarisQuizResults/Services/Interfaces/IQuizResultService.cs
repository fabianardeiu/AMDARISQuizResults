using AmdarisQuizResults.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AmdarisQuizResults.Services
{
    public interface IQuizResultService
    {
        QuizResult AddQuizResult(QuizResult quizResult);
        IEnumerable<QuizResult> ListQuizResults();
    }
}
