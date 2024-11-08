 public class ENSIAQuestionMetadata : BaseEntity
    {
        public int QuestionId { get; set; }
        public Question Question { get; set; }
        public string ENSIACode { get; set; }
        public string ENSIAId { get; set; }
        public string ExternalQuestionId { get; set;}
        public bool? AdditionalMeasure { get; set; }

    }