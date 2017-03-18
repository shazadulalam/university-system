using System.Diagnostics.Eventing.Reader;
using System.Web.Configuration;
using CourseResultWebApp.DAL;
using CourseResultWebApp.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CourseResultWebApp.Controllers
{
    public class StudentController : Controller
    {
        string connectionString =
                WebConfigurationManager.ConnectionStrings["CourseResultDBConnectionString"].ConnectionString;

        public ActionResult Index(Student student)
        {
            try
            {
                Student student_obj = new Student();
                SqlConnection connection = new SqlConnection(connectionString);
                connection.Open();

                string querystring1 = string.Format("select * from Department");
                SqlCommand command1 = new SqlCommand(querystring1, connection);

                SqlDataReader reader1 = command1.ExecuteReader();

                var selectList = new List<SelectListItem>();
                while (reader1.Read())
                {
                    student_obj.DepartmentId = Convert.ToInt32(reader1[0]);
                    student_obj.DepartmentCode = reader1[1].ToString();

                    selectList.Add(new SelectListItem
                    {
                        Value = student_obj.DepartmentId.ToString(),
                        Text = student_obj.DepartmentCode
                    });
                }
                 student_obj.DepartmentId = 0;
                student_obj.Department_List = selectList;                
                student_obj.RegDate = System.DateTime.Now;
                if (TempData["Validation"] != null)
                {
                    ViewBag.Validation = TempData["Validation"];
                }
                if (TempData["Success"] != null)
                {
                    if (TempData["Success"].ToString() == "Yes")
                    {
                        ViewBag.Message = "Student Registered Successfully";
                        ViewBag.Color = "green";
                    }
                    else if (TempData["Success"].ToString() == "No")
                    {
                        ViewBag.Message = "Can't Register. Please try again...";
                        ViewBag.Color = "red";
                    }
                }
                if (TempData["Result"] != null)
                {
                    ViewBag.ShowResult = TempData["Result"];
                }


                if (TempData["Validation"] != null)
                {
                    student_obj.StudentName = student.StudentName;
                    student_obj.StudentEmail = student.StudentEmail;
                    student_obj.StudentContactNo = student.StudentContactNo;
                    student_obj.StudentAddress = student.StudentAddress;
                    student_obj.DepartmentId = student.DepartmentId;
                }
                return View(student_obj);
            }
            catch (Exception ex)
            {
                ViewBag.Message = "Can't Register. Please try again...";
                ViewBag.Color = "red";
                return null;
            }         
        }
        
        Student student_obj = new Student();
        [HttpPost]
        public ActionResult Index(Student student, string msg)
        {
            try
            {
                string EmailHas = null, ContactNoHas = null;
                
                Student student_obj = new Student();
                SqlConnection connection = new SqlConnection(connectionString);
                connection.Open();

                
                string Email = string.Format("select StudentEmail from student");
                SqlCommand EmailCommand = new SqlCommand(Email, connection);
                SqlDataReader Emailreader = EmailCommand.ExecuteReader();
                while (Emailreader.Read())
                {
                    string email = Emailreader["StudentEmail"].ToString();
                    if(email == student.StudentEmail)
                    {
                        EmailHas = email;
                        break;
                    }
                }
                Emailreader.Close();


                string ContactNo = string.Format(@"select StudentContactNo from student");
                SqlCommand ContactNoCommand = new SqlCommand(ContactNo, connection);
                SqlDataReader ContactNoreader = ContactNoCommand.ExecuteReader();
                while (ContactNoreader.Read())
                {
                    string contactno = ContactNoreader["StudentContactNo"].ToString();
                    if (contactno == student.StudentContactNo)
                    {
                        ContactNoHas = contactno;
                        break;
                    }
                }
                ContactNoreader.Close();


                if (!string.IsNullOrEmpty(EmailHas) && string.IsNullOrEmpty(ContactNoHas))
                {
                    TempData["Validation"] = "Email already exists.";
                    connection.Close();
                    return RedirectToAction("Index",student);
                }
                if (string.IsNullOrEmpty(EmailHas) && !string.IsNullOrEmpty(ContactNoHas))
                {
                    TempData["Validation"] = "ContactNo already exists.";
                    connection.Close();
                    return RedirectToAction("Index",student);
                }
                if (!string.IsNullOrEmpty(EmailHas) && !string.IsNullOrEmpty(ContactNoHas))
                {
                    TempData["Validation"] = "Email & ContactNo already exists.";
                    connection.Close();
                    return RedirectToAction("Index", student);
                }
                //For validation end



                string querystring2 = string.Format(@"select * from Department where DepartmentID = '{0}'", student.DepartmentId);
                SqlCommand command2 = new SqlCommand(querystring2, connection);

                SqlDataReader reader = command2.ExecuteReader();
                while (reader.Read())
                {
                    student_obj.DepartmentCode = reader[1].ToString();
                }
                reader.Close();




                string querystring3 = string.Format(@"select * from Student where DepartmentID = '{0}'", student.DepartmentId);
                SqlCommand command3 = new SqlCommand(querystring3, connection);

                SqlDataReader reader3 = command3.ExecuteReader();
                while (reader3.Read())
                {
                    student_obj.RegNo = reader3[1].ToString().Split('-')[2];
                }
                reader3.Close();



                string reg_no = (Convert.ToInt32(student_obj.RegNo) + 1).ToString();
                if (reg_no.Length == 1)
                    reg_no = "0" + "0" + reg_no;
                else if (reg_no.Length == 2)
                    reg_no = "0" + reg_no;
                student_obj.RegNo = student_obj.DepartmentCode + '-' + student.RegDate.Year + '-' + reg_no;

                if (!string.IsNullOrEmpty(student.StudentName) && !string.IsNullOrEmpty(student.StudentEmail) &&
                    !string.IsNullOrEmpty(student.StudentContactNo) && !string.IsNullOrEmpty(student.RegDate.ToString()) &&
                    !string.IsNullOrEmpty(student.StudentAddress) &&
                    !string.IsNullOrEmpty(student.DepartmentId.ToString()))
                {
                    string querystring1 = string.Format(@"insert into Student values ('{0}','{1}','{2}','{3}','{4}','{5}','{6}')", student_obj.RegNo, student.StudentName, student.StudentEmail, student.StudentContactNo, student.RegDate, student.StudentAddress, student.DepartmentId);
                    SqlCommand command1 = new SqlCommand(querystring1, connection);
                    command1.ExecuteNonQuery();
                    TempData["Success"] = "Yes";
                    TempData["Result"] = "Student RegNo: " + student_obj.RegNo + ", " + "Student Name: " +student.StudentName + ", " + "Student Email: " + student.StudentEmail + ", " + "Student ContactNo: " + student.StudentContactNo + ", " + "Student RegDate: " + student.RegDate + ", " + "Student Address: " + student.StudentAddress + ", " + "Department: " + student_obj.DepartmentCode;
                }
                else
                {
                    TempData["Success"] = "No";
                }
                connection.Close();              
                return RedirectToAction("Index");
            }
            catch(Exception ex)
            {
                ViewBag.Message = "Can't Register. Please try again...";
                ViewBag.Color = "red";
                return View();
            }
        }

    }
}
