
using Microsoft.AspNetCore.Mvc;
using System.Data;
using MySql.Data.MySqlClient;

namespace backend.Controllers;

[ApiController]
[Route("[controller]")]
public class ResetController : ControllerBase
{
    private readonly ILogger<ResetController> _logger;

    public ResetController(ILogger<ResetController> logger)
    {
        _logger = logger;
    }

    [HttpGet(Name = "Reset")]
    public void Reset()
    {
        Console.WriteLine("called reset func");
        try 
            { 
                string connString = "server=localhost;user=root;database=sys;port=3306;password=my_password2";
         
                using (MySqlConnection connection = new MySqlConnection(connString))
                {
                    connection.Open();

                    List<string> tableNames = new List<string>(){ "t1","t2","t3","t4","t5" };

                    foreach(string tableName in tableNames){
                        String query = "CREATE TABLE IF NOT EXISTS `sys`.`" + tableName + "` (`id` INT NOT NULL, PRIMARY KEY (`id`));";
                        Console.WriteLine(query);
                        MySqlCommand cmd = new MySqlCommand(query, connection);
                        MySqlDataReader reader = cmd.ExecuteReader();
                        reader.Close();
                    }

                    connection.Close();

                    
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
    }
}
