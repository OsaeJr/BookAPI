

namespace BookStoreAPI.Models
{
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; } = String.Empty;
        public string Description { get; set; } = String.Empty;
        public string Author { get; set; } = String.Empty;

    }
}
