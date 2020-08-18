using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebMotors.Framework;
using WebMotors.Framework.Entities;

namespace WebMotors.Challenge.ModelsPages
{
    public class AnnounceHomeModel
    {
        public AnnounceHomeModel()
        {
            CarMakes = new List<SelectListItem>();
            CarModels = new List<SelectListItem>();
            CarVersions = new List<SelectListItem>();
            Announces = new List<AnnounceModel>();
        }
        //public IList<Framework.Models.CarMake> CarsMakes { get; set; }
        //public IList<Framework.Models.CarModel> ModelsMakes { get; set; }
        //public IList<Framework.Models.CarVersion> CarsVersions { get; set; }
        //public IList<Framework.Entities.Announce> Makes { get; set; }

        public List<SelectListItem> CarMakes { get; set; }
        public List<SelectListItem> CarModels { get; set; }
        public List<SelectListItem> CarVersions { get; set; }

        public List<AnnounceModel> Announces { get; set; }

    }
}
