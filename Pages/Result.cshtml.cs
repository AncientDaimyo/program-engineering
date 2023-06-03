using Microsoft.AspNetCore.Mvc.RazorPages;

namespace itf.Pages;

public class ResultModel : PageModel
{
    public int result;
    public int i;
    
    private readonly ILogger<QuizModel> _logger;

    public ResultModel(ILogger<QuizModel> logger, ApplicationContext db)
    {
        _logger = logger;
    }

    public void OnGet(int result = 0, int i = 0)
    {
        this.result = result;
        this.i = i;
    }
}