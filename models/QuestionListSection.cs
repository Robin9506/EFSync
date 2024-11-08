using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class QuestionListSection : BaseEntity
    {

        public string Name {get; set;}

        public int QuestionListId {get; set;}
        public QuestionList QuestionList { get; set; }

        public ICollection<Question> Questions { get; set; }
    }