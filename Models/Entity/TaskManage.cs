namespace CRM_Portal.Models.Entity
{
    public class TaskManage
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string status { get; set; }
        public long assigned_emp {  get; set; }
    }
}
