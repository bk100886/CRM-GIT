using Microsoft.Xrm.Sdk;
using Navicon.Core.Entities;
using Navicon.Core.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Navicon.Data.Repositories
{
    /// <inheritdoc cref="IContactRepository"/>
    public sealed class ContactRepository : GenericRepository<Contact>, IContactRepository
    {
        /// <inheritdoc/>
        public ContactRepository(IOrganizationService service) : base(service)
        {
        }
    }
}
