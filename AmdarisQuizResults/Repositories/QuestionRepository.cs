using AmdarisQuizResults;
using AmdarisQuizResultsApi.Models;
using AmdarisQuizResultsApi.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AmdarisQuizResultsApi.Repositories
{
    public class QuestionRepository : BaseRepository<Question>, IQuestionRepository
    {
        private readonly AmdarisQuizContext _context;
        public QuestionRepository(AmdarisQuizContext context) : base(context)
        {
            _context = context;
        }
        public override IEnumerable<Question> GetAll()
        {
            var questions = base.GetAll();
            questions.ToList().ForEach(q => q.Answers = new List<Answer>());
            questions.ToList().ForEach(q => q.Answers.ToList().AddRange(_context.Answers.Where(a => a.QuestionId == q.Id)));
            return base.GetAll();
        }
        public IEnumerable<Answer> GetAnswers(int questionId)
        {
            return _context.Questions.FirstOrDefault(q => q.Id == questionId).Answers;
        }
    }
}
