using TestTaskAPI.Dtos;

namespace TestTaskAPI.Services
{
	public interface IEventService
	{
		Task<Response<IEnumerable<EventReadDto>>> GetAllEvents();
		Task<Response<EventReadDto>> GetEventById(int id);
		Task<Response<EventReadDto>> CreateEvent(EventCreateDto eventCreateDto);
		Task<Response<EventReadDto>> UpdateEvent(int id, EventUpdateDto eventUpdateDto);
		Task<Response<EventReadDto>> DeleteEvent(int id);
	}
}
