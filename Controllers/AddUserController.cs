using CRM_Portal.BLL;
using Microsoft.AspNetCore.Mvc;
using CRM_Portal.Data;
using CRM_Portal.Models.Entity;
using CRM_Portal.Models;


namespace CRM_Portal.Controllers
{
    [Route("API")]
    public class AddUserController : Controller
    {
        [HttpPost("CreateCustomer")]

        public ActionResult<Base> CreateCustomer([FromBody] AddUser addUser)
        {


            if (ModelState.IsValid)
            {
                UserBLL userBLL = new UserBLL();
                return Ok(userBLL.addCustomer(addUser));

            }
            else
            {
                return BadRequest();
            }
        }
        [HttpPost("Login")]

        public ActionResult<LoginCustomerResponse> Login([FromBody] LoginCustomerRequest loginCustomerRequest)
        {


            if (ModelState.IsValid)
            {
                UserBLL userBLL = new UserBLL();
                return Ok(userBLL.LoginUser(loginCustomerRequest));

            }
            else
            {
                return BadRequest();
            }
        }
        [HttpPost("AddCars")]

        public ActionResult<Base> Add_Cars([FromBody] AddCarsRequest addCarsRequest)
        {


            if (ModelState.IsValid)
            {
                UserBLL userBLL = new UserBLL();
                return Ok(userBLL.AddCarsBLL(addCarsRequest));

            }
            else
            {
                return BadRequest();
            }
        }
        [HttpGet("AllCars")]

        public ActionResult<ProfilecarsResponse> AllCars()
        {


            if (ModelState.IsValid)
            {
                UserBLL userBLL = new UserBLL();
                return Ok(userBLL.ShowAllCarsBll());

            }
            else
            {
                return BadRequest(ModelState);
            }
        }
        [HttpPut("UpdateCarDetails")]

        public ActionResult<UpdateCarResponse> UpdateCarDetails(UpdateCarRequest updateCarRequest)
        {


            if (ModelState.IsValid)
            {
                UserBLL userBLL = new UserBLL();
                return Ok(userBLL.UpdateCarsBLL(updateCarRequest));

            }
            else
            {
                return BadRequest(ModelState);
            }
        }
        [HttpDelete("DeleteCar")]

        public ActionResult<DeleteCarResponse> DeleteCar([FromBody] DeletecarRequest deletecarRequest)
        {


            if (ModelState.IsValid)
            {
                UserBLL userBLL = new UserBLL();
                return Ok(userBLL.DeleteCarBLL(deletecarRequest));

            }
            else
            {
                return BadRequest(ModelState);
            }
        }
        [HttpGet("SearchCar")]

        public ActionResult<SearchCarResponse> Search_Car([FromQuery] SearchCarRequest searchCarRequest)
        {


            if (ModelState.IsValid)
            {
                UserBLL userBLL = new UserBLL();
                return Ok(userBLL.SearchCarBLL(searchCarRequest));

            }
            else
            {
                return BadRequest(ModelState);
            }
        }
        [HttpPost("TaskManagement")]
        public ActionResult<AddTaskResponse> TaskManagement([FromBody] AddTask addTask)
        {
            if (ModelState.IsValid)
            {
                UserBLL userBLL = new UserBLL();
                return Ok(userBLL.AddTaskBLL(addTask));
            }
            else
            {
                return BadRequest();
            }
        }
        [HttpGet("AllTasks")]

        public ActionResult<ShowTaskResponse> AllTasks()
        {


            if (ModelState.IsValid)
            {
                UserBLL userBLL = new UserBLL();
                return Ok(userBLL.ShowAllTasksBLL());

            }
            else
            {
                return BadRequest(ModelState);
            }
        }
        [HttpDelete("DeleteTask")]

        public ActionResult<DeleteTaskResponse> DeleteTask([FromBody] DeleteTaskRequest deleteTaskRequest)
        {


            if (ModelState.IsValid)
            {
                UserBLL userBLL = new UserBLL();
                return Ok(userBLL.DeleteTaskBLL(deleteTaskRequest));

            }
            else
            {
                return BadRequest(ModelState);
            }
        }
        [HttpPost("AddOpportunity")]
        public ActionResult<AddPipelineResponse> AddOpportunity([FromBody] AddPipeline addPipeline)
        {
            if (ModelState.IsValid)
            {
                UserBLL userBLL = new UserBLL();
                return Ok(userBLL.AddOpportunityBLL(addPipeline));
            }
            else
            {
                return BadRequest();
            }
        }
        [HttpPost("UpdateProfile")]
        public ActionResult<ProfileUpdateResponse> UpdateProfile([FromBody] ProfileupdateRequest profileupdateRequest)
        {
            if (ModelState.IsValid)
            {
                UserBLL userBLL = new UserBLL();
                return Ok(userBLL.UpdateProfileBLL(profileupdateRequest));
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpPost("GeneratTicket")]

        public ActionResult<CustomerTicketResponse> GeneratTicket([FromBody] AddTickets addTickets)
        {


            if (ModelState.IsValid)
            {
                UserBLL userBLL = new UserBLL();
                return Ok(userBLL.GenerateTickeBLL(addTickets));

            }
            else
            {
                return BadRequest(ModelState);
            }
        }


    }
}
