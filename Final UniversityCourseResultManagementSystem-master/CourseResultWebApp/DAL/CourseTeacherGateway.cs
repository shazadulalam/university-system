using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using CourseResultWebApp.Models;

namespace CourseResultWebApp.DAL
{
    public class CourseTeacherGateway
    {
        string connectionString =
                WebConfigurationManager.ConnectionStrings["CourseResultDBConnectionString"].ConnectionString;
        public int Save(CourseTeacher courseTeacher)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            string query = string.Format("INSERT INTO AssignCourse VALUES( @AssignId, @TeacherId, @CourseId, 1)");

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.Clear();

            command.Parameters.Add("AssignId", SqlDbType.Int);
            command.Parameters["AssignId"].Value = courseTeacher.DepartmentId;

            command.Parameters.Add("tTeacherId", SqlDbType.Int);
            command.Parameters["TeacherId"].Value = courseTeacher.TeacherId;

            command.Parameters.Add("CourseId", SqlDbType.Int);
            command.Parameters["CourseId"].Value = courseTeacher.CourseId;

            connection.Open();

            int rowAffected = command.ExecuteNonQuery();
            connection.Close();
            return rowAffected;
        }

        public bool UpdateAssignedCreditOfTeacher(CourseTeacher courseTeacher)
        {

            SqlConnection connection = new SqlConnection(connectionString);
            string query = string.Format("UPDATE Teacher SET RemainingCredit = (RemainingCredit - @courseCredit) WHERE Id = " + courseTeacher.TeacherId);
            SqlCommand command = new SqlCommand(query,connection);
            command.Parameters.Clear();

            command.Parameters.Add("courseCredit", SqlDbType.Float);
            command.Parameters["courseCredit"].Value = courseTeacher.CourseCredit;


            connection.Open();
            int rowAffected = command.ExecuteNonQuery();
            connection.Close();

            if (rowAffected > 0)
                return true;
            else
                return false;
        }

        public bool IsTeacherAssignedToCourse(CourseTeacher courseTeacher)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            string query = "SELECT * FROM AssignCourse WHERE CourseId =" + courseTeacher.CourseId + " AND TeacherId =" + courseTeacher.TeacherId + " AND isDeleted = 1";

            SqlCommand command = new SqlCommand(query,connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();

            if (reader.HasRows)
            {
                reader.Close();
                connection.Close();
                return true;
            }
            reader.Close();
            connection.Close();

            return false;
        }

        public bool IsCourseAssigned(CourseTeacher courseTeacher)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            string query = "SELECT * FROM AssignCourse WHERE CourseId =" + courseTeacher.CourseId + " AND isDeleted = 1";

            SqlCommand command = new SqlCommand(query,connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();

            if (reader.HasRows)
            {
                reader.Close();
                connection.Close();
                return true;
            }
            reader.Close();
            connection.Close();

            return false;
        }

        public List<object> GetCourseInfo(int departmentId)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            
            string query = @"SELECT  CourseCode,
		                    c.CourseName, 
		                    c.Semester,
		                    t.TeacherName
		
                            FROM Course c JOIN AssignCourse a ON c.CourseID = a.CourseID
			                LEFT JOIN Teacher t ON a.TeacherID = t.TeacherID
                            WHERE c.DepartmentID = " + departmentId;

            SqlCommand command = new SqlCommand(query, connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            List<object> courseInfos = new List<object>();

            while (reader.Read())
            {
                var courseInfo = new
                {
                    CourseCode = reader["CourseCode"].ToString(),
                    CourseName = reader["CourseName"].ToString(),
                    Semester = reader["Semester"].ToString(),
                    Teacher = reader["TeacherName"].ToString(),
                };
                courseInfos.Add(courseInfo);
            }
            reader.Close();
            connection.Close();

            return courseInfos;
        }
    }
}