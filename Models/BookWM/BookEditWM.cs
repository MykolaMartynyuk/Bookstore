using Bookstore.Data.DataObjects;
using Bookstore.Services;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Text.RegularExpressions;

namespace Bookstore.Models.BookWM
{
	public class BookEditWM 
	{
		private string _pageTitle = "";
		private IFileUploadService _fileUploadService;
		private Book _bookToShow;
		private Regex _regex = new Regex(@"^(?:ISBN(?:-13)?:?●)?(?=[0-9]{13}$|(?=(?:[0-9]+[-●]){4})[-●0-9]{17}$)↵\r\n97[89][-●]?[0-9]{1,5}[-●]?[0-9]+[-●]?[0-9]+[-●]?[0-9]$");

        public BookEditWM(List<Author> authors, List<Genre> genres)
		{
			Authors = authors;
			Genres = genres;	
			_pageTitle = "New Book";
			NewBook = new Book();
		}

		public BookEditWM()
		{
			_pageTitle = "New Book";
			NewBook = new Book();
			Genres = new List<Genre>();
			Authors = new List<Author>();
		}

		public BookEditWM(Book bookToEdit, List<Author> authors, List<Genre> genres)
		{
			_bookToShow = bookToEdit;
			NewBook = _bookToShow;
			Authors = authors;
			Genres = genres;
			_pageTitle = bookToEdit.Title;
			
		}
		[ValidateNever]
		public Book NewBook { get; set; }

		[ValidateNever]
		public string PageTitle{get => _pageTitle; }

		[Required]
		public int Id { get => NewBook.Id; set => NewBook.Id = value; }

		[ValidateNever]
		public List<Author> Authors { get; set; }

		[ValidateNever]
		public List<Genre> Genres { get; set; }

		[Required]
		public int Author { get => NewBook.AuthorFK; set => NewBook.AuthorFK = value; }

		[Required]
		public int Genre { get => NewBook.GenreId; set=> NewBook.GenreId = value; }

		[Required]
		public string Title { get => NewBook.Title; set => NewBook.Title = value; }

		[Required]
		public double Price { get => NewBook.Price; set => NewBook.Price = value; }
		//[RegularExpression(@"^(?=(?:\D*\d){10}(?:(?:\D*\d){3})?$)[\d-]+$")]
		public string ISBN13 { get => NewBook.ISBN13; set => NewBook.ISBN13 = value; }

		[Required]
		public int Pages { get => NewBook.Pages; set=> NewBook.Id = value; }

		
		public string ImageURL { get => FileToUpload.FileName; set => NewBook.ImageURL = value; }

		[Required]
		public IFormFile FileToUpload { get; set; }



		[Required]
		public Cover Format { get => NewBook.Format; set => NewBook.Format = value; }


	}
}
