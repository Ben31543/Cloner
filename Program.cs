using System;
using System.Net.Mime;
using System.Threading;

namespace ObjectCloner
{
    class Program
    {
        private static Mutex mutex = null;
        const string appName = "ObjectCloner";

        static void Main(string[] args)
        {
            bool applicationIsRunning;
            mutex = new Mutex(true, appName, out applicationIsRunning);

            if (applicationIsRunning)
            {
                var user = new User
                {
                    Age = 17,
                    Name = "Ben",
                    Id = 9,
                    Account = new Account
                    {
                        Id = 1,
                        Nickname = "benatanesyan"
                    }
                };

                var anotherUser = Cloner.DeepClone(user);

                user.Age = 40;
                user.Account.Id = 16;


                Console.WriteLine(user);
                Console.WriteLine();
                Console.WriteLine(anotherUser);
                Console.Read();
            }
        }
    }
}
