using System;
using System.Collections.Generic;
using static System.Console;

namespace WpfApplication42
{
    internal static class Program
    {
        private static void Main()
        {
            // Словарь, в котором в качестве ключа хранится строковое представление 
            // имени свойств класса LogMessage, все буквы в нижнем регистре.
            // В качестве значения словаря хранится результат возвращаемого свойством
            // объекта.

            // Альтернативные способы задать один и тот же словарь. Считаю, что мой более правильный.
            // var namedValues = new Dictionary<string, Func<LogMessage, object>>();
            var namedValues = new Dictionary<string, object>();


            // Индикатор номера свойства, реализованный ввиде свойства. 
            var counter = 0;

            // Цикл итерирует тип LogMessage по всем его свойствам, так как используется
            // Метод GetProperties() возвращающий массив PropertyInfo[].
            foreach (var publicPropInfo in typeof(LogMessage).GetProperties())
            {
                counter++;

                // Возьми для свойства геттер (getter или ещё get-метод свойства).
                var getMethod = publicPropInfo.GetGetMethod();

                // Если get-метод текущего свойства равен null или он не публичный:
                if (getMethod == null || getMethod.IsPublic == false)
                {
                    continue; // Перейти к новой итерации, при выполнении данных условий.
                }

                WriteLine($"{counter})  publicPropInfo.Name.ToLower() = {publicPropInfo.Name.ToLower()}");
                WriteLine(
                    $"{counter})  publicPropInfo.Name = {publicPropInfo.Name}... getMethod.Name = {getMethod.Name}");

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

                // Добавление в словарь.

                // Имя свойства класса LogMessage в нижнем регистре.
                var propertyName = publicPropInfo.Name.ToLower();

                // Поскольку у свойств нет параметров, поэтому в метод Invoke каждого свойства
                // в качестве массива параметров передаётся null. 
                // Строка getMethod.Invoke(message, null) по сути означает:
                // вызвать свойство, хранимое в getMethod для объекта типа LogMessage. 

                // Func<LogMessage, object> - это по сути делегат:
                // public delegate TResult Func<in T, out TResult>(T arg).
                Func<LogMessage, object> functor = (message) =>
                {
                    return getMethod.Invoke(message, null);
                };

                namedValues.Add(propertyName, functor);
            }
        }
    }
}
