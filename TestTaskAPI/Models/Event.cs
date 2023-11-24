using System.ComponentModel.DataAnnotations;

namespace TestTaskAPI.Models
{
	public class Event
	{
		[Key]
		public int Id { get; set; }
		[Required]	
		public string? Topic { get; set; }
		[Required]
		public string? Description { get; set; }
		[Required]
		public DateTime Date { get; set; }
		[Required]
		public string? Location { get; set; }
		public List<Organizer> Organizers { get; set; } = new List<Organizer>();
		public List<Speaker> Speakers { get; set; } = new List<Speaker>();
		public List<EventStage> EventStages { get; set; } = new List<EventStage>();
	}
}
