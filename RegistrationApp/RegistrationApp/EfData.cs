using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegistrationApp.DataAccess
{
    public partial class EfData
    {
        private RegistrationDBEntities1 db = new RegistrationDBEntities1();

        #region Students Data Access
        public List<Student> GetStudents()
        {
            return db.Students.ToList();
        }


        public bool InsertStudent(Student student)
        {
            var matchingMajors = db.Majors.Where(s => s.Id.Equals(student.MajorId));

            if (matchingMajors.Count() == 1)
            {
                db.Students.Add(student);
                return db.SaveChanges() > 0;
            }

            else
            {
                Debug.WriteLine("Could not insert student because major id is invalid.");
                return false;
            }
        }
        #endregion


        #region Majors Data Access
        public List<Major> GetMajors()
        {
            return db.Majors.ToList();
        }


        public bool InsertMajor(Major major)
        {
            var matchingMajors = db.Majors.Where(s => s.Id.Equals(major.Id));
            
            if (matchingMajors.Count() == 0)
            {
                db.Majors.Add(major);
                return db.SaveChanges() > 0;
            }

            else
            {
                Debug.WriteLine("Could not insert major because major id is invalid.");
                return false;
            }
        }
        #endregion


        #region Schedules Data Access
        public List<Schedule> GetSchedules()
        {
            return db.Schedules.ToList();
        }


        public bool InsertSchedule(Schedule schedule)
        {
            var matchingStudents = db.Students.Where(s => s.Id.Equals(schedule.StudentId));
            var matchingSessions = db.CourseSessions.Where(s => s.Id.Equals(schedule.CourseSessionId));

            if ( (matchingStudents.Count() == 1) && (matchingSessions.Count() == 1) )
            {
                db.Schedules.Add(schedule);
                return db.SaveChanges() > 0;
            }

            else
            {
                Debug.WriteLine("Invalid student id or invalid session id.");
                return false;
            }
        }
        #endregion


        #region Sessions Data Access
        public List<CourseSession> GetSessions()
        {
            return db.CourseSessions.ToList();
        }


        public bool InsertSession(CourseSession session)
        {
            var matchingCourses = db.Courses.Where(s => s.Id.Equals(session.CourseId));

            if (matchingCourses.Count() == 1)
            {
                db.CourseSessions.Add(session);
                return db.SaveChanges() > 0;
            }

            else
            {
                Debug.WriteLine("Invalid course id.");
                return false;
            }
        }
        #endregion


        #region Courses Data Access
        public List<Course> GetCourses()
        {
            return db.Courses.ToList();
        }


        public bool InsertCourse(Course course)
        {
            var matchingDepartments = db.Departments.Where(s => s.Id.Equals(course.DepartmentId));

            if (matchingDepartments.Count() == 1)
            {
                db.Courses.Add(course);
                return db.SaveChanges() > 0;
            }

            else
            {
                Debug.WriteLine("Invalid department id.");
                return false;
            }
        }
        #endregion

        
        #region Departments Data Access
        public List<Department> GetDepartments()
        {
            return db.Departments.ToList();
        }


        public bool InsertDepartment(Department department)
        {
            var matchingDepartments = db.Departments.Where(s => s.Id.Equals(department.Id));

            if (matchingDepartments.Count() == 0)
            {
                db.Departments.Add(department);
                return db.SaveChanges() > 0;
            }

            else
            {
                Debug.WriteLine("Could not insert department because department id is invalid.");
                return false;
            }
        }
        #endregion


        #region RegistrationDB Functions
        //Register student for course
        public bool registerStudent(int studentId, int sessionId)
        {
            List<Schedule> allSchedules = GetSchedules();
            var currentStudentSchedule = allSchedules.Where(s => s.StudentId.Equals(studentId));

            List<CourseSession> allSessions = GetSessions();
            var matchingSessions = allSessions.Where(i => i.Id.Equals(sessionId));
            CourseSession session = matchingSessions.First();

            //Check for time conflicts
            bool timeConflict;
            timeConflict = false;
            foreach (Schedule scheduleEntry in currentStudentSchedule)
            {
                if (scheduleEntry.CourseSession.DaysInSession == session.DaysInSession)
                {
                    if (
                        (scheduleEntry.CourseSession.StartTime == session.StartTime) ||
                        (scheduleEntry.CourseSession.StartTime > session.StartTime && scheduleEntry.CourseSession.StartTime < session.EndTime)
                       )
                    {
                        timeConflict = true;
                    }
                }
            }

            if (timeConflict)
            {
                Debug.WriteLine("Student is already registered for a class during this time.");
                return false;
            }

            else
            {
                Schedule registrationEntry = new Schedule() { StudentId = studentId, CourseSessionId = sessionId };
                db.Schedules.Add(registrationEntry);
                return db.SaveChanges() > 0;
            }
        }
        #endregion
    }
}
