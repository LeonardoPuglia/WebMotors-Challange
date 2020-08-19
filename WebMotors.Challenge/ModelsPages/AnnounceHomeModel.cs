using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebMotors.Framework;
using WebMotors.Framework.Entities;
using WebMotors.Framework.Models;
using WebMotors.Framework.Models.Request;

namespace WebMotors.Challenge.ModelsPages
{
    public class AnnounceHomeModel
    {
        public AnnounceHomeModel()
        {
            CarMakes = new List<CarMake> ();
            CarModels = new List<CarModel>();
            CarVersions = new List<CarVersion>();
            Announces = new List<AnnounceModel>();
            Request = new AnnounceRequest();
        }

        public List<CarMake> CarMakes { get; set; }
        public List<CarModel> CarModels { get; set; }
        public List<CarVersion> CarVersions { get; set; }

        public List<AnnounceModel> Announces { get; set; }

        public AnnounceRequest Request { get; set; }


    }
}
