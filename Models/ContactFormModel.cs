using System;
using System.ComponentModel.DataAnnotations;

namespace mywebsite.Models
{
    public class ContactFormModel
    {
       [Required(ErrorMessage ="This field is required"), Display(Name = "Your Name")]
        public string FirstName { get; set;}
       [Required(ErrorMessage = "This field is required"), Display(Name = "Your Last Name")]
        public string LastName { get; set; }
       [Required(ErrorMessage = "This field is required"), Display(Name = "Your Email")]
       public string Email { get; set; }
        [Required(ErrorMessage = "This field is required"), Display(Name = "Your Feedback")]
        public string Feedback { get; set; }
     
    }
}
