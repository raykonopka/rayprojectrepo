using RegistrationApp.DataAccess;
using RegistrationApp.DataClient.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RegistrationApp.DataClient
{
    public class DataMapper
    {
        public static CourseDAO MapToCourseDAO(Course courseToMap)
        {
            CourseDAO course = new CourseDAO();

            course.Id = courseToMap.Id;
            course.Title = courseToMap.Title;
            course.DepartmentId = courseToMap.DepartmentId;
            course.Credits = courseToMap.Credits;

            return course;
        }


        public static CourseSessionDAO MapToCourseSessionDAO(CourseSession sessionToMap)
        {
            CourseSessionDAO courseSession = new CourseSessionDAO();

            courseSession.Id = sessionToMap.Id;
            courseSession.CourseId = sessionToMap.CourseId;
            courseSession.Capacity = sessionToMap.Capacity;
            courseSession.DaysInSession = sessionToMap.DaysInSession;
            courseSession.StartTime = sessionToMap.StartTime;
            courseSession.EndTime = sessionToMap.EndTime;
            courseSession.Professor = sessionToMap.Professor;

            return courseSession;
        }


        public static DepartmentDAO MapToDepartmentDAO(Department departmentToMap)
        {
            DepartmentDAO department = new DepartmentDAO();

            department.Id = departmentToMap.Id;
            department.DepartmentName = departmentToMap.DepartmentName;

            return department;
        }


        public static MajorDAO MapToMajorDAO(Major majorToMap)
        {
            MajorDAO major = new MajorDAO();

            major.Id = majorToMap.Id;
            major.MajorName = majorToMap.MajorName;

            return major;
        }


        public static ScheduleDAO MapToScheduleDAO(Schedule scheduleToMap)
        {
            ScheduleDAO schedule = new ScheduleDAO();

            schedule.Id = scheduleToMap.Id;
            schedule.StudentId = scheduleToMap.StudentId;
            schedule.CourseSessionId = scheduleToMap.CourseSessionId;

            return schedule;
        }


        public static StudentDAO MapToStudentDAO(Student studentToMap)
        {
            StudentDAO student = new StudentDAO();

            student.Id = studentToMap.Id;
            student.StudentName = studentToMap.StudentName;
            student.MajorId = studentToMap.MajorId;

            return student;
        }

    }
}