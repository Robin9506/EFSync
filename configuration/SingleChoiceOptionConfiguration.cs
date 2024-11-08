using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class SingleChoiceOptionConfiguration : IEntityTypeConfiguration<SingleChoiceOption>
    {
        public void Configure(EntityTypeBuilder<SingleChoiceOption> builder)
        {
            builder.HasKey(e => e.Id);

            builder.HasOne(e => e.Question)
                .WithMany(a => a.SingleChoiceOptions)
                .HasForeignKey(e => e.QuestionId)
                .OnDelete(DeleteBehavior.Cascade)
                .IsRequired();

        }
    }
