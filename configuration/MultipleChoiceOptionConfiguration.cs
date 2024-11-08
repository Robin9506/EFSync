using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class MultipleChoiceOptionConfiguration : IEntityTypeConfiguration<MultipleChoiceOption>
{
    public void Configure(EntityTypeBuilder<MultipleChoiceOption> builder)
    {
        builder.HasKey(e => e.Id);

        builder.HasOne(e => e.Question)
            .WithMany(a => a.MultipleChoiceOptions)
            .HasForeignKey(e => e.QuestionId)
            .OnDelete(DeleteBehavior.Cascade);

    }
}