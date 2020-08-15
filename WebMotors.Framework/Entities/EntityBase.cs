using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebMotors.Framework.Entities
{
    public class EntityBase<Key>
    {

        public Key Id { get; set; }

        public DateTime CreateDate { get; set; }
        public DateTime UpdateDate { get; set; }

        public Guid UniqueId { get; set; }
    }
    
}
