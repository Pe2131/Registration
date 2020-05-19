using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DAL.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    UserName = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(maxLength: 256, nullable: true),
                    Email = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(nullable: false),
                    PasswordHash = table.Column<string>(nullable: true),
                    SecurityStamp = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(nullable: false),
                    TwoFactorEnabled = table.Column<bool>(nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(nullable: true),
                    LockoutEnabled = table.Column<bool>(nullable: false),
                    AccessFailedCount = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    IsActive = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tb_Contacts",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: false),
                    Email = table.Column<string>(nullable: false),
                    Subject = table.Column<string>(nullable: false),
                    Text = table.Column<string>(nullable: false),
                    Phone = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_Contacts", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "tb_Contacts2",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: false),
                    Code = table.Column<string>(nullable: false),
                    Email = table.Column<string>(nullable: false),
                    Subject = table.Column<string>(nullable: false),
                    Text = table.Column<string>(nullable: false),
                    Phone = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_Contacts2", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Tb_Orders",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FullName = table.Column<string>(nullable: false),
                    AccountNumber = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: false),
                    Mobile = table.Column<string>(nullable: false),
                    Account = table.Column<string>(nullable: false),
                    Account2 = table.Column<string>(nullable: true),
                    Country = table.Column<string>(nullable: true),
                    CreateAt = table.Column<DateTime>(nullable: false),
                    SubmitDate = table.Column<DateTime>(nullable: false),
                    FileAddress = table.Column<string>(nullable: true),
                    status = table.Column<int>(nullable: false),
                    Paystatus = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tb_Orders", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tb_Settings",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Logo = table.Column<string>(nullable: true),
                    TradeLinks = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    Phone = table.Column<string>(nullable: true),
                    Footer = table.Column<string>(nullable: true),
                    TradePrice = table.Column<string>(nullable: true),
                    Title1 = table.Column<string>(nullable: true),
                    Text1 = table.Column<string>(nullable: true),
                    Title2 = table.Column<string>(nullable: true),
                    Text2 = table.Column<string>(nullable: true),
                    Title3 = table.Column<string>(nullable: true),
                    Text3 = table.Column<string>(nullable: true),
                    Title4 = table.Column<string>(nullable: true),
                    Text4 = table.Column<string>(nullable: true),
                    Steps = table.Column<string>(nullable: true),
                    StepLinks = table.Column<string>(nullable: true),
                    FaceBook = table.Column<string>(nullable: true),
                    YouTube = table.Column<string>(nullable: true),
                    Insta = table.Column<string>(nullable: true),
                    Twiter = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_Settings", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tb_Sliders",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(maxLength: 800, nullable: false),
                    Title2 = table.Column<string>(nullable: true),
                    ImageName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tb_Sliders", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(nullable: false),
                    ProviderKey = table.Column<string>(nullable: false),
                    ProviderDisplayName = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    RoleId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    LoginProvider = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Tb_Sliders",
                columns: new[] { "Id", "ImageName", "Title", "Title2" },
                values: new object[,]
                {
                    { 1, "profitfactory-slider3.jpg", "Best Auto Trading Softwares.", "AI Automatic Trading Algorithms & Strategies" },
                    { 2, "profitfactory-slider4.jpg", "Low Risk Automatic Trading.", "Robot Will Do All Your Risk Managment By Your Choose" },
                    { 3, "profitfactory-slider5.jpg", "Only You Have Access To Your Funds", "You Can Choose Your Broker , Account Type and All Your Deposit & Withdrawal Process" },
                    { 4, "profitfactory-slider6.jpg", "Trade Currencies , Gold , Oil , CFDs", "You can Trade All Assets Automatically" }
                });

            migrationBuilder.InsertData(
                table: "tb_Settings",
                columns: new[] { "Id", "Email", "FaceBook", "Footer", "Insta", "Logo", "Phone", "StepLinks", "Steps", "Text1", "Text2", "Text3", "Text4", "Title1", "Title2", "Title3", "Title4", "TradeLinks", "TradePrice", "Twiter", "YouTube" },
                values: new object[] { 1, "Email.Email.com", "https://www.facebook.com/Copytradingservices/", "* Risk Warning: Trading / CFDs are complex instruments that come with a high risk of rapidly losing money due to leverage. . It is desirable that investors who would consider EA trading, to do so only with the money that they can afford to lose. Please note that even knowledgeable and well-experienced investors can experience large potential losses.Past performance of Profitfactory Software is not a reliable indicator of his future performance.", "https://www.instagram.com/profitfactory.eu", "profit-logo.png", "+123456789", "#,#,#", "OPEN AN ACCOUNT WITH ONE OF OUR SUPPORTED BROKERS. OR, IF YOU ALREADY HAVE A REAL TRADING ACCOUNT YOU CAN JUMP TO STEP TWO. * CHOOSE YOUR SUBSCRIPRION PLAN , THEN JUST FOLLOW THE REGISTRATION STEPS AND FILL UP THE REGISTRATION FIELDS, SO OUR OPERATION DEPARTMENT CAN ADJUST THE SETTINGS TO OBTAIN THE SOFTWARE LICENSE FOR YOUR ACCOUNT. * WITH IN 24 HOURS YOU WILL RECEIVE SOFTWARE FILE AND VIDEO GUIDE BY EMAIL. RUN OUR AUTOMATIC TRADING SOFTWARE. SIT, RELAX AND ENJOY YOUR FUTURE POTENTIAL RESULTS.", "Choose your MONTHLY or YEARLY plan and Start your trading in just few minutes", "we support all meta trader 4 Accounts Types", "We Develop Best Automatic Trading Softwares , That You Can Run It On The All Meta Trade 4 Trading Accounts", "Dont Waste Your Time , In Just 3 Steps You Can Start Trading By Our MT4 Expert Advisor", "Plans & Prices", "Trade on world class platforms", "Why You Should Choose Our Software", "HOW TO START ?", "https://www.myfxbook.com/members/ProfitfactoryEA/multi-asset-25k/5558985,https://www.myfxbook.com/members/ProfitfactoryEA/gold-oil-10k/5573608,https://www.myfxbook.com/members/ProfitfactoryEA/currencies-5k/5573685,https://www.myfxbook.com/members/ProfitfactoryEA/beginner-1k/5573713", "99", "twiter.com", "https://www.youtube.com/channel/UChMVaLmHsher5JVXt2zCgoA/?guided_help_flow=5" });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "tb_Contacts");

            migrationBuilder.DropTable(
                name: "tb_Contacts2");

            migrationBuilder.DropTable(
                name: "Tb_Orders");

            migrationBuilder.DropTable(
                name: "tb_Settings");

            migrationBuilder.DropTable(
                name: "Tb_Sliders");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");
        }
    }
}
