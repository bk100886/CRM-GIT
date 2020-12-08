using Microsoft.Xrm.Sdk;
using Navicon.Core.Entities;
using Navicon.Plugins.NavAgreement.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Navicon.Plugins.NavAgreement
{
    public sealed class PreNavAgreementUpdate:CorePlugin
    {
        public override void Execute(IServiceProvider serviceProvider)
        {
            base.Execute(serviceProvider);
            try
            {
                ConfigurePlugin();
                nav_agreement agreement = GetEntity<Entity>().ToEntity<nav_agreement>();
                var service = new PreNavAgreementUpdateService(ServiceManager);
                //Задача 5.5
                service.SetAgreementPayed(agreement);
            }
            catch (Exception exc)
            {
                LogService.Error(exc.ToString());
                throw new InvalidPluginExecutionException(exc.Message);
            }
        }
    }
}
