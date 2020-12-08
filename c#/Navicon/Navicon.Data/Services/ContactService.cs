using Navicon.Core.Entities;
using Navicon.Core.IRepositories;
using Navicon.Core.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Navicon.Data.Services
{
    /// <inheritdoc cref="IContactService"/>
    public sealed class ContactService :BaseService, IContactService
    {
        /// <summary>
        /// Репозиторий контактов.
        /// </summary>
        private readonly IContactRepository contactRepository;

        /// <summary>
        /// Конструктор.
        /// </summary>
        /// <param name="log">Лог.</param>
        /// <param name="contactRepository">Репозиторий контактов.</param>
        public ContactService(ILogService log, IContactRepository contactRepository) : base(log)
        {
            this.contactRepository = contactRepository;
        }

        /// <inheritdoc/>
        public void UpdateFirstAgreementDate(Guid Id, DateTime date)
        {
            try
            {
                var contact = new Contact{Id = Id, nav_date=date};
                contactRepository.Update(contact);
            }
            catch (Exception exc)
            {
                log.Error(exc.ToString());
                throw;
            }
        }
    }
}
