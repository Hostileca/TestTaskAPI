using System.ComponentModel.DataAnnotations;
using TestTaskAPI.Dtos.EventStage;
using TestTaskAPI.Dtos.Ogranizer;
using TestTaskAPI.Dtos.Speaker;
using TestTaskAPI.Models;

namespace TestTaskAPI.Dtos
{
	public class EventUpdateDto
	{
		public string? Topic { get; set; }
		public string? Description { get; set; }
		public DateTime Date { get; set; }
		public string? Location { get; set; }
		public List<OrganizerUpdateDto> Organizers { get; set; } = new List<OrganizerUpdateDto>();
		public List<SpeakerUpdateDto> Speakers { get; set; } = new List<SpeakerUpdateDto>();
		public List<EventStageUpdateDto> EventStages { get; set; } = new List<EventStageUpdateDto>();
	}
}
