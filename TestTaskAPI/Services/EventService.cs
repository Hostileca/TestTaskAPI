using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TestTaskAPI.Data;
using TestTaskAPI.Dtos;
using TestTaskAPI.Dtos.User;
using TestTaskAPI.Models;

namespace TestTaskAPI.Services
{
	public class EventService : IEventService
	{
		private readonly IRepo<Event> _eventRepo;
		private readonly IMapper _mapper;

		public EventService(IRepo<Event> eventRepo, IMapper mapper)
		{
			_eventRepo = eventRepo;
			_mapper = mapper;
		}

		public async Task<Response<EventReadDto>> CreateEvent(EventCreateDto eventCreateDto)
		{
			var eventModel = _mapper.Map<Event>(eventCreateDto);
			try
			{
				await _eventRepo.CreateItem(eventModel);
				await _eventRepo.SaveChanges();
			}
			catch (Exception ex)
			{
				return new Response<EventReadDto>($"Error adding to database: {ex.Message}");
			}
			return new Response<EventReadDto>(_mapper.Map<EventReadDto>(eventModel));
		}

		public async Task<Response<EventReadDto>> DeleteEvent(int id)
		{
			var eventModelFromRepo = await _eventRepo.GetItemById(id);
			if (eventModelFromRepo == null)
			{
				return new Response<EventReadDto>($"Event not found with id:{id}");
			}
			try
			{
				_eventRepo.DeleteItem(eventModelFromRepo);
				await _eventRepo.SaveChanges();
			}
			catch (Exception ex)
			{
				return new Response<EventReadDto>($"Error deleting to database: {ex.Message}");
			}
			return new Response<EventReadDto>(_mapper.Map<EventReadDto>(eventModelFromRepo));
		}

		public async Task<Response<IEnumerable<EventReadDto>>> GetAllEvents()
		{
			var events = await _eventRepo.GetAllItems();
			return new Response<IEnumerable<EventReadDto>>(_mapper.Map<IEnumerable<EventReadDto>>(events));
		}

		public async Task<Response<EventReadDto>> GetEventById(int id)
		{
			var eventModel = await _eventRepo.GetItemById(id);
			if (eventModel == null)
			{
				return new Response<EventReadDto>($"Event not found with id:{id}");
			}
			return new Response<EventReadDto>(_mapper.Map<EventReadDto>(eventModel));
		}

		public async Task<Response<EventReadDto>> UpdateEvent(int id, EventUpdateDto eventUpdateDto)
		{
			var eventModelFromRepo = _eventRepo.GetItemById(id).Result;
			if (eventModelFromRepo == null)
			{
				return new Response<EventReadDto>($"Event not found with id:{id}");
			}

			var organizerToRepo = _mapper.Map(eventUpdateDto, eventModelFromRepo);
			try
			{
				await _eventRepo.SaveChanges();
			}
			catch (Exception ex)
			{
				return new Response<EventReadDto>($"Error updating to database: {ex.Message}");
			}
			return new Response<EventReadDto>(_mapper.Map<EventReadDto>(organizerToRepo));
		}
	}
}
