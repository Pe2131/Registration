using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using DAL.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PaulMiami.AspNetCore.Mvc.Recaptcha;
using Registration.Models;
using Registration.ViewModels;
using Repository.InterFace;
using Service;

namespace Registration.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IEmailSender _emailSender;


        public HomeController(ILogger<HomeController> logger, IUnitOfWork unitOfWork, IEmailSender emailSender)
        {
            _logger = logger;
            _unitOfWork = unitOfWork;
            _emailSender = emailSender;
        }

        public async Task<IActionResult> Index()
        {
            try
            {
                Home_ViewModel model = new Home_ViewModel();
                model.tb_Sliders = await _unitOfWork.SliderRepo.GetAsync();
                model.tb_Setting = await _unitOfWork.SettingRepo.GetByIdAsync(1);
                return View(model);
            }
            catch (Exception)
            {

                throw;
            }
        }
        public IActionResult Policy()
        {
            return View();
        }
        public async Task<IActionResult> Index2()
        {
            try
            {
                Home_ViewModel model = new Home_ViewModel();
                model.tb_Sliders = await _unitOfWork.SliderRepo.GetAsync();
                model.tb_Setting = await _unitOfWork.SettingRepo.GetByIdAsync(1);
                return View(model);
            }
            catch (Exception)
            {

                throw;
            }

        }
        public async Task<IActionResult> ContactUs()
        {
            var setting = await _unitOfWork.SettingRepo.GetByIdAsync(1);
            ViewBag.phone = setting.Phone;
            ViewBag.email = setting.Email;
            return View();
        }
        [ValidateRecaptcha]
        [HttpPost]
        public async Task<IActionResult> ContactUs(Tb_Contact model)
        {

            try
            {
                var setting = await _unitOfWork.SettingRepo.GetByIdAsync(1);
                ViewBag.phone = setting.Phone;
                ViewBag.email = setting.Email;
                if (ModelState.IsValid)
                {
                    await _unitOfWork.ContactRepo.InsertAsync(model);
                    await _unitOfWork.Save();
                    ViewBag.success = "danger alert-success text-center";
                }
                else
                {
                    ViewBag.error = "somthing is wrong";
                }
                return View();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<IActionResult> ContactUsForCustomer()
        {
            var setting = await _unitOfWork.SettingRepo.GetByIdAsync(1);
            ViewBag.phone = setting.Phone;
            ViewBag.email = setting.Email;
            return View();
        }
        [ValidateRecaptcha]
        [HttpPost]
        public async Task<IActionResult> ContactUsForCustomer(Tb_Contact2 model)
        {

            try
            {
                if (!ModelState.IsValid)
                {
                    ViewBag.error = "somthing is wrong";
                    return View();
                }
                var isCustomerExist = await _unitOfWork.OrderRepo.GetAsync(q => q.AccountNumber == model.Code || q.Account == model.Code);
                if (isCustomerExist.Any())
                {
                    var setting = await _unitOfWork.SettingRepo.GetByIdAsync(1);
                    ViewBag.phone = setting.Phone;
                    ViewBag.email = setting.Email;
                    if (ModelState.IsValid)
                    {
                        await _unitOfWork.Contact2Repo.InsertAsync(model);
                        await _unitOfWork.Save();
                        ViewBag.success = "danger alert-success text-center";
                    }
                    else
                    {
                        ViewBag.error = "somthing is wrong";
                    }
                }
                else
                {
                    ViewBag.error = "your code not valid";
                }

                return View();
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        public async Task<IActionResult> SubmitOrder(int type=0)
        {

            var setting = await _unitOfWork.SettingRepo.GetByIdAsync(1);
            ViewBag.logo = setting.Logo;
            ViewBag.type = type;
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> SubmitOrder(Tb_Orders model)
        {
            try
            {
                var setting = await _unitOfWork.SettingRepo.GetByIdAsync(1);
                ViewBag.logo = setting.Logo;
                if (!ModelState.IsValid)
                {
                    return View(ModelState);
                }
                else
                {
                    Tb_Orders order = new Tb_Orders
                    {
                        AccountNumber = Guid.NewGuid().ToString().Substring(0, 5),
                        Country = model.Country,
                        CreateAt = DateTime.Now,
                        Email = model.Email,
                        FullName = model.FullName,
                        Mobile = model.Mobile,
                        status = Status.register,
                        Account = model.Account,
                        Paystatus = model.Paystatus,
                        Account2 = model.Account2

                    };
                    string price = model.Paystatus == 0 ? "99" : "999";
                    await _unitOfWork.OrderRepo.InsertAsync(order);
                    await _unitOfWork.Save();
                    ViewBag.Code = "Your Order ID Is : " + order.AccountNumber + "<br/> Please Check Your Email For Payment Details & Complete Your Order.";
                    await _emailSender.SendEmailAsync(model.Email, "Your Order & Payment Details", $"Dear {model.FullName}" +
                        $"<br><br>Thank you very much for your order at https://profitfactory.eu - part of (<b>World Outsourcing Services Ltd</b>)" +
                        $"<br> Your Order <b>ID</b> at Profitfactory.eu is: <b>{order.AccountNumber}</b> <br> Please make a note of your Order <b>ID</b> and quote it in any communication with us, no matter whether you contact us by Live chat or by e-mail or even if you are sending payments. Below you can find can find all payment options." +
                        $"<br><br> <b>Option 1 - Revolut :</b><br><br>" +
                        $"Firstly you need to open App Store or Google Play and download the Revolut app. You can also sign up on the Revolut website here. https://www.revolut.com/" +
                         "To Send money to Profitfactory Revolut   account you need to save that number in your phone: (<b>00359897601701</b>) than  Tap 'Payments' on the main navigation screen in the app and select 'Send money" +
                         "Any friend with a Revolut account will have a blue 'R' next to their name.Next, select Profitfactory if tha's the name that you have save us in your phone , choose the currency, and enter in the amount you would like to send." +
                         "<br><br> <b>Option 2 - Details For Wire Transfer:</b> <br><br>" +
                         "<b>Account Name: World Outsourcing Services Ltd</b><br><b>Bank Name: United Bulgarian Bank</b> <br> <b>IBAN: BG18UBBS80021453642710</b> <br> <b>BIC / SWIFT: UBBSBGSF</b> <br><b>Bank Address & Branch :Bulgaria, Sofia, bul.Vitosha 89b</b>"+
                         "<br><br> <b>Option 3 - SKRILL :</b> :<br><br> skrill email profitfactory@protonmail.com <br><br>" +
                        $"Please note that we can only start with the setup of your order once we have received the initial payment. After we have received your payment, we will send you a separate e-mail. It will then take one day until everything has been completed and we will send you the Software file." +
                        $"We therefore would like to ask you to transfer the amount of <b>\"{price}\"EUR</b> to one of the options above if you choose <b>Option 1 or Option 2 </b> use Order <b>ID</b> as subject for the transfer.If you choose <b>Option 3 please inform our support.</b><br>This will make it easier for us to allocate the payment and thus speed up the setup process." +
                        "<br><br> Thank you very much!<br>Team Profitfactory.eu"
                        );
                    return View();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
        public async Task<IActionResult> CheckOrder()
        {
            var setting = await _unitOfWork.SettingRepo.GetByIdAsync(1);
            ViewBag.logo = setting.Logo;
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CheckOrder(string Code)
        {
            var setting = await _unitOfWork.SettingRepo.GetByIdAsync(1);
            ViewBag.logo = setting.Logo;
            if (Code == null)
            {
                ViewBag.error = "Code Not Valid";
                return View();
            }
            var order = await _unitOfWork.OrderRepo.GetAsync(q => q.AccountNumber == Code);
            if (!order.Any())
            {
                ViewBag.error = "Code Not Valid";
                return View();
            }
            double expire = order.SingleOrDefault().SubmitDate.Subtract(DateTime.Now).TotalDays;
            if (order.SingleOrDefault().SubmitDate == default(DateTime))
            {
                ViewBag.Days = "your Account Not Submited";
            }
            else if (expire < 0)
            {
                ViewBag.Days = "your account is expired";
            }
            else
            {
                ViewBag.Days = expire.ToString("F0") + " Dayse To Expire";
            }
            return View();
        }
        public IActionResult Privacy()
        {
            return View();
        }
        public IActionResult Broker()
        {
            return View();
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
