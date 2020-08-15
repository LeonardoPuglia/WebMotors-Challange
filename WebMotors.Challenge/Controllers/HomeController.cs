using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebMotors.Challenge.Controllers.Base;
using WebMotors.Framework.Entities;
using WebMotors.Framework.Services;

namespace WebMotors.Challenge.Controllers
{
    public class HomeController : BaseController
    {
        public HomeController(ILogger<HomeController> logger, IAnnounceService announceService) : base(logger)
        {
            _announceService = announceService;
        }

        public IAnnounceService _announceService;
        public IAnnounceService AnnounceService
        {
            get { return _announceService; }
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
           return await ApiResultAsync<bool>(async () =>{
                return true;
            });

        }


        [HttpGet]
        public async Task<IActionResult> GetAnnounceById([FromQuery] Guid uniqueId)
        {
            return await ApiResultAsync<Announce>(async () => {
                return AnnounceService.GetAnnounceByUniqueId(uniqueId);
            });

        }

        [HttpGet]
        public async Task<IActionResult> ListAnnounceds()
        {
            return await ApiResultAsync<IList<Announce>>(async () => {
                return AnnounceService.ListAnnounce();
            });

        }

        [HttpPost]
        public async Task<IActionResult> PostAnnounced()
        {
            return await ApiResultAsync<bool>(async () => {
                return AnnounceService.PostAnnounce(new Announce());
            });

        }

        [HttpPut]
        public async Task<IActionResult> PutAnnounced([FromQuery] Guid uniqueId)
        {
            return await ApiResultAsync<bool>(async () => {
                return AnnounceService.PutAnnounce(uniqueId);
            });

        }

        [HttpDelete]
        public async Task<IActionResult> DeleteAnnounced([FromQuery] Guid uniqueId)
        {
            return await ApiResultAsync<bool>(async () => {
                return AnnounceService.DeleteAnnounce(uniqueId);
            });

        }



    }
}
