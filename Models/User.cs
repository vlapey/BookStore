namespace Models
{
    public class User
    {
        public uint Id;
        public string Login;
        public string Password;
        public override string ToString()
        {
            return $"{Id}: {Login}, {Password}";
        }
    }
}