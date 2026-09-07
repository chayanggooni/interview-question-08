import { Component, signal } from '@angular/core';
import { Question } from '../../models/question.model';
import { RouterLink } from '@angular/router';

@Component({
  imports: [RouterLink],
  selector: 'app-question-list',
  styleUrl: './question-list.scss',
  templateUrl: './question-list.html',
})
export class QuestionList {
  protected readonly questions = signal<Question[]>([
    {
      id: 1,
      text: 'ข้อใดเป็นจำนวนเฉพาะ',
      choices: [
        { id: 1, choiceNo: 1, text: '3' },
        { id: 2, choiceNo: 2, text: '5' },
        { id: 3, choiceNo: 3, text: '9' },
        { id: 4, choiceNo: 4, text: '11' },
      ],
    },
    {
      id: 2,
      text: '2 × 2 มีค่าเท่าไร',
      choices: [
        { id: 5, choiceNo: 1, text: '1' },
        { id: 6, choiceNo: 2, text: '2' },
        { id: 7, choiceNo: 3, text: '3' },
        { id: 8, choiceNo: 4, text: '4' },
      ],
    },
  ]);
}
