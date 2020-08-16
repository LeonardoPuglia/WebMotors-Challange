using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WebMotors.Framework.Entities;
using WebMotors.Framework.Models.Request;

namespace WebMotors.Framework.Services
{
    public interface IAnnounceService
    {
        Task<Announce> GetAnnounceByUniqueId(Guid uniqueId);
        Task<Announce> PostAnnounce(AnnounceRequest request);
        Task<int> PutAnnounce(Guid uniqueId);
        Task<int> DeleteAnnounce(Guid uniqueId);
        Task<IList<Announce>> ListAnnounce();
    }
}
