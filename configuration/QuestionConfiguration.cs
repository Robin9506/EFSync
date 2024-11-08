using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class QuestionConfiguration : IEntityTypeConfiguration<Question>
	{
		public void Configure(EntityTypeBuilder<Question> builder)
		{
			builder.HasKey(e => e.Id);

			builder.Property(e => e.Name)
				.IsRequired();

            builder.HasOne(e => e.QuestionListSection)
				.WithMany(a => a.Questions)
				.HasForeignKey(e => e.QuestionListSectionId)
				.OnDelete(DeleteBehavior.Cascade)
				.IsRequired();

            builder.HasOne(e => e.LinkedChoice)
				.WithMany(a => a.Questions)
				.HasForeignKey(e => e.LinkedChoiceId)
				.OnDelete(DeleteBehavior.NoAction);

			builder.HasOne(e => e.ENSIAQuestionMetadata)
				.WithOne(eqm => eqm.Question)
				.HasForeignKey<ENSIAQuestionMetadata>(eqm => eqm.QuestionId)
				.IsRequired(true);
		}
	}

