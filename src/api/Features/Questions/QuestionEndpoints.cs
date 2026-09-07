namespace InterviewQuestion08.Api.Features.Questions;

public static class QuestionEndpoints
{
  public static IEndpointRouteBuilder MapQuestionEndpoints(
      this IEndpointRouteBuilder endpoints)
  {
    var group = endpoints.MapGroup("/api/questions");

    group.MapGet("/", async (QuestionService service) =>
    {
      var questions = await service.GetQuestionsAsync();

      return Results.Ok(questions);
    });

    group.MapPost("/", async (CreateQuestionRequest request, QuestionService service) =>
    {
      var errors = ValidateCreateRequest(request);

      if (errors.Count > 0)
      {
        return Results.ValidationProblem(errors);
      }

      var question = await service.CreateQuestionAsync(request);

      return Results.Created(
        $"/api/questions/{question.Id}",
        question
      );
    });

    group.MapDelete("/{id:int}", async (int id, QuestionService service) =>
    {
      var deleted = await service.DeleteQuestionAsync(id);

      return deleted
          ? Results.NoContent()
          : Results.NotFound();
    });

    return endpoints;
  }

  private static Dictionary<string, string[]> ValidateCreateRequest(
    CreateQuestionRequest request)
  {
    var errors = new Dictionary<string, string[]>();

    if (string.IsNullOrWhiteSpace(request.QuestionText))
    {
      errors["questionText"] = ["Question is required."];
    }
    else if (request.QuestionText.Length > 500)
    {
      errors["questionText"] = ["Question must not exceed 500 characters."];
    }

    if (request.Choices.Any(string.IsNullOrWhiteSpace))
    {
      errors["choices"] = ["All choices are required."];
    }
    else if (request.Choices.Any(x => x.Length > 200))
    {
      errors["choices"] = ["Each choice must not exceed 200 characters."];
    }

    return errors;
  }
}