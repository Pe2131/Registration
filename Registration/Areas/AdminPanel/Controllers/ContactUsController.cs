using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Repository.InterFace;

namespace Registration.Areas.AdminPanel.Controllers
{
    [Area("AdminPanel")]
    [authorize]
    public class ContactUsController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public ContactUsController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IActionResult Index()
        {
            try
            {
                var model = _unitOfWork.ContactRepo.Get().OrderByDescending(a => a.id).ToList();
                return View(model);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        public async Task<JsonResult> Delete(int id)
        {
            try
            {
                _unitOfWork.ContactRepo.Delete(id);
                await _unitOfWork.ContactRepo.Save();
                return Json(1);
            }
            catch (Exception)
            {
                return Json(0);
            }
        }
        public IActionResult Index2()
        {
            try
            {
                var model = _unitOfWork.Contact2Repo.Get().OrderByDescending(a => a.id).ToList();
                return View(model);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        public async Task<JsonResult> Delete2(int id)
        {
            try
            {
                _unitOfWork.ContactRepo.Delete(id);
                await _unitOfWork.Contact2Repo.Save();
                return Json(1);
            }
            catch (Exception)
            {
                return Json(0);
            }
        }
    }
}