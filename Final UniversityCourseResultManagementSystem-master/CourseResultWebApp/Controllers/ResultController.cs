using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Rotativa;
using System.Web.Mvc;
using CourseResultWebApp.Manager;
using CourseResultWebApp.Models;

namespace CourseResultWebApp.Controllers {
    public class ResultController : Controller {
        private ResultManager objResultManager = new ResultManager();
        // GET: Result
        public ActionResult ViewResult() {
            var studentList = objResultManager.GetListOfStudents();
            List<SelectListItem> studetListItems = new List<SelectListItem>();
            foreach(Student objStudent in studentList) {
                studetListItems.Add( new SelectListItem { Value = objStudent.StudentRegNo, Text = objStudent.StudentRegNo } );
            }
            ViewBag.StudentListForDDL = studetListItems;
            return View();
        }
        //}
        //GET Student By Registration Number
        public JsonResult GetStudentByRegNo( string registrationNo ) {
            var objStudent = objResultManager.GetStudentByRegNo( registrationNo );
            return Json( objStudent, JsonRequestBehavior.AllowGet );
        }
    }
}