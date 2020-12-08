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
    /// <inheritdoc cref="ICommunicationRepository"/>
    public sealed class CommunicationRepository : GenericRepository<nav_communication>, ICommunicationRepository
    {
        /// <inheritdoc/>
        public CommunicationRepository(IOrganizationService service) : base(service)
        {
        }
    }
}
