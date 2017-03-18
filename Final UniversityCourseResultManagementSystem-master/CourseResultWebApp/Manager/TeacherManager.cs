using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CourseResultWebApp.DAL;
using CourseResultWebApp.Models;

namespace CourseResultWebApp.Manager
{

    public class TeacherManager
    {
        TeacherGateway aTeacherGateway = new TeacherGateway();

        public List<Teacher> GetTeacherByTeacherId(int teacherId)
        {
            return aTeacherGateway.GetTeacherByTeacherId(teacherId);
        }
    }
}