using System.ComponentModel.DataAnnotations;

namespace TestTaskAPI.Dtos.EventStage
{
	public class EventStageReadDto
	{
		public int Number { get; set; }
		public string Name { get; set; }
		public float DurationInMinutes { get; set; }
	}
}
