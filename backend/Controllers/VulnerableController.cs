using Microsoft.AspNetCore.Mvc;
using System.Data;
using MySql.Data.MySqlClient;

namespace backend.Controllers;

[ApiController]
[Route("[controller]")]
public class VulnerableController : ControllerBase
{
    private readonly ILogger<VulnerableController> _logger;

    public VulnerableController(ILogger<VulnerableController> logger)
    {
        _logger = logger;
    }


    [HttpGet(Name = "Vulnerable")]
    public string[] Vulnerable(string username)
    {
        Console.WriteLine("called func");
        Console.WriteLine(username);
        try 
            { 
                string connString = "server=localhost;user=root;database=sys;port=3306;password=my_password2";
         
                using (MySqlConnection connection = new MySqlConnection(connString))
                {
                    
                    connection.Open();

                    String query = "SELECT un FROM APP_USERS WHERE un='" + username + "';";
                    Console.WriteLine(query);
                    MySqlCommand cmd = new MySqlCommand(query, connection);
                    MySqlDataReader reader = cmd.ExecuteReader();
                    
                    Console.WriteLine("reading data");
                    string[] queryResults = new string[10];
                    int i = 0;
                    while (reader.Read()){

                        //queryResults.Push((string)reader["un"][0]);
                        queryResults[i] = (string)reader["un"];
                        i += 1;
                        Console.WriteLine((string)reader["un"]);
                    }

                    connection.Close();
                    
                    return queryResults;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                string[] r = {"error"};
                return r;
            }
    }
}
