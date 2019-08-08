using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AmdarisQuizResults.Models;

namespace AmdarisQuizResults.Services
{
    public class QuizResultService : IQuizResultService
    {
        private readonly AmdarisQuizContext _context;
        public QuizResultService(AmdarisQuizContext context)
        {
            _context = context;
        }
        public async Task<QuizResult> AddQuizResult(QuizResult quizResult)
        {
            await _context.AddAsync(quizResult);
            await _context.SaveChangesAsync();
            return quizResult;
        }

        public IEnumerable<QuizResult> ListQuizResults()
        {
            return _context.QuizResults.ToList();
        }
    }
}
