namespace Models
{
    public class Author
    {
        public uint Id;
        public string Name;
        public override string ToString()
        {
            return $"{Id}: {Name}";
        }
    }
}