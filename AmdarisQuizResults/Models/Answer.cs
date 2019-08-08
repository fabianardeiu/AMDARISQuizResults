using AmdarisQuizResults.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AmdarisQuizResultsApi.Models
{
    public class Answer : IBaseModel
    {
        [Key]
        public int Id { get; set; }
        public string Text { get; set; }
        public bool IsCorrect { get; set; }
        [ForeignKey("Question")]
        public int QuestionId { get; set; }
        //[ForeignKey("QuestionId")]
        //public virtual Question Question { get; set; }
    }
}
