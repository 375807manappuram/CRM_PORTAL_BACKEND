using Microsoft.Data.SqlClient;
using System.Data;
using CRM_Portal.Data;
//using SKbooks.Data;
using CRM_Portal.Models.Entity;
using CRM_Portal.Models;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Azure;
using System.Collections;

namespace CRM_Portal.BLL
{
    public class UserBLL
    {
        public Base addCustomer(AddUser addUser)
        {

            //string UniquiID = Guid.NewGuid().ToString();

            Base res = new Base();

            try
            {
                DBhelper helper = new DBhelper();
                string usertype = addUser.UserType;
                //if (usertype == "Customer")
                //{

                //    string sql = "insert into users(Name,Email,Password,Phone,Address,UserType)values('" + addUser.Name + "','" + addUser.Email + "','" + addUser.password + "'," + addUser.phno + ",'" + addUser.address + "','" + addUser.UserType + "')";
                //    helper.Exexecutenonquery(sql);
                //}
                //else
                //{
                string sql = "insert into users(Name,Email,Password,Phone,Address,UserType,Empcode)values('" + addUser.Name + "','" + addUser.Email + "','" + addUser.password + "'," + addUser.phno + ",'" + addUser.address + "','" + addUser.UserType + "'," + addUser.Empcode + ")";
                helper.Exexecutenonquery(sql);
                //}
                res.Status.code = ResponseStatus.success;
                res.Status.message = "Registered Successfully !!";
            }

            catch (Exception ex)
            {
                res.Status.code = ResponseStatus.failed; ;
                res.Status.message = ex.Message;
            }

            return res;
        }
        public LoginCustomerResponse LoginUser(LoginCustomerRequest loginCustomerRequest)
        {

            LoginCustomerResponse response = new LoginCustomerResponse();

            try
            {
                DBhelper helper = new DBhelper();
                DataTable dt = new DataTable();
                string usertype = loginCustomerRequest.UserType;
                if (!string.IsNullOrEmpty(loginCustomerRequest.Email) && !string.IsNullOrEmpty(loginCustomerRequest.password))
                {

                    string sql = "select users.id,users.Name,users.Email,users.Phone,users.Address,users.UserType,users.Empcode from users where users.Email='" + loginCustomerRequest.Email + "' and users.Password='" + loginCustomerRequest.password + "'";
                    dt = helper.ExecuteDataSet(sql).Tables[0];

                    if (dt.Rows.Count > 0)
                    {
                        response.Id = Convert.ToInt32(dt.Rows[0][0]);
                        response.Name = dt.Rows[0][1].ToString();
                        response.Email = dt.Rows[0][2].ToString();
                        response.phno = Convert.ToInt64(dt.Rows[0][3]);
                        response.address = dt.Rows[0][4].ToString();
                        response.UserType = dt.Rows[0][5].ToString();
                        response.Empcode = Convert.ToInt64(dt.Rows[0][6]);
                        response.Status.code = ResponseStatus.success;
                        response.Status.message = "Successfully logged in! You can now proceed. !!";
                    }
                    else
                    {
                        response.Status.code = ResponseStatus.failed;
                        response.Status.message = "Invalid Credential, Please Register Account !!!";
                    }

                }
                else
                {

                    response.Status.code = ResponseStatus.failed;
                    response.Status.message = "Something went wrong.Please check your credentials  !!!";
                }

            }

            catch (Exception ex)
            {

                response.Status.code = ResponseStatus.failed;
                response.Status.message = ex.Message;
            }

            return response;
        }
        // add cars

        public Base AddCarsBLL(AddCarsRequest addCarsRequest)
        {
            Base res = new Base();

            try
            {
                DBhelper helper = new DBhelper();

                // Ensure that the Pic field is properly formatted for SQL
                string pic = string.IsNullOrEmpty(addCarsRequest.Pic) ? "NULL" : "'" + addCarsRequest.Pic + "'";

                // Construct the SQL query using string concatenation
                string sql = "INSERT INTO cars (CarName, Pic, Price, Country, Year, Description, Warranty, BrandName) " +
                             "VALUES ('" + addCarsRequest.CarName + "', " + pic + ", " + addCarsRequest.price + ", '" +
                             addCarsRequest.country + "', " + addCarsRequest.Year + ", '" + addCarsRequest.Description + "', '" +
                             addCarsRequest.Warranty + "', '" + addCarsRequest.BrandName + "')";

                helper.Exexecutenonquery(sql);

                res.Status.code = ResponseStatus.success;
                res.Status.message = "New car added successfully !!";
            }
            catch (Exception ex)
            {
                res.Status.code = ResponseStatus.failed;
                res.Status.message = ex.Message; // Consider logging the exception
            }

            return res;
        }

        
        //show cars
        public ProfilecarsResponse ShowAllCarsBll()
        {
            List<ShowCarsResponse> responseList = new List<ShowCarsResponse>();
            ProfilecarsResponse response = new ProfilecarsResponse();
            try
            {
                DBhelper helper = new DBhelper();
                DataTable dt = new DataTable();

                string sql = "SELECT t.Id,t.BrandName, t.CarName, t.Pic, t.price, t.country, t.Year, t.Description,t.Warranty FROM cars t";
                dt = helper.ExecuteDataSet(sql).Tables[0];

                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow row in dt.Rows)
                    {

                        responseList.Add(new ShowCarsResponse()
                        {
                            Id = Convert.ToInt32(row[0]),
                            BrandName = row[1].ToString(),
                            CarName = row[2].ToString(),
                            Pic = row[3].ToString(),
                            price = Convert.ToInt64(row[4]),
                            country = row[5].ToString(),
                            Year = Convert.ToInt32(row[6].ToString()),
                            Description = row[7].ToString(),
                            Warranty = row[8].ToString()

                        });
                    }

                    response.Cars.AddRange(responseList);
                    response.Status.code = ResponseStatus.success;
                    response.Status.message = "Cars retrieved successfully.";


                }
                else
                {
                    response.Status.code = ResponseStatus.failed;
                    response.Status.message = "No Cars found !!";
                }
            }
            catch (Exception ex)
            {
                response.Status.code = ResponseStatus.failed;
                response.Status.message = ex.Message;
            }

            return response;
        }

        public UpdateCarResponse UpdateCarsBLL(UpdateCarRequest updateCarRequest)
        {

            UpdateCarResponse res = new UpdateCarResponse();

            try
            {
                DBhelper helper = new DBhelper();

                string sql = "update cars set CarName='"+updateCarRequest.CarName+"', price=" + updateCarRequest.price + ",country='" + updateCarRequest.country + "',Year=" + updateCarRequest.Year + ",Description='" + updateCarRequest.Description + "',Warranty='" + updateCarRequest.Warranty + "' where Id=" + updateCarRequest.Id + "";
                helper.Exexecutenonquery(sql);

                res.Status.code = ResponseStatus.success;
                res.Status.message = "Updated details successfully !!";
            }

            catch (Exception ex)
            {
                res.Status.code = ResponseStatus.failed; ;
                res.Status.message = ex.Message;
            }

            return res;
        }
        //delete car
        public DeleteCarResponse DeleteCarBLL(DeletecarRequest deletecarRequest)
        {
            DeleteCarResponse res = new DeleteCarResponse();

            try
            {
                // Validate that the ID is a valid integer
                if (deletecarRequest.Id <= 0)
                {
                    res.Status.code = ResponseStatus.failed;
                    res.Status.message = "Invalid car ID.";
                    return res;
                }

                   DBhelper helper = new DBhelper();
                
                    // Construct the SQL query safely
                    string sql = "DELETE FROM cars WHERE id=" + deletecarRequest.Id;
                    helper.Exexecutenonquery(sql);

                    res.Status.code = ResponseStatus.success;
                    res.Status.message = "Car deleted!";
               
            }
            catch (Exception ex)
            {
                res.Status.code = ResponseStatus.failed;
                res.Status.message = ex.Message;
            }

            return res;
        }

        //search car by id

        public SearchCarResponse SearchCarBLL(SearchCarRequest searchCarRequest)
        {
            SearchCarResponse response = new SearchCarResponse();
            try
            {
                DBhelper helper = new DBhelper();
                DataTable dt = new DataTable();
                if (searchCarRequest.Id <= 0)
                {
                    response.Status.code = ResponseStatus.failed;
                    response.Status.message = "Invalid car ID!";
                    return response;
                }
                string sql = "SELECT t.BrandName, t.CarName,t.price, t.country, t.Year, t.Description,t.Warranty,t.pic FROM cars t where t.id="+searchCarRequest.Id+"";
                dt = helper.ExecuteDataSet(sql).Tables[0];

                if (dt.Rows.Count > 0)
                {

                    response.BrandName = dt.Rows[0][0].ToString();
                    response.CarName = dt.Rows[0][1].ToString();
                    response.price = Convert.ToInt64(dt.Rows[0][2]);
                    response.country = dt.Rows[0][3].ToString();
                    response.Year = Convert.ToInt32(dt.Rows[0][4].ToString());
                    response.Description = dt.Rows[0][5].ToString();
                    response.Warranty = dt.Rows[0][6].ToString();
                    response.pic = dt.Rows[0][7].ToString();

                    response.Status.code = ResponseStatus.success;
                    response.Status.message = "Cars retrieved successfully  !!";


                }
                else
                {
                    response.Status.code = ResponseStatus.failed;
                    response.Status.message = "No Cars found !!";
                }
            }
            catch (Exception ex)
            {
                response.Status.code = ResponseStatus.failed;
                response.Status.message = ex.Message;
            }

            return response;
        }
        // Helper method to convert Base64 string to image URL
        private string ConvertBase64ToImageUrl(string base64String)
        {
            if (string.IsNullOrEmpty(base64String))
            {
                return null; // or return a default image URL
            }

            // Assuming the Base64 string is in the format "data:image/png;base64,..."
            return $"data:image/png;base64,{base64String}";
        }

        // add task
        public Base AddTaskBLL(AddTask addTask)
        {
            Base res = new Base();

            try
            {
                DBhelper helper = new DBhelper();

                // Generate a new GUID for the task Id
                Guid newTaskId = Guid.NewGuid();

                // Construct the SQL query using string interpolation
                string sql = $"INSERT INTO taskManages (Id, Title, Description, status, assigned_emp) VALUES ('{newTaskId}', '{addTask.Title.Replace("'", "''")}', '{addTask.Description.Replace("'", "''")}', 'Assigned',{addTask.assigned_emp})";

                // Execute the query
                helper.Exexecutenonquery(sql);

                res.Status.code = ResponseStatus.success;
                res.Status.message = "New Task added successfully !!";
            }
            catch (Exception ex)
            {
                res.Status.code = ResponseStatus.failed;
                res.Status.message = ex.Message;
            }

            return res;
        }

        // show tasks

        public ShowTaskResponse ShowAllTasksBLL()
        {
            List<AllTask> responseList = new List<AllTask>();
            ShowTaskResponse response = new ShowTaskResponse();
            try
            {
                DBhelper helper = new DBhelper();
                DataTable dt = new DataTable();

                string sql = "SELECT t.Id,t.Title, t.Description,t.status,t.assigned_emp FROM taskManages t";
                dt = helper.ExecuteDataSet(sql).Tables[0];

                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow row in dt.Rows)
                    {

                        responseList.Add(new AllTask()
                        {
                            Id = Guid.NewGuid(),
                            Title = row[1].ToString(),
                            Description = row[2].ToString(),
                            status = row[3].ToString(),
                            assigned_emp = Convert.ToInt64(row[4])
                        });
                    }

                    response.Tasks.AddRange(responseList);
                    response.Status.code = ResponseStatus.success;
                    response.Status.message = "Task List retrieving !!.";


                }
                else
                {
                    response.Status.code = ResponseStatus.failed;
                    response.Status.message = "No Task found !!";
                }
            }
            catch (Exception ex)
            {
                response.Status.code = ResponseStatus.failed;
                response.Status.message = ex.Message;
            }

            return response;
        }
        // delete task
        public DeleteTaskResponse DeleteTaskBLL(DeleteTaskRequest deleteTaskRequest)
        {
            DeleteTaskResponse res = new DeleteTaskResponse();

            try
            {
                DBhelper helper = new DBhelper();

                // Construct the SQL query using string interpolation
                string sql = "delete from taskManages where taskManages.id='"+deleteTaskRequest.Id+"'";

                // Execute the query
                helper.Exexecutenonquery(sql);

                res.Status.code = ResponseStatus.success;
                res.Status.message = "Task Deleted !!";
            }
            catch (Exception ex)
            {
                res.Status.code = ResponseStatus.failed;
                res.Status.message = ex.Message;
            }

            return res;
        }
        // add opportunities
        public Base AddOpportunityBLL(AddPipeline addPipeline)
        {
            Base res = new Base();

            try
            {
                DBhelper helper = new DBhelper();
                Guid NewId = Guid.NewGuid();
           
                string sql = "INSERT INTO pipelines (Id, StageId, Stage, OpportunityName, Description, CreatedAt) " +
                             $"VALUES ('{NewId}', {addPipeline.StageId}, '{addPipeline.Stage}', " +
                             $"'{addPipeline.OpportunityName}', '{addPipeline.Description}', GETDATE())";

                helper.Exexecutenonquery(sql);

                res.Status.code = ResponseStatus.success;
                res.Status.message = "New Opportunity added successfully!";
            }
            catch (Exception ex)
            {
                res.Status.code = ResponseStatus.failed;
                res.Status.message = ex.Message;
            }

            return res;
        }
        // update profile
        public ProfileUpdateResponse UpdateProfileBLL(ProfileupdateRequest profileupdateRequest)
        {

            ProfileUpdateResponse res = new ProfileUpdateResponse();

            try
            {
                DBhelper helper = new DBhelper();

                string sql = "update users set Name='"+profileupdateRequest.Name+"' ,Email='"+profileupdateRequest.Email+"',Phone='" + profileupdateRequest.phno + "',Address='" + profileupdateRequest.address + "' where Id=" + profileupdateRequest.Id +"";
                helper.Exexecutenonquery(sql);

                res.Status.code = ResponseStatus.success;
                res.Status.message = "Updated details successfully !!";
            }

            catch (Exception ex)
            {
                res.Status.code = ResponseStatus.failed; ;
                res.Status.message = ex.Message;
            }

            return res;
        }
        // create tickets
        public CustomerTicketResponse GenerateTickeBLL(AddTickets addTickets)
        {
            CustomerTicketResponse res = new CustomerTicketResponse();

            try
            {
                DBhelper helper = new DBhelper();

                // Construct the SQL query using string concatenation
                string sql = "insert into tickets(Cust_id,Cust_Name,Email,Phone,Ticket_no,Reason,status) " +
                             "VALUES (" + addTickets.Cust_id + ", '" + addTickets.Cust_Name + "', '" + addTickets.Email + "', " +
                addTickets.Phone + ", NEXT VALUE FOR TicketNumberSequence1 , '" + addTickets.Reason + "', '" +
                             0 + "')";

                helper.Exexecutenonquery(sql);


                string sql1 = "select ticket_no from tickets where cust_id=" + addTickets.Cust_id + "";
                DataTable val = helper.ExecuteDataSet(sql1).Tables[0];
                res.Status.code = ResponseStatus.success;
                res.Status.message = "Your Complaint Has Registered Successfully.Complaint Number is : " + val.Rows[0][0] + " !!";
            }
            catch (Exception ex)
            {
                res.Status.code = ResponseStatus.failed;
                res.Status.message = ex.Message; // Consider logging the exception
            }

            return res;
        }



    }
}
