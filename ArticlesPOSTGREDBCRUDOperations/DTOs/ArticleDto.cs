using Microsoft.VisualBasic;

namespace ArticlesPOSTGREDBCRUDOperations.DTOs
{
    //public class ArticleDto
    //{
    //    public int Id { get; set; }
    //    public string Title { get; set; }
    //    public string Content { get; set; }
    //    public DateTime CreatedAt { get; set; }
    //    public AuthorDto Author { get; set; }

    //}

    public class ArticleDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime CreatedAt { get; set; }
        public int AuthorId { get; set; }
        public string AuthorName { get; set; } // Assuming you want to include the author's name
        public List<string> Categories { get; set; } // Assuming you want to include category names
    }
}
