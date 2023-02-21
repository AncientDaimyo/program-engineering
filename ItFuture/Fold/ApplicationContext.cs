using Microsoft.EntityFrameworkCore;
 
public class ApplicationContext : DbContext
{
    public DbSet<Quiz> Quizs => Set<Quiz>();
    public ApplicationContext() => Database.EnsureCreated();
 
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("Data Source=ITFuture.db");
    }
}