using System;

namespace ObjectCloner
{
    public class User
    {
        public int Age { get; set; }

        public string Name { get; set; }

        public Account Account { get; set; }
    }

    public class Account
    {
        public int Id { get; set; }

        public string Nickname { get; set; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var user = new User
            {
                Age = 17,
                Name = "Ben",
                Account = new Account
                {
                    Id = 1,
                    Nickname = "benatanesyan"
                }
            };

            var anotherUser = new User();

            Cloner.GetDeepClone<User>(user, anotherUser);

            user.Age = 40;
            user.Account.Id = 16;

            Console.WriteLine($"user: {user.Age}");
            Console.WriteLine($"newUser: {anotherUser.Age}");

            Console.WriteLine($"user: {user.Account.Id}");
            Console.WriteLine($"newUser: {anotherUser.Account.Id}");
        }
    }
}
