using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CourseResultWebApp.Manager;
using CourseResultWebApp.Models;

namespace CourseResultWebApp.Controllers
{
    public class CourseTeacherController : Controller
    {
        DepartmentManager aDepartmentManager = new DepartmentManager();
        TeacherManager aTeacherManager = new TeacherManager();
        CourseTeacherManager aCoursesManager = new CourseTeacherManager();

        public ActionResult Save()
        {
            ViewBag.Departments = aDepartmentManager.DepartmentDropdown();
            return View();
        }

        [HttpPost]
        public ActionResult Save(CourseTeacher courseTeacher)
        {
            if (aCoursesManager.IsTeacherAssignedToCourse(courseTeacher))
            {
                ViewBag.Message = (dynamic)new HtmlString("<div class='alert alert-warning'><strong>Error!</strong> Teacher already Assigned.</div>");
            }
            else if (aCoursesManager.IsCourseAssigned(courseTeacher))
            {
                ViewBag.Message = (dynamic)new HtmlString("<div class='alert alert-warning'><strong>Error!</strong> Course already Assigned.</div>");
            }
            else
            {
                ViewBag.Message = aCoursesManager.Save(courseTeacher)
                ? (dynamic)new HtmlString("<div class='alert alert-success'><strong>Success!</strong> Teacher has been saved assigned successfully.</div>")
                : (dynamic)new HtmlString("<div class='alert alert-danger'><strong>Error!</strong> Failed to assign Teacher.</div>");
            }
            ModelState.Clear();
            ViewBag.Departments = aDepartmentManager.DepartmentDropdown();
            return View();
        }

        public JsonResult AjaxGetTeacherByTeacherId(int teacherId)
        {
            var teacher = aTeacherManager.GetTeacherByTeacherId(teacherId);
            return Json(teacher, JsonRequestBehavior.AllowGet);
        }

        public ActionResult ViewCourseStatics()
        
        
        
        
        {
            ViewBag.Departments = aDepartmentManager.DepartmentDropdown();
            return View();
        }

        public JsonResult AjaxGetCourseInfo(int departmentId)
        {
            var courseInfos = aCoursesManager.GetCourseInfo(departmentId);
            return Json(courseInfos, JsonRequestBehavior.AllowGet);
        }
	}
}