namespace CRM_Portal.Models
{
    public class AddTickets
    {
        public long Cust_id { get; set; }
        public string Cust_Name { get; set; }
        public string Email { get; set; }
        public long Phone { get; set; }
        public string Reason { get; set; }
    }
    public class CustomerTicketResponse : Base
    {
        public long Ticket { get; set; }
    }
}
