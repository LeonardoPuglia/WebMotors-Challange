using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebMotors.Framework;

namespace WebMotors.Challenge.ModelsPages
{
    public class AnnounceHomeModel
    {
        public IList<Framework.Models.CarMake> CarsMakes { get; set; }
        public IList<Framework.Models.CarModel> ModelsMakes { get; set; }
        public IList<Framework.Models.CarVersion> CarsVersions { get; set; }
        public IList<Framework.Entities.Announce> Makes { get; set; }
    }
}
