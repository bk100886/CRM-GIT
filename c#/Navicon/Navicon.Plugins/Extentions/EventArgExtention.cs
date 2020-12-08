using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Navicon.Plugins.Extentions
{
    /// <summary>
    /// Расширение аргументов событий.
    /// </summary>
    public static class EventArgExtensions
    {
        /// <summary>
        /// Вызвать событие.
        /// </summary>
        /// <typeparam name="TEventArgs">Тип аргумента.</typeparam>
        /// <param name="e">Аргумент.</param>
        /// <param name="sender">Инициатор события.</param>
        /// <param name="eventDelegate">Обработчик события.</param>
        public static void Raise<TEventArgs>(this TEventArgs e,
            Object sender, ref EventHandler<TEventArgs> eventDelegate)
        {
            EventHandler<TEventArgs> temp = Volatile.Read(ref eventDelegate);
            if (temp != null) temp(sender, e);
        }
    }
}
