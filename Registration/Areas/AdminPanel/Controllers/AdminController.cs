using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DAL.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Registration.Areas.Models.AccountViewModels;
using Repository.InterFace;

namespace Registration.Areas.AdminPanel.Controllers
{
    [Area("AdminPanel")]
    [Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly UserManager<ApplicationUser> _userManager;

        public AdminController(IUnitOfWork unitOfWork, UserManager<ApplicationUser> userManager)
        {
            _unitOfWork = unitOfWork;
            _userManager = userManager;
        }
        public async Task<IActionResult> Index()
        {
            try
            {
                var orders = await _unitOfWork.OrderRepo.GetAsync();
                var contacts = await _unitOfWork.Contact2Repo.GetAsync();
                ViewBag.orders = orders.Count();
                ViewBag.tickets = contacts.Count();
                ViewBag.sumSell = (orders.Where(q => q.status == Status.paid & q.Paystatus == PayStatus.Monthly).Count() * 99) + (orders.Where(q => q.status == Status.paid & q.Paystatus == PayStatus.Yearly).Count() * 999);
                ViewBag.Account = orders.Select(q => q.Email).Distinct().Count();

                return View();
            }
            catch (Exception e)
            {

                throw e;
            }

        }
      
        public IActionResult CreateUser()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateUser(RegisterViewModel model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(model);
                }
                ApplicationUser User = new ApplicationUser {Email = model.Email, Name=model.Name, UserName = model.Email, IsActive = true };
                if (await _userManager.FindByNameAsync(model.Name) != null)
                {
                    ViewBag.Success = "thi User Name Already Exist!!!";
                    return View(model);
                }
                await _userManager.CreateAsync(User, model.Password);
                await _userManager.AddToRoleAsync(User, model.Role);
                await _unitOfWork.Save();
                ViewBag.Success = "Created";
                return View(model);
            }
            catch (Exception e)
            {

                throw e;
            }

        }

        public IActionResult Users()
        {
            var users=_userManager.Users.ToList();
            return View(users);
        }
        public async Task<IActionResult> DeleteUser(string id)
        {
           var user= await _userManager.FindByIdAsync(id);
            if (user != null)
            {
                await _userManager.DeleteAsync(user);

            }
            return RedirectToAction("Users");
        }
    }
}