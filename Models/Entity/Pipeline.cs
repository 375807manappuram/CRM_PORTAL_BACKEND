namespace CRM_Portal.Models.Entity
{
    public class Pipeline
    {
        public Guid Id { get; set; }                  // Unique identifier for each opportunity
        public int StageId { get; set; }
        public string Stage { get; set; }             // The stage in the pipeline (e.g., "qualification")
        public string OpportunityName { get; set; }              // The name of the opportunity
        public string Description { get; set; }       // A brief description of the opportunity (optional)
        public DateTime? CreatedAt { get; set; }      // Timestamp of when the opportunity was created (optional)
    }
}
