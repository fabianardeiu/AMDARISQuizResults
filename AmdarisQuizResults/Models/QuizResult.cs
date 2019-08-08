using System.ComponentModel.DataAnnotations;

namespace AmdarisQuizResults.Models
{
    public class QuizResult : IBaseModel
    {
        [Key]
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Score { get; set; }
    }
}
