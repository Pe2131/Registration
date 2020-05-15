using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DAL.Models
{
   public class Tb_Contact2
    {
        [Key]
        public int id { get; set; }
        [Display(Name = "Name")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Enter {0}")]
        public string Name { get; set; }
        [Display(Name = "Coutomer Code")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Enter {0}")]
        public string Code { get; set; }
        [Display(Name = "Email")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Enter {0}")]
        public string Email { get; set; }
        [Display(Name = "Subject")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Enter {0}")]
        public string Subject { get; set; }
        [Display(Name = "text")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Enter {0}")]
        [MinLength(10, ErrorMessage = "{0} must more than 5 character")]
        public string Text { get; set; }
        [Display(Name = "Phone")]
        public string Phone { get; set; }
    }
}
