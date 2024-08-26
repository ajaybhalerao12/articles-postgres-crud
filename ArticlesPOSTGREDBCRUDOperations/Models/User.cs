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
        public string UserName  { get; set; }
        [Required]
        [StringLength(50)]
        public string Password { get; set; }
    }
}
