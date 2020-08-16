using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebMotors.Framework.Exceptions;

namespace WebMotors.Framework.Models.Request
{
    public class AnnounceRequest
    {

        public int MakeId { get; set; }
        public int ModelId { get; set; }
        public int Page { get; set; }


        public void Validate()
        {
            if (MakeId >= 0)
                throw new BadRequestException("");

            if (ModelId >= 0)
                throw new BadRequestException("");

            if (Page >= 0)
                throw new BadRequestException("");
        }
    }
}
