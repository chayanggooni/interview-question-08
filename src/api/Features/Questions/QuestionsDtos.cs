namespace InterviewQuestion08.Api.Features.Questions;

public record CreateQuestionRequest(
    string QuestionText,
    IReadOnlyList<string> Choices
);

public record QuestionChoiceResponse(
    int Id,
    int ChoiceNo,
    string ChoiceText
);

public record QuestionResponse(
    int Id,
    string QuestionText,
    IReadOnlyList<QuestionChoiceResponse> Choices
);