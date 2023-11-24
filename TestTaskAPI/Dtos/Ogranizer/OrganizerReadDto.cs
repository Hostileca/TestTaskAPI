using System.ComponentModel.DataAnnotations;
using TestTaskAPI.Models;

namespace TestTaskAPI.Dtos.Ogranizer
{
	public class OrganizerReadDto
	{
		public int Id { get; set; }
		public string? FirstName { get; set; }
		public string? SecondName { get; set; }
		public string? ThirdName { get; set; }
		public string? CompanyName { get; set; }
		public string? PhoneNumber { get; set; }
	}
}
