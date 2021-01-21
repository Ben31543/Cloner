using System;

namespace ObjectCloner
{
    class Program
    {
        static void Main(string[] args)
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



            Console.WriteLine(user + Environment.NewLine);

            Console.WriteLine(anotherUser);
        }
    }
}
