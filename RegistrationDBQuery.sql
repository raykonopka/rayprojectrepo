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
	,Capacity INT null 
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
GO

