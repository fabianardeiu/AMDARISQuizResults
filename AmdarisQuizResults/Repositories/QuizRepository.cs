using AmdarisQuizResults;
using AmdarisQuizResultsApi.Models;
using AmdarisQuizResultsApi.Models.Enums;
using AmdarisQuizResultsApi.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AmdarisQuizResultsApi.Repositories
{
    public class QuizRepository : BaseRepository<Quiz>, IQuizRepository
    {
        private readonly AmdarisQuizContext _context = null;
        private static Random rand = new Random();
        private Dictionary<QuestionDifficultyLevel, float> levelTypeStrategy = new Dictionary<QuestionDifficultyLevel, float>()
        {
            {QuestionDifficultyLevel.Easy, 0.5f},
            {QuestionDifficultyLevel.Medium, 0.3f},
            {QuestionDifficultyLevel.Hard, 0.2f}
        };
        public QuizRepository(AmdarisQuizContext context) : base(context)
        {
            _context = context;
        }

        public override Quiz AddEntity(Quiz obj)
        {
            base.AddEntity(obj);
            obj.Name = $"Quiz{obj.Id}";
            base.Update(obj);
            return obj;
        }
        private IEnumerable<Question> GenerateQuestions(int elementsCount)
        {
            var totalQuesitons = new List<Question>();
            foreach (QuestionDifficultyLevel levelType in Enum.GetValues(typeof(QuestionDifficultyLevel)))
            {
                if(levelTypeStrategy.TryGetValue(levelType, out float foundPercentage))
                {
                    var res = _context.Questions
                                      .Where(q => q.Level == levelType)
                                      .OrderBy(q => Guid.NewGuid())
                                      .Take((int)(Math.Round(elementsCount* foundPercentage))).ToList();
                    res.ForEach(q => q.Answers = new List<Answer>());
                    res.ToList().ForEach(q => q.Answers.ToList()
                    .AddRange(_context.Answers.Where(a => a.QuestionId == q.Id)));
                    
                    totalQuesitons.AddRange(res);
                }
            }
            return totalQuesitons;
        }
        public Quiz GenerateQuiz(Quiz quiz, int questionsCount)
        {
            quiz.Questions = GenerateQuestions(questionsCount).ToList();
            return quiz;
        }

        
    }
}
