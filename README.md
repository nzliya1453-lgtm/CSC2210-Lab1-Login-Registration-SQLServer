# Login, Registration & Logout System using C# and SQL Server

## Course Information

- **Course:** CSC 2210 - Object Oriented Programming 2 (C#)
- **Semester:** Summer 2025-26
- **Lab:** Lab 1 (Resubmission)
- **Student Name:** Nusrat Zaman Liya
- **Student ID:** 23-51614-2
- **Section:** R

---

## Project Description

This project is a Windows Forms Application developed using C# and SQL Server.

The application provides:

- User Registration
- User Login Authentication
- Dashboard Access
- User Logout

The original application used Microsoft Access Database with OleDb. This project converts the application to SQL Server using `System.Data.SqlClient`.

---

## Technologies Used

- C#
- Windows Forms
- SQL Server
- SQL Server Management Studio (SSMS)
- Visual Studio
- System.Data.SqlClient

---

## Database Setup

Run the following SQL script in SQL Server Management Studio:

```sql
CREATE DATABASE db_users;
GO

USE db_users;
GO

CREATE TABLE tbl_users
(
    id INT IDENTITY(1,1) PRIMARY KEY,
    username VARCHAR(50) NOT NULL UNIQUE,
    password VARCHAR(255) NOT NULL
);
GO

INSERT INTO tbl_users (username, password)
VALUES ('admin', '12345');
GO
```

---

## Connection String

```csharp
private static readonly string myConn =
@"Data Source=.\SQLEXPRESS;
Initial Catalog=db_users;
Integrated Security=True;";
```

Or using App.config:

```xml
<configuration>
  <connectionStrings>
    <add name="connString"
         connectionString="Data Source=.\SQLEXPRESS;Initial Catalog=db_users;Integrated Security=True"
         providerName="System.Data.SqlClient"/>
  </connectionStrings>
</configuration>
```

---

## Features

### Registration

- Create a new account
- Prevent duplicate usernames
- Confirm password matching
- Store data in SQL Server database

### Login

- Authenticate users using username and password
- Validate credentials from SQL Server database
- Open Dashboard after successful login

### Dashboard

- Accessible only after successful login
- Contains Logout functionality

### Logout

- Logout confirmation message
- Returns user to Login Form

---

## Forms Included

### frmLogin

- Username
- Password
- Show Password
- Login Button
- Clear Button
- Close Button

### frmRegister

- Username
- Password
- Confirm Password
- Register Button
- Clear Button
- Back Button

### frmDashboard

- Welcome Dashboard
- Logout Button

---

## Sample Login

```text
Username: admin
Password: 12345
```

Or register a new user and login using the newly created account.

---

## Project Structure

```text
Login and Register
│
├── frmLogin.cs
├── frmRegister.cs
├── frmDashboard.cs
├── Program.cs
├── App.config
├── packages.config
└── Login and Register.sln
```

---

## How to Run

1. Open the project in Visual Studio.
2. Restore NuGet packages.
3. Create the database using the SQL script.
4. Ensure the connection string is correct.
5. Build the solution.
6. Run the application.
7. Register a new user or login with an existing account.

---

## Conclusion

This project successfully implements a Login, Registration, Dashboard, and Logout system using C# Windows Forms and SQL Server. The original Microsoft Access database was replaced with SQL Server, and all authentication features work through SQL queries using `SqlConnection` and `SqlCommand`.
