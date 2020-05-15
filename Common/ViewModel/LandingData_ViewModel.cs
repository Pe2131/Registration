using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Common.ViewModel
{
    public class LandingData_ViewModel
    {
        [Required]
        public string LandingId { get; set; }
        [Required]
        public string name { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Phone { get; set; }
        [Required]
        public string Ip { get; set; }
        public string Country { get; set; }
        public string CallCode { get; set; }
        public string City { get; set; }
        public string Currency { get; set; }
        public string languages { get; set; }
        public string CountryCode { get; set; }
    }
}
