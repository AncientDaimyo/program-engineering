using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace itf.Pages;

public class QuizModel : PageModel
{
    public int result = -1;
    public int i = -1;
    private readonly ApplicationContext _db;
    private readonly ILogger<QuizModel> _logger;
    public List<Quiz> Quizs;
    public List<Question> Questions;
    public List<Answer> Answers;
    public List<User> Users;
    public List<Result> Results;
    public int Id;
    public Quiz? currentQuiz = null;
    public QuizModel(ILogger<QuizModel> logger, ApplicationContext db)
    {
        _logger = logger;
        _db = db;
        this.Quizs = _db.Quizs.ToList();
        this.Questions = _db.Question.ToList();
        this.Answers = _db.Answer.ToList();
        this.Users = _db.Users.ToList();
        this.Results = _db.Results.ToList();
    }

    public void OnGet(int id)
    {
        this.Id = id;
        foreach (var Quiz in this.Quizs)
        {
            if (Quiz.Id == this.Id)
            {
                this.currentQuiz = Quiz;
            }
        }
    }

    public IActionResult OnPost(int id, int answer1 = -1, int answer2 = -1, int answer3 = -1, int answer4 = -1, int answer5 = -1,
                       int answer6 = -1, int answer7 = -1, int answer8 = -1, int answer9 = -1, int answer10 = -1)
    {
        int[] mass = { answer1, answer2, answer3, answer4, answer5, answer6, answer7, answer8, answer9, answer10 };
        this.Id = id;
        foreach (var Quiz in this.Quizs)
        {
            if (Quiz.Id == this.Id)
            {
                this.currentQuiz = Quiz;
            }
        }
        result = 0;
        i = 0;
        if (this.currentQuiz != null)
        {
            if (currentQuiz.Questions != null)
            {
                foreach (var q in this.currentQuiz.Questions)
                {
                    if (q.RightAnswer == mass[i])
                    {
                        result += 1;
                    }
                    i++;
                }
            }
        }
        if(HttpContext.Session.Keys.Contains("Username")) {
            foreach(var u in this.Users)
            {
                if(u.Username == HttpContext.Session.GetString("Username")) {
                    Result r = new Result(u.Id,id,result);
                    u.Results.Add(r);
                    _db.SaveChanges();
                    return RedirectToPage("Account");
                }
            }

        }
        return RedirectToPage("Result", new { result = result.ToString(), i = i.ToString() });
    }

}