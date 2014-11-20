namespace DAA.DP.InputControl
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    class Program
    {
        static void Main()
        {
            int value = Input.Int32("Введите число");
            Console.WriteLine("Вы ввели:");
            Console.WriteLine(value);
            Console.ReadLine();
        }
    }
}
