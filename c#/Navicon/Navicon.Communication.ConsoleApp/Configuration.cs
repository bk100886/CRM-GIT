using Navicon.Communication.ConsoleApp.Contracts;
using Navicon.Communication.ConsoleApp.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Navicon.Communication.ConsoleApp
{
    static class Configuration
    {
      
        ///// <summary>
        ///// Сконфигурировать сервисы.
        ///// </summary>
        ///// <param name="library">Библиотека сервисов.</param>
        //public static void ConfigureServices(ref IServiceLibrary lib)
        //{
        //    lib =(IServiceLibrary) new Object();
        //    lib.LoggerService = new LoggerService();
        //    lib.ConnectionService = new ConnectionService(lib.LoggerService);
        //}
        /// <summary>
        /// Сконфигурировать протокол TLS12
        /// </summary>
        public static void ConfigureTLS12()
        {
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
        }    
        /// <summary>
        /// Сконфигурировать консоль.
        /// </summary>
        public static void ConfigureConsole()
        {
            Console.OutputEncoding = Encoding.UTF8;
        }
    }
}
