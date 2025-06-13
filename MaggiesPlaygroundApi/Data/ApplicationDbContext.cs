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
		
		// Configure Race
		var seedDate = new DateTime(2024, 1, 1, 0, 0, 0, DateTimeKind.Utc);
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
			
			// Add foreign key relationship to Client
			entity.HasOne<Client>()
				.WithMany()
				.HasForeignKey(p => p.ClientId)
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
	}
}