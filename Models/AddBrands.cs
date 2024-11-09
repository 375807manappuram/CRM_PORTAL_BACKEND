using System.Collections;

namespace CRM_Portal.Models
{
   
    // show all car response
    public class AddBrands: Base
    {
        public int Id { get; set; }
        public string BrandName { get; set; }
        public string Logo { get; set; }
      
    }
    public class AddCarsRequest
    {
      //  public int Id { get; set; }
        public string CarName { get; set; }
        public string Pic { get; set; }
        public double price { get; set; }
        public string country { get; set; }
        public int Year { get; set; }
        public string Description { get; set; }
        public string Warranty { get; set; }
        public string BrandName { get; set; }

    }
    public class AddCarsRsponse : Base
    {

    }
    public class ShowCarsResponse
    {
        public int Id { get; set; }
        public string BrandName { get; set; }
        public string CarName { get; set; }
        public string Pic { get; set; }
        public double price { get; set; }
        public string country { get; set; }
        public int Year { get; set; }
        public string Warranty { get; set; }
        public string Description { get; set; }
      


    }

    public class ProfilecarsResponse: Base
    {
       
        public List<ShowCarsResponse> Cars { get; set; } = new List<ShowCarsResponse>();
    }


    public class UpdateCarRequest
    {    
        public int Id { get; set; }
        public string CarName { get; set; }
        public double price { get; set; }
        public string country { get; set; }
        public int Year { get; set; }
        public string Warranty { get; set; }
        public string Description { get; set; }
    }
    public class UpdateCarResponse:Base
    {
       
    }
    public class SearchCarRequest
    {
        public int Id { get; set; }
    }
   
    public class SearchCarResponse:Base
    {
        public string BrandName { get; set; }
        public string CarName { get; set; }
        public double price { get; set; }
        public string country { get; set; }
        public int Year { get; set; }
        public string Warranty { get; set; }
        public string Description { get; set; }
        public string pic {  get; set; }
    }
    public class DeletecarRequest
    {
        public int Id { get; set; }
    }
    public class DeleteCarResponse:Base
    {

    }
}
