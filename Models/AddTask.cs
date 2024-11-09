namespace CRM_Portal.Models
{
    public class AddTask
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
       // public string status { get; set; }
        public long assigned_emp { get; set; }
    }
    public class AddTaskResponse : Base
    {

    }
    public class ShowTaskResponse:Base
    {
        public List<AllTask> Tasks { get; set; } = new List<AllTask>();
        
    }
    public class AllTask
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string status { get; set; }
        public long assigned_emp { get; set; }
    }
    public class DeleteTaskRequest
    {
        public Guid Id { get; set; }
    }
    public class DeleteTaskResponse : Base
    {

    }
}
