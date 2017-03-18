using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using CourseResultWebApp.Models;

namespace CourseResultWebApp.DAL
{
    public class DepartmentGateway
    {

        string connectionString =
                WebConfigurationManager.ConnectionStrings["CourseResultDBConnectionString"].ConnectionString;


        public int Save(Department department)
        {
            SqlConnection connection = new SqlConnection(connectionString);

            string query = string.Format("INSERT INTO Department(DepartmentCode,DepartmentName) VALUES ('{0}','{1}')",
                department.DepartmentCode, department.DepartmentName);

            SqlCommand command = new SqlCommand(query, connection);
            connection.Open();

            int isRowAffected = command.ExecuteNonQuery();
            connection.Close();

            return isRowAffected;
        }

        public List<Department> GetAllDepartment()
        {
            SqlConnection connection = new SqlConnection(connectionString);

            string query = string.Format("SELECT * FROM Department");
            SqlCommand command = new SqlCommand(query, connection);

            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            List<Department> departments = new List<Department>();

            while (reader.Read())
            {
                Department department = new Department();
                {
                    department.DepartmentId = Convert.ToInt32(reader["DepartmentId"]);
                    department.DepartmentCode = reader["DepartmentCode"].ToString();
                    department.DepartmentName = reader["DepartmentName"].ToString();
                }
                departments.Add(department);

            }
            reader.Close();
            connection.Close();
            return departments;
        }

        public bool IsDepartmentExist(string DepartmentName)
        {
            SqlConnection connection = new SqlConnection(connectionString);

            string query = string.Format("SELECT * FROM Department WHERE DepartmentName = '{0}'", DepartmentName);

            SqlCommand command = new SqlCommand(query, connection);
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

        public Department GetDepartmentById(int DepartmentId)
        {
            SqlConnection connection = new SqlConnection();

            string query = string.Format("SELECT * FROM Department WHERE DepartmentID = " + DepartmentId);
            SqlCommand command = new SqlCommand(query, connection);
            connection.Open();

            SqlDataReader reader = command.ExecuteReader();
            Department department = new Department();

            if (reader.Read())
            {
                department = new Department();
                {
                    department.DepartmentId = Convert.ToInt32("DepartmentId");
                    department.DepartmentCode = reader["DepartmentCode"].ToString();
                    department.DepartmentName = reader["DepartmentName"].ToString();
                }

            }
            reader.Close();
            connection.Close();

            return department;
        }

        public bool IsDepartmentCodeExist(string code)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            string query = string.Format("SELECT * FROM Department WHERE DepartmentCode ='{0}'", code);

            SqlCommand command = new SqlCommand(query, connection);
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
    }
}