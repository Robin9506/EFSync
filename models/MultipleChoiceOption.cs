public class MultipleChoiceOption : BaseEntity
	{
		public string Text { get; set; }
		public int? Score { get; set; }
		public int Index { get; set; }
		public bool CanHaveRemarkAnswer { get; set; }
		public bool CanHaveLink { get; set; }
		public string Explanation { get; set; }
		public int QuestionId { get; set; }
        public string ExternalId { get; set; }
        public bool Compliant { get; set; }
        public Question Question { get; set; }
	}