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
    /// <inheritdoc cref="IModelRepository"/>
    public sealed class ModelRepository : GenericRepository<nav_model>, IModelRepository
    {
        /// <inheritdoc/>
        public ModelRepository(IOrganizationService service) : base(service)
        {
        }
    }
}
