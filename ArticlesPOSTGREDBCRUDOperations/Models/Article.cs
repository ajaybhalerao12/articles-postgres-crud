using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ArticlesPOSTGREDBCRUDOperations.Models;

public class Article
{

    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    [Required]
    [StringLength(100)]
    public string Title { get; set; }

    [Required]
    [StringLength(255)]
    public string Content { get; set; }
    
    public DateTime CreatedAt { get; set; }
    
    public int AuthorId { get; set; }

    public Author Author { get; set; }

    public ICollection<ArticleCategory> ArticleCategories { get; set; }
}
