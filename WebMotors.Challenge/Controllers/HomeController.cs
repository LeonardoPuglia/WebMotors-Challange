using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using Swashbuckle.AspNetCore.Annotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebMotors.Challenge.Controllers.Base;
using WebMotors.Challenge.ModelsPages;
using WebMotors.Framework.Entities;
using WebMotors.Framework.Models;
using WebMotors.Framework.Models.Request;
using WebMotors.Framework.Services;
using WebMotors.Framework.ThirdAPIs;

namespace WebMotors.Challenge.Controllers
{
    public class HomeController : BaseController
    {
        public HomeController(ILogger<HomeController> logger, IAnnounceService announceService , IWebMotorsAPI webMotorsAPI , IMapper mapper) : base(logger)
        {
            _announceService = announceService;
            _webMotorsAPI = webMotorsAPI;
            _mapper = mapper;
        }


        #region Properties
        private IAnnounceService _announceService;
        public IAnnounceService AnnounceService
        {
            get { return _announceService; }
        }

        private IWebMotorsAPI _webMotorsAPI;
        public IWebMotorsAPI WebMotorsAPI
        {
            get { return _webMotorsAPI; }
        }


        private readonly IMapper _mapper;
        public  IMapper Mapper
        {
            get { return _mapper; }
        }
        #endregion

        [HttpGet]
        public async Task<IActionResult> Index()
        {
           

            var model = new AnnounceHomeModel();

            var list = await  AnnounceService.ListAllAnnounces();

            if (list != null && list.Count > 0)
                model.Announces = Mapper.Map<List<Announce>, List<AnnounceModel>>(list.ToList());
            
            return View(model);
          
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {

            var makes = await GetAllMakes();

            var makesList = makes != null ? makes.ToList() : new List<CarMake>();

            var model = new AnnounceHomeModel();

            model.CarMakes.Add(new SelectListItem("Selecione uma marca ... ", ""));
            makesList.ForEach(x =>
            {
                model.CarMakes.Add(new SelectListItem(x.Name, x.Id.ToString()));
            });

            model.CarModels.Add(new SelectListItem("Selecione um modelo ... ", ""));
            model.CarVersions.Add(new SelectListItem("Selecione uma versão ... ", ""));

            return View(model);

        }


        [HttpGet]
        [ProducesResponseType(typeof(Announce), 200)]
        [ProducesResponseType(typeof(ErrorModel), 500)]
        [SwaggerOperation(Summary = "Retorna pelo UniqueId", Description = "Retorna um anúncio cadastrado passando o unique Id")]
        [Produces("application/json")]
        public async Task<IActionResult> GetAnnounceById([FromQuery] Guid uniqueId)
        {
            return await ApiResultAsync<Announce>(async () => {
                return await AnnounceService.GetAnnounceByUniqueId(uniqueId);
            });

        }

        //[HttpGet]
        //[ProducesResponseType(typeof(IList<Announce>), 200)]
        //[ProducesResponseType(typeof(ErrorModel), 500)]
        //[SwaggerOperation(Summary = "Retorna pelo UniqueId", Description = "Retorna um anúncio cadastrado passando o unique Id")]
        //public async Task<IActionResult> ListAnnounceds()
        //{
        //    return await ApiResultAsync<IList<Announce>>(async () => {
        //        return await AnnounceService.ListAnnounce();
        //    });

        //}

        [HttpPost]
        [ProducesResponseType(typeof(Announce), 200)]
        [ProducesResponseType(typeof(ErrorModel), 500)]
        [SwaggerOperation(Summary = "Criação de Anúncio", Description = "Gerar um anúncio informando a marca e o modelo do carro e a página que contem os veículos a serem anunciados (acionando API da webmotors.")]
        [Produces("application/json")]
        public async Task<IActionResult> PostAnnounced( int makeId ,  int modelId,  int page)
        {
            return await ApiResultAsync<Announce>(async () => {


                var request = new AnnounceRequest { MakeId = makeId, ModelId = modelId, Page = page };
           
                var result = await AnnounceService.PostAnnounce(request);

                return result;
            });

        }

        [HttpPut]
        [ProducesResponseType(typeof(Announce), 200)]
        [ProducesResponseType(typeof(ErrorModel), 500)]
        [SwaggerOperation(Summary = "Atualiza um anúncio UniqueId", Description = "Atualiza um anúncio cadastrado passando o unique Id")]
        [Produces("application/json")]
        public async Task<IActionResult> PutAnnounced([FromQuery] Guid uniqueId)
        {
            return await ApiResultAsync<bool>(async () => {
                return await AnnounceService.PutAnnounce(uniqueId) == 1;
            });

        }

        [HttpDelete]
        [ProducesResponseType(typeof(Announce), 200)]
        [ProducesResponseType(typeof(ErrorModel), 500)]
        [SwaggerOperation(Summary = "Exclui um UniqueId", Description = "Deleta um anúncio cadastrado passando o unique Id")]
        [Produces("application/json")]
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
        public async Task<IActionResult> GetAllModels( int makeId)
        {
            return await ApiResultAsync<IList<CarModel>>(async () => {
                return await WebMotorsAPI.GetCarModelsByMakeId(makeId);
            });

        }

        [HttpGet]
        public async Task<IActionResult> GetAllVersions( int modelId)
        {
            return await ApiResultAsync<IList<CarVersion>>(async () => {
                return await WebMotorsAPI.GetCarVersionByModelId(modelId);
            });

        }

    }
}
