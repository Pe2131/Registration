using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Common.Extensions;
using Common.Images;
using DAL.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Registration.Areas.AdminPanel.Utilitis;
using Repository.InterFace;
using Service;

namespace Registration.Areas.AdminPanel.Controllers
{
    [Area("AdminPanel")]
    [Authorize(Roles = "Admin,Suport")]
    public class OrderController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IEmailSender _emailSender;

        public OrderController(IUnitOfWork unitOfWork, IEmailSender emailSender)
        {
            _unitOfWork = unitOfWork;
            _emailSender = emailSender;
        }
        public async Task<IActionResult> Index()
        {
            var oerders = await _unitOfWork.OrderRepo.GetAsync(null, q => q.OrderByDescending(o => o.Id));
            return View(oerders);
        }
        public async Task<IActionResult> Payments()
        {
            var oerders = await _unitOfWork.OrderRepo.GetAsync(q=>q.status==Status.paid, q => q.OrderByDescending(o => o.Id));
            return View(oerders);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SendEmail(int Id, string email, IFormFile File)
        {
            try
            {
                if (Id != 0 & email != null)
                {
                    var order = await _unitOfWork.OrderRepo.GetByIdAsync(Id);
                    if (File != null)
                    {
                        order.FileAddress = order.AccountNumber + Path.GetExtension(File.FileName);
                        string savePath = Path.Combine(
                            Directory.GetCurrentDirectory(), "wwwroot/Files", order.FileAddress
                        );
                        string DirectoryPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Files");
                        Upload uploader = new Upload();
                        await uploader.UploadImage(savePath, DirectoryPath, File);
                    }
                    else
                    {
                        ViewBag.fail = "File must be fill";
                        return RedirectToAction(nameof(Index));
                    }
                    if (order.Paystatus == DAL.Models.PayStatus.Monthly)
                    {
                        order.SubmitDate = DateTime.Now.AddDays(30);
                    }
                    else
                    {
                        order.SubmitDate= DateTime.Now.AddDays(365);
                    }
                    order.status = Status.paid;
                    _unitOfWork.OrderRepo.Update(order);
                    await _unitOfWork.Save();
                    if (order.FileAddress != null)
                    {
                        string link = Url.DownloadLink(order.AccountNumber, order.Id, Request.Scheme);
                        await Task.Run(() => _emailSender.SendDownladLinkAsync(order.Email, link));

                    }
                    ViewBag.Success = "Email Sent";
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    ViewBag.fail = "Data Not Valid";
                    return RedirectToAction(nameof(Index));
                }
            }
            catch (Exception e)
            {

                throw e;
            }
        }
    }
}