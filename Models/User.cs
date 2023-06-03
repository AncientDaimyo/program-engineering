using System.ComponentModel.DataAnnotations;

public class User
{
    public int Id { get; set; }

    [Required]
    public string Username { get; set; }
    [Required]
    public string Password { get; set; }
    public List<Result> Results { get; set; }

    public User(string Username, string Password) {
        this.Username = Username;
        this.Password = Password;
        this.Results = new List<Result>(); 
    }
}

public class Result 
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public int QuizId { get; set; }
    public int Score { get; set; }

    public Result(int UserId, int QuizId, int Score) {
        this.UserId = UserId;
        this.QuizId = QuizId;
        this.Score = Score;
    }
}