using System.ComponentModel.DataAnnotations;

namespace TestTaskAPI.Models
{
	public class Speaker
	{
		public int Id { get; set; }
		public string? FirstName { get; set; }
		public string? SecondName { get; set; }
		public string? ThirdName { get; set; }
		public string? PhotoNumber { get; set; }
		public Event? Event { get; set; }
	}
}
