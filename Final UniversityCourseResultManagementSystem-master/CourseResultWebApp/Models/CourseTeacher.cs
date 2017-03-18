using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace CourseResultWebApp.Models
{
    public class CourseTeacher
    {
        public int Id { get; set; }

        [DisplayName("Department")]
        public int DepartmentId { get; set; }

        [DisplayName("Teacher")]
        public int TeacherId { get; set; }

        [DisplayName("Course Code")]
        public int CourseId { get; set; }

        public double CourseCredit { get; set; }
    }
}