using System.ComponentModel.DataAnnotations;

namespace TestTaskAPI.Dtos.Speaker
{
	public class SpeakerCreateDto
	{
		public string? FirstName { get; set; }
		public string? SecondName { get; set; }
		public string? ThirdName { get; set; }
		public string? PhotoNumber { get; set; }
	}
}
