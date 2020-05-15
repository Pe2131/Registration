using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DAL.Models
{
   public class Tb_Setting
    {
        [Key]
        public int Id { get; set; }
        public string Logo { get; set; }
        public string TradeLinks { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Footer { get; set; }
        public string TradePrice { get; set; }
        public string Title1 { get; set; }
        public string Text1 { get; set; }
        public string Title2 { get; set; }
        public string Text2 { get; set; }
        public string Title3 { get; set; }
        public string Text3 { get; set; }
        public string Title4 { get; set; }
        public string Text4 { get; set; }
        public string Steps { get; set; }
        public string StepLinks { get; set; }
   
        public string FaceBook { get; set; }
        public string YouTube { get; set; }
        public string Insta { get; set; }
        public string Twiter { get; set; }
    }
}
