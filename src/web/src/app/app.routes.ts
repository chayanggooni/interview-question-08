import { Routes } from '@angular/router';

export const routes: Routes = [
  {
    path: 'questions',
    loadComponent: () =>
      import('./features/questions/pages/question-list/question-list').then((m) => m.QuestionList),
  },
  {
    path: 'questions/new',
    loadComponent: () =>
      import('./features/questions/pages/question-create/question-create').then(
        (m) => m.QuestionCreate,
      ),
  },
  {
    path: '',
    pathMatch: 'full',
    redirectTo: 'questions',
  },
];
