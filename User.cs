namespace ObjectCloner
{
    public class User
    {
        public int Age { get; set; }

        public string Name { get; set; }

        public Account Account { get; set; }

        public int Id;

        public override string ToString()
        {
            return $"{Name}, {Age}, {Account.Id}, {Account.Nickname}";
        }
    }
}
