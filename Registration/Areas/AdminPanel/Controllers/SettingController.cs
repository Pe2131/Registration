using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Common.Images;
using DAL.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Repository.InterFace;

namespace Registration.Areas.AdminPanel.Controllers
{
    [Area("AdminPanel")]
    [authorize]
    public class SettingController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public SettingController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<IActionResult> Index()
        {
            var setting = await _unitOfWork.SettingRepo.GetByIdAsync(1);
            return View(setting);
        }
        [HttpPost]
        public async Task<IActionResult> Index(Tb_Setting model, IFormFile File)
        {
            try
            {
                var setting = await _unitOfWork.SettingRepo.GetByIdAsync(1);
                if (ModelState.IsValid)
                {
                    if (File != null)
                    {
                        setting.Logo = Guid.NewGuid() + Path.GetExtension(File.FileName);
                        string savePath = Path.Combine(
                            Directory.GetCurrentDirectory(), "wwwroot/HomeStyle/img", setting.Logo
                        );
                        string DirectoryPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/HomeStyle/img");
                        Upload uploader = new Upload();
                        await uploader.UploadImage(savePath, DirectoryPath, File);
                    }
                    setting.Phone = model.Phone;
                    setting.Steps = model.Steps;
                    setting.Text1 = model.Text1;
                    setting.Text2 = model.Text2;
                    setting.Title1 = model.Title1;
                    setting.Title2 = model.Title2;
                    setting.TradePrice = model.TradePrice;
                    setting.Twiter = model.Twiter;
                    setting.YouTube = model.YouTube;
                    setting.Insta = model.Insta;
                    setting.Footer = model.Footer;
                    setting.Email = model.Email;
                    setting.FaceBook = model.FaceBook;
                    setting.Title3 = model.Title3;
                    setting.Title4 = model.Title4;
                    setting.Text3 = model.Text3;
                    setting.Text4 = model.Text4;
                    setting.StepLinks = model.StepLinks;
                    setting.TradeLinks = model.TradeLinks;
                    _unitOfWork.SettingRepo.Update(setting);
                    await _unitOfWork.Save();
                    return View(model);
                }
                return View();
            }
            catch(Exception e)
            {
                throw e;
            }
           
        }
    }
}