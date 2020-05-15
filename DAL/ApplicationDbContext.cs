using DAL.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        { }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Tb_Setting>().HasData(
                new Tb_Setting
                {
                    Id = 1,
                    Email = "Email.Email.com",
                    FaceBook = "https://www.facebook.com/Copytradingservices/",
                    Insta = "https://www.instagram.com/profitfactory.eu",
                    Phone = "+123456789",
                    Steps = "OPEN AN ACCOUNT WITH ONE OF OUR SUPPORTED BROKERS. OR, IF YOU ALREADY HAVE A REAL TRADING ACCOUNT YOU CAN JUMP TO STEP TWO. *" +
                    " CHOOSE YOUR SUBSCRIPRION PLAN , THEN JUST FOLLOW THE REGISTRATION STEPS AND FILL UP THE REGISTRATION FIELDS, SO OUR OPERATION DEPARTMENT CAN ADJUST THE SETTINGS TO OBTAIN THE SOFTWARE LICENSE FOR YOUR ACCOUNT. *" +
                    " WITH IN 24 HOURS YOU WILL RECEIVE SOFTWARE FILE AND VIDEO GUIDE BY EMAIL. RUN OUR AUTOMATIC TRADING SOFTWARE. SIT, RELAX AND ENJOY YOUR FUTURE POTENTIAL RESULTS.",
                    Text1 = "Choose your MONTHLY or YEARLY plan and Start your trading in just few minutes",
                    Text2 = "we support all meta trader 4 Accounts Types",
                    Footer = "* Risk Warning: Trading / CFDs are complex instruments that come with a high risk of rapidly losing money due to leverage. . It is desirable that investors who would consider EA trading, to do so only with the money that they can afford to lose. Please note that even knowledgeable and well-experienced investors can experience large potential losses.Past performance of Profitfactory Software is not a reliable indicator of his future performance.",
                    Title1 = "Plans & Prices",
                    Title2 = "Trade on world class platforms",
                    TradePrice = "99",
                    Twiter = "twiter.com",
                    YouTube = "https://www.youtube.com/channel/UChMVaLmHsher5JVXt2zCgoA/?guided_help_flow=5",
                    Logo = "profit-logo.png",
                    Text3 = "We Develop Best Automatic Trading Softwares , That You Can Run It On The All Meta Trade 4 Trading Accounts",
                    Text4 = "Dont Waste Your Time , In Just 3 Steps You Can Start Trading By Our MT4 Expert Advisor",
                    Title3 = "Why You Should Choose Our Software",
                    Title4 = "HOW TO START ?",
                    StepLinks = "#,#,#",
                    TradeLinks = "https://www.myfxbook.com/members/ProfitfactoryEA/multi-asset-25k/5558985,https://www.myfxbook.com/members/ProfitfactoryEA/gold-oil-10k/5573608,https://www.myfxbook.com/members/ProfitfactoryEA/currencies-5k/5573685,https://www.myfxbook.com/members/ProfitfactoryEA/beginner-1k/5573713"

                });
            modelBuilder.Entity<Tb_Slider>().HasData(
            new Tb_Slider { Id = 1, ImageName = "profitfactory-slider3.jpg", Title = "Best Auto Trading Softwares.", Title2 = "AI Automatic Trading Algorithms & Strategies" },
            new Tb_Slider { Id = 2, ImageName = "profitfactory-slider4.jpg", Title = "Low Risk Automatic Trading.", Title2 = "Robot Will Do All Your Risk Managment By Your Choose" },
            new Tb_Slider { Id = 3, ImageName = "profitfactory-slider5.jpg", Title = "Only You Have Access To Your Funds", Title2 = "You Can Choose Your Broker , Account Type and All Your Deposit & Withdrawal Process" },
            new Tb_Slider { Id = 4, ImageName = "profitfactory-slider6.jpg", Title = "Trade Currencies , Gold , Oil , CFDs", Title2 = "You can Trade All Assets Automatically" }

            );
        }
        public DbSet<Tb_Orders> Tb_Orders { get; set; }
        public DbSet<Tb_Slider> Tb_Sliders { get; set; }
        public DbSet<Tb_Setting> tb_Settings { get; set; }
        public DbSet<Tb_Contact> tb_Contacts { get; set; }
        public DbSet<Tb_Contact2> tb_Contacts2 { get; set; }



    }
}
