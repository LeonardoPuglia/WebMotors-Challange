using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WebMotors.Framework.Entities;
using WebMotors.Framework.Exceptions;
using WebMotors.Framework.Models.Request;
using WebMotors.Framework.Repositories;
using WebMotors.Framework.ThirdAPIs;

namespace WebMotors.Framework.Services
{
    public class AnnounceService : IAnnounceService
    {

        #region Properties
        public IWebMotorsAPI _webMotorsAPI;
        public IWebMotorsAPI WebMotorsAPI { get { return _webMotorsAPI; } }


        public IAnnounceRepository _announceRepository;
        public IAnnounceRepository AnnounceRepository { get { return _announceRepository; } }

        #endregion

        #region Ctor

        public AnnounceService(IWebMotorsAPI webMotorsAPI , IAnnounceRepository announceRepository)
        {
            _webMotorsAPI = webMotorsAPI;
            _announceRepository = announceRepository;
        }

        #endregion

        #region Methods
        public async Task<int> DeleteAnnounce(Guid uniqueId)
        {
            if (uniqueId == Guid.Empty)
                throw new BadRequestException("Unique id do anúncio é obrigatório");

            return await AnnounceRepository.RemoveAnnounceAsync(uniqueId);
        }

        public async Task<Announce> GetAnnounceByUniqueId(Guid uniqueId)
        {
            if (uniqueId == Guid.Empty)
                throw new BadRequestException("Unique id do anúncio é obrigatório");

            var entity = await AnnounceRepository.GetAnnounceAsync(uniqueId);

            if (entity == null)
                throw new NotFoundException($"Anúncio inexistente para o UniqueId : {uniqueId}");

            return entity;
        }

        public async Task<Announce> PostAnnounce(AnnounceRequest request)
        {
            if (request == null)
                throw new BadRequestException("O dados de requisição da criação do anúncio não foram informados.");

            var entity = await WebMotorsAPI.GetAnnounceByAPI(request);

            return await AnnounceRepository.InsertAnnounceAsync(entity);
        }

        public async Task<int> PutAnnounce(Guid uniqueId)
        {
            if (uniqueId == Guid.Empty)
                throw new BadRequestException("Unique id do anúncio é obrigatório");

            var entity = await AnnounceRepository.GetAnnounceAsync(uniqueId);

            if (entity == null)
                throw new NotFoundException($"Anúncio inexistente para o UniqueId : {uniqueId}");

            return await AnnounceRepository.UpdateAnnounceAsync(entity);
        }

        public async Task<IList<Announce>> ListAllAnnounces()
        {

            return await AnnounceRepository.ListAllAnnounceAsync();

        }

        #endregion
    }
}
