using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using WebMotors.Framework.Entities;
using WebMotors.Framework.Exceptions;
using WebMotors.Framework.Models;
using WebMotors.Framework.Models.Request;

namespace WebMotors.Framework.ThirdAPIs
{
    public class WebMotorsAPI : BaseAPI, IWebMotorsAPI
    {

        #region Constants

        public const string MAKE_PATH_URL = "Make";
        public const string MODEL_PATH_URL = "Model";
        public const string VERSION_PATH_URL = "Version";
        public const string VEHICLES_PATH_URL = "Vehicles";

        #endregion
        private HttpClient _client { get; set; }
        protected HttpClient Client
        {
            get { return _client; }
        }



        public WebMotorsAPI(HttpClient client): base(client)
        {
            //_client = client;
        }


        public async Task<Announce> GetAnnounceByAPI(AnnounceRequest request)
        {
            request.Validate();


            #region Marcas

            var makes = await GetCarMakes();

            if (makes == null || makes.Count == 0)
                throw new NotFoundException("API de marcas não retornou resultados");

            var makeChoiced = makes.FirstOrDefault(x => x.Id == request.MakeId);

            #endregion

            #region Modelos

            var models = await GetCarModelsByMakeId(request.MakeId);

            if (models == null || models.Count == 0)
                throw new NotFoundException($"API não retornou modelos para a marca de Id :  {request.MakeId}");

            var modelChoiced = models.FirstOrDefault(x => x.Id == request.ModelId);

            #endregion

            #region Versões

            var versions = await GetCarVersionByModelId(request.ModelId);

            if (versions == null || versions.Count == 0)
                throw new NotFoundException($"API não retornou versões para o modelo de Id :  {request.ModelId}");

            var versionChoiced = versions.FirstOrDefault(x => x.ModelId == request.ModelId);


            #endregion

            #region Carros

            Vehicle carSelected = null;
            IList<Vehicle> vehicles = null;
            var page = 1;
            var nextPage = false;

            do
            {
                vehicles = await GetVehiclesByPage(page);

                if(vehicles != null && vehicles.Any())
                    carSelected = vehicles.FirstOrDefault(x => x.Make.ToLowerInvariant() == makeChoiced.Name.ToLowerInvariant() && x.Model.ToLowerInvariant() == modelChoiced.Name.ToLowerInvariant());

                page++;

                nextPage =  (carSelected == null && vehicles.Count > 0);

            } while (nextPage);

            if (carSelected == null)
                throw new NotFoundException("Não foi encontrado um veículo pelos parâmetros informados.");

            #endregion

            return new Announce
            {
                Branch = makeChoiced.Name,
                Model = modelChoiced.Name,
                Version = versionChoiced.Name,
                Mileage = !String.IsNullOrWhiteSpace(carSelected.KM) ? int.Parse(carSelected.KM) : 0,
                Year = !String.IsNullOrWhiteSpace(carSelected.YearFab) ? int.Parse(carSelected.YearFab) : 0,
                Observation = request.Observation
            };

        }

        

        
        public async Task<IList<CarMake>> GetCarMakes()
        {
            var result = await ExecuteGetApiAsync<IList<CarMake>>($"{MAKE_PATH_URL}");
            return result;

        }


        public async Task<IList<CarModel>> GetCarModelsByMakeId(int MakeId)
        {
            var result = await ExecuteGetApiAsync<IList<CarModel>>($"{MODEL_PATH_URL}?MakeID={MakeId}");
            return result;
        }

        public async Task<IList<CarVersion>> GetCarVersionByModelId(int modelId)
        {
            var result = await ExecuteGetApiAsync<IList<CarVersion>>($"{VERSION_PATH_URL}?ModelID={modelId}");
            return result;
        }

        public async Task<IList<Vehicle>> GetVehiclesByPage(int page)
        {
            var result = await ExecuteGetApiAsync<IList<Vehicle>>($"{VEHICLES_PATH_URL}?Page={page}");
            return result;
        }



        #region Private
        

        //private async Task<TModel> ExecuteGetApiAsync<TModel>(string path) where TModel : class
        //{
        //    try
        //    {
        //        var response = await Client.GetAsync(path);

        //        response.EnsureSuccessStatusCode();

        //        string responseBody = await response.Content.ReadAsStringAsync();

        //        if (string.IsNullOrWhiteSpace(responseBody))
        //            throw new InternalServerErrorException("External WebMotors API - Response retornou nulo.");

        //        var result = JsonConvert.DeserializeObject<TModel>(responseBody);

        //        return result;
        //    }
        //    catch (Exception ex)
        //    {

        //        throw new InternalServerErrorException($"Houve um erro ao acessar a API externa: {ex.Message}");
        //    }
        //}
        #endregion

    }
}
