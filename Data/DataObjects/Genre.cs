using System.ComponentModel.DataAnnotations;

namespace Bookstore.Data.DataObjects
{
    public class Genre
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
    }
}
