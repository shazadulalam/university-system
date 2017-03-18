using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using CourseResultWebApp.Models;

namespace CourseResultWebApp.DAL
{
    public class TeacherGateway
    {
        string connectionString =
                WebConfigurationManager.ConnectionStrings["CourseResultDBConnectionString"].ConnectionString;

        public List<Teacher> GetTeacherByTeacherId(int teacherId)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            string query = "SELECT * FROM Teacher WHERE TeacherID=" + teacherId;
            SqlCommand command = new SqlCommand(query,connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            List<Teacher> teachers = new List<Teacher>();

            while (reader.Read())
            {
                Teacher teacher = new Teacher()
                {
                    Id = Convert.ToInt32(reader["Id"]),
                    TeacherName = reader["Name"].ToString(),
                    TeacherAddress = reader["Address"].ToString(),
                    TeacherEmail = reader["Email"].ToString(),
                    TeacherContactNo = reader["ContactNo"].ToString(),
                    TeacherDesignation = Convert.ToInt32(reader["Designation"]),
                    DepartmentID = Convert.ToInt32(reader["DepartmentId"]),
                    TeacherCredit = Convert.ToDouble(reader["CreditLimit"]),
                    RemainingCredit = Convert.ToDouble(reader["RemainingCredit"])
                };
                teachers.Add(teacher);
            }
            reader.Close();
            connection.Close();
            return teachers;
        }

        public List<Teacher> GetTeachersByDepartment(int departmentId)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            string query = "SELECT Id, Name FROM Teacher WHERE DepartmentId=" + departmentId;
            SqlCommand command = new SqlCommand(query, connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();

            List<Teacher> teachers = new List<Teacher>();

            while (reader.Read())
            {
                Teacher teacher = new Teacher()
                {
                    Id = Convert.ToInt32(reader["Id"]),
                    TeacherName = reader["Name"].ToString()
                };
                teachers.Add(teacher);
            }
            reader.Close();
            connection.Close();
            return teachers;
        }
    }
}