namespace CRM_Portal.Models
{
    public class AddPipeline
    {
        public Guid Id { get; set; }
        public int StageId { get; set; }
        public string Stage { get; set; }           
        public string OpportunityName { get; set; }            
        public string Description { get; set; }     
        public DateTime? CreatedAt { get; set; }      
    }
    public class AddPipelineResponse : Base
    {

    }
}
