using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Common.Images;
using DAL.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Repository.InterFace;

namespace Registration.Areas.AdminPanel.Controllers
{
    [Area("AdminPanel")]
    [Authorize]
    public class SliderController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public SliderController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<IActionResult> Index()
        {
            try
            {
                var sliders = await _unitOfWork.SliderRepo.GetAsync(null, q => q.OrderByDescending(o => o.Id));
                return View(sliders);
            }
            catch (Exception)
            {

                throw;
            }

        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(Tb_Slider model, IFormFile File)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (File != null)
                    {
                        model.ImageName = Guid.NewGuid() + Path.GetExtension(File.FileName);
                        string savePath = Path.Combine(
                            Directory.GetCurrentDirectory(), "wwwroot/Sliders", model.ImageName
                        );
                        string DirectoryPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Sliders");
                        Upload uploader = new Upload();
                        await uploader.UploadImage(savePath, DirectoryPath, File);
                        await _unitOfWork.SliderRepo.InsertAsync(model);
                        await _unitOfWork.Save();
                        return RedirectToAction(nameof(Index));
                    }
                    else
                    {
                        ModelState.AddModelError(string.Empty, "you must select one image at least");
                        return RedirectToAction(nameof(Index));
                    }
                }
                else
                {
                    return RedirectToAction(nameof(Index));
                }

            }
            catch (Exception)
            {

                throw;
            }
        }
        public async Task<IActionResult> Edit(int Id)
        {
            try
            {
                var slider = await _unitOfWork.SliderRepo.GetByIdAsync(Id);
                return View(slider);
            }
            catch (Exception)
            {

                throw;
            }

        }
        [HttpPost]
        public async Task<IActionResult> Edit(Tb_Slider model, IFormFile File)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var slider = await _unitOfWork.SliderRepo.GetByIdAsync(model.Id);
                    if (File != null)
                    {
                        model.ImageName = Guid.NewGuid() + Path.GetExtension(File.FileName);
                        string savePath = Path.Combine(
                            Directory.GetCurrentDirectory(), "wwwroot/Sliders", model.ImageName
                        );
                        string DirectoryPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Sliders");
                        Upload uploader = new Upload();
                        Delete delete = new Delete();
                        delete.DeleteImage(Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Sliders", slider.ImageName));
                        await uploader.UploadImage(savePath, DirectoryPath, File);
                        slider.ImageName = model.ImageName;
                    }

                    slider.Title = model.Title;
                    slider.Title2 = model.Title2;
                     _unitOfWork.SliderRepo.Update(slider);
                    await _unitOfWork.Save();
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    return RedirectToAction(nameof(Index));
                }

            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}