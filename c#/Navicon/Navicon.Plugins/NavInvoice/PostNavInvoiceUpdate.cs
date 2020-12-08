using Microsoft.Xrm.Sdk;
using Navicon.Core.Entities;
using Navicon.Plugins.Constants;
using Navicon.Plugins.NavInvoice.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Navicon.Plugins.NavInvoice
{
    public sealed class PostNavInvoiceUpdate:CorePlugin
    {
        public override void Execute(IServiceProvider serviceProvider)
        {
            base.Execute(serviceProvider);
            try
            {
                ConfigurePlugin();
                nav_invoice invoice = GetEntity<Entity>().ToEntity<nav_invoice>();
                var service = new PostNavInvoiceUpdateService(ServiceManager);
                //Задача 5.3
                service.RecalcFactSumma(invoice);
            }
            catch (Exception exc)
            {
                if (LogService != null) LogService.Error(exc.ToString());
                throw new InvalidPluginExecutionException(exc.Message);
            }

        }
    }
}
