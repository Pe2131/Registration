using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DAL.Models
{
  public class Tb_Orders
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string FullName { get; set; }
        public string AccountNumber { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Mobile { get; set; }
        [Required]
        public string Account { get; set; }
        public string Account2 { get; set; }

        public string Country { get; set; }
        public DateTime CreateAt { get; set; }
        public DateTime SubmitDate { get; set; }
        public string FileAddress { get; set; }
        public Status status { get; set; }
        public PayStatus Paystatus { get; set; }


    }
    public enum Status
    {
        register=1,
        paid=2
    }
    public enum PayStatus
    {
        Monthly=0,
        Yearly=1
    }
}
