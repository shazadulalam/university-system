using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using CourseResultWebApp.Models;

namespace CourseResultWebApp.DataAcess {
    public class ViewResultGateway {
        static readonly string ConnectionString = WebConfigurationManager.ConnectionStrings["CourseResultDBString"].ConnectionString;
        private SqlConnection _connection = new SqlConnection( ConnectionString );

        //Getting the list of all students for ViewResult DropDownList
        public List<Student> GetListOfStudents() {
            List<Student> allStudents = new List<Student>();
            string getAllStudentsQuery = "SELECT * FROM GetStudentInfoForViewResult";
            SqlCommand getAllStudentCommand = new SqlCommand( getAllStudentsQuery, _connection );

            _connection.Open();
            try {
                SqlDataReader objReader = getAllStudentCommand.ExecuteReader();
                while(objReader.Read()) {
                    Student objStudent = new Student();
                    objStudent.StudentRegNo = Convert.ToString( objReader["RegNo"] );
                    allStudents.Add( objStudent );
                }
                objReader.Close();
            }
            catch(Exception e) {
                _connection.Close();
                throw e;
            }
            _connection.Close();
            return allStudents;
        }

        //Get Info of Specific Student By Registration Number
        public List<Result> GetStudentByRegNo( string studentReg ) {
            List<Result> resultList = new List<Result>();
            string getStudentByRegNoQuery = "SELECT R.StudentRegNo,R.StudentName, R.StudentEmail, R.DepartmentName,C.CourseCode,R.CourseName,R.CourseGrade FROM Result R INNER JOIN Course C ON R.CourseName = C.CourseName WHERE R.StudentRegNo= @regNo";
            SqlCommand getStudentInfoCommand = new SqlCommand( getStudentByRegNoQuery, _connection );

            getStudentInfoCommand.Parameters.Clear();
            getStudentInfoCommand.Parameters.Add( "regNo", SqlDbType.VarChar );
            getStudentInfoCommand.Parameters["regNo"].Value = studentReg;

            _connection.Open();
            try {
                SqlDataReader objReader = getStudentInfoCommand.ExecuteReader();
                while(objReader.Read()) {
                    Result objResult = new Result();
                    objResult.StudentName = Convert.ToString( objReader["StudentName"] );
                    objResult.StudentEmail = Convert.ToString( objReader["StudentEmail"] );
                    objResult.DepartmentName = Convert.ToString( objReader["DepartmentName"] );
                    objResult.CourseCode = Convert.ToString( objReader["CourseCode"] );
                    objResult.CourseName = Convert.ToString( objReader["CourseName"] );
                    objResult.CourseGarde = Convert.ToString( objReader["CourseGrade"] );
                    resultList.Add(objResult);
                }
                objReader.Close();
            }
            catch(Exception ex) {
                _connection.Close();
                throw ex;
            }
            _connection.Close();
            return resultList;
        }
    }
}