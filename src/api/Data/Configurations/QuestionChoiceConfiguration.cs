using InterviewQuestion08.Api.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace InterviewQuestion08.Api.Data.Configurations;

public class QuestionChoiceConfiguration
    : IEntityTypeConfiguration<QuestionChoice>
{
  public void Configure(EntityTypeBuilder<QuestionChoice> builder)
  {
    builder.Property(x => x.ChoiceText)
        .HasMaxLength(200)
        .IsRequired();

    builder.HasIndex(x => new { x.QuestionId, x.ChoiceNo })
        .IsUnique();
  }
}