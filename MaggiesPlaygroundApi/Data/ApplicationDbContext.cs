using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MaggiesPlaygroundApi.Models;

namespace MaggiesPlaygroundApi.Data;

public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
{
	public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
		: base(options)
	{
	}

	public DbSet<Client> Clients { get; set; } = null!;
	public DbSet<ClientType> ClientTypes { get; set; } = null!;

	protected override void OnModelCreating(ModelBuilder builder)
	{
		base.OnModelCreating(builder);

		// Configure ApplicationUser
		builder.Entity<ApplicationUser>(entity =>
		{
			entity.Property(e => e.FirstName).HasMaxLength(100);
			entity.Property(e => e.LastName).HasMaxLength(100);
			entity.Property(e => e.CreatedAt).HasDefaultValueSql("CURRENT_TIMESTAMP");
		});

		// Configure Client
		builder.Entity<Client>(entity =>
		{
			entity.Property(e => e.ClientName).HasMaxLength(255);
			entity.Property(e => e.EnteredBy).HasMaxLength(100);
			entity.Property(e => e.CreatedDate).HasDefaultValueSql("CURRENT_TIMESTAMP");
			
			// Add foreign key relationship to ClientType
			entity.HasOne<ClientType>()
				.WithMany()
				.HasForeignKey(c => c.ClientTypeId)
				.OnDelete(DeleteBehavior.Restrict);
		});
		
		// Configure ClientType
		builder.Entity<ClientType>(entity =>
		{
			entity.Property(e => e.Name).HasMaxLength(255);
			entity.Property(e => e.EnteredBy).HasMaxLength(100);
			entity.Property(e => e.CreatedDate).HasDefaultValueSql("CURRENT_TIMESTAMP");
		});
	}
}