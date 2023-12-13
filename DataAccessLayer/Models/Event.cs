using System.ComponentModel.DataAnnotations;

namespace TestTaskAPI.Models
{
	public class Event
	{
		public int Id { get; set; }
		public string? Topic { get; set; }
		public string? Description { get; set; }
		public DateTime Date { get; set; }
		public string? Location { get; set; }
		public List<Organizer> Organizers { get; set; } = new List<Organizer>();
		public List<Speaker> Speakers { get; set; } = new List<Speaker>();
		public List<EventStage> EventStages { get; set; } = new List<EventStage>();
	}
}
