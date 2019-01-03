using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace JIWebPictureDemo.Models
{
    public class Student
    {
        public byte[] Photo { get; set; }

        [Display(Name = "Student Id:")]
        public int StudentId { get; set; }

        // Zero (0) for new and One (1) for update
        [HiddenInput(DisplayValue = false)]
        public int StudentType { get; set; }

        [Display(Name = "Full Name:")]
        [Required(ErrorMessage = "Full Name is required.")]
        public string FullName { get; set; }

        [Display(Name = "Email Address:")]
        [Required(ErrorMessage = "Email Address is required.")]
        public string Email { get; set; }

        [Display(Name = "Mobile:")]
        public string Mobile { get; set; }

        [Display(Name = "Telephone:")]
        public string Telephone { get; set; }

        [Display(Name = "Address 1:")]
        public string Address1 { get; set; }

        [Display(Name = "Address 2:")]
        public string Address2 { get; set; }

        [Display(Name = "City:")]
        [UIHint("CityComboBox")]
        public int? City { get; set; }

        [Display(Name = "County:")]
        [UIHint("CountyComboBox")]
        public int? County { get; set; }

        [Display(Name = "Post Code:")]
        public string PostCode { get; set; }

        [Display(Name = "Notes:")]
        [DataType(DataType.MultilineText)]
        public string Notes { get; set; }
    }
}