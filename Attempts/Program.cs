using System;
using IIG.PasswordHashingUtils;
using IIG.BinaryFlag;

namespace Attempts
{
    /// <summary>
    /// Sandbox for manual testing
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            MultipleBinaryFlag obj = new MultipleBinaryFlag(2);
            Console.WriteLine(obj.ToString());
        }
    }
}
