using EFSync;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;


namespace EFSync
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var target = new TargetContext();
            using (var source = new SourceContext())
            {
                var systemTypesInSource = source.SystemType.ToList();
                var questionListsInSource = source.QuestionList.ToList();
                if(systemTypesInSource.Count < 1 || questionListsInSource.Count < 1){
                    SetDefaultItems(source, target);
                }

                SynchronizeQuestionListsToTarget(source, target);
                // GetQuestionListsSource(source);
                // GetQuestionListsTarget(target);
            }
        }

        public static void SynchronizeQuestionListsToTarget(SourceContext source, TargetContext target){
                var watch = System.Diagnostics.Stopwatch.StartNew();

                var sourceQuestionList = source.QuestionList
                .Include(ql => ql.SystemType)
                .Include(ql => ql.QuestionListSections)
                    .ThenInclude(ql => ql.Questions)
                        .ThenInclude(q => q.SingleChoiceOptions)
                .Include(ql => ql.QuestionListSections)
                    .ThenInclude(ql => ql.Questions)
                        .ThenInclude(q => q.MultipleChoiceOptions)
                .Include(ql => ql.QuestionListSections)
                    .ThenInclude(ql => ql.Questions)
                        .ThenInclude(q => q.ENSIAQuestionMetadata)
                .ToList();

                var defaultSystemType = target.SystemType.Where(st => st.Name == "Generiek").FirstOrDefault();
                if (defaultSystemType == null){
                    target.SystemType.Add(new SystemType{ Name = "Generiek"});
                    target.SaveChanges();
                }
                
                var targetQuestionList = target.QuestionList
                .Include(ql => ql.SystemType)
                .Include(ql => ql.QuestionListSections)
                    .ThenInclude(ql => ql.Questions)
                        .ThenInclude(q => q.SingleChoiceOptions)
                .Include(ql => ql.QuestionListSections)
                    .ThenInclude(ql => ql.Questions)
                        .ThenInclude(q => q.MultipleChoiceOptions)
                .Include(ql => ql.QuestionListSections)
                    .ThenInclude(ql => ql.Questions)
                        .ThenInclude(q => q.ENSIAQuestionMetadata)
                .ToList();
                
                if (sourceQuestionList.Count > 0){

                    var unAddedQuestionList = sourceQuestionList.Where(ql => !targetQuestionList.Any(ql2 => 
                    ql.SystemType.Name == ql2.SystemType.Name
                    && ql.StartDate == ql2.StartDate
                    && ql.EndDate == ql2.EndDate
                    )).ToList();

                    Console.WriteLine(unAddedQuestionList.Count);

                   foreach (var list in unAddedQuestionList)
                    {

                        var type = target.SystemType.Where(st => st.Name == list.SystemType.Name).FirstOrDefault();
                        var newQuestionList = new QuestionList
                        {
                            SystemType = type,
                            SystemPhase = list.SystemPhase,
                            QuestionListSections = list.QuestionListSections.Select(section =>
                                new QuestionListSection{
                                    Name = section.Name,
                                    Guid = section.Guid,
                                    Created = section.Created,
                                    
                                    Questions = section.Questions.Select(question => 
                                    
                                    new Question{
                                        Name = question.Name,
                                        Guid = question.Guid,
                                        Created = question.Created,
                                        SingleChoiceOptions = question.SingleChoiceOptions.Select(sco => 
                                        new SingleChoiceOption {
                                            Text = sco.Text,
                                            Classification = sco.Classification,
                                            Score = sco.Score,
                                            Index = sco.Index,
                                            CanHaveRemarkAnswer = sco.CanHaveRemarkAnswer,
                                            CanHaveLink = sco.CanHaveLink,
                                            CanGenerateTask = sco.CanGenerateTask,
                                            TaskName = sco.TaskName,
                                            TaskDescription = sco.TaskDescription,
                                            Explanation = sco.Explanation,
                                            ExternalId = sco.ExternalId,
                                            Compliant = sco.Compliant,
                                            Guid = sco.Guid,
                                            Created = sco.Created
                                        }   
                                        ).ToList() ?? new List<SingleChoiceOption>(),
                                        MultipleChoiceOptions = question.MultipleChoiceOptions.Select(mco => 
                                        new MultipleChoiceOption {
                                            Text = mco.Text,
                                            Score = mco.Score,
                                            Index = mco.Index,
                                            CanHaveRemarkAnswer = mco.CanHaveRemarkAnswer,
                                            CanHaveLink = mco.CanHaveLink,
                                            Explanation = mco.Explanation,
                                            ExternalId = mco.ExternalId,
                                            Compliant = mco.Compliant,
                                            Guid = mco.Guid,
                                            Created = mco.Created
                                        }).ToList() ?? new List<MultipleChoiceOption>(),
                                        ENSIAQuestionMetadata = question.ENSIAQuestionMetadata != null ? new ENSIAQuestionMetadata{
                                            ENSIACode = question.ENSIAQuestionMetadata.ENSIACode,
                                            ENSIAId = question.ENSIAQuestionMetadata.ENSIAId,
                                            ExternalQuestionId = question.ENSIAQuestionMetadata.ExternalQuestionId,
                                            AdditionalMeasure = question.ENSIAQuestionMetadata?.AdditionalMeasure
                                        } : null          
                                    }).ToList()         
                                }
                            ).ToList(),
                            StartDate = list.StartDate,
                            EndDate = list.EndDate,
                            Guid = list.Guid,
                            Created = list.Created
                        };

                        target.QuestionList.Add(newQuestionList);
                    }
                        target.SaveChanges();
                    }     

                        watch.Stop();
                        Console.WriteLine(watch.ElapsedMilliseconds);
                }
        
        public static void UpdateQuestionList(SourceContext source, TargetContext target){
                var sourceQuestionList =  source.QuestionList.Include(ql => ql.SystemType).ToList();

                foreach(var ql in sourceQuestionList){
                    var targetQuestionList =  target.QuestionList
                    .Include(ql => ql.SystemType)
                    .Where(qls => ql.SystemType.Id == qls.SystemType.Id 
                    && ql.StartDate== qls.StartDate
                    && ql.EndDate == qls.EndDate).SingleOrDefault();

                    if(targetQuestionList != null){
                        Console.WriteLine(targetQuestionList.StartDate);
                    }
                }             
        }

        public static void GetSameQuestionLists(SourceContext source, TargetContext target){
                var sourceQuestionList =  source.QuestionList.Include(ql => ql.SystemType).ToList();
              foreach(var ql in sourceQuestionList){
                    var targetQuestionList =  target.QuestionList
                    .Include(ql => ql.SystemType)
                    .Where(qls => ql.SystemType.Id == qls.SystemType.Id 
                    && ql.StartDate == qls.StartDate
                    && ql.EndDate == qls.EndDate).ToList();

                    if(targetQuestionList.Count > 0){
                        foreach(var tql in targetQuestionList){
                            Console.WriteLine(tql.StartDate);

                        }
                    }
                }
        }

        public static void GetQuestionListsSource(SourceContext context){
            var watch = System.Diagnostics.Stopwatch.StartNew();
            var questionLists =  context.QuestionList
                    .Include(ql => ql.SystemType)
                    .Include(ql => ql.QuestionListSections)
                     .ThenInclude(ql => ql.Questions)
                        .ThenInclude(q => q.SingleChoiceOptions)
                    .Include(ql => ql.QuestionListSections)
                     .ThenInclude(ql => ql.Questions)
                        .ThenInclude(q => q.MultipleChoiceOptions)
                    .Include(ql => ql.QuestionListSections)
                     .ThenInclude(ql => ql.Questions)
                        .ThenInclude(q => q.ENSIAQuestionMetadata)
                        // .Where(ql => ql.Guid == Guid.Parse("04de85fe-254b-4076-944b-80636e512355"))
                        .Where(ql => ql.SystemPhase >= 3150 && ql.SystemPhase < 3250) 

                    .ToList();

            watch.Stop();
            Console.WriteLine("Source Count: " + questionLists.Count);
            Console.WriteLine("Source: " + watch.ElapsedMilliseconds);
        }

        public static void GetQuestionListsTarget(TargetContext context){
            var watch = System.Diagnostics.Stopwatch.StartNew();
            var questionLists =  context.QuestionList
                    .Include(ql => ql.SystemType)
                    .Include(ql => ql.QuestionListSections)
                     .ThenInclude(ql => ql.Questions)
                        .ThenInclude(q => q.SingleChoiceOptions)
                    .Include(ql => ql.QuestionListSections)
                     .ThenInclude(ql => ql.Questions)
                        .ThenInclude(q => q.MultipleChoiceOptions)
                    .Include(ql => ql.QuestionListSections)
                     .ThenInclude(ql => ql.Questions)
                        .ThenInclude(q => q.ENSIAQuestionMetadata)
                    // .Where(ql => ql.Guid == Guid.Parse("5156e99b-347f-45e3-b3a3-1887234b1103"))
                    .Where(ql => ql.SystemPhase < 101) 
                    .ToList();

            watch.Stop();
            Console.WriteLine("Target Count: " + questionLists.Count);
            Console.WriteLine("Target: " + watch.ElapsedMilliseconds);
        }

        public static void SetDefaultItems(SourceContext source, TargetContext target){


                source.SystemType.Add(new SystemType{ Name = "Generiek"});
                source.SaveChanges();

                var defaultSystemType = target.SystemType.Where(st => st.Name == "Generiek").FirstOrDefault();
                if (defaultSystemType == null){
                    target.SystemType.Add(new SystemType{ Name = "Generiek"});
                    target.SaveChanges();
                }

                var types = source.SystemType.ToList();

                var questionList0 = new QuestionList{
                    SystemType = types[0],
                    SystemPhase = 1,
                    StartDate = DateTime.Now,
                    EndDate = DateTime.Now.AddDays(2),
                    Guid = Guid.NewGuid(),
                    Created = DateTime.Now
                };

                var questionList1 = new QuestionList{
                    SystemType = types[0],
                    SystemPhase = 2,
                    StartDate = DateTime.Now,
                    EndDate = DateTime.Now.AddDays(2),
                    Guid = Guid.NewGuid(),
                    Created = DateTime.Now
                };

                var questionList2 = new QuestionList{
                    SystemType = types[0],
                    SystemPhase = 1,
                    StartDate = DateTime.Now.AddDays(2),
                    EndDate = DateTime.Now.AddDays(3),
                    Guid = Guid.NewGuid(),
                    Created = DateTime.Now
                };

                source.QuestionList.Add(questionList0);
                source.QuestionList.Add(questionList1);
                source.QuestionList.Add(questionList2);

                var section0 = new QuestionListSection{
                    Name = "Sectie 1",
                    QuestionList = questionList0,
                    Guid = Guid.NewGuid(),
                    Created = DateTime.Now
                };

                var section1 = new QuestionListSection{
                    Name = "Sectie 2",
                    QuestionList = questionList1,
                    Guid = Guid.NewGuid(),
                    Created = DateTime.Now
                };

                source.QuestionListSection.Add(section0);
                source.QuestionListSection.Add(section1);

                var question0 = new Question{
                    Name = "Vraag 1 - Single",
                    QuestionListSection = section0,
                    Guid = Guid.NewGuid(),
                    Created = DateTime.Now
                };

                var question1 = new Question{
                    Name = "Vraag 2 - Multiple",
                    QuestionListSection = section1,
                    Guid = Guid.NewGuid(),
                    Created = DateTime.Now
                };

                source.Question.Add(question0);
                source.Question.Add(question1);

                var singleChoiceOption0 = new SingleChoiceOption{
                    Text = "Voldoet",
                    Classification = Classification.Low,
                    Score = 1,
                    Index = 0,
                    CanHaveRemarkAnswer = false,
                    CanHaveLink = false,
                    Explanation = "Eerst optie",
                    CanGenerateTask = false,
                    TaskName = null,
                    TaskDescription = null,
                    Question = question0,
                    ExternalId = null,
                    Compliant = false,
                    Guid = Guid.NewGuid(),
                    Created = DateTime.Now

                };

                var singleChoiceOption1 = new SingleChoiceOption{
                    Text = "Voldoet niet",
                    Classification = Classification.High,
                    Score = 0,
                    Index = 1,
                    CanHaveRemarkAnswer = false,
                    CanHaveLink = false,
                    Explanation = "Tweede optie",
                    CanGenerateTask = true,
                    TaskName = "Actie",
                    TaskDescription = "Dit is een actie die wordt aangemaakt",
                    Question = question0,
                    ExternalId = null,
                    Compliant = false,
                    Guid = Guid.NewGuid(),
                    Created = DateTime.Now

                };

                source.SingleChoiceOption.Add(singleChoiceOption0);
                source.SingleChoiceOption.Add(singleChoiceOption1);

                var multipleChoiceOption0 = new MultipleChoiceOption{
                    Text = "Huis",
                    Score = 1,
                    Index = 0,
                    CanHaveRemarkAnswer = false,
                    CanHaveLink = false,
                    Explanation = "Eerste optie",
                    Question = question1,
                    ExternalId = "117a",
                    Compliant = false,
                    Guid = Guid.NewGuid(),
                    Created = DateTime.Now

                };

                var multipleChoiceOption1 = new MultipleChoiceOption{
                    Text = "Auto",
                    Score = 1,
                    Index = 1,
                    CanHaveRemarkAnswer = false,
                    CanHaveLink = false,
                    Explanation = "Tweede optie",
                    Question = question1,
                    ExternalId = "117a",
                    Compliant = false,
                    Guid = Guid.NewGuid(),
                    Created = DateTime.Now

                };

                source.MultipleChoiceOption.Add(multipleChoiceOption0);
                source.MultipleChoiceOption.Add(multipleChoiceOption1);

                var metadata = new ENSIAQuestionMetadata{
                    ENSIACode = "Code 1",
                    ENSIAId = "1.0.0",
                    ExternalQuestionId = "117a",
                    AdditionalMeasure = false,
                    Question = question0,
                    Guid = Guid.NewGuid(),
                    Created = DateTime.Now
                };

                source.ENSIAQuestionMetadata.Add(metadata);

                source.SaveChanges();
        }
    }
}
