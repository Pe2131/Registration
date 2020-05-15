using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Common.Encrypt;
using Common.Extensions;
using Common.String;
using Common.ViewModel;
using DAL.Models;
using Registration.Areas.AdminPanel.Utilitis;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Repository.InterFace;
using Service;
using Service.Telegram.InterFace;

namespace Registration.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SetDataController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IEmailSender _emailSender;
        private readonly IWebHostEnvironment _env;
        private readonly ITelegramService _telegramService;


        public SetDataController(IUnitOfWork unitOfWork, IEmailSender emailSender, IWebHostEnvironment env,ITelegramService telegramService)
        {
            _unitOfWork = unitOfWork;
            _emailSender = emailSender;
            _env = env;
            _telegramService = telegramService;
        }
        // GET: api/SetData
        [HttpGet]
        public async Task<IActionResult> GetAsync()
        {

            await _telegramService.SendMessage("-1001234999929","hi");
            return Ok();
            //get deposit
            //GetDeposit_Req req = new GetDeposit_Req
            //{
            //    affiliateID = 84,
            //    dateFrom = DateTime.Now.AddDays(-1).Iso8601Format(),
            //    dateTo = DateTime.Now.Iso8601Format(),
            //    leadsIDs = "200330076000"
            //};
            //string checksummaker = $"affiliateID=84&dateFrom={req.dateFrom.UrlEncode().ToUpper()}&dateTo={req.dateTo.UrlEncode().ToUpper()}&leadsIDs={req.leadsIDs}";
            //req.checksum = checksummaker.MakeCheckSum("U0kOmx");
            //var res = await _apiService.GetDiposits(req);
            //return Ok(res);
            // get conversion
            //GetConversion_Req req = new GetConversion_Req
            //{
            //    affiliateID=84,
            //    dateFrom=DateTime.Now.AddDays(-1),
            //    dateTo=DateTime.Now,
            //};
            //string checksummaker = $"affiliateID=84&dateFrom={req.dateFrom.Iso8601Format().UrlEncode().ToUpper()}&dateTo={req.dateTo.Iso8601Format().UrlEncode().ToUpper()}";
            //req.checksum = checksummaker.MakeCheckSum("U0kOmx");
            //var res = await _apiService.GetConversion(req);
            //return Ok(res);
        }

        // GET: api/SetData/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }

        [HttpGet("/SetData/Download")]
        public async Task<IActionResult> Download(string code, int code2)
        {
            try
            {
                var order = await _unitOfWork.OrderRepo.GetAsync(q=>q.Id==code2 & q.AccountNumber==code);
                if (order == null)
                {
                    return BadRequest("your information was not correct");
                }
                //order.EmailConfirmed = true;
                //_unitOfWork.order.Update(order);
                //await _unitOfWork.Save();
                string mediaType = "application/zip";
                string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Files", order.SingleOrDefault().FileAddress);
                var fileInfo = new FileInfo(path);
                return PhysicalFile(path, mediaType, "Download.zip");
            }
            catch (Exception e)
            {
                throw e;
            }

        }
        // POST: api/SetData
        [HttpPost]
        public async Task<IActionResult> Post(LandingData_ViewModel model)
        {
            try
            {
                //if (ModelState.IsValid)
                //{
                //    if (model.LandingId != null)
                //    {
                //        var landingInfo = await _unitOfWork.LandingRepo.GetByIdAsync(Guid.Parse(model.LandingId));
                //        if (landingInfo == null)
                //        {
                //            return Ok("Data Invalid");
                //        }
                //        var landingExistInDb = await _unitOfWork.LandingDataRepo.GetAsync(q => q.Email == model.Email & q.LandingId == Guid.Parse(model.LandingId));
                //        if (landingExistInDb.Any())
                //        {
                //            return Ok("your Email have already Saved");
                //        }
                //        Tb_LandingsData tb_LandingsData = new Tb_LandingsData();
                //        if (model.Ip != null && model.Country == null)
                //        {
                //            var ipInfo = await model.Ip.GetInfoAsync();
                //            tb_LandingsData = new Tb_LandingsData
                //            {
                //                Email = model.Email,
                //                Name = model.name,
                //                LastName = model.LastName,
                //                Phone = model.Phone,
                //                LandingId = Guid.Parse(model.LandingId),
                //                Ip = ipInfo.ip,
                //                Country = ipInfo.country_name,
                //                CallingCode = ipInfo.country_calling_code,
                //                City = ipInfo.city,
                //                CountryCode = ipInfo.country,
                //                Language = ipInfo.languages,
                //                Currency = ipInfo.currency,
                //                createdAt = DateTime.Now
                //            };
                //        }
                //        else
                //        {
                //            tb_LandingsData = new Tb_LandingsData
                //            {
                //                Email = model.Email,
                //                Name = model.name,
                //                LastName = model.LastName,
                //                Phone = model.Phone,
                //                LandingId = Guid.Parse(model.LandingId),
                //                Ip = model.Ip,
                //                Country = model.Country,
                //                Currency = model.Currency,
                //                CallingCode = model.CallCode,
                //                City = model.City,
                //                CountryCode = model.CountryCode,
                //                Language = model.languages,
                //                createdAt = DateTime.Now
                //            };
                //        }
                //        await _unitOfWork.LandingDataRepo.InsertAsync(tb_LandingsData);
                //        await _unitOfWork.Save();
                //        if (landingInfo.FileAddress != null)
                //        {
                //            string link = Url.DownloadLink(model.LandingId, tb_LandingsData.Id, Request.Scheme);
                //            if (landingInfo.EmailContent == null)
                //            {
                //                await Task.Run(() => _emailSender.SendDownladLinkAsync(model.Email, link));
                //            }
                //            else
                //            {
                //                await Task.Run(() => _emailSender.SendDownladLinkAsync(model.Email, link, landingInfo.Name, landingInfo.EmailContent));
                //            }
                //        }
                //        var request = _apiService.MakeCreateLeadRequest(tb_LandingsData);
                //        var LeadResponse = await _apiService.CreateLead(request);
                //        if (LeadResponse.data != null)
                //        {
                //            tb_LandingsData.LeadID = LeadResponse.data.leadID;
                //            tb_LandingsData.DateRegistered = LeadResponse.data.dateRegistered;
                //            _unitOfWork.LandingDataRepo.Update(tb_LandingsData);
                //            await _unitOfWork.LandingDataRepo.Save();
                //            return Ok("Save SuccessFully an email was sent For you");
                //        }
                //        else
                //        {
                //            return Ok(LeadResponse.description);
                //        }

                //    }
                //    else
                //    {
                //        return Ok("your Data Not Valid");
                //    }
                //}
                //else
                //{
                //    return Ok("your data not valid");
                //}
                return Ok();
            }
            catch (Exception e)
            {

                return Ok(e.Message);
            }
        }
        public async Task<IActionResult> SubmitForm(Tb_Orders model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                else
                {
                    Guid code = new Guid();
                    Tb_Orders order = new Tb_Orders
                    {
                        AccountNumber = code.ToString().Substring(0, 5),
                        Country = model.Country,
                        CreateAt = DateTime.Now,
                        Email = model.Email,
                        FullName = model.FullName,
                        Mobile = model.Mobile,
                        status = Status.register

                    };
                    await _unitOfWork.OrderRepo.InsertAsync(order);
                    await _unitOfWork.Save();
                    return Ok();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        // PUT: api/SetData/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
