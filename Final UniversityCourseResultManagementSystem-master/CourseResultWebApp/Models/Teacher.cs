using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CourseResultWebApp.Models
{
    public class Teacher
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Please enter Name")]
        [StringLength(200)]
        public string TeacherName { get; set; }

        [Required(ErrorMessage = "Please enter Address")]
        public string TeacherAddress { get; set; }

        [Required(ErrorMessage = "Please enter Email")]
        [StringLength(100, ErrorMessage = "Please enter maximum 100 characters")]
        [RegularExpression(@"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$", ErrorMessage = "Please enter a valid email adress")]
        public string TeacherEmail { get; set; }

        [DisplayName("Contact Number")]
        [Required(ErrorMessage = "Please enter Contact Number")]
        [StringLength(20)]

        public string TeacherContactNo { get; set; }

        [DisplayName("Designation")]
        [Required(ErrorMessage = "Please Select Designation")]
        public int TeacherDesignation { get; set; }

        [DisplayName("Department")]
        [Required(ErrorMessage = "Please Select Department")]
        public int DepartmentID { get; set; }

        [DisplayName("Credit Limit")]
        [Required(ErrorMessage = "Please enter Credit Limit")]
        [Range(0, 100, ErrorMessage = "Please enter value between 0 to 100")]
        public double TeacherCredit { get; set; }
        public double RemainingCredit { get; set; }
    }
}