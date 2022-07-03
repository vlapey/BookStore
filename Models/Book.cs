namespace Models
{
    public class Book
    {
        public uint Id;
        public string Name { get; set; }
        public int Price { get; set; }
        public Author Author { get; set; }
        public override string ToString()
        {
            return $"{Id}: {Name}, {Price}, {Author}";
        }
    }
}