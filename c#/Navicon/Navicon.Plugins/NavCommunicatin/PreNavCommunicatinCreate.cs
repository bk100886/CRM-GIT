using Microsoft.Xrm.Sdk;
using Navicon.Core.Entities;
using Navicon.Plugins.NavCommunicatin.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Navicon.Plugins.NavCommunicatin
{
    public sealed class PreNavCommunicatinCreate:CorePlugin
    {
        public override void Execute(IServiceProvider serviceProvider)
        {
            base.Execute(serviceProvider);
            try
            {
                ConfigurePlugin();
                nav_communication communication = GetEntity<Entity>().ToEntity<nav_communication>();
                var service = new PreNavCommunicatinCreateService(ServiceManager);
                service.CheckContactHasMainPhone(communication);//Задача 6.1.
                service.CheckContactHasMainEmail(communication);//Задача 6.2
            }
            catch (InvalidPluginExecutionException exc)
            {
                LogService.Info(exc.ToString());
                throw;
            }
            catch (Exception exc)
            {
                LogService.Error(exc.ToString());
                throw new InvalidPluginExecutionException(exc.Message);
            }
        }
    }
}
