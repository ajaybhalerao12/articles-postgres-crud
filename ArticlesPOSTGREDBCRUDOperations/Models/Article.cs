using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ArticlesPOSTGREDBCRUDOperations.Models;

public class Article
{

    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    [Required]
    [StringLength(20)]
    public string Title { get; set; }

    [Required]
    [StringLength(50)]
    public string Content { get; set; }
    
    public DateTime CreatedAt { get; set; }
}
