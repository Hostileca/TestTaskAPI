using System.ComponentModel.DataAnnotations;

namespace TestTaskAPI.Models
{
	public class Speaker
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
		public string? PhotoNumber { get; set; }
		[Required]
		public Event? Event { get; set; }
	}
}
