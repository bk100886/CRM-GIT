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
    /// <inheritdoc cref="IAgreementRepository"/>
    public sealed class AgreementRepository : GenericRepository<nav_agreement>, IAgreementRepository
    {
        /// <inheritdoc/>
        public AgreementRepository(IOrganizationService service) : base(service)
        {
        }
    }
}
