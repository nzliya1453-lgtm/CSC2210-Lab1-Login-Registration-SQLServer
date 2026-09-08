# Login, Registration & Logout System using C# and SQL Server

## Student Information

- **Name:** Nusrat Zaman Liya
- **Student ID:** 23-51614-2
- **Course:** CSC 2210 - Object Oriented Programming 2 (C#)
- **Semester:** Summer 2025-26
- **Section:** R
- **Lab:** Lab 1 (Resubmission)

---

# Project Overview

This project is a Windows Forms application developed using C# and SQL Server.

The application provides the following functionality:

- User Registration
- User Login Authentication
- Dashboard Access
- User Logout

The original project used Microsoft Access (`.mdb`) and `System.Data.OleDb`. For this lab, the application was successfully migrated to SQL Server using `System.Data.SqlClient`.

---

# Objectives

The main objectives of this project are:

1. Replace Microsoft Access with SQL Server.
2. Remove all OleDb-related code.
3. Store the database connection string in App.config.
4. Use parameterized SQL queries for database operations.
5. Implement user registration, login, and logout functionality.

---

# Technologies Used

- C#
- Windows Forms
- SQL Server
- SQL Server Management Studio (SSMS)
- Visual Studio
- System.Data.SqlClient
- App.config

---

# Database Design

## Database Name

```sql
db_users
```

## Table Name

```sql
tbl_users
```

## Table Structure

| Column Name | Data Type | Description |
|-------------|-----------|-------------|
| id | INT | Primary Key, Auto Increment |
| username | VARCHAR(50) | Unique Username |
| password | VARCHAR(255) | User Password |

---

# Database Setup

The file `database.sql` is included in this repository.

Run the following script in SQL Server Management Studio:

```sql
IF DB_ID('db_users') IS NULL
BEGIN
    CREATE DATABASE db_users;
END
GO

USE db_users;
GO

IF OBJECT_ID('dbo.tbl_users', 'U') IS NULL
BEGIN
    CREATE TABLE tbl_users
    (
        id INT IDENTITY(1,1) PRIMARY KEY,
        username VARCHAR(50) NOT NULL UNIQUE,
        password VARCHAR(255) NOT NULL
    );
END
GO

IF NOT EXISTS
(
    SELECT *
    FROM tbl_users
    WHERE username = 'admin'
)
BEGIN
    INSERT INTO tbl_users (username, password)
    VALUES ('admin', '12345');
END
GO
```

---

# Connection String Configuration

The database connection is stored inside **App.config** instead of being hardcoded in multiple forms.

### App.config

```xml
<?xml version="1.0" encoding="utf-8" ?>
<configuration>

  <connectionStrings>
    <add name="connString"
         connectionString="Data Source=.\SQLEXPRESS;Initial Catalog=db_users;Integrated Security=True"
         providerName="System.Data.SqlClient" />
  </connectionStrings>

</configuration>
```

---

# Why App.config?

Using App.config makes the application easier to maintain.

Benefits:

- Connection details are stored in one place.
- Database server changes require updating only App.config.
- No need to modify code in every form.
- Improves scalability and maintainability.
- Separates configuration from application logic.

The application reads the connection string using:

```csharp
ConfigurationManager.ConnectionStrings["connString"].ConnectionString
```

---

# Login Functionality

The Login form allows users to authenticate using their username and password.

### Features

- Empty field validation
- Database authentication
- Successful login redirects to Dashboard
- Invalid login displays an error message

### SQL Query

```sql
SELECT COUNT(*)
FROM tbl_users
WHERE username=@username
AND password=@password
```

---

# Registration Functionality

The Registration form allows users to create new accounts.

### Features

- Empty field validation
- Password confirmation validation
- Duplicate username checking
- User data insertion into SQL Server

### Duplicate Username Check

```sql
SELECT COUNT(*)
FROM tbl_users
WHERE username=@username
```

### Insert New User

```sql
INSERT INTO tbl_users
(username,password)
VALUES
(@username,@password)
```

---

# Logout Functionality

The Dashboard contains a Logout button.

When clicked:

1. A confirmation dialog appears.
2. If the user selects **Yes**, the Dashboard closes.
3. The Login form reopens.

This allows the user to log out without closing the entire application.

---

# Security Improvement

The original application used SQL string concatenation:

```csharp
SELECT * FROM tbl_users
WHERE username='" + username + "'
AND password='" + password + "'";
```

This approach is vulnerable to SQL Injection attacks.

The updated version uses parameterized queries:

```csharp
cmd.Parameters.AddWithValue("@username", username);
cmd.Parameters.AddWithValue("@password", password);
```

### Why Parameterized Queries?

Benefits:

- Prevent SQL Injection attacks.
- Improve security.
- Handle special characters safely.
- Improve query reliability.

---

# Forms Included

## frmLogin

- Username
- Password
- Show Password Checkbox
- Login Button
- Register Button
- Clear Button
- Close Button

---

## frmRegister

- Username
- Password
- Confirm Password
- Register Button
- Clear Button
- Back Button

---

## frmDashboard

- Dashboard Screen
- Logout Button

---

# Sample Login Credentials

```text
Username: admin
Password: 12345
```

You may also create new users through the Registration form.

---

# Project Structure

```text
Login-and-Register

│
├── frmLogin.cs
├── frmLogin.Designer.cs
├── frmRegister.cs
├── frmRegister.Designer.cs
├── frmDashboard.cs
├── frmDashboard.Designer.cs
├── Program.cs
├── App.config
├── database.sql
├── README.md
└── Login and Register.sln
```

---

# How to Run the Project

1. Open the solution in Visual Studio.
2. Restore required packages and references.
3. Execute database.sql in SQL Server Management Studio.
4. Verify the connection string in
