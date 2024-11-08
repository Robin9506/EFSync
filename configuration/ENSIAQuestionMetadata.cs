using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
public class ENSIAQuestionMetadataConfiguration : IEntityTypeConfiguration<ENSIAQuestionMetadata>
{
    public void Configure(EntityTypeBuilder<ENSIAQuestionMetadata> builder)
    {

        builder.HasKey(eqm => eqm.Id);

        builder.Property(eqm => eqm.ENSIAId);

        builder.Property(eqm => eqm.ENSIACode);

        builder.Property(eqm => eqm.AdditionalMeasure);

        builder.HasOne(eqm => eqm.Question)
            .WithOne(q => q.ENSIAQuestionMetadata)
            .HasForeignKey<Question>(q => q.ENSIAQuestionMetadataId)
            .IsRequired(false);

    }
}