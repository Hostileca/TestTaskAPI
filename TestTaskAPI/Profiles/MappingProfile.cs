using AutoMapper;
using TestTaskAPI.Dtos;
using TestTaskAPI.Dtos.EventStage;
using TestTaskAPI.Dtos.Ogranizer;
using TestTaskAPI.Dtos.Speaker;
using TestTaskAPI.Models;

namespace TestTaskAPI.Profiles
{
    public class MappingProfile : Profile
	{
		public MappingProfile() 
		{
			CreateMap<Event, EventReadDto>();
			CreateMap<EventCreateDto, Event>();
			CreateMap<EventUpdateDto, Event>();

			CreateMap<Organizer, OrganizerReadDto>();
			CreateMap<OrganizerCreateDto, Organizer>();
			CreateMap<OrganizerUpdateDto, Organizer>();

			CreateMap<Speaker, SpeakerReadDto>();
			CreateMap<SpeakerCreateDto, Speaker>();
			CreateMap<SpeakerUpdateDto, Speaker>();

			CreateMap<EventStage, EventStageReadDto>();
			CreateMap<EventStageCreateDto, EventStage>();
			CreateMap<EventStageUpdateDto, EventStage>();
		}
	}
}
