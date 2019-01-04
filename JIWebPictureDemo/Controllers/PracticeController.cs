using JIWebPictureDemo.Models.Test;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace JIWebPictureDemo.Controllers
{
    public class PracticeController : Controller
    {
        // GET: Practice
        public ActionResult DropDownListTest()
        {
            //PersonTest pt = GetPerson();
            return View("~/Views/Practice/DropDownListTest.cshtml", GetPerson());
        }

        private PersonTest GetPerson()
        {
            PersonTest pt = new PersonTest();
            pt.PersonId = "ABC43";
            pt.FullName = "John Taylor";
            pt.Email = "john.taylor@gmail.com";
            pt.Gender = "13";
            pt.City = "2";
            ViewBag.Gender = pt.Gender;
            ViewBag.City = pt.City;
            return pt;
        }
    }
}