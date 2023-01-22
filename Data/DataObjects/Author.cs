using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Bookstore.Data.DataObjects
{
    public class Author
    {
        [Required]
        public DateTime BirthDate { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Key]
        public int Id { get; set; }

        [NotMapped]
        public ICollection<Book> Book { get; set; }
    }
}
