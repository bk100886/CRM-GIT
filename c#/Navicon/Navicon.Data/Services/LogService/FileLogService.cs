using Navicon.Core.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Navicon.Data.Services.LogService
{
    /// <summary>
    /// Сервис логирования в файл.
    /// </summary>
    public sealed class FileLogService : ILogService
    {
        /// <inheritdoc/>
        public void Debug(object message)
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc/>
        public void Error(object message)
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc/>
        public void Fatal(object message)
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc/>
        public void Info(object message)
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc/>
        public void Warning(object message)
        {
            throw new NotImplementedException();
        }
    }
}
