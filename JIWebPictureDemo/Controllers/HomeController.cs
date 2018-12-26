using JIWebPictureDemo.Models;
using JIWebPictureDemo.ViewModels.Students;
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

                StudentViewModel svm = new StudentViewModel();
                svm.InsertStudentInfo(student);

                //ViewBag.Message = "Student Details are saved successfully.";
                TempData["Message"] = "Student Details are saved successfully.";


                //return PartialView("~/Views/Shared/PartialPages/SuccessDialogBox.cshtml");
                //return RedirectToAction("Edit", "Home", new { id = student.StudentId });
                //return PartialView("~/Home/Index.cshtml", student);
                //return Response.Redirect()
                //return JavaScript("location.reload(true)");
                return JavaScript("window.location = '" + Url.Action("Edit", "Home", new { id = student.StudentId }) + "'");
            }

            return View(student);
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            StudentViewModel svm = new StudentViewModel();
            Student student = svm.GetStudentDetailsByStudentId(id);

            //return Response.Redirect("~/Home/Index/" + id);
            return View("~/Views/Home/Index.cshtml", student);
        }

        [HttpPost, ValidateAntiForgeryToken]
        public ActionResult Edit(Student student, HttpPostedFileBase file)
        {
            if (ModelState.IsValid)
            {
                if (file != null && file.ContentLength > 0)
                {
                    student.Photo = new byte[file.ContentLength];
                    file.InputStream.Read(student.Photo, 0, file.ContentLength);
                }

                StudentViewModel svm = new StudentViewModel();
                svm.UpdateStudentInfo(student);

                //ViewBag.Message = "Student Details are saved successfully.";
                TempData["Message"] = "Student Details are updated successfully.";


                //return PartialView("~/Views/Shared/PartialPages/SuccessDialogBox.cshtml");
                //return RedirectToAction("Edit", "Home");
                //return PartialView("~/Home/Index.cshtml", student);
            }

            return View(student);
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