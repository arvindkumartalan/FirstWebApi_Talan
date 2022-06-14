using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FirstWebApi_Talan.Models
{
    public class EmployeeModel
    {
        public int empid { get; set; }
        public string empname { get; set; }
        public string empsalary { get; set; }
        public string empmail { get; set; }
    }
}