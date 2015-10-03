using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RomaAuto.Models
{
    public class RegisterModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "შევსება აუცილებელია")]
        [DisplayName("სახელი")]
        [StringLength(100, ErrorMessage = "{0} მინუმუმ უნდა იყოს {2} სიმბოლო.", MinimumLength = 6)]
        public string Name { get; set; }

        [Required(ErrorMessage = "შევსება აუცილებელია")]
        [DisplayName("გვარი")]
        [StringLength(100, ErrorMessage = "{0} მინუმუმ უნდა იყოს {2} სიმბოლო.", MinimumLength = 6)]
        public string LastName { get; set; }

        [Required(ErrorMessage = "შევსება აუცილებელია")]
        [StringLength(100, ErrorMessage = "{0} მინუმუმ უნდა იყოს {2} სიმბოლო.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [Required]
        public int AdminCategoryId { get; set; }
    }

    public class LoginModel
    {
        [Required]
        [Display(Name = "სახელი")]
        public string Name { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "პაროლი")]
        public string Password { get; set; }
    }

    public class MainUser
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public int Category { get; set; }
    }
}