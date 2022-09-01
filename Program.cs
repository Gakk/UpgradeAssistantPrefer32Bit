using System;
using System.Diagnostics;
using System.IO;

namespace UpgradeAssistantPrefer32Bit
{
    class Program
    {
        static void Main(string[] args)
        {
            var array = new byte[100000];
            var memory = new MemoryStream();

            try
            {
                while (true)
                {
                    memory.Write(array, 0, array.Length);
                }
            }
            catch
            {
                Console.WriteLine($"PrivateMemory: {Process.GetCurrentProcess().PrivateMemorySize64:N0}");
            }

            Console.WriteLine("Press any key to exit.");
            Console.ReadKey();
        }
    }
}
