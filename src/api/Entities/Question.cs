namespace InterviewQuestion08.Api.Entities;

public class Question
{
  public int Id { get; set; }
  public required string QuestionText { get; set; }
  public ICollection<QuestionChoice> Choices { get; set; } = [];
}