public class Quiz
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public int Difficulty { get; set; }
    public string? Theme { get; set; }
    public List<Question>? Questions { get; set; }
    public byte[]? Image { get; set; }
}

public class Question
{
    public int Id { get; set; }
    public int QuizId { get; set; }
    public string? QuestionText { get; set; }
    public List<Answer>? Answers { get; set; }
    public int RightAnswer { get; set; }

}

public class Answer
{
    public int Id { get; set; }
    public int QuestionId { get; set; }
    public string? AnswerText { get; set; }
}