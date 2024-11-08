using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Pepperflow.Salt.Data.Configurations
{
	public class SystemTypeConfigurationRelation : IEntityTypeConfiguration<SystemType>
	{
		public void Configure(EntityTypeBuilder<SystemType> builder)
		{
			builder.HasKey(e => e.Id);

			builder.Property(e => e.Name)
			   .IsRequired()
			   .HasMaxLength(250);
		}
	}
}
