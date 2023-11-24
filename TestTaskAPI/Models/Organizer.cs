using System.ComponentModel.DataAnnotations;

namespace TestTaskAPI.Models
{
	public class Organizer
	{
		[Key]
		public int Id { get; set; }
		[Required]
		public string? FirstName { get; set; }
		[Required]
		public string? SecondName { get; set; }
		[Required]
		public string? ThirdName { get; set; }
		[Required]
		public string? CompanyName { get; set; }
		[Required]
		public string? PhoneNumber { get; set; }
	}
}
