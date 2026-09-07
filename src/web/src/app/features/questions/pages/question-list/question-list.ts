import { Component, inject, signal } from '@angular/core';
import { Question } from '../../models/question.model';
import { RouterLink } from '@angular/router';
import { QuestionService } from '../../services/question.service';

@Component({
  imports: [RouterLink],
  selector: 'app-question-list',
  styleUrl: './question-list.scss',
  templateUrl: './question-list.html',
})
export class QuestionList {
  private readonly questionService = inject(QuestionService);

  protected readonly questions = signal<Question[]>([]);
  protected readonly isLoading = signal(false);
  protected readonly errorMessage = signal<string | null>(null);

  constructor() {
    this.loadQuestions();
  }

  private loadQuestions(): void {
    this.isLoading.set(true);
    this.errorMessage.set(null);

    this.questionService.getQuestions().subscribe({
      next: (questions) => {
        this.questions.set(questions);
        this.isLoading.set(false);
      },
      error: () => {
        this.errorMessage.set('Unable to load questions.');
        this.isLoading.set(false);
      },
    });
  }
}
