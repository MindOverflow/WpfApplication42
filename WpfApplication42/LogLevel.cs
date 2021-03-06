﻿namespace WpfApplication42
{
    /// <summary>
    /// Определяет уровень трудности сообщения, записываемого в журнал.
    /// Чем больше значение, тем более суровый уровень сообщения.
    /// </summary>
    public enum LogLevel
    {
        // Сообщение не представляет никакой трудности.
        Off = 0,
        // Сообщения с таким уровнем пишутся для отладки.
        Debug = 1,
        // Сообщения с таким уровнем носят информационный характер.
        Info = 2,
        // Сообщения с таким уровнем носят характер предупрежденения
        // о потенциальной опасности.
        Warn = 3,
        // Сообщения с таким уровнем сложности свидетельствуют
        // о ошибке, возникшей в ходе выполнения программы.
        Error = 4,
        // Сообщения с таким уровнем являются фатальными,
        // то есть приводят к фатальному падению приложения.
        Fatal = 5
    }
}
