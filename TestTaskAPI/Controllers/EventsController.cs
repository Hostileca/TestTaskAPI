using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TestTaskAPI.Data;
using TestTaskAPI.Dtos;
using TestTaskAPI.Models;

namespace TestTaskAPI.Controllers
{
	[Authorize]
	[Route("api/v1/[controller]")]
	[ApiController]
	public class EventsController : ControllerBase
	{
		private readonly IRepo<Event> _eventRepo;
		private readonly IMapper _mapper;

		public EventsController(IRepo<Event> eventRepo, IMapper mapper)
		{
			_eventRepo = eventRepo;
			_mapper = mapper;
		}

		[HttpGet]
		public async Task<ActionResult<IEnumerable<EventReadDto>>> GetAllEvents()
		{
			var events = await _eventRepo.GetAllItems();
			return Ok(_mapper.Map<IEnumerable<EventReadDto>>(events));
		}

		[HttpGet("{id}")]
		public async Task<ActionResult<EventReadDto>> GetEventById(int id)
		{
			var eventModel = await _eventRepo.GetItemById(id);
			if (eventModel != null)
			{
				return Ok(_mapper.Map<EventReadDto>(eventModel));
			}
			return NotFound();
		}

		[HttpPost]
		public async Task<ActionResult<EventReadDto>> CreateEvent(EventCreateDto eventCreateDto)
		{
			var eventModel = _mapper.Map<Event>(eventCreateDto);
			await _eventRepo.CreateItem(eventModel);
			await _eventRepo.SaveChanges();

			return Ok(_mapper.Map<EventReadDto>(eventModel));
		}

		[HttpPut("{id}")]
		public async Task<ActionResult<EventReadDto>> UpdateEvent(int id, EventUpdateDto eventUpdateDto)
		{
			var eventModelFromRepo = _eventRepo.GetItemById(id).Result;
			if (eventModelFromRepo == null)
			{
				return NotFound();
			}

			var organizerToRepo = _mapper.Map(eventUpdateDto, eventModelFromRepo);
			await _eventRepo.SaveChanges();
			return Ok(_mapper.Map<EventReadDto>(organizerToRepo));
		}

		[HttpDelete("{id}")]
		public async Task<ActionResult<EventReadDto>> DeleteEvent(int id)
		{
			var eventModelFromRepo = _eventRepo.GetItemById(id).Result;
			if (eventModelFromRepo == null)
			{
				return NotFound();
			}
			_eventRepo.DeleteItem(eventModelFromRepo);
			await _eventRepo.SaveChanges();
			return Ok(_mapper.Map<EventReadDto>(eventModelFromRepo));
		}


	}
}
