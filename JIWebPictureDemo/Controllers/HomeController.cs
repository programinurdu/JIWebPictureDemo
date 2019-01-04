using JIWebPictureDemo.Models;
using JIWebPictureDemo.Models.General;
using JIWebPictureDemo.ViewModels.Students;
using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Mvc;

namespace JIWebPictureDemo.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            StudentViewModel svm = new StudentViewModel();
            Student student = new Student
            {
                StudentId = svm.GenerateStudentId()
            };

            return View(student);
        }

        [HttpPost, ValidateAntiForgeryToken]
        public ActionResult Index(Student student, HttpPostedFileBase file)
        {
            if (ModelState.IsValid)
            {
                if (file != null && file.ContentLength > 0)
                {
                    student.Photo = new byte[file.ContentLength];
                    file.InputStream.Read(student.Photo, 0, file.ContentLength);
                }

                if (student.StudentType == (int)StudentType.Insert)
                {
                    StudentViewModel svm = new StudentViewModel();
                    svm.InsertStudentInfo(student);

                    ViewBag.Message = "Student Details are saved successfully.";
                }
                else
                {
                    StudentViewModel svm = new StudentViewModel();
                    svm.UpdateStudentInfo(student);

                    ViewBag.Message = "Student Details are updated successfully.";
                }

                //return PartialView("~/Views/Shared/PartialPages/SuccessDialogBox.cshtml");
                return JavaScript("window.location = '" + Url.Action("Edit", "Home", new { id = student.StudentId }) + "'");
            }

            return View(student);
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            StudentViewModel svm = new StudentViewModel();
            Student student = svm.GetStudentDetailsByStudentId(id);

            // Initialise Student Type, in this case it is update so 1 or Update.
            student.StudentType = (int)StudentType.Update;
            ViewBag.City = student.City;
            ViewBag.County = student.County;

            return View("~/Views/Home/Index.cshtml", student);
        }

        [HttpGet]
        public ActionResult StudentList()
        {
            StudentViewModel svm = new StudentViewModel();
            List<Student> students = svm.StudentList();

            return View(students);
        }
    }
}