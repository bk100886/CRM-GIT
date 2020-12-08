using Microsoft.Xrm.Sdk;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Navicon.Plugins.Events
{
    /// <summary>
    /// Аргументы для Entity.
    /// </summary>
    public sealed class EntityEventArgs:BaseEventArgs
    {
        /// <summary>
        /// Entity.
        /// </summary>
        public Entity Entity { get; set; }
        
    }
}
