using AmdarisQuizResults.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AmdarisQuizResultsApi.Models
{
    public class QuizToQuestion : IBaseModel
    {
        public int Id { get; set; }

        public int QuizId { get; set; }

        [ForeignKey("QuizId")]
        public Quiz Quiz { get; set; }

        public int QuestionId { get; set; }

        [ForeignKey("QuestionId")]
        public Question Question { get; set; }
    }
}
