# To-Do List Application in ASP.NET

Welcome to the To-Do List Application! This application is built using ASP.NET and provides a platform for users to manage their daily tasks. The key features include user registration, login, daily diary entries, and task management (add, edit, delete, display). This README file will guide you through setting up and using the application.

## Features

1. **User Registration**: Allows new users to register an account.
2. **User Login**: Enables registered users to log in to their account.
3. **Daily Diary**: Users can maintain a daily diary.
4. **Task Management**:
   - **Add Tasks**: Users can add new tasks to their to-do list.
   - **Edit Tasks**: Users can edit existing tasks.
   - **Delete Tasks**: Users can delete tasks.
   - **Display Tasks**: Users can view their list of tasks.

## Prerequisites

- .NET SDK
- Visual Studio
- SQL Server or any other supported database
- Basic knowledge of C# and ASP.NET

## Getting Started

### 1. Clone the Repository

```bash
git clone https://github.com/yourusername/todo-list-aspnet.git
cd todo-list-aspnet
```
### 2. Open the Project
Open the project in Visual Studio.

### 3. Configure the Database
Update the connection string in appsettings.json to match your database configuration.
```
"ConnectionStrings": {
  "DefaultConnection": "Server=your_server;Database=your_database;User Id=your_user;Password=your_password;"
}
```
### 4. Run Migrations
Run the following commands in the Package Manager Console to apply migrations and create the database schema.
```
Update-Database
```
### 5. Build and Run the Application
Press F5 in Visual Studio to build and run the application.

## Project Structure
- Controllers: Contains the controllers for handling HTTP requests.
- AccountController: Manages user registration and login.
- DiaryController: Handles daily diary entries.
- TaskController: Manages tasks (add, edit, delete, display).
- Models: Contains the application models.
- User: Represents a user in the system.
- DiaryEntry: Represents a daily diary entry.
- Task: Represents a task in the to-do list.
- Views: Contains the Razor views for the application.
- Account: Views for registration and login.
- Diary: Views for daily diary entries.
- Tasks: Views for task management.
- Data: Contains the data context and migrations.
- ApplicationDbContext: The database context.
- Migrations: Database migrations.
- Usage
- Register
- Navigate to the registration page.
- Fill in the required details and submit the form.
- After successful registration, you can log in using your credentials.
- Login
- Navigate to the login page.
- Enter your credentials and submit the form.
- Upon successful login, you will be redirected to the dashboard.
- Daily Diary
- Navigate to the daily diary page.
- Add a new diary entry by filling in the details and submitting the form.
- View or edit existing diary entries.
- Task Management
- Navigate to the tasks page.
- Add a new task by filling in the details and submitting the form.
- Edit existing tasks by selecting the edit option next to the task.
- Delete tasks by selecting the delete option next to the task.
- View all tasks in the to-do list.
- Contributing
I f you wish to contribute to the project, please fork the repository and submit a pull request  .
