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
    /// <inheritdoc cref="IBrandRepository"/>
    public sealed class BrandRepository : GenericRepository<nav_brand>, IBrandRepository
    {
        /// <inheritdoc/>
        public BrandRepository(IOrganizationService service) : base(service)
        {
        }
    }
}
