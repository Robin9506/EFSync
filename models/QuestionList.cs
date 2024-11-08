    public class QuestionList : BaseEntity
    {
        public SystemType? SystemType {get; set;}
        public int SystemTypeId {get; set;}
        public int SystemPhase { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public ICollection<QuestionListSection> QuestionListSections { get; set; }
    }