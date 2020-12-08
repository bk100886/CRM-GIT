using Navicon.Core.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Navicon.Data.Services.LogService
{
    /// <summary>
    /// Логирование без реализации.
    /// Эта реализация будет использоваться по умолчанию в CRUD.
    /// </summary>
    public sealed class EmptyLogService : ILogService
    {
        /// <inheritdoc/>
        public void Debug(object message) { }

        /// <inheritdoc/>
        public void Error(object message) { }

        /// <inheritdoc/>
        public void Fatal(object message) { }

        /// <inheritdoc/>
        public void Info(object message) { }

        /// <inheritdoc/>
        public void Warning(object message) { }
       
    }
}
