using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;

namespace CourseResultWebApp.Models
{
    public class Course
    {
        public int CourseId { get; set; }

        [Required (ErrorMessage = "Please Enter your Course Code.")]
        [StringLength(20,MinimumLength = 8,ErrorMessage = "Course code must be 5 to 50 character long.")]
        public string CourseCode { get; set; }

        [Required (ErrorMessage = "Please enter Course name.")]
        public string CourseName { get; set; }

        [Required(ErrorMessage = "Please enter Course name.")]
        [Range(0.5,5.0,ErrorMessage = "Enter your course credit between 0.5 to 5.0.")]
        public double CourseCredit { get; set; }

        [Required(ErrorMessage = "Please enter course description.")]
        public string CourseDescription { get; set; }

        [Required (ErrorMessage = "Please select Department.")]
        [DisplayName("Department")]
        public int DepartmentId { get; set; }

        [Required(ErrorMessage = "Please select semester.")]
        [DisplayName("Semester")]
        public int  Semester { get; set; }

        public int Course_Teacher { get; set; }

        public List<SelectListItem> Department_List = new List<SelectListItem>();
        public List<SelectListItem> Couse_Info_List = new List<SelectListItem>();
    }
}