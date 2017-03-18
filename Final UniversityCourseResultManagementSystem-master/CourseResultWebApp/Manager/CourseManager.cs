using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CourseResultWebApp.DAL;
using CourseResultWebApp.Models;

namespace CourseResultWebApp.Manager
{
    public class CourseManager
    {
        
        public bool Save(Course course)
        {
            return true;
        }

        public bool IsCodeExist(string code)
        {
            return true;
        }

        public bool IsNameExist(string name)
        {
            return true;
        }

        public List<Course> GetCourseByDepartmentId(int departmentId)
        {
            return null;
        }

        public Course GetCourseById(int courseId)
        {
            return null;
        }
    }
}