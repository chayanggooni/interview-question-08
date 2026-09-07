import { HttpClient } from '@angular/common/http';
import { inject, Injectable } from '@angular/core';

import { CreateQuestionRequest, Question } from '../models/question.model';

@Injectable({
  providedIn: 'root',
})
export class QuestionService {
  private readonly http = inject(HttpClient);

  private readonly baseUrl = '/api/questions';

  getQuestions() {
    return this.http.get<Question[]>(this.baseUrl);
  }

  createQuestion(request: CreateQuestionRequest) {
    return this.http.post<Question>(this.baseUrl, request);
  }

  deleteQuestion(id: number) {
    return this.http.delete<void>(`${this.baseUrl}/${id}`);
  }
}
