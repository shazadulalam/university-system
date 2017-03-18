using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CourseResultWebApp.Manager;
using CourseResultWebApp.Models;

namespace CourseResultWebApp.Controllers
{
    public class CourseController : Controller
    {
        DepartmentManager aDepartmentManager = new DepartmentManager();
        //SemesterManager aSemesterManager = new SemesterManager();
        private CourseManager aCourseManager = new CourseManager();

        public ActionResult Save()
        {
            ViewBag.Departments = aDepartmentManager.DepartmentDropdown();
            
            return View();
        }

        [HttpPost]
        public ActionResult Save(Course course)
        {
            if (aCourseManager.IsCodeExist(course.CourseCode))
            {
                ViewBag.Message = (dynamic)new HtmlString("<div class='alert alert-warning'><strong>Error!</strong> Code already exist.</div>");
            }
            else if (aCourseManager.IsNameExist(course.CourseName))
            {
                ViewBag.Message = (dynamic)new HtmlString("<div class='alert alert-warning'><strong>Error!</strong> Name already exist.</div>");
            }
            else
            {
                ViewBag.Message = aCourseManager.Save(course)
                ? (dynamic)new HtmlString("<div class='alert alert-success'><strong>Success!</strong> Information has been saved successfully.</div>")
                : (dynamic)new HtmlString("<div class='alert alert-danger'><strong>Error!</strong> Failed to save Information.</div>");
                ModelState.Clear();
            }

            ViewBag.Departments = aDepartmentManager.DepartmentDropdown();
          
            return View();
        }
    }
}
