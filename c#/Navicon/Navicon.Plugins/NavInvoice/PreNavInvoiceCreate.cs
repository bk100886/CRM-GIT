using Microsoft.Xrm.Sdk;
using Navicon.Configuration;
using Navicon.Configuration.Interfaces;
using Navicon.Core.Entities;
using Navicon.Core.IServices;
using Navicon.Plugins.Constants;
using Navicon.Plugins.NavInvoice.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Navicon.Plugins.NavInvoice
{
    public sealed class PreNavInvoiceCreate : CorePlugin
    {
        public override void Execute(IServiceProvider serviceProvider)
        {
            base.Execute(serviceProvider);
            try
            {
                ConfigurePlugin();
                nav_invoice invoice = GetEntity<Entity>().ToEntity<nav_invoice>();
                var service = new PreNavInvoiceCreateService(ServiceManager);
                //Задача 5.1
                service.CheckType(invoice);
                //Задача 5.4.1, 5.4.2
                service.CheckAgreementSumCorrect(invoice, PluginExeсute.InvoiceTotalAmountMoreThenAgreementSumma);
            }
            catch (InvalidPluginExecutionException exc)
            {
                LogService.Info(exc.ToString());
                throw;
            }
            catch (Exception exc)
            {
                if (LogService != null) LogService.Error(exc.ToString());
                throw new InvalidPluginExecutionException(exc.Message);
            }
        }
    }
}
