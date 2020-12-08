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
    /// <inheritdoc cref="IInvoiceRepository"/>
    public sealed class InvoiceRepository : GenericRepository<nav_invoice>, IInvoiceRepository
    {
        /// <inheritdoc/>
        public InvoiceRepository(IOrganizationService service) : base(service)
        {
        }
    }
}
