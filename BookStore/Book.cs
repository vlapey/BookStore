namespace BookStore
{
    public class Book
    {
        public string Name { get; set; }
        public int Price { get; set; }

        public override string ToString()
        {
            string str = $"Book name is {Name}, and price is {Price}";
            return str;
        }
    }
}