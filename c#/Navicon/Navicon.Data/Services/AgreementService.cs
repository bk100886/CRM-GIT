using Navicon.Core.IRepositories;
using Navicon.Core.IServices;
using Navicon.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Query;

namespace Navicon.Data.Services
{
    /// <inheritdoc cref="IAgreementService"/>
    public sealed class AgreementService : BaseService, IAgreementService
    {
        /// <summary>
        /// Репозиторий договоров.
        /// </summary>
        private readonly IAgreementRepository ageementRepository;

        /// <summary>
        /// Конструктор.
        /// </summary>
        /// <param name="log">Сервис логирования</param>
        /// <param name="ageementRepository">Репозиторий договоров.</param>
        public AgreementService(ILogService log, IAgreementRepository ageementRepository) : base(log)
        {
            this.ageementRepository = ageementRepository ?? throw new ArgumentNullException(nameof(ageementRepository));
        }

        /// <inheritdoc/>
        public List<nav_agreement> GetAllAgreements()
        {
            List<nav_agreement> result = null;
            try
            {
                result = ageementRepository.Get();
            }
            catch (Exception exc)
            {
                log.Error(exc.ToString());
            
                throw;
            }
            return result;
        }

        /// <inheritdoc/>
        public long GetCountByContactId(Guid contactId)
        {
            var filter = new FilterExpression();
            filter.AddCondition(nav_agreement.Fields.nav_contact, ConditionOperator.Equal, contactId);
            return ageementRepository.Get(filter, cols: nav_agreement.PrimaryIdAttribute).Count();
        }

        /// <inheritdoc/>
        public Money GetFactSumma(Guid Id)
        {
            return ageementRepository.GetById(Id, nav_agreement.Fields.nav_factsumma).nav_factsumma;
            //return AsQueryable().Where(item => item.Id == Id).Select(s => s.nav_factsumma).ToList().FirstOrDefault();
        }

        /// <inheritdoc/>
        public Money GetSumma(Guid Id)
        {          
            return ageementRepository.GetById(Id, cols: nav_agreement.Fields.nav_summa).nav_summa;
        }

        /// <inheritdoc/>
        public void UpdateFactSumma(Guid Id, Money summa)
        {
            var agreement = new nav_agreement { Id = Id, nav_factsumma = summa };
            ageementRepository.Update(agreement);
        }
    }
}
