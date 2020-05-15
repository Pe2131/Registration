using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DAL.Models
{
    public class Tb_Slider
    {
        [Key]
        public int Id { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Please Enter {0}")]
        [MaxLength(800, ErrorMessage = "{0} can only {1} characters")]
        [Display(Name = "Title")]
        public string Title { get; set; }
        public string Title2 { get; set; }

        public string ImageName { get; set; }
    }
}
