using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CourseResultWebApp.DAL;
using CourseResultWebApp.Models;

namespace CourseResultWebApp.Manager
{
    public class CourseTeacherManager
    {
        CourseTeacherGateway courseGateway = new CourseTeacherGateway();
        public bool Save(CourseTeacher courseTeacher)
        {
            if (courseGateway.Save(courseTeacher) > 0)
            {
                return (courseGateway.UpdateAssignedCreditOfTeacher(courseTeacher));
            }
            return false;
        }

        public bool IsTeacherAssignedToCourse(CourseTeacher courseTeacher)
        {
            return courseGateway.IsTeacherAssignedToCourse(courseTeacher);
        }

        public bool IsCourseAssigned(CourseTeacher courseTeacher)
        {
            return courseGateway.IsCourseAssigned(courseTeacher);
        }

        public List<object> GetCourseInfo(int departmentId)
        {
            return courseGateway.GetCourseInfo(departmentId);
        }
    }
}