using System;

namespace WpfApplication42
{
    internal static class Program
    {
        private static void Main()
        {
            // Цикл итерирует тип LogMessage по всем его свойствам, так как используется
            // Метод GetProperties() возвращающий массив PropertyInfo[].
            foreach (var publicPropInfo in typeof(LogMessage).GetProperties())
            {
                Console.WriteLine(publicPropInfo.Name);
            }
        }
    }
}
