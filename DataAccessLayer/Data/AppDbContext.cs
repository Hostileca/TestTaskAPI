using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
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

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);

			modelBuilder.Entity<Event>(entity =>
			{
				entity.HasKey(e => e.Id);
				entity.Property(e => e.Topic).IsRequired();
				entity.Property(e => e.Description).IsRequired();
				entity.Property(e => e.Date).IsRequired();
				entity.Property(e => e.Location).IsRequired();
				entity.HasMany(e => e.Organizers).WithOne(o => o.Event).IsRequired();
				entity.HasMany(e => e.Speakers).WithOne(s => s.Event).IsRequired();
				entity.HasMany(e => e.EventStages).WithOne(es => es.Event).IsRequired();
			});

			modelBuilder.Entity<EventStage>(entity =>
			{
				entity.HasKey(es => es.Id);
				entity.Property(es => es.Number).IsRequired();
				entity.Property(es => es.Name).IsRequired();
				entity.Property(es => es.DurationInMinutes).IsRequired();
				entity.HasOne(es => es.Event).WithMany(e => e.EventStages).IsRequired();
			});

			modelBuilder.Entity<Organizer>(entity =>
			{
				entity.HasKey(o => o.Id);
				entity.Property(o => o.FirstName).IsRequired();
				entity.Property(o => o.SecondName).IsRequired();
				entity.Property(o => o.ThirdName).IsRequired();
				entity.Property(o => o.CompanyName).IsRequired();
				entity.Property(o => o.PhoneNumber).IsRequired();
				entity.HasOne(o => o.Event).WithMany(e => e.Organizers).IsRequired();
			});

			modelBuilder.Entity<Speaker>(entity =>
			{
				entity.HasKey(s => s.Id);
				entity.Property(s => s.FirstName).IsRequired();
				entity.Property(s => s.SecondName).IsRequired();
				entity.Property(s => s.ThirdName).IsRequired();
				entity.Property(s => s.PhotoNumber).IsRequired();
				entity.HasOne(s => s.Event).WithMany(e => e.Speakers).IsRequired();
			});
		}
	}
}
