using Microsoft.AspNetCore.Mvc;
using Repository.InterFace;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Registration.ViewComponents
{
    public class HeaderViewComponent:ViewComponent
    {
        private readonly IUnitOfWork _unitOfWork;
        public HeaderViewComponent(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View("P_Header",await _unitOfWork.SettingRepo.GetByIdAsync(1));
        }

    }
}
