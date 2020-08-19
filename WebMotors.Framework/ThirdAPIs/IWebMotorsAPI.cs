using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WebMotors.Framework.Entities;
using WebMotors.Framework.Models;
using WebMotors.Framework.Models.Request;

namespace WebMotors.Framework.ThirdAPIs
{
    public interface IWebMotorsAPI
    {
        Task<IList<CarMake>> GetCarMakes();
        Task<IList<CarModel>> GetCarModelsByMakeId(int MakeId);
        Task<IList<CarVersion>> GetCarVersionByModelId(int modelId);
        Task<IList<Vehicle>> GetVehiclesByPage(int page);

        Task<Announce> GetAnnounceByAPI(AnnounceRequest request);

    }
}
