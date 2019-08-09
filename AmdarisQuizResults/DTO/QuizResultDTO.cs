using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AmdarisQuizResultsApi.DTO
{
    public class QuizResultDTO
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public int QuizId { get; set; }
        public List<AnswerDTO> Answers { get; set; }
    }
}
