using System;
using System.Collections.Generic;
<<<<<<< 6ddd651715f2bd4d41a8a6797b4f7a52a08666d8
using System.Linq;
using System.Web;

namespace CourseResultWebApp.Models {
    public class Student {
        public string StudentRegNo { get; set; }
        public string StudentName { get; set; }
        public string StudentEmail { get; set; }
        public string StudentContactNo { get; set; }
        public DateTime StudentRegDate { get; set; }
        public string StudentAddress { get; set; }
        public string DepartmentName { get; set; }
=======
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CourseResultWebApp.Models
{
    public class Student
    {
        public int StudentId { get; set; }
        public string RegNo { get; set; }

        [Required(ErrorMessage="Name is required")]
        [StringLength(50, ErrorMessage = "Please maximum 50 characters")]
        public string StudentName { get; set; }

        [Required(ErrorMessage = "Please enter you email address. ")]
        [EmailAddress (ErrorMessage= "Email format is invalid")]
        public string StudentEmail { get; set; }

        [DisplayName("Contact Number")]
        [Required(ErrorMessage = "Please enter contact number.")]
        [StringLength(20,ErrorMessage = "Number is more then 20 characters.")]
        public string StudentContactNo { get; set; }

        [Required(ErrorMessage = "Please enter your registration date.")]
        public DateTime RegDate { get; set; }

        [Required(ErrorMessage = "Please enter your full address.")]
        public string StudentAddress { get; set; }
        public int DepartmentId { get; set; }
        public string DepartmentCode { get; set; }

        public List<SelectListItem> Department_List = new List<SelectListItem>();
>>>>>>> Final Commit
    }
}