using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebMotors.Challenge.Controllers.Base;
using WebMotors.Framework.Entities;
using WebMotors.Framework.Models;
using WebMotors.Framework.Models.Request;
using WebMotors.Framework.Services;
using WebMotors.Framework.ThirdAPIs;

namespace WebMotors.Challenge.Controllers
{
    public class HomeController : BaseController
    {
        public HomeController(ILogger<HomeController> logger, IAnnounceService announceService , IWebMotorsAPI webMotorsAPI) : base(logger)
        {
            _announceService = announceService;
            _webMotorsAPI = webMotorsAPI;
        }

        public IAnnounceService _announceService;
        public IAnnounceService AnnounceService
        {
            get { return _announceService; }
        }

        public IWebMotorsAPI _webMotorsAPI;
        public IWebMotorsAPI WebMotorsAPI
        {
            get { return _webMotorsAPI; }
        }


        [HttpGet]
        public async Task<IActionResult> Index()
        {
           
            var makes = await GetAllMakes();

            var model = new ModelsPages.AnnounceHomeModel
            {
                CarsMakes = makes
            };

            return View(model);
          
        }


        [HttpGet]
        public async Task<IActionResult> GetAnnounceById([FromQuery] Guid uniqueId)
        {
            return await ApiResultAsync<Announce>(async () => {
                return await AnnounceService.GetAnnounceByUniqueId(uniqueId);
            });

        }

        [HttpGet]
        public async Task<IActionResult> ListAnnounceds()
        {
            return await ApiResultAsync<IList<Announce>>(async () => {
                return await AnnounceService.ListAnnounce();
            });

        }

        [HttpPost]
        public async Task<IActionResult> PostAnnounced([FromQuery] int makeId , [FromQuery] int modelId, [FromQuery] int page)
        {
            return await ApiResultAsync<Announce>(async () => {


                var request = new AnnounceRequest { MakeId = makeId, ModelId = modelId, Page = page };
           
                var result = await AnnounceService.PostAnnounce(request);

                return result;
            });

        }

        [HttpPut]
        public async Task<IActionResult> PutAnnounced([FromQuery] Guid uniqueId)
        {
            return await ApiResultAsync<bool>(async () => {
                return await AnnounceService.PutAnnounce(uniqueId) == 1;
            });

        }

        [HttpDelete]
        public async Task<IActionResult> DeleteAnnounced([FromQuery] Guid uniqueId)
        {
            return await ApiResultAsync<bool>(async () => {
                return await AnnounceService.DeleteAnnounce(uniqueId) == 1;
            });

        }


        private async Task<IList<CarMake>> GetAllMakes()
        {
             return await WebMotorsAPI.GetCarMakes();
        }

        [HttpGet]
        public async Task<IActionResult> GetAllModels([FromQuery] int makeId)
        {
            return await ApiResultAsync<IList<CarModel>>(async () => {
                return await WebMotorsAPI.GetCarModelsByMakeId(makeId);
            });

        }

        [HttpGet]
        public async Task<IActionResult> GetAllVersions([FromQuery] int modelId)
        {
            return await ApiResultAsync<IList<CarVersion>>(async () => {
                return await WebMotorsAPI.GetCarVersionByModelId(modelId);
            });

        }

    }
}
