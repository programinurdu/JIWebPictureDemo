﻿using JIWebPictureDemo.Models;
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
            Student student = new Student();
            student.StudentId = svm.GenerateStudentId();
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

                ViewBag.Message = "Student Details are saved successfully.";

                return PartialView("~/Views/Shared/PartialPages/Message.cshtml");
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