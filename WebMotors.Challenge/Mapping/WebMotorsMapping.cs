using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebMotors.Challenge.ModelsPages;
using WebMotors.Framework.Entities;

namespace WebMotors.Challenge.Mapping
{
    public class WebMotorsMapping : Profile
    {
        public WebMotorsMapping()
        {
            CreateMap<Announce , AnnounceModel>();
            CreateMap<AnnounceModel, Announce>();
        }
    }
}
