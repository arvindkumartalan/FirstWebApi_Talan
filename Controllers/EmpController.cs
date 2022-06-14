using FirstWebApi_Talan.Employee_db;
using FirstWebApi_Talan.Models;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace FirstWebApi_Talan.Controllers
{
    public class EmpController : ApiController
    {
        arvindEntities1 db = new arvindEntities1();
        [HttpGet]
        [Route("Employee/Details")]
        public List<string> GetEmp()
        {
            var list = new List<string>()
            {
                "Arvind Kumar Talan",
                "Rahul Kumar",
                "Dharemendra Verma",
                "Lalit Kumar"
            };
            return list;
        }
        [HttpGet]
        [Route("Data/Employee/Details")]
        public List<employee1> GetEmployee()
        {
            List<EmployeeModel> listemp = new List<EmployeeModel>();
            var result = db.employee1.ToList();
            return result;
        }
        [HttpPost]
        [Route("emoloyee/AddorEdit")]
        public HttpResponseMessage AddEdit(EmployeeModel obj)
        {
            employee1 emp = new employee1();
            emp.empid = obj.empid;
            emp.empmail = obj.empmail;
            emp.empname = obj.empname;
            emp.empsalary = obj.empsalary;
            if (obj.empid == 0)
            {
                db.employee1.Add(emp);
                db.SaveChanges();
            }
            else
            {
                db.Entry(emp).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
            }
            HttpResponseMessage result = new HttpResponseMessage(HttpStatusCode.OK);
            return result;
        }
        [HttpDelete]
        [Route("employee/delete")]
        public HttpResponseMessage Delete(int id)
        {
            var resDelete = db.employee1.Where(m => m.empid == id).First();
            db.employee1.Remove(resDelete);
            db.SaveChanges();
            HttpResponseMessage result = new HttpResponseMessage(HttpStatusCode.OK);
            return result;
        }
        [HttpGet]
        [Route("employee/edit")]
        public EmployeeModel Edit(int id)
        {
            var resEdit = db.employee1.Where(s => s.empid == id).First();
            EmployeeModel emp = new EmployeeModel();
            emp.empid = resEdit.empid;
            emp.empname = resEdit.empname;
            emp.empsalary = resEdit.empsalary;
            emp.empmail = resEdit.empmail;
            return emp;
        }
    }
}