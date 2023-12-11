using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TestTaskAPI.Dtos;
using TestTaskAPI.Services;

namespace TestTaskAPI.Controllers
{
	[Authorize]
	[Route("api/v1/events")]
	[ApiController]
	public class EventsController : ControllerBase
	{
		private readonly IEventService _eventService;

		public EventsController(IEventService eventService)
		{
			_eventService = eventService;
		}

		[HttpGet]
		public async Task<Response<IEnumerable<EventReadDto>>> GetAllEvents()
		{
			var events = await _eventService.GetAllEvents();
			return events;
		}

		[HttpGet("{id}")]
		public async Task<Response<EventReadDto>> GetEventById(int id)
		{
			var @event = await _eventService.GetEventById(id);
			return @event;
		}

		[HttpPost]
		public async Task<ActionResult<Response<EventReadDto>>> CreateEvent(EventCreateDto eventCreateDto)
		{
			var eventReadDto = await _eventService.CreateEvent(eventCreateDto);
			return eventReadDto;
		}

		[HttpPut("{id}")]
		public async Task<ActionResult<Response<EventReadDto>>> UpdateEvent(int id, EventUpdateDto eventUpdateDto)
		{
			var eventReadDto = await _eventService.UpdateEvent(id, eventUpdateDto);
			return eventReadDto;
		}

		[HttpDelete("{id}")]
		public async Task<ActionResult<Response<EventReadDto>>> DeleteEvent(int id)
		{
			var eventReadDto = await _eventService.DeleteEvent(id);
			return eventReadDto;
		}
	}
}
