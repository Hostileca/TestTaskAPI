using Microsoft.EntityFrameworkCore;
using TestTaskAPI.Models;

namespace TestTaskAPI.Data
{
	public class EventRepo : IRepo<Event>
	{
		private readonly AppDbContext _context;
		public EventRepo(AppDbContext context) 
		{
			_context = context;
		}

		public async Task CreateItem(Event item)
		{
			await _context.Events.AddAsync(item);
		}

		public void DeleteItem(Event item)
		{
			_context.Events.Remove(item);
		}

		public async Task<Event?> GetItemById(int id)
		{
			return await _context.Events.Include(e => e.Speakers)
										.Include(e => e.Organizers)
										.Include(e => e.EventStages)
										.FirstOrDefaultAsync(e => e.Id == id);
		}

		public async Task SaveChanges()
		{
			await _context.SaveChangesAsync();
		}

		public async Task<IEnumerable<Event>> GetAllItems()
		{
			return await _context.Events.Include(e=>e.Speakers)
										.Include(e=>e.Organizers)
										.Include(e=>e.EventStages).ToListAsync();
		}
	}
}
