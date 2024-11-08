using EFSync;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Reflection;
public class SourceContext : DbContext
{
    public IConfiguration configuration;
    public DbSet<QuestionList> QuestionList { get; set; }
    public DbSet<QuestionListSection> QuestionListSection { get; set; }
    public DbSet<Question> Question { get; set; }
    public DbSet<SystemType> SystemType { get; set; }
    public DbSet<SingleChoiceOption> SingleChoiceOption { get; set; }
    public DbSet<MultipleChoiceOption> MultipleChoiceOption { get; set; }
    public DbSet<ENSIAQuestionMetadata> ENSIAQuestionMetadata { get; set; }

    public SourceContext()
    {
        configuration = new ConfigurationBuilder()
        .AddUserSecrets<Program>()
        .Build();
    }

    protected override void OnConfiguring(DbContextOptionsBuilder options)
        => options.UseSqlServer(configuration["ConnectionStrings:SourceConnection"]);

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly()); // <- Zorgt ervoor dat alle IEntityTypeConfiguration worden uitgevoerd
    }
}