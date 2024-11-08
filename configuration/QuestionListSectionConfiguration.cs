using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class QuestionListSectionConfiguration : IEntityTypeConfiguration<QuestionListSection>
{
    public void Configure(EntityTypeBuilder<QuestionListSection> builder)
    {
        builder.HasKey(e => e.Id);

        builder.HasOne(e => e.QuestionList)
            .WithMany(a => a.QuestionListSections)
            .HasForeignKey(e => e.QuestionListId)
            .OnDelete(DeleteBehavior.Cascade)
            .IsRequired();

    }
}

