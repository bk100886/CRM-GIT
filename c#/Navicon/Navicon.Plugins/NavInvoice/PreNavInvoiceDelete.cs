using Microsoft.Xrm.Sdk;
using Navicon.Core.Entities;
using Navicon.Plugins.NavInvoice.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Navicon.Plugins.NavInvoice
{
    public sealed class PreNavInvoiceDelete:CorePlugin
    {
        public override void Execute(IServiceProvider serviceProvider)
        {
            base.Execute(serviceProvider);
            try
            {
                ConfigurePlugin();
                EntityReference invoceRef = GetEntity<EntityReference>();
                nav_invoice invoice = new nav_invoice { Id = invoceRef.Id };
                var service = new PreNavInvoiceDeleteService(ServiceManager);
                service.RecalcFactSumma(invoice);//Задача 5.3
            }
            catch (Exception exc)
            {
                if (LogService != null) LogService.Error(exc.ToString());
                throw new InvalidPluginExecutionException(exc.Message);
            }

        }
    }
}
