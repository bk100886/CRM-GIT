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
    /// <inheritdoc cref="IAutoRepository"/>
    public sealed class AutoRepository : GenericRepository<nav_auto>, IAutoRepository
    {
        /// <inheritdoc/>
        public AutoRepository(IOrganizationService service) : base(service)
        {
        }
    }
}
