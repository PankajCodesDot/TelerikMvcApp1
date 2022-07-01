using TelerikMvcApp1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TelerikMvcApp1.ViewModel;
using Kendo.Mvc.UI;
using Kendo.Mvc.Extensions;

namespace kendovijay.Controllers
{
    public class HomeController : Controller
    {
        DatabaseContext db = new DatabaseContext();
        public ActionResult Index()
        {
            return View();
        }
        public JsonResult GetStudent([DataSourceRequest] DataSourceRequest request)
        {
        //    IEnumerable<UserModel> StudentlistViewModel =
        //        (from objstudent in db.students
        //         select new UserModel()
        //         {
        //             id = objstudent.id,
        //             name = objstudent.name,
        //             address = objstudent.address
        //         }).ToList();
            var StudentlistViewModel = db.students.ToList();
            return Json(StudentlistViewModel.ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
        }

        public void AddEmployee(student stu)
        {
           
            db.students.Add(stu);
            db.SaveChanges();
        }

        public void DeleteEmployee(student stu)
        {
           
            student objToDelete = db.students.Find(stu.id);
            db.students.Remove(objToDelete);
            db.SaveChanges();
        }

        public void UpdateEmployee(student stu)
        {
            DatabaseContext db = new DatabaseContext();
            student objToUpdate = db.students.Find(stu.id);
            objToUpdate.name = stu.name;
            objToUpdate.address = stu.address;
            db.Entry(objToUpdate).State = System.Data.EntityState.Modified;
            db.SaveChanges();
        }



    }
}