using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;


namespace itf.Pages;

public class AdminModel : PageModel
{
    public List<Quiz>? Quizs { get; set; }
    public List<Question>? QuestionsStream { get; set; }
    public List<Answer>? AnswersStream { get; set; }
    private readonly ILogger<AdminModel> _logger;
    private  ApplicationContext _db;


    public AdminModel(ILogger<AdminModel> logger, ApplicationContext db)
    {
        _logger = logger;
        _db = db;
        this.Quizs = _db.Quizs.ToList();
    }

    public void OnGet()
    {

    }

    public void OnPostUpload(IFormFile picture, int i = -1) 
    {
            if(i != -1) {
                if (this.Quizs != null) {
                    foreach(var quiz in this.Quizs) {
                    if (quiz.Id == i) {
                        byte[] bytes;
                        using (var binaryReader = new BinaryReader(picture.OpenReadStream()))
                        {
                            bytes = binaryReader.ReadBytes((int)picture.Length);
                        }
                        quiz.Image = bytes;
                        _db.SaveChanges();
                        break;
                    }
                }
            }
        }
    }
}