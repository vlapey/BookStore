namespace Models
{
    public class Author
    {
        public uint Id { get; set; }
        public string Name { get; set; }
        public override string ToString()
        {
            return $"{Id}: {Name}";
        }
    }
}