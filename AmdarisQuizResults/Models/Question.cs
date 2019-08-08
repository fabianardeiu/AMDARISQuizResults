using AmdarisQuizResults.Models;
using AmdarisQuizResultsApi.Models.Enums;
using System.Collections.Generic;

namespace AmdarisQuizResultsApi.Models
{
    public class Question : IBaseModel
    {
        public int Id { get; set; }
        public string SnippetUrl { get; set; }
        public string Text { get; set; }
        public ICollection<Answer> Answers { get; set; }
        public QuestionDifficultyLevel Level { get; set; }
        public virtual IList<QuizToQuestion> QuizToQuestions { get; set; }

    }
}
