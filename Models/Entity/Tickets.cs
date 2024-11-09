namespace CRM_Portal.Models.Entity
{
    public class Tickets
    {
        public int Id { get; set; }
        public long Cust_id { get; set; }
        public string Cust_Name { get; set; }
        public string Email { get; set; }
        public long Phone { get; set; }
        public long Ticket_no { get; set; }
        public string Reason { get; set; }
        public int status { get; set; }
    }
}
