using Microsoft.Xrm.Sdk;

namespace Navicon.Communication.ConsoleApp.Contracts
{
    /// <summary>
    /// Сервис подключения к CRM.
    /// </summary>
    public interface IConnectionService
    {
        /// <summary>
        /// Выполнить подключение к CRM.
        /// </summary>
        /// <returns>Сервис CRM или null.</returns>
        IOrganizationService Connect();
    }
}
