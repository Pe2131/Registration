﻿// <auto-generated />
using System;
using DAL;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace DAL.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.2");

            modelBuilder.Entity("DAL.Models.ApplicationUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("TEXT");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("INTEGER");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("TEXT");

                    b.Property<string>("Email")
                        .HasColumnType("TEXT")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("IsActive")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("INTEGER");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.Property<string>("NormalizedEmail")
                        .HasColumnType("TEXT")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasColumnType("TEXT")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash")
                        .HasColumnType("TEXT");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("TEXT");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("INTEGER");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("TEXT");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("INTEGER");

                    b.Property<string>("UserName")
                        .HasColumnType("TEXT")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("DAL.Models.Tb_Contact", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Phone")
                        .HasColumnType("TEXT");

                    b.Property<string>("Subject")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Text")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("id");

                    b.ToTable("tb_Contacts");
                });

            modelBuilder.Entity("DAL.Models.Tb_Contact2", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Phone")
                        .HasColumnType("TEXT");

                    b.Property<string>("Subject")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Text")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("id");

                    b.ToTable("tb_Contacts2");
                });

            modelBuilder.Entity("DAL.Models.Tb_Orders", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Account")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Account2")
                        .HasColumnType("TEXT");

                    b.Property<string>("AccountNumber")
                        .HasColumnType("TEXT");

                    b.Property<string>("Country")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("CreateAt")
                        .HasColumnType("TEXT");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("FileAddress")
                        .HasColumnType("TEXT");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Mobile")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("Paystatus")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("SubmitDate")
                        .HasColumnType("TEXT");

                    b.Property<int>("status")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("Tb_Orders");
                });

            modelBuilder.Entity("DAL.Models.Tb_Setting", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Email")
                        .HasColumnType("TEXT");

                    b.Property<string>("FaceBook")
                        .HasColumnType("TEXT");

                    b.Property<string>("Footer")
                        .HasColumnType("TEXT");

                    b.Property<string>("Insta")
                        .HasColumnType("TEXT");

                    b.Property<string>("Logo")
                        .HasColumnType("TEXT");

                    b.Property<string>("Phone")
                        .HasColumnType("TEXT");

                    b.Property<string>("StepLinks")
                        .HasColumnType("TEXT");

                    b.Property<string>("Steps")
                        .HasColumnType("TEXT");

                    b.Property<string>("Text1")
                        .HasColumnType("TEXT");

                    b.Property<string>("Text2")
                        .HasColumnType("TEXT");

                    b.Property<string>("Text3")
                        .HasColumnType("TEXT");

                    b.Property<string>("Text4")
                        .HasColumnType("TEXT");

                    b.Property<string>("Title1")
                        .HasColumnType("TEXT");

                    b.Property<string>("Title2")
                        .HasColumnType("TEXT");

                    b.Property<string>("Title3")
                        .HasColumnType("TEXT");

                    b.Property<string>("Title4")
                        .HasColumnType("TEXT");

                    b.Property<string>("TradeLinks")
                        .HasColumnType("TEXT");

                    b.Property<string>("TradePrice")
                        .HasColumnType("TEXT");

                    b.Property<string>("Twiter")
                        .HasColumnType("TEXT");

                    b.Property<string>("YouTube")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("tb_Settings");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Email = "Email.Email.com",
                            FaceBook = "https://www.facebook.com/Copytradingservices/",
                            Footer = "* Risk Warning: Trading / CFDs are complex instruments that come with a high risk of rapidly losing money due to leverage. . It is desirable that investors who would consider EA trading, to do so only with the money that they can afford to lose. Please note that even knowledgeable and well-experienced investors can experience large potential losses.Past performance of Profitfactory Software is not a reliable indicator of his future performance.",
                            Insta = "https://www.instagram.com/profitfactory.eu",
                            Logo = "profit-logo.png",
                            Phone = "+123456789",
                            StepLinks = "#,#,#",
                            Steps = "OPEN AN ACCOUNT WITH ONE OF OUR SUPPORTED BROKERS. OR, IF YOU ALREADY HAVE A REAL TRADING ACCOUNT YOU CAN JUMP TO STEP TWO. * CHOOSE YOUR SUBSCRIPRION PLAN , THEN JUST FOLLOW THE REGISTRATION STEPS AND FILL UP THE REGISTRATION FIELDS, SO OUR OPERATION DEPARTMENT CAN ADJUST THE SETTINGS TO OBTAIN THE SOFTWARE LICENSE FOR YOUR ACCOUNT. * WITH IN 24 HOURS YOU WILL RECEIVE SOFTWARE FILE AND VIDEO GUIDE BY EMAIL. RUN OUR AUTOMATIC TRADING SOFTWARE. SIT, RELAX AND ENJOY YOUR FUTURE POTENTIAL RESULTS.",
                            Text1 = "Choose your MONTHLY or YEARLY plan and Start your trading in just few minutes",
                            Text2 = "we support all meta trader 4 Accounts Types",
                            Text3 = "We Develop Best Automatic Trading Softwares , That You Can Run It On The All Meta Trade 4 Trading Accounts",
                            Text4 = "Dont Waste Your Time , In Just 3 Steps You Can Start Trading By Our MT4 Expert Advisor",
                            Title1 = "Plans & Prices",
                            Title2 = "Trade on world class platforms",
                            Title3 = "Why You Should Choose Our Software",
                            Title4 = "HOW TO START ?",
                            TradeLinks = "https://www.myfxbook.com/members/ProfitfactoryEA/multi-asset-25k/5558985,https://www.myfxbook.com/members/ProfitfactoryEA/gold-oil-10k/5573608,https://www.myfxbook.com/members/ProfitfactoryEA/currencies-5k/5573685,https://www.myfxbook.com/members/ProfitfactoryEA/beginner-1k/5573713",
                            TradePrice = "89.99",
                            Twiter = "twiter.com",
                            YouTube = "https://www.youtube.com/channel/UChMVaLmHsher5JVXt2zCgoA/?guided_help_flow=5"
                        });
                });

            modelBuilder.Entity("DAL.Models.Tb_Slider", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("ImageName")
                        .HasColumnType("TEXT");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasMaxLength(800);

                    b.Property<string>("Title2")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Tb_Sliders");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            ImageName = "profitfactory-slider3.jpg",
                            Title = "Best Auto Trading Softwares.",
                            Title2 = "AI Automatic Trading Algorithms & Strategies"
                        },
                        new
                        {
                            Id = 2,
                            ImageName = "profitfactory-slider4.jpg",
                            Title = "Low Risk Automatic Trading.",
                            Title2 = "Robot Will Do All Your Risk Managment By Your Choose"
                        },
                        new
                        {
                            Id = 3,
                            ImageName = "profitfactory-slider5.jpg",
                            Title = "Only You Have Access To Your Funds",
                            Title2 = "You Can Choose Your Broker , Account Type and All Your Deposit & Withdrawal Process"
                        },
                        new
                        {
                            Id = 4,
                            ImageName = "profitfactory-slider6.jpg",
                            Title = "Trade Currencies , Gold , Oil , CFDs",
                            Title2 = "You can Trade All Assets Automatically"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("TEXT");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasColumnType("TEXT")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("ClaimType")
                        .HasColumnType("TEXT");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("TEXT");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("ClaimType")
                        .HasColumnType("TEXT");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("TEXT");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("TEXT");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("TEXT");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("TEXT");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("TEXT");

                    b.Property<string>("RoleId")
                        .HasColumnType("TEXT");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("TEXT");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.Property<string>("Value")
                        .HasColumnType("TEXT");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("DAL.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("DAL.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DAL.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("DAL.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
