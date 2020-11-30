using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Tooling.Connector;
using Navicon.Communication.ConsoleApp.Contracts;
using System;

namespace Navicon.Communication.ConsoleApp.Services
{
    /// <inheritdoc cref="IConnectionService"/>
    public sealed class CrmConnectionService : IConnectionService
    {
        private readonly ILoggerService _loggerService;
        /// <summary>
        /// Конструктор.
        /// </summary>
        /// <param name="loggerService">Сервис логирования.</param>
        public CrmConnectionService(ILoggerService loggerService)
        {
            _loggerService = loggerService ?? throw new ArgumentNullException(nameof(loggerService));
        }
        /// <inheritdoc/>
        public IOrganizationService Connect()
        {
            IOrganizationService result = null;
            try
            {
                var connection = System.Configuration.ConfigurationManager.ConnectionStrings["crm"].ConnectionString;
                var client = new CrmServiceClient(connection);
                if (client.LastCrmException == null) result = client;
                else _loggerService.Error(client.LastCrmException);
                
            }
            catch (Exception ex)
            {
                _loggerService.Debug(ex);
            }
            return result;
        }
    }
}
