using System.Collections.Generic;

namespace AmdarisQuizResultsApi.DTO
{
    public class QuizDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public IList<QuestionDTO> QuestionDTOs { get; set; }
    }
}
