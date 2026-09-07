using InterviewQuestion08.Api.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace InterviewQuestion08.Api.Data.Configurations;

public class QuestionConfiguration : IEntityTypeConfiguration<Question>
{
  public void Configure(EntityTypeBuilder<Question> builder)
  {
    builder.Property(x => x.QuestionText)
        .HasMaxLength(500)
        .IsRequired();

    builder.HasMany(x => x.Choices)
        .WithOne(x => x.Question)
        .HasForeignKey(x => x.QuestionId)
        .OnDelete(DeleteBehavior.Cascade);
  }
}