namespace CRM_Portal.Models
{

    public class Base
    {
        public Base()
        {
            Status = new ResponseBase();
            Status.message = "Failed";
        }
        public ResponseBase Status { get; set; }

    }

    public class ResponseBase
    {
        public ResponseStatus code { get; set; }
        public string message { get; set; }
    }

    public enum ResponseStatus
    {
        success = 1,
        failed = 0,
        exception = 3
    }
}
