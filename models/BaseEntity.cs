
public abstract class BaseEntity{
        public int Id { get; set; }
		public Guid Guid { get; set; }
		public DateTime Created { get; set; }
		public DateTime? Modified { get; set; }
		public DateTime? Deleted { get; set; }
		public DateTime? Archived { get; set; }
}