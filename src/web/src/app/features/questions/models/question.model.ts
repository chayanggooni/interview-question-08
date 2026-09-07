export interface Question {
  id: number;
  questionText: string;
  choices: QuestionChoice[];
}

export interface QuestionChoice {
  id: number;
  choiceNo: number;
  choiceText: string;
}

export interface CreateQuestionRequest {
  questionText: string;
  choices: string[];
}
