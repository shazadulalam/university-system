using System;
using System.Collections.Generic;
<<<<<<< 6ddd651715f2bd4d41a8a6797b4f7a52a08666d8
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
=======
>>>>>>> Final Commit
using System.Linq;
using System.Web;

namespace CourseResultWebApp.Models {
    public class Result {
        public int  ResultId { get; set; }
<<<<<<< 6ddd651715f2bd4d41a8a6797b4f7a52a08666d8
        [Required(ErrorMessage = "Please Select a Registration Number")]
        [DisplayName("Student Reg. No.")]
        public string StudentRegNo { get; set; }

        [DisplayName("Name")]
        public string StudentName { get; set; }

        [DisplayName("Email")]
        public string StudentEmail { get; set; }

        [DisplayName("Department")]
        public string DepartmentName { get; set; }

        public string CourseCode { get; set; }
=======
        public string StudentRegNo { get; set; }
        public string StudentName { get; set; }
        public string StudentEmail { get; set; }
        public string DepartmentName { get; set; }
>>>>>>> Final Commit
        public string CourseName { get; set; }
        public string CourseGarde { get; set; }
    }
}