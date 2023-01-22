using Bookstore.Data.DataObjects;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;

namespace Bookstore.Models.AuthorWM
{
    public class AuthorEditWM
    {
        private Author _authorToShow;

       

        public AuthorEditWM(Author author)
        {
            _authorToShow = author;
			NewAuthor = _authorToShow;
			PageTitle = "Edit Author";
			
        }

		public AuthorEditWM()
		{
			PageTitle = "Add Author";
			NewAuthor = new Author();
		}

        [ValidateNever]
		public Author NewAuthor { get; set; }

		public string PageTitle { get; }

		[Required]
		public int Id { get => NewAuthor.Id; set => NewAuthor.Id = value; }

        [Required]
        public string FirstName { get => NewAuthor.FirstName; set => NewAuthor.FirstName = value; }

		[Required]
		public string LastName { get => NewAuthor.LastName; set => NewAuthor.LastName = value; }

        [Required]
        public DateTime BirthDay { get => NewAuthor.BirthDate; set => NewAuthor.BirthDate = value; }
	}
}
