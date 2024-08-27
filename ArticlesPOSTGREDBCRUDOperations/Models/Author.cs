namespace ArticlesPOSTGREDBCRUDOperations.Models;

public class Author
{
    public int AuthorId { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public string Bio { get; set; }
    public ICollection<Article> Articles { get; set; }
}