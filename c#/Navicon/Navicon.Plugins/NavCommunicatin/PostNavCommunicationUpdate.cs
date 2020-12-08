using Microsoft.Xrm.Sdk;
using Navicon.Core.Entities;
using Navicon.Plugins.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Navicon.Plugins.NavCommunicatin
{
    public sealed class PostNavCommunicationUpdate:CorePlugin
    {
        public override void Execute(IServiceProvider serviceProvider)
        {
            base.Execute(serviceProvider);
            try
            {
                
                
               
                
                
            }
            catch (Exception exc)
            {
                if (LogService != null) LogService.Error(exc.ToString());
                throw new InvalidPluginExecutionException(exc.Message);
            }

        }
    }
}
