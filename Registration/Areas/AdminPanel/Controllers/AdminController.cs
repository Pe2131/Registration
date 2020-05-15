using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DAL.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Repository.InterFace;

namespace Registration.Areas.AdminPanel.Controllers
{
    [Area("AdminPanel")]
    [Authorize]
    public class AdminController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public AdminController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
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
    }
}