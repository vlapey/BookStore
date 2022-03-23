

namespace BookStore
{
    public class User
    {
        public uint id;
        public string Login;
        public string Password;

        public override string ToString()
        {
            return $"{Login}, {Password}";
        }
    }
}