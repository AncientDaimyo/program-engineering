using Microsoft.EntityFrameworkCore;

public class ApplicationContext : DbContext
{
    public ApplicationContext(DbContextOptions<ApplicationContext> options)
    : base(options)
    {
        Database.EnsureCreated();
    }
    public DbSet<Quiz> Quizs => Set<Quiz>();
    public DbSet<Question> Question => Set<Question>();
    public DbSet<Answer> Answer => Set<Answer>();
    public DbSet<User> Users => Set<User>();
    public DbSet<Result> Results => Set<Result>();


}