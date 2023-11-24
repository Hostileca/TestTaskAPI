using System.ComponentModel.DataAnnotations;
using TestTaskAPI.Dtos.EventStage;
using TestTaskAPI.Dtos.Ogranizer;
using TestTaskAPI.Dtos.Speaker;
using TestTaskAPI.Models;

namespace TestTaskAPI.Dtos
{
	public class EventCreateDto
	{
		public string? Topic { get; set; }
		public string? Description { get; set; }
		public DateTime Date { get; set; }
		public string? Location { get; set; }
		public List<OrganizerCreateDto> Organizers { get; set; } = new List<OrganizerCreateDto>();
		public List<SpeakerCreateDto> Speakers { get; set; } = new List<SpeakerCreateDto>();
		public List<EventStageCreateDto> EventStages { get; set; } = new List<EventStageCreateDto>();
	}
}
