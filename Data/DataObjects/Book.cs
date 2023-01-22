using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Bookstore.Data.DataObjects
{
    public class Book
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string ISBN13 { get; set; }
        [Required]
        public int Pages { get; set; }
        [Required]
        public Cover Format { get; set; }
        [Required]
        public double Price { get; set; }
        [Required]
        public string ImageURL { get; set; }

        [Required]
        [ForeignKey("AuthorFK")]
        public Author Author { get; set; }
		[Required]
		public int AuthorFK { get; set; }
        [Required]
        public int GenreId { get; set; }
    }

    public enum Cover { Hardcover, Paperback, EBook }
}
