namespace CRM_Portal.Models.Entity
{
    public class User
    {
        public int Id { get; set; } 
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public long Phone { get; set; }
        public string Address { get; set; }
        public string UserType { get; set; }
        public long Empcode { get; set; }
       // public string Created { get; set; }

    }
}
