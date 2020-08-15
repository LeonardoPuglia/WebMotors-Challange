using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebMotors.Challenge.Models.Response
{
    public class AnnounceResponse
    {
        public string Branch { get; set; }
        public string Model { get; set; }
        public string Version { get; set; }
        public int Year { get; set; }
        public int Mileage { get; set; }

        public string Observation { get; set; }
    }
}
