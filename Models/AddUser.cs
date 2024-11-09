namespace CRM_Portal.Models
{
    public class AddUser
    {
        public  string Name { get; set; }
        public  string Email { get; set; }
        public  string password { get; set; }
        public  long phno { get; set; }
        public string address { get; set; }
        public string UserType { get; set; }
        public long Empcode { get; set; }
    }


    //public class SuccessStatus
    //{
    //    public int status { get; set; }
    //    public string message { get; set; }
        
    //}

    public class LoginCustomerRequest
    {
        public string Email { get; set; }
        public string password { get; set; }
        public string UserType { get; set; }

    }
    public class LoginCustomerResponse: Base
    {

        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public long phno { get; set; }
        public string address { get; set; }
        public string UserType { get; set; }
        public long Empcode { get; set; }

        
    }
    public class CustomerdtlRequest
    {
        public int Id { get; set; }
    }
    public class ProfileupdateRequest
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public long phno { get; set; }
        public string address { get; set; }
    }
    public class ProfileUpdateResponse:Base
    {

    }

}


