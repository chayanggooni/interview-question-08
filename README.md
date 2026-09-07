# Interview Question 08

A full-stack application for managing exam questions, built with Angular and ASP.NET Core.

## Features

- View exam questions and choices
- Add a new question with 4 choices
- Delete questions
- Automatically display continuous question numbers after deletion
- Form validation
- Initial sample data seeding

## Tech Stack

### Frontend
- Angular 22
- Bootstrap 5
- SCSS
- Reactive Forms

### Backend
- ASP.NET Core (.NET 10)
- Entity Framework Core
- SQLite

### Development
- Docker
- Docker Compose

## Project Structure

```text
src/
├── web/    Angular frontend
└── api/    ASP.NET Core API

tests/
└── InterviewQuestion08.Api.Tests/
```

## Run with Docker

Clone the repository:

```bash
git clone https://github.com/chayanggooni/interview-question-08.git
cd interview-question-08
```

Start the application:

```bash
docker compose up --build
```

Open:

```text
http://localhost:4200
```

The SQLite database is created automatically using EF Core migrations and initialized with sample data.

## Reset Database

To remove the current database and start again with the initial seed data:

```bash
docker compose down -v
docker compose up --build
```

## API Endpoints

| Method | Endpoint | Description |
| --- | --- | --- |
| GET | `/api/questions` | Get all questions |
| POST | `/api/questions` | Create a question |
| DELETE | `/api/questions/{id}` | Delete a question |

## Notes

Question IDs are database identifiers and are not used as question numbers.

Question numbers are generated from the displayed list order, so after a question is deleted the remaining questions are automatically displayed with continuous numbering.
