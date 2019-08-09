using AmdarisQuizResults.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AmdarisQuizResultsApi.Models
{
    public class Participant : IBaseModel
    {
        [Key]
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public ICollection<QuizResult> QuizResults { get; set; }
    }
}
