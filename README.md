#  StudyMate — Smart Student Planner

### A Smart Study Management Application Built with C# and Blazor

StudyMate is a web-based student productivity application designed to help students organize assignments, manage deadlines, track academic progress, and improve study habits.

The application combines task management, scheduling, focus sessions, analytics, and personalized study recommendations in one user-friendly platform.

##  Project Objectives

The main objectives of StudyMate are to:

- Simplify academic task management.
- Help students organize assignments and deadlines.
- Improve time management and productivity.
- Provide visual insights into study progress.
- Support focused study sessions using the Pomodoro technique.
- Generate personalized task recommendations.
- Create a responsive and accessible study environment.

##  Main Features

### 1. Dashboard

The Dashboard provides an overview of academic activities, including:

- Total assignments.
- Completed tasks.
- Tasks in progress.
- Pending assignments.
- Study progress percentage.
- Upcoming deadlines.
- Deadline reminders.

### 2. Task Management

Students can:

- Create new assignments.
- Edit existing tasks.
- Delete assignments with confirmation.
- Assign priorities and deadlines.
- Change task statuses.
- Search and filter assignments.
- Sort tasks by deadline, priority, or title.

The application includes input validation and error handling to prevent invalid task information.

### 3. Academic Calendar

The Calendar displays assignments according to their deadlines and allows students to review tasks for selected dates.

### 4. Subject Progress

The Subjects page organizes assignments by academic subject and displays progress information.

### 5. Pomodoro Focus Timer

StudyMate includes a Pomodoro timer with:

- Focus sessions.
- Short breaks.
- Long breaks.
- Start, pause, and reset controls.
- Customizable session durations.
- Saved focus session history.

### 6. Study Analytics

The Analytics page provides visual information about task completion and study activity.

It includes task statistics, focus session data, and productivity indicators.

### 7. Smart Recommendations

StudyMate includes a rule-based recommendation system that analyzes:

- Task priority.
- Deadline urgency.
- Current task status.

The system calculates recommendation scores and suggests which assignments students should focus on first.

### 8. Study Notes

Students can create, edit, search, and delete study notes.

### 9. Personalized Settings

Users can customize:

- Student profile information.
- Application color theme.
- Pomodoro timer durations.
- Deadline reminder visibility.

Settings are saved and managed through the application's state management system.

##  Technologies Used

| Technology | Purpose |
|---|---|
| C# | Application logic |
| .NET 8 | Application framework |
| Blazor Web App | Interactive web interface |
| Razor Components | Reusable UI components |
| Entity Framework Core | Database operations |
| SQLite | Local data storage |
| HTML | Page structure |
| CSS | Styling and responsive design |
| Dependency Injection | Service management |
| xUnit | Unit testing |
| Visual Studio 2022 | Development environment |
| Git & GitHub | Version control |

##  Application Architecture

StudyMate uses a component-based architecture with separation of responsibilities.

**Presentation Layer**

Blazor Razor components provide the user interface and handle user interactions.

**Business Logic Layer**

Services implement task management, recommendations, validation, settings, notes, and focus session operations.

**Data Layer**

Entity Framework Core communicates with SQLite databases to store and retrieve application data.

### Main Architectural Components

**Components**

- Dashboard
- Tasks
- Calendar
- Subjects
- Focus Timer
- Analytics
- Smart Recommendations
- Study Notes
- Settings

**Services**

- TaskService
- PomodoroService
- NoteService
- SettingsService
- RecommendationService
- ValidationService
- AppState

**Models**

- TaskItem
- SmartRecommendation
- AppSettings
- PomodoroSession

The project uses Dependency Injection to connect application components with their services.

##  Smart Recommendation Algorithm

The recommendation system assigns scores to unfinished assignments based on three factors.

**Priority Score**

- High: 40 points
- Medium: 25 points
- Low: 10 points

**Deadline Score**

- Overdue: 60 points
- Due today: 55 points
- Due tomorrow: 45 points
- Due within 3 days: 30 points
- Due within 7 days: 15 points
- Later deadlines: 5 points

**Status Bonus**

- In Progress: +10 points

Completed tasks are excluded from recommendations.

The remaining tasks are ranked by their calculated scores, helping students identify the most important assignments.

##  Testing and Quality Assurance

StudyMate uses xUnit for automated unit testing.

The test suite covers:

- Recommendation scoring.
- Deadline urgency.
- Task priority.
- Completed task exclusion.
- Recommendation sorting.
- Input validation.
- Invalid task information.
- Missing required fields.

Additional tests verify recommendation behavior under different conditions. 

The application also supports manual functional testing of its main features.

##  Responsive Design

StudyMate uses responsive CSS layouts to support different screen sizes.

The interface includes adaptive cards, grids, navigation elements, and task tables.

##  Validation and Error Handling

StudyMate includes validation rules for task information.

The application checks required fields, title length, deadline values, task priorities, and task statuses.

User-friendly error messages help students correct invalid information.

Exception handling is used in task operations to reduce unexpected application failures.

##  Running the Project

### Requirements

- Visual Studio 2022
- .NET 8 SDK
- ASP.NET Core development tools

### Installation

1. Clone or download the StudyMate repository.
2. Open the StudyMate solution in Visual Studio 2022.
3. Restore NuGet packages.
4. Build the solution.
5. Set the StudyMate web project as the startup project.
6. Run the application using F5.

### Running Unit Tests

1. Open the solution in Visual Studio.
2. Navigate to Test ? Test Explorer.
3. Select Run All Tests.
4. Review the test results.

##  Future Improvements

Potential improvements include:

- Student authentication and individual accounts.
- Cloud database integration.
- Email and push notifications.
- Collaboration between students.
- AI-assisted study planning.
- Mobile application support.
- Integration with university learning platforms.

##  Conclusion

StudyMate demonstrates how C#, Blazor, Entity Framework Core, and SQLite can be combined to develop an interactive student productivity application.

The project focuses on practical functionality, modular architecture, responsive interface design, data persistence, automated testing, and personalized study planning.

StudyMate aims to provide students with a convenient environment for organizing academic responsibilities and improving productivity.