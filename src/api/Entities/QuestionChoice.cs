namespace InterviewQuestion08.Api.Entities;

public class QuestionChoice
{
  public int Id { get; set; }
  public int QuestionId { get; set; }
  public int ChoiceNo { get; set; }
  public required string ChoiceText { get; set; }
  public Question Question { get; set; } = null!;
}