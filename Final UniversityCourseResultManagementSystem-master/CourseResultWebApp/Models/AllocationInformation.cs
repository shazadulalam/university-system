using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CourseResultWebApp.Models {
    public class AllocationInformation {
        public int RoomAllocId { get; set; }
        public string DepartmentCode { get; set; }
        public string CourseCode { get; set; }
        public string CourseName { get; set; }
        public string RoomName { get; set; }
        public string RoomAllocDay { get; set; }
        public string AllocTimeFrom { get; set; }
        public string AllocTimeTo { get; set; }
    }
}