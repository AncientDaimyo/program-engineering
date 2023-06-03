using Microsoft.AspNetCore.Mvc.RazorPages;

namespace itf.Pages;

public class IndexModel : PageModel
{
    private readonly ApplicationContext _db;
    private readonly ILogger<IndexModel> _logger;
    public List<Quiz> Quizs;

    public IndexModel(ILogger<IndexModel> logger, ApplicationContext db)
    {
        _logger = logger;
        _db = db;
        this.Quizs = _db.Quizs.ToList();
    }

    public void OnGet()
    {

    }
}
