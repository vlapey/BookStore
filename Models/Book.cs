namespace Models
{
    public class Book
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
        public int AuthorId { get; set; }
        public Author Author { get; set; }
        public override string ToString()
        {
            return $"{Id}: {Name}, {Price}, {Author}";
        }
    }
}