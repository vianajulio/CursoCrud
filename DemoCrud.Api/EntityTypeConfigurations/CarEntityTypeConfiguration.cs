using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DemoCrud.Api.EntityTypeConfigurations;

public class CarEntityTypeConfiguration : IEntityTypeConfiguration<Car>
{
	public void Configure(EntityTypeBuilder<Car> builder)
	{
		builder.HasKey(x => x.Id);

		builder.Property(x => x.Id)
			.ValueGeneratedNever()
			.IsRequired();

		builder.Property(x => x.Name)
			.HasMaxLength(100)
			.IsRequired();

		builder.Property(x => x.Price)
			.IsRequired();

		builder.HasIndex(x => x.Name)
			.IsUnique();
	}
}
