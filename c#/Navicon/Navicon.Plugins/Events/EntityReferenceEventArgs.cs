using Microsoft.Xrm.Sdk;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Navicon.Plugins.Events
{
    /// <summary>
    /// Аргументы для EntityReference.
    /// </summary>
    public sealed class EntityReferenceEventArgs:BaseEventArgs
    {
        public EntityReference EntityReference { get; set; }
    }
}
