using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class QuestionListConfiguration : IEntityTypeConfiguration<QuestionList>
{
    public void Configure(EntityTypeBuilder<QuestionList> builder)
    {
        builder.HasKey(e => e.Id);

        // builder.Property(e => e.SystemType)
        //    .IsRequired()
        //    .HasMaxLength(250);

        builder.Property(e => e.SystemPhase)
            .IsRequired()
            .HasMaxLength(250);

        builder.Property(e => e.StartDate)
            .IsRequired()
            .HasMaxLength(250);
    }
}

