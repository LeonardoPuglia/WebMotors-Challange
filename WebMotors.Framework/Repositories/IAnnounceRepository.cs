using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WebMotors.Framework.Entities;

namespace WebMotors.Framework.Repositories
{
    public interface IAnnounceRepository
    {
        Task<Announce> GetAnnounceAsync(Guid uniqueId);
        Task<int> RemoveAnnounceAsync(Guid uniqueId);
        Task<int> UpdateAnnounceAsync(Announce entity);
        Task<Announce> InsertAnnounceAsync(Announce entity);
    }
}
