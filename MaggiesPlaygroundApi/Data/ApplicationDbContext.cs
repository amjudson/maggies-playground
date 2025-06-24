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
	public DbSet<Race> Races { get; set; } = null!;
	public DbSet<Gender> Genders { get; set; } = null!;
	public DbSet<PersonType> PersonTypes { get; set; } = null!;
	public DbSet<Person> People { get; set; } = null!;
	public DbSet<AddressType> AddressTypes { get; set; } = null!;
	public DbSet<Address> Addresses { get; set; } = null!;
	public DbSet<PhoneType> PhoneTypes { get; set; } = null!;
	public DbSet<Phone> Phones { get; set; } = null!;
	public DbSet<EmailType> EmailTypes { get; set; } = null!;
	public DbSet<Email> Emails { get; set; } = null!;
	public DbSet<State> States { get; set; } = null!;
	
	// Lookup tables for Client associations
	public DbSet<ClientAddress> ClientAddresses { get; set; } = null!;
	public DbSet<ClientPhone> ClientPhones { get; set; } = null!;
	public DbSet<ClientEmail> ClientEmails { get; set; } = null!;
	
	// Lookup tables for Person associations
	public DbSet<PersonAddress> PersonAddresses { get; set; } = null!;
	public DbSet<PersonPhone> PersonPhones { get; set; } = null!;
	public DbSet<PersonEmail> PersonEmails { get; set; } = null!;

	protected override void OnModelCreating(ModelBuilder builder)
	{
		base.OnModelCreating(builder);

		var seedDate = new DateTime(2024, 1, 1, 0, 0, 0, DateTimeKind.Utc);

		// Configure ApplicationUser
		builder.Entity<ApplicationUser>(entity =>
		{
			entity.Property(e => e.FirstName).HasMaxLength(100);
			entity.Property(e => e.LastName).HasMaxLength(100);
			entity.Property(e => e.CreatedAt).HasDefaultValueSql("CURRENT_TIMESTAMP");
		});

		// Configure ClientType
		builder.Entity<ClientType>(entity =>
		{
			entity.Property(e => e.Name).HasMaxLength(255);
			entity.Property(e => e.EnteredBy).HasMaxLength(100);
			entity.Property(e => e.CreatedDate).HasDefaultValueSql("CURRENT_TIMESTAMP");

			entity.HasData(
				new ClientType { ClientTypeId = 1, Name = "Corporate", Active = true, CreatedDate = seedDate, EnteredBy = "System" },
				new ClientType { ClientTypeId = 2, Name = "Small Business", Active = true, CreatedDate = seedDate, EnteredBy = "System" },
				new ClientType { ClientTypeId = 3, Name = "Startup", Active = true, CreatedDate = seedDate, EnteredBy = "System" },
				new ClientType { ClientTypeId = 4, Name = "Non-Profit", Active = true, CreatedDate = seedDate, EnteredBy = "System" },
				new ClientType { ClientTypeId = 5, Name = "Government", Active = true, CreatedDate = seedDate, EnteredBy = "System" }
			);
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

			entity.HasData(
				new Client { ClientId = Guid.Parse("00000000-0000-0000-0000-000000000001"), ClientName = "Acme Corporation", Active = true, ClientTypeId = 1, CreatedDate = seedDate, EnteredBy = "System" },
				new Client { ClientId = Guid.Parse("00000000-0000-0000-0000-000000000002"), ClientName = "TechStart Inc", Active = true, ClientTypeId = 3, CreatedDate = seedDate, EnteredBy = "System" },
				new Client { ClientId = Guid.Parse("00000000-0000-0000-0000-000000000003"), ClientName = "Local Bakery", Active = true, ClientTypeId = 2, CreatedDate = seedDate, EnteredBy = "System" },
				new Client { ClientId = Guid.Parse("00000000-0000-0000-0000-000000000004"), ClientName = "City Health Department", Active = true, ClientTypeId = 5, CreatedDate = seedDate, EnteredBy = "System" },
				new Client { ClientId = Guid.Parse("00000000-0000-0000-0000-000000000005"), ClientName = "Green Earth Foundation", Active = true, ClientTypeId = 4, CreatedDate = seedDate, EnteredBy = "System" },
				new Client { ClientId = Guid.Parse("00000000-0000-0000-0000-000000000006"), ClientName = "Global Industries", Active = true, ClientTypeId = 1, CreatedDate = seedDate, EnteredBy = "System" },
				new Client { ClientId = Guid.Parse("00000000-0000-0000-0000-000000000007"), ClientName = "Innovate Labs", Active = true, ClientTypeId = 3, CreatedDate = seedDate, EnteredBy = "System" },
				new Client { ClientId = Guid.Parse("00000000-0000-0000-0000-000000000008"), ClientName = "Family Restaurant", Active = true, ClientTypeId = 2, CreatedDate = seedDate, EnteredBy = "System" },
				new Client { ClientId = Guid.Parse("00000000-0000-0000-0000-000000000009"), ClientName = "County Education Board", Active = true, ClientTypeId = 5, CreatedDate = seedDate, EnteredBy = "System" },
				new Client { ClientId = Guid.Parse("00000000-0000-0000-0000-000000000010"), ClientName = "Community Outreach", Active = true, ClientTypeId = 4, CreatedDate = seedDate, EnteredBy = "System" },
				new Client { ClientId = Guid.Parse("00000000-0000-0000-0000-000000000011"), ClientName = "MegaCorp International", Active = true, ClientTypeId = 1, CreatedDate = seedDate, EnteredBy = "System" },
				new Client { ClientId = Guid.Parse("00000000-0000-0000-0000-000000000012"), ClientName = "Future Tech", Active = true, ClientTypeId = 3, CreatedDate = seedDate, EnteredBy = "System" },
				new Client { ClientId = Guid.Parse("00000000-0000-0000-0000-000000000013"), ClientName = "Neighborhood Cafe", Active = true, ClientTypeId = 2, CreatedDate = seedDate, EnteredBy = "System" },
				new Client { ClientId = Guid.Parse("00000000-0000-0000-0000-000000000014"), ClientName = "State Transportation", Active = true, ClientTypeId = 5, CreatedDate = seedDate, EnteredBy = "System" },
				new Client { ClientId = Guid.Parse("00000000-0000-0000-0000-000000000015"), ClientName = "Youth Development", Active = true, ClientTypeId = 4, CreatedDate = seedDate, EnteredBy = "System" },
				new Client { ClientId = Guid.Parse("00000000-0000-0000-0000-000000000016"), ClientName = "Enterprise Solutions", Active = true, ClientTypeId = 1, CreatedDate = seedDate, EnteredBy = "System" },
				new Client { ClientId = Guid.Parse("00000000-0000-0000-0000-000000000017"), ClientName = "NextGen Innovations", Active = true, ClientTypeId = 3, CreatedDate = seedDate, EnteredBy = "System" },
				new Client { ClientId = Guid.Parse("00000000-0000-0000-0000-000000000018"), ClientName = "Artisan Crafts", Active = true, ClientTypeId = 2, CreatedDate = seedDate, EnteredBy = "System" },
				new Client { ClientId = Guid.Parse("00000000-0000-0000-0000-000000000019"), ClientName = "Public Safety", Active = true, ClientTypeId = 5, CreatedDate = seedDate, EnteredBy = "System" },
				new Client { ClientId = Guid.Parse("00000000-0000-0000-0000-000000000020"), ClientName = "Cultural Heritage", Active = true, ClientTypeId = 4, CreatedDate = seedDate, EnteredBy = "System" }
			);
		});
		
		// Configure Race
		builder.Entity<Race>(entity =>
		{
			entity.Property(e => e.Name).HasMaxLength(255);
			entity.Property(e => e.Description).HasMaxLength(255);
			entity.Property(e => e.EnteredBy).HasMaxLength(100);
			entity.Property(e => e.CreatedDate).HasDefaultValueSql("CURRENT_TIMESTAMP");

			entity.HasData(
				new Race { RaceId = 1, Name = "White", Description = "White", CreatedDate = seedDate, EnteredBy = "System" },
				new Race { RaceId = 2, Name = "Black or African American", Description = "Black or African American", CreatedDate = seedDate, EnteredBy = "System" },
				new Race { RaceId = 3, Name = "Asian", Description = "Asian", CreatedDate = seedDate, EnteredBy = "System" },
				new Race { RaceId = 4, Name = "Native American", Description = "Native American or Alaska Native", CreatedDate = seedDate, EnteredBy = "System" },
				new Race { RaceId = 5, Name = "Pacific Islander", Description = "Native Hawaiian or Other Pacific Islander", CreatedDate = seedDate, EnteredBy = "System" },
				new Race { RaceId = 6, Name = "Other", Description = "Other/Unspecified", CreatedDate = seedDate, EnteredBy = "System" }
			);
		});
		
		// Configure Gender
		builder.Entity<Gender>(entity =>
		{
			entity.Property(e => e.Name).HasMaxLength(255);
			entity.Property(e => e.Description).HasMaxLength(255);
			entity.Property(e => e.EnteredBy).HasMaxLength(100);
			entity.Property(e => e.CreatedDate).HasDefaultValueSql("CURRENT_TIMESTAMP");

			entity.HasData(
				new Gender { GenderId = 1, Name = "Male", Description = "Male", CreatedDate = seedDate, EnteredBy = "System" },
				new Gender { GenderId = 2, Name = "Female", Description = "Female", CreatedDate = seedDate, EnteredBy = "System" },
				new Gender { GenderId = 3, Name = "Other", Description = "Other/Unspecified", CreatedDate = seedDate, EnteredBy = "System" }
			);
		});
		
		// Configure PersonType
		builder.Entity<PersonType>(entity =>
		{
			entity.Property(e => e.Name).HasMaxLength(255);
			entity.Property(e => e.Description).HasMaxLength(255);
			entity.Property(e => e.EnteredBy).HasMaxLength(100);
			entity.Property(e => e.CreatedDate).HasDefaultValueSql("CURRENT_TIMESTAMP");
			
			// Configure the Client relationship
			entity.HasOne(pt => pt.Client)
				.WithMany()
				.HasForeignKey(pt => pt.ClientId)
				.OnDelete(DeleteBehavior.SetNull);

			entity.HasData(
				new PersonType { PersonTypeId = 1, Name = "Employee", Description = "Employee", ClientOption = false, CreatedDate = seedDate, EnteredBy = "System" },
				new PersonType { PersonTypeId = 2, Name = "Contractor", Description = "Contractor", ClientOption = false, CreatedDate = seedDate, EnteredBy = "System" },
				new PersonType { PersonTypeId = 3, Name = "Customer", Description = "Customer", ClientOption = false, CreatedDate = seedDate, EnteredBy = "System" },
				new PersonType { PersonTypeId = 4, Name = "Vendor", Description = "Vendor", ClientOption = false, CreatedDate = seedDate, EnteredBy = "System" }
			);
		});

		// Configure Person
		builder.Entity<Person>(entity =>
		{
			entity.Property(e => e.LastName).HasMaxLength(255);
			entity.Property(e => e.FirstName).HasMaxLength(255);
			entity.Property(e => e.MiddleName).HasMaxLength(255);
			entity.Property(e => e.Suffix).HasMaxLength(255);
			entity.Property(e => e.Prefix).HasMaxLength(255);
			entity.Property(e => e.Alias).HasMaxLength(255);
			entity.Property(e => e.EnteredBy).HasMaxLength(100);
			entity.Property(e => e.CreatedDate).HasDefaultValueSql("CURRENT_TIMESTAMP");
			
			// Add foreign key relationships
			entity.HasOne(p => p.PersonType)
				.WithMany()
				.HasForeignKey(p => p.PersonTypeId)
				.OnDelete(DeleteBehavior.Restrict);
				
			entity.HasOne(p => p.Race)
				.WithMany()
				.HasForeignKey(p => p.RaceId)
				.OnDelete(DeleteBehavior.Restrict);
				
			entity.HasOne(p => p.Gender)
				.WithMany()
				.HasForeignKey(p => p.GenderId)
				.OnDelete(DeleteBehavior.Restrict);

			var peopleSeedDate = DateTime.SpecifyKind(new DateTime(2024, 1, 1, 0, 0, 0), DateTimeKind.Utc);
			entity.HasData(
				// First 12 existing records
				new Person { PersonId = new Guid("00000000-0000-0000-0000-000000000001"), LastName = "Smith", FirstName = "John", MiddleName = "A", Suffix = null, Prefix = null, PersonTypeId = 1, Alias = "jsmith", RaceId = 1, DateOfBirth = DateTime.SpecifyKind(new DateTime(1990, 1, 1), DateTimeKind.Utc), GenderId = 1, CreatedDate = peopleSeedDate, EnteredBy = "System" },
				new Person { PersonId = new Guid("00000000-0000-0000-0000-000000000002"), LastName = "Johnson", FirstName = "Emily", MiddleName = "B", Suffix = null, Prefix = null, PersonTypeId = 2, Alias = "ejohnson", RaceId = 2, DateOfBirth = DateTime.SpecifyKind(new DateTime(1985, 2, 2), DateTimeKind.Utc), GenderId = 2, CreatedDate = peopleSeedDate, EnteredBy = "System" },
				new Person { PersonId = new Guid("00000000-0000-0000-0000-000000000003"), LastName = "Williams", FirstName = "Michael", MiddleName = "C", Suffix = null, Prefix = null, PersonTypeId = 3, Alias = "mwilliams", RaceId = 3, DateOfBirth = DateTime.SpecifyKind(new DateTime(1978, 3, 3), DateTimeKind.Utc), GenderId = 1, CreatedDate = peopleSeedDate, EnteredBy = "System" },
				new Person { PersonId = new Guid("00000000-0000-0000-0000-000000000004"), LastName = "Brown", FirstName = "Sarah", MiddleName = "D", Suffix = null, Prefix = null, PersonTypeId = 4, Alias = "sbrown", RaceId = 4, DateOfBirth = DateTime.SpecifyKind(new DateTime(1992, 4, 4), DateTimeKind.Utc), GenderId = 2, CreatedDate = peopleSeedDate, EnteredBy = "System" },
				new Person { PersonId = new Guid("00000000-0000-0000-0000-000000000005"), LastName = "Jones", FirstName = "David", MiddleName = "E", Suffix = null, Prefix = null, PersonTypeId = 1, Alias = "djones", RaceId = 5, DateOfBirth = DateTime.SpecifyKind(new DateTime(1980, 5, 5), DateTimeKind.Utc), GenderId = 1, CreatedDate = peopleSeedDate, EnteredBy = "System" },
				new Person { PersonId = new Guid("00000000-0000-0000-0000-000000000006"), LastName = "Garcia", FirstName = "Jessica", MiddleName = "F", Suffix = null, Prefix = null, PersonTypeId = 2, Alias = "jgarcia", RaceId = 6, DateOfBirth = DateTime.SpecifyKind(new DateTime(1995, 6, 6), DateTimeKind.Utc), GenderId = 2, CreatedDate = peopleSeedDate, EnteredBy = "System" },
				new Person { PersonId = new Guid("00000000-0000-0000-0000-000000000007"), LastName = "Miller", FirstName = "Chris", MiddleName = "G", Suffix = null, Prefix = null, PersonTypeId = 3, Alias = "cmiller", RaceId = 1, DateOfBirth = DateTime.SpecifyKind(new DateTime(1988, 7, 7), DateTimeKind.Utc), GenderId = 1, CreatedDate = peopleSeedDate, EnteredBy = "System" },
				new Person { PersonId = new Guid("00000000-0000-0000-0000-000000000008"), LastName = "Davis", FirstName = "Ashley", MiddleName = "H", Suffix = null, Prefix = null, PersonTypeId = 4, Alias = "adavis", RaceId = 2, DateOfBirth = DateTime.SpecifyKind(new DateTime(1991, 8, 8), DateTimeKind.Utc), GenderId = 2, CreatedDate = peopleSeedDate, EnteredBy = "System" },
				new Person { PersonId = new Guid("00000000-0000-0000-0000-000000000009"), LastName = "Martinez", FirstName = "Matthew", MiddleName = "I", Suffix = null, Prefix = null, PersonTypeId = 1, Alias = "mmartinez", RaceId = 3, DateOfBirth = DateTime.SpecifyKind(new DateTime(1983, 9, 9), DateTimeKind.Utc), GenderId = 1, CreatedDate = peopleSeedDate, EnteredBy = "System" },
				new Person { PersonId = new Guid("00000000-0000-0000-0000-000000000010"), LastName = "Hernandez", FirstName = "Amanda", MiddleName = "J", Suffix = null, Prefix = null, PersonTypeId = 2, Alias = "ahernandez", RaceId = 4, DateOfBirth = DateTime.SpecifyKind(new DateTime(1993, 10, 10), DateTimeKind.Utc), GenderId = 2, CreatedDate = peopleSeedDate, EnteredBy = "System" },
				new Person { PersonId = new Guid("00000000-0000-0000-0000-000000000011"), LastName = "Lopez", FirstName = "Joshua", MiddleName = "K", Suffix = null, Prefix = null, PersonTypeId = 3, Alias = "jlopez", RaceId = 5, DateOfBirth = DateTime.SpecifyKind(new DateTime(1987, 11, 11), DateTimeKind.Utc), GenderId = 1, CreatedDate = peopleSeedDate, EnteredBy = "System" },
				new Person { PersonId = new Guid("00000000-0000-0000-0000-000000000012"), LastName = "Gonzalez", FirstName = "Brittany", MiddleName = "L", Suffix = null, Prefix = null, PersonTypeId = 4, Alias = "bgonzalez", RaceId = 6, DateOfBirth = DateTime.SpecifyKind(new DateTime(1996, 12, 12), DateTimeKind.Utc), GenderId = 2, CreatedDate = peopleSeedDate, EnteredBy = "System" },
				// Additional records to reach 50
				new Person { PersonId = new Guid("00000000-0000-0000-0000-000000000013"), LastName = "Wilson", FirstName = "Robert", MiddleName = "M", Suffix = null, Prefix = null, PersonTypeId = 1, Alias = "rwilson", RaceId = 1, DateOfBirth = DateTime.SpecifyKind(new DateTime(1982, 1, 15), DateTimeKind.Utc), GenderId = 1, CreatedDate = peopleSeedDate, EnteredBy = "System" },
				new Person { PersonId = new Guid("00000000-0000-0000-0000-000000000014"), LastName = "Anderson", FirstName = "Jennifer", MiddleName = "N", Suffix = null, Prefix = null, PersonTypeId = 2, Alias = "janderson", RaceId = 2, DateOfBirth = DateTime.SpecifyKind(new DateTime(1994, 2, 16), DateTimeKind.Utc), GenderId = 2, CreatedDate = peopleSeedDate, EnteredBy = "System" },
				new Person { PersonId = new Guid("00000000-0000-0000-0000-000000000015"), LastName = "Thomas", FirstName = "Daniel", MiddleName = "O", Suffix = null, Prefix = null, PersonTypeId = 3, Alias = "dthomas", RaceId = 3, DateOfBirth = DateTime.SpecifyKind(new DateTime(1979, 3, 17), DateTimeKind.Utc), GenderId = 1, CreatedDate = peopleSeedDate, EnteredBy = "System" },
				new Person { PersonId = new Guid("00000000-0000-0000-0000-000000000016"), LastName = "Taylor", FirstName = "Lisa", MiddleName = "P", Suffix = null, Prefix = null, PersonTypeId = 4, Alias = "ltaylor", RaceId = 4, DateOfBirth = DateTime.SpecifyKind(new DateTime(1991, 4, 18), DateTimeKind.Utc), GenderId = 2, CreatedDate = peopleSeedDate, EnteredBy = "System" },
				new Person { PersonId = new Guid("00000000-0000-0000-0000-000000000017"), LastName = "Moore", FirstName = "James", MiddleName = "Q", Suffix = null, Prefix = null, PersonTypeId = 1, Alias = "jmoore", RaceId = 5, DateOfBirth = DateTime.SpecifyKind(new DateTime(1985, 5, 19), DateTimeKind.Utc), GenderId = 1, CreatedDate = peopleSeedDate, EnteredBy = "System" },
				new Person { PersonId = new Guid("00000000-0000-0000-0000-000000000018"), LastName = "Jackson", FirstName = "Michelle", MiddleName = "R", Suffix = null, Prefix = null, PersonTypeId = 2, Alias = "mjackson", RaceId = 6, DateOfBirth = DateTime.SpecifyKind(new DateTime(1993, 6, 20), DateTimeKind.Utc), GenderId = 2, CreatedDate = peopleSeedDate, EnteredBy = "System" },
				new Person { PersonId = new Guid("00000000-0000-0000-0000-000000000019"), LastName = "Martin", FirstName = "Andrew", MiddleName = "S", Suffix = null, Prefix = null, PersonTypeId = 3, Alias = "amartin", RaceId = 1, DateOfBirth = DateTime.SpecifyKind(new DateTime(1987, 7, 21), DateTimeKind.Utc), GenderId = 1, CreatedDate = peopleSeedDate, EnteredBy = "System" },
				new Person { PersonId = new Guid("00000000-0000-0000-0000-000000000020"), LastName = "Lee", FirstName = "Stephanie", MiddleName = "T", Suffix = null, Prefix = null, PersonTypeId = 4, Alias = "slee", RaceId = 2, DateOfBirth = DateTime.SpecifyKind(new DateTime(1990, 8, 22), DateTimeKind.Utc), GenderId = 2, CreatedDate = peopleSeedDate, EnteredBy = "System" },
				new Person { PersonId = new Guid("00000000-0000-0000-0000-000000000021"), LastName = "Thompson", FirstName = "Kevin", MiddleName = "U", Suffix = null, Prefix = null, PersonTypeId = 1, Alias = "kthompson", RaceId = 3, DateOfBirth = DateTime.SpecifyKind(new DateTime(1984, 9, 23), DateTimeKind.Utc), GenderId = 1, CreatedDate = peopleSeedDate, EnteredBy = "System" },
				new Person { PersonId = new Guid("00000000-0000-0000-0000-000000000022"), LastName = "White", FirstName = "Nicole", MiddleName = "V", Suffix = null, Prefix = null, PersonTypeId = 2, Alias = "nwhite", RaceId = 4, DateOfBirth = DateTime.SpecifyKind(new DateTime(1992, 10, 24), DateTimeKind.Utc), GenderId = 2, CreatedDate = peopleSeedDate, EnteredBy = "System" },
				new Person { PersonId = new Guid("00000000-0000-0000-0000-000000000023"), LastName = "Harris", FirstName = "Brian", MiddleName = "W", Suffix = null, Prefix = null, PersonTypeId = 3, Alias = "bharris", RaceId = 5, DateOfBirth = DateTime.SpecifyKind(new DateTime(1986, 11, 25), DateTimeKind.Utc), GenderId = 1, CreatedDate = peopleSeedDate, EnteredBy = "System" },
				new Person { PersonId = new Guid("00000000-0000-0000-0000-000000000024"), LastName = "Clark", FirstName = "Rachel", MiddleName = "X", Suffix = null, Prefix = null, PersonTypeId = 4, Alias = "rclark", RaceId = 6, DateOfBirth = DateTime.SpecifyKind(new DateTime(1994, 12, 26), DateTimeKind.Utc), GenderId = 2, CreatedDate = peopleSeedDate, EnteredBy = "System" },
				new Person { PersonId = new Guid("00000000-0000-0000-0000-000000000025"), LastName = "Lewis", FirstName = "Steven", MiddleName = "Y", Suffix = null, Prefix = null, PersonTypeId = 1, Alias = "slewis", RaceId = 1, DateOfBirth = DateTime.SpecifyKind(new DateTime(1983, 1, 27), DateTimeKind.Utc), GenderId = 1, CreatedDate = peopleSeedDate, EnteredBy = "System" },
				new Person { PersonId = new Guid("00000000-0000-0000-0000-000000000026"), LastName = "Robinson", FirstName = "Melissa", MiddleName = "Z", Suffix = null, Prefix = null, PersonTypeId = 2, Alias = "mrobinson", RaceId = 2, DateOfBirth = DateTime.SpecifyKind(new DateTime(1991, 2, 28), DateTimeKind.Utc), GenderId = 2, CreatedDate = peopleSeedDate, EnteredBy = "System" },
				new Person { PersonId = new Guid("00000000-0000-0000-0000-000000000027"), LastName = "Walker", FirstName = "Timothy", MiddleName = "AA", Suffix = null, Prefix = null, PersonTypeId = 3, Alias = "twalker", RaceId = 3, DateOfBirth = DateTime.SpecifyKind(new DateTime(1988, 3, 29), DateTimeKind.Utc), GenderId = 1, CreatedDate = peopleSeedDate, EnteredBy = "System" },
				new Person { PersonId = new Guid("00000000-0000-0000-0000-000000000028"), LastName = "Young", FirstName = "Kimberly", MiddleName = "AB", Suffix = null, Prefix = null, PersonTypeId = 4, Alias = "kyoung", RaceId = 4, DateOfBirth = DateTime.SpecifyKind(new DateTime(1993, 4, 30), DateTimeKind.Utc), GenderId = 2, CreatedDate = peopleSeedDate, EnteredBy = "System" },
				new Person { PersonId = new Guid("00000000-0000-0000-0000-000000000029"), LastName = "Allen", FirstName = "Richard", MiddleName = "AC", Suffix = null, Prefix = null, PersonTypeId = 1, Alias = "rallen", RaceId = 5, DateOfBirth = DateTime.SpecifyKind(new DateTime(1985, 5, 31), DateTimeKind.Utc), GenderId = 1, CreatedDate = peopleSeedDate, EnteredBy = "System" },
				new Person { PersonId = new Guid("00000000-0000-0000-0000-000000000030"), LastName = "King", FirstName = "Laura", MiddleName = "AD", Suffix = null, Prefix = null, PersonTypeId = 2, Alias = "lking", RaceId = 6, DateOfBirth = DateTime.SpecifyKind(new DateTime(1990, 6, 1), DateTimeKind.Utc), GenderId = 2, CreatedDate = peopleSeedDate, EnteredBy = "System" },
				new Person { PersonId = new Guid("00000000-0000-0000-0000-000000000031"), LastName = "Wright", FirstName = "Charles", MiddleName = "AE", Suffix = null, Prefix = null, PersonTypeId = 3, Alias = "cwright", RaceId = 1, DateOfBirth = DateTime.SpecifyKind(new DateTime(1987, 7, 2), DateTimeKind.Utc), GenderId = 1, CreatedDate = peopleSeedDate, EnteredBy = "System" },
				new Person { PersonId = new Guid("00000000-0000-0000-0000-000000000032"), LastName = "Scott", FirstName = "Heather", MiddleName = "AF", Suffix = null, Prefix = null, PersonTypeId = 4, Alias = "hscott", RaceId = 2, DateOfBirth = DateTime.SpecifyKind(new DateTime(1992, 8, 3), DateTimeKind.Utc), GenderId = 2, CreatedDate = peopleSeedDate, EnteredBy = "System" },
				new Person { PersonId = new Guid("00000000-0000-0000-0000-000000000033"), LastName = "Green", FirstName = "Joseph", MiddleName = "AG", Suffix = null, Prefix = null, PersonTypeId = 1, Alias = "jgreen", RaceId = 3, DateOfBirth = DateTime.SpecifyKind(new DateTime(1984, 9, 4), DateTimeKind.Utc), GenderId = 1, CreatedDate = peopleSeedDate, EnteredBy = "System" },
				new Person { PersonId = new Guid("00000000-0000-0000-0000-000000000034"), LastName = "Baker", FirstName = "Elizabeth", MiddleName = "AH", Suffix = null, Prefix = null, PersonTypeId = 2, Alias = "ebaker", RaceId = 4, DateOfBirth = DateTime.SpecifyKind(new DateTime(1991, 10, 5), DateTimeKind.Utc), GenderId = 2, CreatedDate = peopleSeedDate, EnteredBy = "System" },
				new Person { PersonId = new Guid("00000000-0000-0000-0000-000000000035"), LastName = "Adams", FirstName = "Thomas", MiddleName = "AI", Suffix = null, Prefix = null, PersonTypeId = 3, Alias = "tadams", RaceId = 5, DateOfBirth = DateTime.SpecifyKind(new DateTime(1986, 11, 6), DateTimeKind.Utc), GenderId = 1, CreatedDate = peopleSeedDate, EnteredBy = "System" },
				new Person { PersonId = new Guid("00000000-0000-0000-0000-000000000036"), LastName = "Nelson", FirstName = "Christine", MiddleName = "AJ", Suffix = null, Prefix = null, PersonTypeId = 4, Alias = "cnelson", RaceId = 6, DateOfBirth = DateTime.SpecifyKind(new DateTime(1993, 12, 7), DateTimeKind.Utc), GenderId = 2, CreatedDate = peopleSeedDate, EnteredBy = "System" },
				new Person { PersonId = new Guid("00000000-0000-0000-0000-000000000037"), LastName = "Carter", FirstName = "Paul", MiddleName = "AK", Suffix = null, Prefix = null, PersonTypeId = 1, Alias = "pcarter", RaceId = 1, DateOfBirth = DateTime.SpecifyKind(new DateTime(1985, 1, 8), DateTimeKind.Utc), GenderId = 1, CreatedDate = peopleSeedDate, EnteredBy = "System" },
				new Person { PersonId = new Guid("00000000-0000-0000-0000-000000000038"), LastName = "Mitchell", FirstName = "Samantha", MiddleName = "AL", Suffix = null, Prefix = null, PersonTypeId = 2, Alias = "smitchell", RaceId = 2, DateOfBirth = DateTime.SpecifyKind(new DateTime(1990, 2, 9), DateTimeKind.Utc), GenderId = 2, CreatedDate = peopleSeedDate, EnteredBy = "System" },
				new Person { PersonId = new Guid("00000000-0000-0000-0000-000000000039"), LastName = "Perez", FirstName = "Mark", MiddleName = "AM", Suffix = null, Prefix = null, PersonTypeId = 3, Alias = "mperez", RaceId = 3, DateOfBirth = DateTime.SpecifyKind(new DateTime(1987, 3, 10), DateTimeKind.Utc), GenderId = 1, CreatedDate = peopleSeedDate, EnteredBy = "System" },
				new Person { PersonId = new Guid("00000000-0000-0000-0000-000000000040"), LastName = "Roberts", FirstName = "Patricia", MiddleName = "AN", Suffix = null, Prefix = null, PersonTypeId = 4, Alias = "proberts", RaceId = 4, DateOfBirth = DateTime.SpecifyKind(new DateTime(1992, 4, 11), DateTimeKind.Utc), GenderId = 2, CreatedDate = peopleSeedDate, EnteredBy = "System" },
				new Person { PersonId = new Guid("00000000-0000-0000-0000-000000000041"), LastName = "Turner", FirstName = "Donald", MiddleName = "AO", Suffix = null, Prefix = null, PersonTypeId = 1, Alias = "dturner", RaceId = 5, DateOfBirth = DateTime.SpecifyKind(new DateTime(1985, 5, 12), DateTimeKind.Utc), GenderId = 1, CreatedDate = peopleSeedDate, EnteredBy = "System" },
				new Person { PersonId = new Guid("00000000-0000-0000-0000-000000000042"), LastName = "Phillips", FirstName = "Nancy", MiddleName = "AP", Suffix = null, Prefix = null, PersonTypeId = 2, Alias = "nphillips", RaceId = 6, DateOfBirth = DateTime.SpecifyKind(new DateTime(1991, 6, 13), DateTimeKind.Utc), GenderId = 2, CreatedDate = peopleSeedDate, EnteredBy = "System" },
				new Person { PersonId = new Guid("00000000-0000-0000-0000-000000000043"), LastName = "Campbell", FirstName = "George", MiddleName = "AQ", Suffix = null, Prefix = null, PersonTypeId = 3, Alias = "gcampbell", RaceId = 1, DateOfBirth = DateTime.SpecifyKind(new DateTime(1986, 7, 14), DateTimeKind.Utc), GenderId = 1, CreatedDate = peopleSeedDate, EnteredBy = "System" },
				new Person { PersonId = new Guid("00000000-0000-0000-0000-000000000044"), LastName = "Parker", FirstName = "Karen", MiddleName = "AR", Suffix = null, Prefix = null, PersonTypeId = 4, Alias = "kparker", RaceId = 2, DateOfBirth = DateTime.SpecifyKind(new DateTime(1993, 8, 15), DateTimeKind.Utc), GenderId = 2, CreatedDate = peopleSeedDate, EnteredBy = "System" },
				new Person { PersonId = new Guid("00000000-0000-0000-0000-000000000045"), LastName = "Evans", FirstName = "Edward", MiddleName = "AS", Suffix = null, Prefix = null, PersonTypeId = 1, Alias = "eevans", RaceId = 3, DateOfBirth = DateTime.SpecifyKind(new DateTime(1984, 9, 16), DateTimeKind.Utc), GenderId = 1, CreatedDate = peopleSeedDate, EnteredBy = "System" },
				new Person { PersonId = new Guid("00000000-0000-0000-0000-000000000046"), LastName = "Edwards", FirstName = "Betty", MiddleName = "AT", Suffix = null, Prefix = null, PersonTypeId = 2, Alias = "bedwards", RaceId = 4, DateOfBirth = DateTime.SpecifyKind(new DateTime(1990, 10, 17), DateTimeKind.Utc), GenderId = 2, CreatedDate = peopleSeedDate, EnteredBy = "System" },
				new Person { PersonId = new Guid("00000000-0000-0000-0000-000000000047"), LastName = "Collins", FirstName = "William", MiddleName = "AU", Suffix = null, Prefix = null, PersonTypeId = 3, Alias = "wcollins", RaceId = 5, DateOfBirth = DateTime.SpecifyKind(new DateTime(1987, 11, 18), DateTimeKind.Utc), GenderId = 1, CreatedDate = peopleSeedDate, EnteredBy = "System" },
				new Person { PersonId = new Guid("00000000-0000-0000-0000-000000000048"), LastName = "Stewart", FirstName = "Helen", MiddleName = "AV", Suffix = null, Prefix = null, PersonTypeId = 4, Alias = "hstewart", RaceId = 6, DateOfBirth = DateTime.SpecifyKind(new DateTime(1992, 12, 19), DateTimeKind.Utc), GenderId = 2, CreatedDate = peopleSeedDate, EnteredBy = "System" },
				new Person { PersonId = new Guid("00000000-0000-0000-0000-000000000049"), LastName = "Sanchez", FirstName = "Ronald", MiddleName = "AW", Suffix = null, Prefix = null, PersonTypeId = 1, Alias = "rsanchez", RaceId = 1, DateOfBirth = DateTime.SpecifyKind(new DateTime(1985, 1, 20), DateTimeKind.Utc), GenderId = 1, CreatedDate = peopleSeedDate, EnteredBy = "System" },
				new Person { PersonId = new Guid("00000000-0000-0000-0000-000000000050"), LastName = "Morris", FirstName = "Margaret", MiddleName = "AX", Suffix = null, Prefix = null, PersonTypeId = 2, Alias = "mmorris", RaceId = 2, DateOfBirth = DateTime.SpecifyKind(new DateTime(1990, 12, 31), DateTimeKind.Utc), GenderId = 3, CreatedDate = peopleSeedDate, EnteredBy = "System" }
			);
		});

		// Configure AddressType
		builder.Entity<AddressType>(entity =>
		{
			entity.Property(e => e.Description).HasMaxLength(255);
			entity.Property(e => e.Name).HasMaxLength(255);
			entity.Property(e => e.ClientId).HasMaxLength(255);

			entity.HasData(
				new AddressType { AddressTypeId = 1, Description = "Home address", Name = "Home", ClientId = null, ClientOption = false },
				new AddressType { AddressTypeId = 2, Description = "Work address", Name = "Work", ClientId = null, ClientOption = false },
				new AddressType { AddressTypeId = 3, Description = "Billing address", Name = "Billing", ClientId = null, ClientOption = false },
				new AddressType { AddressTypeId = 4, Description = "Shipping address", Name = "Shipping", ClientId = null, ClientOption = false },
				new AddressType { AddressTypeId = 5, Description = "Mailing address", Name = "Mailing", ClientId = null, ClientOption = false }
			);
		});

		// Configure Address
		builder.Entity<Address>(entity =>
		{
			entity.Property(e => e.AddressLine1).HasMaxLength(255);
			entity.Property(e => e.AddressLine2).HasMaxLength(255);
			entity.Property(e => e.City).HasMaxLength(255);
			entity.Property(e => e.Zip).HasMaxLength(20);
			
			// Add foreign key relationship to AddressType
			entity.HasOne<AddressType>()
				.WithMany()
				.HasForeignKey(a => a.AddressTypeId)
				.OnDelete(DeleteBehavior.Restrict);
				
			// Add foreign key relationship to State
			entity.HasOne<State>()
				.WithMany()
				.HasForeignKey(a => a.StateId)
				.OnDelete(DeleteBehavior.Restrict);

			// Seed Address data
			var addressSeedData = new List<Address>();
			var random = new Random(42); // Fixed seed for consistent data
			
			for (int i = 1; i <= 60; i++)
			{
				var streetNumber = random.Next(100, 9999);
				var streetName = GetRandomStreetName(random);
				var city = GetRandomCity(random);
				var stateId = random.Next(1, 51); // 1-50 for states
				var zip = random.Next(10000, 100000).ToString();
				var addressTypeId = random.Next(1, 6); // 1-5 for address types
				
				addressSeedData.Add(new Address
				{
					AddressId = new Guid($"00000000-0000-0000-0000-{i:D012}"),
					AddressLine1 = $"{streetNumber} {streetName}",
					AddressLine2 = random.Next(0, 3) == 0 ? $"Apt {random.Next(1, 1000)}" : null,
					City = city,
					StateId = stateId,
					Zip = zip,
					AddressTypeId = addressTypeId
				});
			}
			
			entity.HasData(addressSeedData);
		});

		// Configure PhoneType
		builder.Entity<PhoneType>(entity =>
		{
			entity.Property(e => e.Description).HasMaxLength(255);
			entity.Property(e => e.Name).HasMaxLength(255);
			entity.Property(e => e.ClientId).HasMaxLength(255);

			entity.HasData(
				new PhoneType { PhoneTypeId = 1, Description = "Home phone number", Name = "Home", ClientId = null, ClientOption = false },
				new PhoneType { PhoneTypeId = 2, Description = "Work phone number", Name = "Work", ClientId = null, ClientOption = false },
				new PhoneType { PhoneTypeId = 3, Description = "Mobile phone number", Name = "Mobile", ClientId = null, ClientOption = false },
				new PhoneType { PhoneTypeId = 4, Description = "Fax number", Name = "Fax", ClientId = null, ClientOption = false },
				new PhoneType { PhoneTypeId = 5, Description = "Emergency contact number", Name = "Emergency", ClientId = null, ClientOption = false }
			);
		});

		// Configure Phone
		builder.Entity<Phone>(entity =>
		{
			entity.Property(e => e.PhoneNumber).HasMaxLength(20);
			entity.Property(e => e.Extension).HasMaxLength(10);
			
			// Add foreign key relationship to PhoneType
			entity.HasOne<PhoneType>()
				.WithMany()
				.HasForeignKey(p => p.PhoneTypeId)
				.OnDelete(DeleteBehavior.Restrict);

			// Seed Phone data
			var phoneSeedData = new List<Phone>();
			var random = new Random(42); // Fixed seed for consistent data
			
			for (int i = 1; i <= 60; i++)
			{
				var areaCode = random.Next(200, 999);
				var prefix = random.Next(100, 999);
				var lineNumber = random.Next(1000, 9999);
				var phoneTypeId = random.Next(1, 6); // 1-5 for phone types
				var extension = random.Next(0, 3) == 0 ? random.Next(1000, 9999).ToString() : null;
				
				phoneSeedData.Add(new Phone
				{
					PhoneId = new Guid($"00000000-0000-0000-0000-{i + 100:D012}"),
					PhoneNumber = $"{areaCode}-{prefix}-{lineNumber}",
					Extension = extension,
					PhoneTypeId = phoneTypeId
				});
			}
			
			entity.HasData(phoneSeedData);
		});

		// Configure EmailType
		builder.Entity<EmailType>(entity =>
		{
			entity.Property(e => e.Description).HasMaxLength(255);
			entity.Property(e => e.Name).HasMaxLength(255);
			entity.Property(e => e.ClientId).HasMaxLength(255);

			entity.HasData(
				new EmailType { EmailTypeId = 1, Description = "Personal email address", Name = "Personal", ClientId = null, ClientOption = false },
				new EmailType { EmailTypeId = 2, Description = "Work email address", Name = "Work", ClientId = null, ClientOption = false },
				new EmailType { EmailTypeId = 3, Description = "Business email address", Name = "Business", ClientId = null, ClientOption = false },
				new EmailType { EmailTypeId = 4, Description = "Marketing email address", Name = "Marketing", ClientId = null, ClientOption = false },
				new EmailType { EmailTypeId = 5, Description = "Support email address", Name = "Support", ClientId = null, ClientOption = false }
			);
		});

		// Configure Email
		builder.Entity<Email>(entity =>
		{
			entity.Property(e => e.EmailAddress).HasMaxLength(255);
			
			// Add foreign key relationship to EmailType
			entity.HasOne<EmailType>()
				.WithMany()
				.HasForeignKey(e => e.EmailTypeId)
				.OnDelete(DeleteBehavior.Restrict);

			// Seed Email data
			var emailSeedData = new List<Email>();
			var random = new Random(42); // Fixed seed for consistent data
			
			for (int i = 1; i <= 60; i++)
			{
				var firstName = GetRandomFirstName(random);
				var lastName = GetRandomLastName(random);
				var domain = GetRandomDomain(random);
				var emailTypeId = random.Next(1, 6); // 1-5 for email types
				
				emailSeedData.Add(new Email
				{
					EmailId = new Guid($"00000000-0000-0000-0000-{i + 200:D012}"),
					EmailAddress = $"{firstName.ToLower()}.{lastName.ToLower()}@{domain}",
					EmailTypeId = emailTypeId
				});
			}
			
			entity.HasData(emailSeedData);
		});

		// Configure State
		builder.Entity<State>(entity =>
		{
			entity.Property(e => e.Abbreviation).HasMaxLength(2);
			entity.Property(e => e.Name).HasMaxLength(255);

			entity.HasData(
				new State { StateId = 1, Abbreviation = "AL", Name = "Alabama" },
				new State { StateId = 2, Abbreviation = "AK", Name = "Alaska" },
				new State { StateId = 3, Abbreviation = "AZ", Name = "Arizona" },
				new State { StateId = 4, Abbreviation = "AR", Name = "Arkansas" },
				new State { StateId = 5, Abbreviation = "CA", Name = "California" },
				new State { StateId = 6, Abbreviation = "CO", Name = "Colorado" },
				new State { StateId = 7, Abbreviation = "CT", Name = "Connecticut" },
				new State { StateId = 8, Abbreviation = "DE", Name = "Delaware" },
				new State { StateId = 9, Abbreviation = "FL", Name = "Florida" },
				new State { StateId = 10, Abbreviation = "GA", Name = "Georgia" },
				new State { StateId = 11, Abbreviation = "HI", Name = "Hawaii" },
				new State { StateId = 12, Abbreviation = "ID", Name = "Idaho" },
				new State { StateId = 13, Abbreviation = "IL", Name = "Illinois" },
				new State { StateId = 14, Abbreviation = "IN", Name = "Indiana" },
				new State { StateId = 15, Abbreviation = "IA", Name = "Iowa" },
				new State { StateId = 16, Abbreviation = "KS", Name = "Kansas" },
				new State { StateId = 17, Abbreviation = "KY", Name = "Kentucky" },
				new State { StateId = 18, Abbreviation = "LA", Name = "Louisiana" },
				new State { StateId = 19, Abbreviation = "ME", Name = "Maine" },
				new State { StateId = 20, Abbreviation = "MD", Name = "Maryland" },
				new State { StateId = 21, Abbreviation = "MA", Name = "Massachusetts" },
				new State { StateId = 22, Abbreviation = "MI", Name = "Michigan" },
				new State { StateId = 23, Abbreviation = "MN", Name = "Minnesota" },
				new State { StateId = 24, Abbreviation = "MS", Name = "Mississippi" },
				new State { StateId = 25, Abbreviation = "MO", Name = "Missouri" },
				new State { StateId = 26, Abbreviation = "MT", Name = "Montana" },
				new State { StateId = 27, Abbreviation = "NE", Name = "Nebraska" },
				new State { StateId = 28, Abbreviation = "NV", Name = "Nevada" },
				new State { StateId = 29, Abbreviation = "NH", Name = "New Hampshire" },
				new State { StateId = 30, Abbreviation = "NJ", Name = "New Jersey" },
				new State { StateId = 31, Abbreviation = "NM", Name = "New Mexico" },
				new State { StateId = 32, Abbreviation = "NY", Name = "New York" },
				new State { StateId = 33, Abbreviation = "NC", Name = "North Carolina" },
				new State { StateId = 34, Abbreviation = "ND", Name = "North Dakota" },
				new State { StateId = 35, Abbreviation = "OH", Name = "Ohio" },
				new State { StateId = 36, Abbreviation = "OK", Name = "Oklahoma" },
				new State { StateId = 37, Abbreviation = "OR", Name = "Oregon" },
				new State { StateId = 38, Abbreviation = "PA", Name = "Pennsylvania" },
				new State { StateId = 39, Abbreviation = "RI", Name = "Rhode Island" },
				new State { StateId = 40, Abbreviation = "SC", Name = "South Carolina" },
				new State { StateId = 41, Abbreviation = "SD", Name = "South Dakota" },
				new State { StateId = 42, Abbreviation = "TN", Name = "Tennessee" },
				new State { StateId = 43, Abbreviation = "TX", Name = "Texas" },
				new State { StateId = 44, Abbreviation = "UT", Name = "Utah" },
				new State { StateId = 45, Abbreviation = "VT", Name = "Vermont" },
				new State { StateId = 46, Abbreviation = "VA", Name = "Virginia" },
				new State { StateId = 47, Abbreviation = "WA", Name = "Washington" },
				new State { StateId = 48, Abbreviation = "WV", Name = "West Virginia" },
				new State { StateId = 49, Abbreviation = "WI", Name = "Wisconsin" },
				new State { StateId = 50, Abbreviation = "WY", Name = "Wyoming" }
			);
		});

		// Configure ClientAddress lookup table
		builder.Entity<ClientAddress>(entity =>
		{
			entity.Property(e => e.EnteredBy).HasMaxLength(100);
			entity.Property(e => e.CreatedDate).HasDefaultValueSql("CURRENT_TIMESTAMP");
			
			// Configure foreign key relationships
			entity.HasOne(ca => ca.Client)
				.WithMany()
				.HasForeignKey(ca => ca.ClientId)
				.OnDelete(DeleteBehavior.Cascade);
				
			entity.HasOne(ca => ca.Address)
				.WithMany()
				.HasForeignKey(ca => ca.AddressId)
				.OnDelete(DeleteBehavior.Cascade);
		});

		// Configure ClientPhone lookup table
		builder.Entity<ClientPhone>(entity =>
		{
			entity.Property(e => e.EnteredBy).HasMaxLength(100);
			entity.Property(e => e.CreatedDate).HasDefaultValueSql("CURRENT_TIMESTAMP");
			
			// Configure foreign key relationships
			entity.HasOne(cp => cp.Client)
				.WithMany()
				.HasForeignKey(cp => cp.ClientId)
				.OnDelete(DeleteBehavior.Cascade);
				
			entity.HasOne(cp => cp.Phone)
				.WithMany()
				.HasForeignKey(cp => cp.PhoneId)
				.OnDelete(DeleteBehavior.Cascade);
		});

		// Configure ClientEmail lookup table
		builder.Entity<ClientEmail>(entity =>
		{
			entity.Property(e => e.EnteredBy).HasMaxLength(100);
			entity.Property(e => e.CreatedDate).HasDefaultValueSql("CURRENT_TIMESTAMP");
			
			// Configure foreign key relationships
			entity.HasOne(ce => ce.Client)
				.WithMany()
				.HasForeignKey(ce => ce.ClientId)
				.OnDelete(DeleteBehavior.Cascade);
				
			entity.HasOne(ce => ce.Email)
				.WithMany()
				.HasForeignKey(ce => ce.EmailId)
				.OnDelete(DeleteBehavior.Cascade);
		});

		// Configure PersonAddress lookup table
		builder.Entity<PersonAddress>(entity =>
		{
			entity.Property(e => e.EnteredBy).HasMaxLength(100);
			entity.Property(e => e.CreatedDate).HasDefaultValueSql("CURRENT_TIMESTAMP");
			
			// Configure foreign key relationships
			entity.HasOne(pa => pa.Person)
				.WithMany()
				.HasForeignKey(pa => pa.PersonId)
				.OnDelete(DeleteBehavior.Cascade);
				
			entity.HasOne(pa => pa.Address)
				.WithMany()
				.HasForeignKey(pa => pa.AddressId)
				.OnDelete(DeleteBehavior.Cascade);
		});

		// Configure PersonPhone lookup table
		builder.Entity<PersonPhone>(entity =>
		{
			entity.Property(e => e.EnteredBy).HasMaxLength(100);
			entity.Property(e => e.CreatedDate).HasDefaultValueSql("CURRENT_TIMESTAMP");
			
			// Configure foreign key relationships
			entity.HasOne(pp => pp.Person)
				.WithMany()
				.HasForeignKey(pp => pp.PersonId)
				.OnDelete(DeleteBehavior.Cascade);
				
			entity.HasOne(pp => pp.Phone)
				.WithMany()
				.HasForeignKey(pp => pp.PhoneId)
				.OnDelete(DeleteBehavior.Cascade);
		});

		// Configure PersonEmail lookup table
		builder.Entity<PersonEmail>(entity =>
		{
			entity.Property(e => e.EnteredBy).HasMaxLength(100);
			entity.Property(e => e.CreatedDate).HasDefaultValueSql("CURRENT_TIMESTAMP");
			
			// Configure foreign key relationships
			entity.HasOne(pe => pe.Person)
				.WithMany()
				.HasForeignKey(pe => pe.PersonId)
				.OnDelete(DeleteBehavior.Cascade);
				
			entity.HasOne(pe => pe.Email)
				.WithMany()
				.HasForeignKey(pe => pe.EmailId)
				.OnDelete(DeleteBehavior.Cascade);
		});
	}

	// Helper methods for generating random seed data
	private static string GetRandomStreetName(Random random)
	{
		var streetNames = new[]
		{
			"Main St", "Oak Ave", "Elm St", "Pine Rd", "Cedar Ln", "Maple Dr", "Washington Blvd", "Lincoln Ave",
			"Park St", "Lake Dr", "River Rd", "Hill St", "Valley Ave", "Sunset Blvd", "Sunrise Dr", "Forest Ln",
			"Garden St", "Meadow Ave", "Brook Rd", "Spring St", "Summer Ave", "Winter Dr", "Autumn Ln", "Cherry St",
			"Apple Ave", "Peach Rd", "Plum St", "Berry Ave", "Grape Dr", "Orange Ln", "Lemon St", "Lime Ave",
			"Blueberry Rd", "Strawberry St", "Raspberry Ave", "Blackberry Dr", "Cranberry Ln", "Boysenberry St",
			"Elderberry Ave", "Gooseberry Rd", "Currant St", "Mulberry Ave", "Huckleberry Dr", "Serviceberry Ln"
		};
		return streetNames[random.Next(streetNames.Length)];
	}

	private static string GetRandomCity(Random random)
	{
		var cities = new[]
		{
			"New York", "Los Angeles", "Chicago", "Houston", "Phoenix", "Philadelphia", "San Antonio", "San Diego",
			"Dallas", "San Jose", "Austin", "Jacksonville", "Fort Worth", "Columbus", "Charlotte", "San Francisco",
			"Indianapolis", "Seattle", "Denver", "Washington", "Boston", "El Paso", "Nashville", "Detroit",
			"Oklahoma City", "Portland", "Las Vegas", "Memphis", "Louisville", "Baltimore", "Milwaukee", "Albuquerque",
			"Tucson", "Fresno", "Sacramento", "Mesa", "Kansas City", "Atlanta", "Long Beach", "Colorado Springs",
			"Raleigh", "Miami", "Virginia Beach", "Omaha", "Oakland", "Minneapolis", "Tulsa", "Arlington",
			"Tampa", "New Orleans", "Wichita", "Cleveland", "Bakersfield", "Aurora", "Anaheim", "Honolulu"
		};
		return cities[random.Next(cities.Length)];
	}

	private static string GetRandomFirstName(Random random)
	{
		var firstNames = new[]
		{
			"James", "Mary", "John", "Patricia", "Robert", "Jennifer", "Michael", "Linda", "William", "Elizabeth",
			"David", "Barbara", "Richard", "Susan", "Joseph", "Jessica", "Thomas", "Sarah", "Christopher", "Karen",
			"Charles", "Nancy", "Daniel", "Lisa", "Matthew", "Betty", "Anthony", "Helen", "Mark", "Sandra",
			"Donald", "Donna", "Steven", "Carol", "Paul", "Ruth", "Andrew", "Sharon", "Joshua", "Michelle",
			"Kenneth", "Laura", "Kevin", "Emily", "Brian", "Kimberly", "George", "Deborah", "Edward", "Dorothy",
			"Ronald", "Lisa", "Timothy", "Nancy", "Jason", "Karen", "Jeffrey", "Betty", "Ryan", "Helen"
		};
		return firstNames[random.Next(firstNames.Length)];
	}

	private static string GetRandomLastName(Random random)
	{
		var lastNames = new[]
		{
			"Smith", "Johnson", "Williams", "Brown", "Jones", "Garcia", "Miller", "Davis", "Rodriguez", "Martinez",
			"Hernandez", "Lopez", "Gonzalez", "Wilson", "Anderson", "Thomas", "Taylor", "Moore", "Jackson", "Martin",
			"Lee", "Perez", "Thompson", "White", "Harris", "Sanchez", "Clark", "Ramirez", "Lewis", "Robinson",
			"Walker", "Young", "Allen", "King", "Wright", "Scott", "Torres", "Nguyen", "Hill", "Flores",
			"Green", "Adams", "Nelson", "Baker", "Hall", "Rivera", "Campbell", "Mitchell", "Carter", "Roberts"
		};
		return lastNames[random.Next(lastNames.Length)];
	}

	private static string GetRandomDomain(Random random)
	{
		var domains = new[]
		{
			"gmail.com", "yahoo.com", "hotmail.com", "outlook.com", "aol.com", "icloud.com", "protonmail.com",
			"company.com", "business.com", "corporate.com", "enterprise.com", "organization.com", "firm.com",
			"consulting.com", "services.com", "solutions.com", "tech.com", "digital.com", "online.com", "web.com"
		};
		return domains[random.Next(domains.Length)];
	}
}