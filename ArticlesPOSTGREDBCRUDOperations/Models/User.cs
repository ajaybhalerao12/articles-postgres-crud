using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ArticlesPOSTGREDBCRUDOperations.Models
{
    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [StringLength(20)]
        public required string UserName  { get; set; }

        [Required]
        [StringLength(255)]
        public required string PasswordHash { get; set; }
    }
}
