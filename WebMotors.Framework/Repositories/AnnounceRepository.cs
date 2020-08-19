using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WebMotors.Framework.Entities;

namespace WebMotors.Framework.Repositories
{
    public class AnnounceRepository : IAnnounceRepository
    {
        public WebMotorsDbContext _context;
        public WebMotorsDbContext Context { get { return _context; } }

        public AnnounceRepository(WebMotorsDbContext context)
        {
            _context = context;
        }

        public async Task<int> RemoveAnnounceAsync(Guid uniqueId)
        {
            var entity = await GetAnnounceAsync(uniqueId);

            Context.Set<Announce>().Remove(entity);

            return await Context.SaveChangesAsync();
        }

        public async Task<Announce> InsertAnnounceAsync(Announce entity)
        {
            var result  = await Context.Set<Announce>().AddAsync(entity);
            await Context.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<Announce> GetAnnounceAsync(Guid uniqueId)
        {
            return await Context.Set<Announce>().FirstOrDefaultAsync(x => x.UniqueId == uniqueId);
        }

        public async Task<int> UpdateAnnounceAsync(Announce entity)
        {
             Context.Set<Announce>().Update(entity);

            return await Context.SaveChangesAsync();
        }

        public async Task<IList<Announce>> ListAllAnnounceAsync()
        {
            return await Context.Set<Announce>().ToListAsync();
        }
    }
}
