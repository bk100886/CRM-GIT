using Microsoft.Xrm.Sdk;
using Navicon.Core.Entities;
using Navicon.Core.IServices;
using Navicon.Plugins.NavAgreement.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Navicon.Plugins.NavAgreement
{
    public sealed class PreNavAgreementCreate:CorePlugin
    {
        public override void Execute(IServiceProvider serviceProvider)
        {
            base.Execute(serviceProvider);
            try
            {
                ConfigurePlugin();
                nav_agreement agreement = GetEntity<Entity>().ToEntity<nav_agreement>();
                var service = new PreNavAgreementCreateService(ServiceManager);
                service.FillContactFirstAgreementDate(agreement);//Задача 5.2
            }
            catch (Exception exc)
            {
                if (LogService != null) LogService.Error(exc.ToString());
                throw new InvalidPluginExecutionException(exc.Message);
            }
        }
    }
}
