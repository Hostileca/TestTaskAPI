using System.ComponentModel.DataAnnotations;

namespace TestTaskAPI.Models
{
	public class EventStage
	{
		[Key]
		public int Id { get; set; }
		[Required]
		public int Number { get; set; }
		[Required]
		public string Name { get; set; }
		[Required]
		public float DurationInMinutes { get; set; }
		[Required]
		public Event? Event { get; set; }
	}
}
