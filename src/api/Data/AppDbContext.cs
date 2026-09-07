using InterviewQuestion08.Api.Entities;
using Microsoft.EntityFrameworkCore;

namespace InterviewQuestion08.Api.Data;

public class AppDbContext(DbContextOptions<AppDbContext> options)
    : DbContext(options)
{
  public DbSet<Question> Questions => Set<Question>();
  public DbSet<QuestionChoice> QuestionChoices => Set<QuestionChoice>();

  protected override void OnModelCreating(ModelBuilder modelBuilder)
  {
    modelBuilder.ApplyConfigurationsFromAssembly(
        typeof(AppDbContext).Assembly
    );
  }
}