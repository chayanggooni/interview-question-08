using InterviewQuestion08.Api.Data;
using InterviewQuestion08.Api.Entities;
using Microsoft.EntityFrameworkCore;

namespace InterviewQuestion08.Api.Features.Questions;

public class QuestionService(AppDbContext dbContext)
{
  public async Task<IReadOnlyList<QuestionResponse>> GetQuestionsAsync()
  {
    return await dbContext.Questions
        .AsNoTracking()
        .OrderBy(x => x.Id)
        .Select(x => new QuestionResponse(
            x.Id,
            x.QuestionText,
            x.Choices
                .OrderBy(choice => choice.ChoiceNo)
                .Select(choice => new QuestionChoiceResponse(
                    choice.Id,
                    choice.ChoiceNo,
                    choice.ChoiceText
                ))
                .ToList()
        ))
        .ToListAsync();
  }

  public async Task<QuestionResponse> CreateQuestionAsync(
    CreateQuestionRequest request)
  {
    var question = new Question
    {
      QuestionText = request.QuestionText.Trim(),
      Choices = request.Choices
            .Select((choice, index) => new QuestionChoice
            {
              ChoiceNo = index + 1,
              ChoiceText = choice.Trim(),
            })
            .ToList(),
    };

    dbContext.Questions.Add(question);

    await dbContext.SaveChangesAsync();

    return new QuestionResponse(
        question.Id,
        question.QuestionText,
        question.Choices
            .OrderBy(x => x.ChoiceNo)
            .Select(x => new QuestionChoiceResponse(
                x.Id,
                x.ChoiceNo,
                x.ChoiceText
            ))
            .ToList()
    );
  }

  public async Task<bool> DeleteQuestionAsync(int id)
  {
    var question = await dbContext.Questions.FindAsync(id);

    if (question is null)
    {
      return false;
    }

    dbContext.Questions.Remove(question);

    await dbContext.SaveChangesAsync();

    return true;
  }
}