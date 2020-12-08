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
    public sealed class PostNavInvoiceCreate : CorePlugin
    {
        public override void Execute(IServiceProvider serviceProvider)
        {
            base.Execute(serviceProvider);
            try
            {
                ConfigurePlugin();
                nav_invoice invoce = GetEntity<Entity>().ToEntity<nav_invoice>();
                var service = new PostNavInvoiceCreateService(ServiceManager);
                service.RecalcFactSumma(invoce);//Задача 5.3
            }
            catch (Exception exc)
            {
                LogService.Error(exc.ToString());
                throw new InvalidPluginExecutionException(exc.Message);
            }

        }
    }
}