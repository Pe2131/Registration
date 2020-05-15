using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Registration.Areas.Models.AccountViewModels
{
    public class ResetPasswordViewModel
    {
        [EmailAddress(ErrorMessage = "لطفا ایمیل را بدرستی وارد کنید")]
        [Required(ErrorMessage = "لطفا فیلد {0} را وارد کنید")]
        [Display(Name = "ایمیل")]
        public string Email { get; set; }

        [Display(Name = "کلمه عبور")]
        [Required(ErrorMessage = "لطفا فیلد {0} را وارد کنید")]
        [StringLength(100, ErrorMessage = "فیلد {0} باید بین {2} و {1} کاراکتر طول داشته باشد", MinimumLength = 6)]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "تایید کلمه عبور")]
        [Compare("Password", ErrorMessage = "کلمه عبور با تایید کلمه عبور همخوانی ندارد")]
        public string ConfirmPassword { get; set; }

        public string Code { get; set; }
    }
}
