using AmdarisQuizResultsApi.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AmdarisQuizResults.Models
{
    public class QuizResult : IBaseModel
    {
        [Key]
        public int Id { get; set; }
        public int QuizId { get; set; }
        public int ParticipantId { get; set; }
        [ForeignKey("ParticipantId")]
        public Participant Participant { get; set; }
        public int Score { get; set; }
    }
}
