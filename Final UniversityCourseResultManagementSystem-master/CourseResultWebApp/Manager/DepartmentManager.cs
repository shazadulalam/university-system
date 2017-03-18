using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CourseResultWebApp.DAL;
using CourseResultWebApp.Models;

namespace CourseResultWebApp.Manager
{
    public class DepartmentManager
    {
        DepartmentGateway aDepartmentGateway = new DepartmentGateway();

        public bool Save(Department department)
        {
            return aDepartmentGateway.Save(department) > 0;
        }

        public List<Department> GetAllDepartment()
        {
            return aDepartmentGateway.GetAllDepartment();
        }

        public Department GetDepartmentById(int departmentId)
        {
            return aDepartmentGateway.GetDepartmentById(departmentId);
        }
        public bool IsDepartmentExist(string name)
        {
            return aDepartmentGateway.IsDepartmentExist(name);
        }

        public List<SelectListItem> DepartmentDropdown()
        {
            List<Department> departments = new List<Department>();
            departments = GetAllDepartment();

            List<SelectListItem> dropdownItems = new List<SelectListItem>();

            SelectListItem selectListItem = new SelectListItem { Text = "Select Department", Value = "" };
            dropdownItems.Add(selectListItem);
            foreach (var department in departments)
            {
                selectListItem = new SelectListItem { Text = department.DepartmentName, Value = Convert.ToString((int)department.DepartmentId) };
                dropdownItems.Add(selectListItem);
            }
            return dropdownItems;
        }

        public bool IsDepartmentCodeExist(string code)
        {
            return aDepartmentGateway.IsDepartmentCodeExist(code);
        }
    }
}