using System;
using IIG.PasswordHashingUtils;

namespace Attempts
{
    /// <summary>
    /// Sandbox for manual testing
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            PasswordHasher hasher = new PasswordHasher();
            PasswordHasher.Init("dsad", 32);
            string res = PasswordHasher.GetHash("genji");
            PasswordHasher.Init("dsad", 33);
            PasswordHasher.Init("dsa", 32);
            string res1 = PasswordHasher.GetHash("genji");
            Console.WriteLine(res);
            Console.WriteLine(res1);
        }
    }
}
