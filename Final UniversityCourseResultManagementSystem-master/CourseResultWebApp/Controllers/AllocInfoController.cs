using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CourseResultWebApp.Manager;

namespace CourseResultWebApp.Controllers {
    public class AllocInfoController : Controller {
        private AllocationInfoManager objAllocationInfoManager = new AllocationInfoManager();
        // GET: AllocInfo
        public ActionResult ViewClassSchedule() {
            return View();
        }
    }
}