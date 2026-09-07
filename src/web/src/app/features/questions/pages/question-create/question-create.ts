import { Component, inject, signal } from '@angular/core';
import { NonNullableFormBuilder, ReactiveFormsModule, Validators } from '@angular/forms';
import { Router, RouterLink } from '@angular/router';
import { QuestionService } from '../../services/question.service';
import { finalize } from 'rxjs';

@Component({
  imports: [ReactiveFormsModule, RouterLink],
  selector: 'app-question-create',
  styleUrl: './question-create.scss',
  templateUrl: './question-create.html',
})
export class QuestionCreate {
  private readonly fb = inject(NonNullableFormBuilder);
  private readonly questionService = inject(QuestionService);
  private readonly router = inject(Router);

  protected readonly isSaving = signal(false);
  protected readonly errorMessage = signal<string | null>(null);

  private createChoiceControl() {
    return this.fb.control('', [Validators.required, Validators.maxLength(200)]);
  }

  protected readonly form = this.fb.group({
    questionText: ['', [Validators.required, Validators.maxLength(500)]],

    choices: this.fb.array([
      this.createChoiceControl(),
      this.createChoiceControl(),
      this.createChoiceControl(),
      this.createChoiceControl(),
    ]),
  });

  protected submit(): void {
    if (this.form.invalid) {
      this.form.markAllAsTouched();
      return;
    }

    this.isSaving.set(true);
    this.errorMessage.set(null);

    const request = this.form.getRawValue();

    this.questionService
      .createQuestion(request)
      .pipe(finalize(() => this.isSaving.set(false)))
      .subscribe({
        next: () => {
          this.router.navigate(['/questions']);
        },
        error: () => {
          this.errorMessage.set('Unable to save the question. Please try again.');
        },
      });
  }
}
