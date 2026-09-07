export interface Question {
  id: number;
  text: string;
  choices: QuestionChoice[];
}

export interface QuestionChoice {
  id: number;
  choiceNo: number;
  text: string;
}
