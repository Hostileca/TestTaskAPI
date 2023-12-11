using System.ComponentModel.DataAnnotations;

namespace TestTaskAPI.Models
{
	public class Organizer
	{
		public int Id { get; set; }
		public string? FirstName { get; set; }
		public string? SecondName { get; set; }
		public string? ThirdName { get; set; }
		public string? CompanyName { get; set; }
		public string? PhoneNumber { get; set; }
		public Event? Event { get; set; }
	}
}
