using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using TestTaskAPI.Models;

namespace TestTaskAPI.Data
{
	public class AppDbContext : IdentityDbContext<IdentityUser>
	{
		public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

		public DbSet<Event> Events => Set<Event>();
		public DbSet<Speaker> Speakers => Set<Speaker>();
		public DbSet<Organizer> Organizers => Set<Organizer>();
		public DbSet<EventStage> EventStages => Set<EventStage>();
	}
}
