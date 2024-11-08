
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
public class Question : BaseEntity {

    public string Name { get; set; }
    public int QuestionListSectionId { get; set; }
    public QuestionListSection QuestionListSection { get; set; }
    public int? ENSIAQuestionMetadataId {get; set;}
    public ENSIAQuestionMetadata? ENSIAQuestionMetadata { get; set; }
    public int? LinkedChoiceId { get; set; }
    public SingleChoiceOption LinkedChoice { get; set; }
    public ICollection<SingleChoiceOption> SingleChoiceOptions { get; set; }
    public ICollection<MultipleChoiceOption> MultipleChoiceOptions { get; set; }	
}