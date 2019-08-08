using AmdarisQuizResults.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AmdarisQuizResultsApi.Models
{
    public class Quiz : IBaseModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Question> Questions { get; set; }

        public virtual IList<QuizToQuestion> QuizToQuestions { get; set; }
    }
}
