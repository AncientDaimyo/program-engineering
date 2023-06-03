using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace itf.Pages;
public class AccountModel : PageModel
{
    private readonly ApplicationContext _db;
    private readonly ILogger<AccountModel> _logger;
    public List<Quiz> Quizs;
    public List<Question> Questions;
    public List<Answer> Answers;
    public List<User> Users;
    public List<Result> Results;

    public AccountModel(ILogger<AccountModel> logger, ApplicationContext db)
    {
        _logger = logger;
        _db = db;
        this.Quizs = _db.Quizs.ToList();
        this.Questions = _db.Question.ToList();
        this.Answers = _db.Answer.ToList();
        this.Users = _db.Users.ToList();
        this.Results = _db.Results.ToList();
    }

    public IActionResult OnPostSignIn(string Username, string Password)
    {
        foreach(var u in this.Users) {
            if (u.Username == Username) {
                if(u.Password == Password) {
                    HttpContext.Session.SetString("Username", Username);
                    return Page();
                }
                else {
                    return Page();
                }
            }
        }
        return Page();  
    }

    public IActionResult OnPostSignUp(string Username, string Password) 
    {
        foreach(var u in this.Users) {
            if (Username == u.Username) {
                return Page();
            }
        }
        User user = new User(Username, Password);
        _db.Users.Add(user);
        _db.SaveChanges();
        HttpContext.Session.SetString("Username", Username);
        return Page(); 
    }

    public IActionResult OnPostLogout() {
        HttpContext.Session.Clear();
        return Page();
    }
}