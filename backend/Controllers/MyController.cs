using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Data.SqlClient;

namespace backend.Controllers;

[ApiController]
[Route("[controller]")]
public class MyController : ControllerBase
{
    private readonly ILogger<MyController> _logger;

    public MyController(ILogger<MyController> logger)
    {
        _logger = logger;
    }


    [HttpPost(Name = "ReceiveData")]
    public void Post()
    {
        try 
            { 
                SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();

                builder.DataSource = "https://127.0.0.1:3307"; 
                builder.UserID = "root";            
                builder.Password = "";     
                builder.InitialCatalog = "MySQL";
         
                using (SqlConnection connection = new SqlConnection(builder.ConnectionString))
                {
                    Console.WriteLine("\nQuery data example:");
                    Console.WriteLine("=========================================\n");
                    
                    connection.Open();       

                    String sql = "SELECT id, un, pw FROM sys.Tables.APP_USERS";

                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Console.WriteLine("{0} {1}", reader.GetString(0), reader.GetString(1));
                            }
                        }
                    }                   
                }
            }
            catch (SqlException e)
            {
                Console.WriteLine(e.ToString());
            }
        Console.WriteLine("f");
        //Debug.WriteLine("f2");
    }
}
