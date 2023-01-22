namespace Bookstore.Services
{
	public interface IFileUploadService
	{
		public void UploadFileAsync(IFormFile file);
	}
}
