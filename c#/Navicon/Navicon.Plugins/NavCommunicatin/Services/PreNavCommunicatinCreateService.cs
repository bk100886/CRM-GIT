using Microsoft.Xrm.Sdk;
using Navicon.Configuration.Interfaces;
using Navicon.Core.Entities;
using Navicon.Core.IServices;
using Navicon.Plugins.Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Navicon.Plugins.NavCommunicatin.Services
{
    public sealed class PreNavCommunicatinCreateService : BaseService
    {
        public PreNavCommunicatinCreateService(IServiceManager manager) : base(manager)
        {
        }

        /// <summary>
        /// Для объекта Средство связи реализовать логику, которая позволяет иметь только один объект Средство связи для контакта с Типом=Телефон и Основной=Да. 
        /// </summary>
        /// <param name="communication">Средство связи.</param>
        public void CheckContactHasMainPhone(nav_communication communication)
        {
            ICommunicationService communicationService = manager.GetService<ICommunicationService>();
            ILogService logService = manager.GetService<ILogService>();
            if (communication.nav_contactid != null
                && communication.nav_main == true
                && communication.nav_type == nav_communication_nav_type.Telefon)
                if (communicationService.HasMainCommunication(communication.nav_contactid.Id, nav_communication_nav_type.Telefon))
                    throw new InvalidPluginExecutionException(PluginExeсute.ContactHasMainPhone);                   
        }

        /// <summary>
        /// Реализовать логику, которая позволяет иметь только один объект Средство связи для организации с Типом=E-mail и Основной=Да 
        /// </summary>
        /// <param name="communication">Средство связи.</param>
        public void CheckContactHasMainEmail(nav_communication communication)
        {
            ICommunicationService communicationService = manager.GetService<ICommunicationService>();
            ILogService logService = manager.GetService<ILogService>();
            if (communication.nav_contactid != null
                && communication.nav_main == true
                && communication.nav_type == nav_communication_nav_type.E_mail)
                if (communicationService.HasMainCommunication(communication.nav_contactid.Id, nav_communication_nav_type.E_mail))
                    throw new InvalidPluginExecutionException(PluginExeсute.ContactHasMainMail);
        }
    }
}
