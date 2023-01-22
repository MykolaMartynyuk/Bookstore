using IHostingEnvironment = Microsoft.AspNetCore.Hosting.IHostingEnvironment;

namespace Bookstore.Services
{
	public class FileUploadService : IFileUploadService
	{
		private IHostingEnvironment _enviroment;

		public FileUploadService(IHostingEnvironment environment)
		{
			this._enviroment = environment;
		}

		public async void UploadFileAsync(IFormFile file)
		{
			var filePath = Path.Combine(_enviroment.ContentRootPath, @"wwwroot\img", file.FileName);
			using var fileStream = new FileStream(filePath, FileMode.Create);
			await file.CopyToAsync(fileStream);

		
		}
	}
}
