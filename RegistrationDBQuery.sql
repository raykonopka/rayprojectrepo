-- Setup database
USE master;
GO

CREATE DATABASE RegistrationDB;
GO

USE RegistrationDB;
GO

CREATE SCHEMA Registration;
GO



-- Create tables and primary keys
CREATE TABLE Registration.Courses
(
    Id int not null IDENTITY(1,1)
    ,Title NVARCHAR(250) not null
    ,DepartmentId INT not null
    ,Credits INT not null 
);

ALTER TABLE Registration.Courses
    ADD CONSTRAINT pk_courses_id primary key clustered (Id);
GO


CREATE TABLE Registration.Departments
(
    Id int not null IDENTITY(1,1)
    ,DepartmentName NVARCHAR(250) not null
);

ALTER TABLE Registration.Departments
    ADD CONSTRAINT pk_departments_id PRIMARY KEY CLUSTERED (Id);
GO


CREATE TABLE Registration.CourseSessions
(
    Id INT not null IDENTITY(1,1)
    ,CourseId INT not null
    ,Professor NVARCHAR(250) not null 
	,StartTime TIME not null 
	,EndTime TIME not null
	,DaysInSession NVARCHAR(10) not null
	,Capacity INT not null 
);

ALTER TABLE Registration.CourseSessions
    ADD CONSTRAINT pk_coursesessions_id PRIMARY KEY CLUSTERED (Id);
GO


CREATE TABLE Registration.Students
(
    Id int not null IDENTITY(1,1)
    ,StudentName NVARCHAR(250) not null
    ,MajorId INT not null 
);

ALTER TABLE Registration.Students
    ADD CONSTRAINT pk_students_id PRIMARY KEY CLUSTERED (Id);
GO


CREATE TABLE Registration.Majors
(
    Id INT not null IDENTITY(1,1)
    ,MajorName NVARCHAR(250) not null
);

ALTER TABLE Registration.Majors
    ADD CONSTRAINT pk_majors_id PRIMARY KEY CLUSTERED (Id);
GO


CREATE TABLE Registration.Schedules
(
    Id int not null IDENTITY(1,1)
    ,StudentId INT not null
    ,CourseSessionId INT not null 
);

ALTER TABLE Registration.Schedules
    ADD CONSTRAINT pk_schedules_id PRIMARY KEY CLUSTERED (Id);
GO


CREATE TABLE Registration.StudentUsers
(
    Id int not null IDENTITY(1,1)
    ,Username NVARCHAR(150) not null
    ,UserPassword NVARCHAR(150) not null
    ,StudentId INT not null
);

ALTER TABLE Registration.StudentUsers
    ADD CONSTRAINT pk_studentusers_id PRIMARY KEY CLUSTERED (Id);
GO


CREATE TABLE Registration.RegistrarUsers
(
    Id int not null IDENTITY(1,1)
    ,Username NVARCHAR(150) not null
    ,UserPassword NVARCHAR(150) not null
);

ALTER TABLE Registration.RegistrarUsers
    ADD CONSTRAINT pk_registrarusers_id PRIMARY KEY CLUSTERED (Id);
GO


CREATE TABLE Registration.BookmarkedSessions
(
    Id int not null IDENTITY(1,1)
	,StudentUserId INT not null
	,SessionId INT not null
);

ALTER TABLE Registration.BookmarkedSessions
    ADD CONSTRAINT pk_bookmarkedsessions_id PRIMARY KEY CLUSTERED (Id);
GO



-- Create foreign keys
ALTER TABLE Registration.Courses
    ADD CONSTRAINT fk_courses_departmentid FOREIGN KEY (DepartmentId) REFERENCES Registration.Departments (Id); 

ALTER TABLE Registration.CourseSessions
    ADD CONSTRAINT fk_coursesessions_courseid FOREIGN KEY (CourseId) REFERENCES Registration.Courses (Id); 

ALTER TABLE Registration.Students
    ADD CONSTRAINT fk_students_majorid FOREIGN KEY (MajorId) REFERENCES Registration.Majors (Id); 

ALTER TABLE Registration.Schedules
    ADD CONSTRAINT fk_schedules_studentid FOREIGN KEY (StudentId) REFERENCES Registration.Students (Id); 

ALTER TABLE Registration.Schedules
    ADD CONSTRAINT fk_schedules_coursesessionid FOREIGN KEY (CourseSessionId) REFERENCES Registration.CourseSessions (Id); 

ALTER TABLE Registration.StudentUsers
    ADD CONSTRAINT fk_studentusers_studentid FOREIGN KEY (StudentId) REFERENCES Registration.Students (Id); 

ALTER TABLE Registration.BookmarkedSessions
    ADD CONSTRAINT fk_bookmarkedsessions_sessionid FOREIGN KEY (SessionId) REFERENCES Registration.CourseSessions (Id); 

ALTER TABLE Registration.BookmarkedSessions
    ADD CONSTRAINT fk_bookmarkedsessions_studentuserid FOREIGN KEY (StudentUserId) REFERENCES Registration.StudentUsers (Id); 
GO



--Add Test data
INSERT INTO Registration.Departments
VALUES ('Engineering');

INSERT INTO Registration.Departments
VALUES ('Writing');

INSERT INTO Registration.Courses
VALUES ('Intro To Java', 1, 3);

INSERT INTO Registration.Courses
VALUES ('Composition I', 2, 3);

INSERT INTO Registration.Courses
VALUES ('Composition II', 2, 3);

INSERT INTO Registration.CourseSessions
VALUES (5, 'Bob Smith', '12:30:00', '13:30:00', 'MWF', 15);

INSERT INTO Registration.CourseSessions
VALUES (5, 'Cindy Johnson', '18:00:00', '19:30:00', 'TH', 22);

INSERT INTO Registration.CourseSessions
VALUES (9, 'Jessica Johnson', '8:00:00', '10:30:00', 'TH', 28);

INSERT INTO Registration.CourseSessions
VALUES (5, 'Ryan Smith', '10:30:00', '12:30:00', 'MWF', 25);

INSERT INTO Registration.CourseSessions
VALUES (1, 'Ron Smith', '13:30:00', '15:30:00', 'MWF', 32);

INSERT INTO Registration.CourseSessions
VALUES (1, 'Bob Johnson', '17:00:00', '18:30:00', 'MWF', 20);

INSERT INTO Registration.Majors
VALUES ('Computer Science');

INSERT INTO Registration.Students
VALUES ('Ray Konopka', 1);

INSERT INTO Registration.Students
VALUES ('John Smith', 1);

INSERT INTO Registration.Schedules
VALUES (1,1);

INSERT INTO Registration.Schedules
VALUES (1,12);

INSERT INTO Registration.StudentUsers
VALUES ('raystudent', 'password123', 1); 

INSERT INTO Registration.RegistrarUsers
VALUES ('rayregistrar', 'password123'); 

INSERT INTO Registration.RegistrarUsers
VALUES ('bobregistrar', 'password123'); 

INSERT INTO Registration.BookmarkedSessions
VALUES (1,2); 
GO



-- Read Test Data
SELECT * FROM
Registration.Departments;

SELECT * FROM
Registration.Courses;

SELECT * FROM
Registration.CourseSessions;

SELECT * FROM
Registration.Majors;

SELECT * FROM
Registration.Students;

SELECT * FROM
Registration.Schedules;

SELECT * FROM
Registration.StudentUsers;

SELECT * FROM
Registration.RegistrarUsers;

SELECT * FROM
Registration.BookmarkedSessions;
GO

DELETE FROM Registration.BookmarkedSessions
WHERE Id = 14;

DELETE FROM Registration.Schedules
WHERE Id = 16;
GO