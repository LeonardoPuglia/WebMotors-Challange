using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WebMotors.Framework.Entities;
using WebMotors.Framework.Models;

namespace WebMotors.Framework.ThirdAPIs
{
    public interface IWebMotorsAPI
    {
        Task<CarMake> GetCarMake();
        Task<CarModel> GetCarModelByMakeId(int MakeId);
        Task<CarVersion> GetCarVersionByModelId(int modelId);
        Task<IList<Vehicles>> GetVehiclesByPage(int page);
    }
}
