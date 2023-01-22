using Microsoft.AspNetCore.Identity;

namespace Bookstore.Data.DataObjects
{
	public class CustomUser : IdentityUser
	{
		[PersonalData]
		public string FirstName { get; set; }
		[PersonalData]
		public string LastName { get; set; }
		[PersonalData]
		public DateTime BirthDate { get; set; }
	}
}
