using storeProcedure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace storeProcedure.Controllers
{
    public class StoreProcedureController : Controller
    {
        // GET: StoreProcedure
        shivamtestdbEntities1 testdb = new shivamtestdbEntities1();
        public ActionResult Index()
        {
            return View(testdb.sp_select_Branch());
        }
        public ActionResult Create()
        {
            return View();
        }
       [HttpPost]
        public ActionResult Create(SpData student)
        {
            testdb.sp_insert_Branch(student.Id, student.Name, student.Email);
            return RedirectToAction("Index");
        }
        public ActionResult Edit(int id)
        {
           var data= testdb.sp_Find_Branch(id).FirstOrDefault();          
            return View(data);
        }
        [HttpPost]
        public ActionResult Edit(SpData student)
        {
            testdb.sp_update_Branch(student.Id,student.Name,student.Email);
            return RedirectToAction("Index");
        }
        public ActionResult Delete(int id)
        {
             testdb.sp_Delete_Branch(id);
            return RedirectToAction("Index");
        }
    }
}