public class SingleChoiceOption : BaseEntity
	{
		public string Text { get; set; }
		public Classification Classification {get; set;}
		public int? Score { get; set; }
		public int Index { get; set; }
		public bool CanHaveRemarkAnswer { get; set; }
		public bool CanHaveLink { get; set; }
		public string? Explanation { get; set; }
		public bool CanGenerateTask { get; set; }
		public string? TaskName { get; set; }
		public string? TaskDescription { get; set; }
		public int QuestionId { get; set; }
		public Question Question { get; set; }
		public string? ExternalId { get; set; }
		public bool Compliant { get; set; }
		public ICollection<Question> Questions { get; set; }
		
	}