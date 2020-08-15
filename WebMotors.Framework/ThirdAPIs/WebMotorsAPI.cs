using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using WebMotors.Framework.Models;

namespace WebMotors.Framework.ThirdAPIs
{
    public class WebMotorsAPI : BaseAPI , IWebMotorsAPI 
    {

        #region Constants

        public const string MAKE_PATH_URL = "";
        public const string MODEL_PATH_URL = "";
        public const string VERSION_PATH_URL = "";
        public const string VEHICLES_PATH_URL = "";

        #endregion


        public WebMotorsAPI(HttpClient client) : base(client) { }


        public async Task<CarMake> GetCarMake()
        {
            var result = await ExecuteGetApiAsync<CarMake>($"{MAKE_PATH_URL}");
            return result;

        }

        public async Task<CarModel> GetCarModelByMakeId(int MakeId)
        {
            var result = await ExecuteGetApiAsync<CarModel>($"{MODEL_PATH_URL}");
            return result;
        }

        public async Task<CarVersion> GetCarVersionByModelId(int modelId)
        {
            var result = await ExecuteGetApiAsync<CarVersion>($"{VERSION_PATH_URL}");
            return result;
        }

        public async Task<IList<Vehicles>> GetVehiclesByPage(int page)
        {
            var result = await ExecuteGetApiAsync<IList<Vehicles>>($"{VERSION_PATH_URL}");
            return result;
        }
    }
}
