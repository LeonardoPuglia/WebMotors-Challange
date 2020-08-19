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
        public string Version { get; set; }

        public string Observation { get; set; }


        public void Validate()
        {
            if (MakeId <= 0)
                throw new BadRequestException("Marca é obrigatória parar gerar o anúncio");

            if (ModelId <= 0)
                throw new BadRequestException("Modelo é obrigatório parar gerar o anúncio");

            if (String.IsNullOrWhiteSpace(Version))
                throw new BadRequestException("Versão é obrigatório parar gerar o anúncio");
        }
    }
}
