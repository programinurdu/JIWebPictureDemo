using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace JIWebPictureDemo.Models.Test
{
    public class PersonTest
    {
        //[DisplayName("Person Id:")] OR
        [Display(Name = "Person Id:")]
        public string PersonId { get; set; }

        [Display(Name = "Full Name:")]
        [Required(ErrorMessage = "Full Name is required.")]
        public string FullName { get; set; }

        [Display(Name = "Email:")]
        [Required(ErrorMessage = "Email is required.")]
        public string Email { get; set; }

        [Display(Name = "Gender:")]
        [UIHint("GenderComboBox")]
        public string Gender { get; set; }

        [Display(Name = "City:")]
        [UIHint("CityComboBox")]
        public string City { get; set; }
    }
}