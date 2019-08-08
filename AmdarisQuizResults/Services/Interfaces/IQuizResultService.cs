using AmdarisQuizResults.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AmdarisQuizResults.Services
{
    public interface IQuizResultService
    {
        Task<QuizResult> AddQuizResult(QuizResult quizResult);
        IEnumerable<QuizResult> ListQuizResults();
    }
}
