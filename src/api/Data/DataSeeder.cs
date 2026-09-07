using InterviewQuestion08.Api.Entities;
using Microsoft.EntityFrameworkCore;

namespace InterviewQuestion08.Api.Data;

public static class DataSeeder
{
  public static async Task SeedAsync(AppDbContext dbContext)
  {
    if (await dbContext.Questions.AnyAsync())
    {
      return;
    }

    var questions = new[]
    {
            new Question
            {
                QuestionText = "ข้อใดเป็นจำนวนเฉพาะ",
                Choices =
                [
                    new QuestionChoice { ChoiceNo = 1, ChoiceText = "3" },
                    new QuestionChoice { ChoiceNo = 2, ChoiceText = "5" },
                    new QuestionChoice { ChoiceNo = 3, ChoiceText = "9" },
                    new QuestionChoice { ChoiceNo = 4, ChoiceText = "11" },
                ],
            },
            new Question
            {
                QuestionText = "2 x 2 มีค่าเท่าไร",
                Choices =
                [
                    new QuestionChoice { ChoiceNo = 1, ChoiceText = "1" },
                    new QuestionChoice { ChoiceNo = 2, ChoiceText = "2" },
                    new QuestionChoice { ChoiceNo = 3, ChoiceText = "3" },
                    new QuestionChoice { ChoiceNo = 4, ChoiceText = "4" },
                ],
            },
        };

    dbContext.Questions.AddRange(questions);

    await dbContext.SaveChangesAsync();
  }
}