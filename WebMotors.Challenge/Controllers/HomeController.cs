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

        #region Open Page
        [HttpGet]
        public async Task<IActionResult> Index()
        {


            var model = new AnnounceHomeModel();

            var list = await AnnounceService.ListAllAnnounces();

            if (list != null && list.Count > 0)
                model.Announces = Mapper.Map<List<Announce>, List<AnnounceModel>>(list.ToList());

            return View(model.Announces);

        }

        public async Task<IActionResult> Create()
        {
            var model = new AnnounceHomeModel();

            var makes = await GetAllMakes();

            model.CarMakes = makes != null ? makes.ToList() : new List<CarMake>();


            return View(model);

        } 
        #endregion


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



        [HttpPost]
        [ProducesResponseType(typeof(Announce), 200)]
        [ProducesResponseType(typeof(ErrorModel), 500)]
        [SwaggerOperation(Summary = "Criação de Anúncio", Description = "Gerar um anúncio informando a marca e o modelo do carro e a página que contem os veículos a serem anunciados (acionando API da webmotors.")]
        [Produces("application/json")]
        public async Task<IActionResult> PostAnnounced( AnnounceRequest request)
        {
            var result = await ApiResultAsync<Announce>(async () => {

           
                return await AnnounceService.PostAnnounce(request);

            });

            return RedirectToAction("Index");

        }

        [HttpPut]
        [ProducesResponseType(typeof(Announce), 200)]
        [ProducesResponseType(typeof(ErrorModel), 500)]
        [SwaggerOperation(Summary = "Atualiza um anúncio UniqueId", Description = "Atualiza um anúncio cadastrado passando o unique Id")]
        [Produces("application/json")]
        public async Task<IActionResult> PutAnnounced( Guid uniqueId)
        {
            

            var result = await ApiResultAsync<bool>(async () => {


                return await AnnounceService.PutAnnounce(uniqueId) == 1;

            });

            return RedirectToAction("Index");

        }

        [HttpDelete]
        [ProducesResponseType(typeof(Announce), 200)]
        [ProducesResponseType(typeof(ErrorModel), 500)]
        [SwaggerOperation(Summary = "Exclui um UniqueId", Description = "Deleta um anúncio cadastrado passando o unique Id")]
        [Produces("application/json")]
        public async Task<IActionResult> DeleteAnnounced( Guid uniqueId)
        {
            var result = await ApiResultAsync<bool>(async () => {


                return await AnnounceService.DeleteAnnounce(uniqueId) == 1;

            });

            return RedirectToAction("Index");

        }


        private async Task<IList<CarMake>> GetAllMakes()
        {
             return await WebMotorsAPI.GetCarMakes();
        }

        [HttpGet]
        public async Task<IList<CarModel>> GetAllModels( int makeId)
        {
            return await WebMotorsAPI.GetCarModelsByMakeId(makeId);

        }

        [HttpGet]
        public async Task<IList<CarVersion>> GetAllVersions( int modelId)
        {
            return await WebMotorsAPI.GetCarVersionByModelId(modelId);

        }

    }
}
