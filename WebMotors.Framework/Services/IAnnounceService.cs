using System;
using System.Collections.Generic;
using System.Text;
using WebMotors.Framework.Entities;

namespace WebMotors.Framework.Services
{
    public interface IAnnounceService
    {
        Announce GetAnnounceByUniqueId(Guid uniqueId);
        bool PostAnnounce(Announce entity);
        bool PutAnnounce(Guid uniqueId);
        bool DeleteAnnounce(Guid uniqueId);
        IList<Announce> ListAnnounce();
    }
}
