import { Component, inject } from '@angular/core';
import { NonNullableFormBuilder, ReactiveFormsModule, Validators } from '@angular/forms';
import { RouterLink } from '@angular/router';

@Component({
  imports: [ReactiveFormsModule, RouterLink],
  selector: 'app-question-create',
  styleUrl: './question-create.scss',
  templateUrl: './question-create.html',
})
export class QuestionCreate {
  private readonly fb = inject(NonNullableFormBuilder);

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

    const payload = this.form.getRawValue();

    console.log(payload);
  }
}
