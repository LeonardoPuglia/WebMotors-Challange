using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebMotors.Challenge.ModelsPages
{
    public class AnnounceModel
    {
        public DateTime CreateDate { get; set; }
        public DateTime UpdateDate { get; set; }

        public Guid UniqueId { get; set; }

        public string Branch { get; set; }
        public string Model { get; set; }
        public string Version { get; set; }
        public int Year { get; set; }
        public int Mileage { get; set; }

        public string Observation { get; set; }
    }
}
