namespace DAA.DP.InputControl
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public static class Input
    {
        internal static int Int32(string phrase)
        {
            Console.WriteLine(phrase);
            ConsoleKeyInfo keyInfo;
            StringBuilder buffer = new StringBuilder(20);
            IList<char> validChars = GetValidChars().ToList();
            while (true)
            {
                keyInfo = Console.ReadKey(true);
                if (validChars.Contains(keyInfo.KeyChar))
                {
                    buffer.Append(keyInfo.KeyChar);
                    ClearConsoleLine();
                    Console.Write(buffer.ToString());
                    continue;
                }
                if (keyInfo.Key == ConsoleKey.Backspace)
                {
                    if (buffer.RemoveLastSymbol())
                    {                        
                        Console.Write(buffer.ToString());
                        continue;
                    }
                }
                if (keyInfo.Key == ConsoleKey.Enter && buffer.IsNotEmpty())
                {
                    break;
                }
                Console.Beep();
            }
            Console.WriteLine();

            return int.Parse(buffer.ToString());
        }

        private static void ClearConsoleLine()
        {
            var str = new string('\b', Console.CursorLeft);
            Console.Write(str);
        }

        public static bool IsEmpty(this StringBuilder StrBuilder)
        {
            return StrBuilder.Length == 0;
        }

        public static bool IsNotEmpty(this StringBuilder StrBuilder)
        {
            return !StrBuilder.IsEmpty();
        }

        public static bool RemoveLastSymbol(this StringBuilder StrBuilder)
        {
            if (StrBuilder.IsNotEmpty())
            {
                StrBuilder.Remove(StrBuilder.Length - 1, 1);
                Console.Clear();
                return true;
            }

            return false;
        }

        private static IEnumerable<char> GetValidChars()
        {
            foreach (var item in "0123456789")
            {
                yield return item;
            }
        }
    }
}
