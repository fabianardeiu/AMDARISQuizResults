namespace AmdarisQuizResultsApi.DTO
{
    public class AnswerDTO
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public bool IsSelected { get; set; }
        public int QuestionId { get; set; }
    }
}
