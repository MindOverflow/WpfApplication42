using System;
using static System.Console;

namespace WpfApplication42
{
    internal static class Program
    {
        private static void Main()
        {
            // Индикатор номера свойства. 
            int counter = 0;

            // Цикл итерирует тип LogMessage по всем его свойствам, так как используется
            // Метод GetProperties() возвращающий массив PropertyInfo[].
            foreach (var publicPropInfo in typeof(LogMessage).GetProperties())
            {
                counter++;

                // Возьми для свойства геттер (getter или ещё get-метод свойства).
                var getMethod = publicPropInfo.GetGetMethod();

                WriteLine($"{counter})  publicPropInfo.Name = {publicPropInfo.Name}... getMethod.Name = {getMethod.Name}");

                // Если get-метод текущего свойства равен null.
                if (getMethod == null)
                {
                    ForegroundColor = ConsoleColor.DarkRed;
                    WriteLine($"{counter}) {getMethod.Name} равен null");
                }
                
                // Если get-метод текущего свойства публичный.
                if (getMethod.IsPublic)
                {
                    ForegroundColor = ConsoleColor.Green;
                    WriteLine($"{counter}) {getMethod.Name} публичный геттер.");
                }

                // Если get-метод текущего свойства приватный.
                if (getMethod.IsPrivate)
                {
                    ForegroundColor = ConsoleColor.Red;
                    WriteLine($"{counter}) {getMethod.Name} приватный геттер.");
                }

                ForegroundColor = ConsoleColor.Gray;
            }
        }
    }
}
