using System.ComponentModel.DataAnnotations;

namespace TestTaskAPI.Models
{
	public class EventStage
	{
		public int Id { get; set; }
		public int Number { get; set; }
		public string Name { get; set; }
		public float DurationInMinutes { get; set; }
		public Event? Event { get; set; }
	}
}
