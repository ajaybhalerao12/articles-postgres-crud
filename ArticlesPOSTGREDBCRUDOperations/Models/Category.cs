namespace ArticlesPOSTGREDBCRUDOperations.Models;

public class Category
{
    public int CategoryId { get; set; }
    public string CategoryName { get; set; }
    public ICollection<ArticleCategory> ArticleCategories { get; set; }
}
