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
    /// <inheritdoc cref="ICreditRepository"/>
    public sealed class CreditRepository : GenericRepository<nav_credit>, ICreditRepository
    {
        /// <inheritdoc/>
        public CreditRepository(IOrganizationService service) : base(service)
        {
        }
    }
}
