using System.ComponentModel.DataAnnotations;
using TestTaskAPI.Dtos.EventStage;
using TestTaskAPI.Dtos.Ogranizer;
using TestTaskAPI.Dtos.Speaker;
using TestTaskAPI.Models;

namespace TestTaskAPI.Dtos
{
	public class EventReadDto
	{
		public int Id { get; set; }
		public string? Topic { get; set; }
		public string? Description { get; set; }
		public DateTime Date { get; set; }
		public string? Location { get; set; }
		public List<OrganizerReadDto> Organizers { get; set; } = new List<OrganizerReadDto>();
		public List<SpeakerReadDto> Speakers { get; set; } = new List<SpeakerReadDto>();
		public List<EventStageReadDto> EventStages { get; set; } = new List<EventStageReadDto>();
	}
}
