using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CourseResultWebApp.DataAcess;
using CourseResultWebApp.Models;

namespace CourseResultWebApp.Manager {
    public class ResultManager {
        ViewResultGateway objViewResultGateway = new ViewResultGateway();

        //Getting the list of all students for ViewResult DropDownList
        public List<Student> GetListOfStudents() {
            List<Student> allStudents = objViewResultGateway.GetListOfStudents();
            return allStudents;
        }

        public List<Result> GetStudentByRegNo(string studentReg) {
            return objViewResultGateway.GetStudentByRegNo(studentReg);
        }
    }
}