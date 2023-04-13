using Microsoft.AspNetCore.Mvc;
//using Microsoft.AspNet.WebApi.Cors;
using System.Data;
using MySql.Data.MySqlClient;

namespace backend.Controllers;

[ApiController]
//[EnableCors("_myAllowAllOrigins")]
[Route("[controller]")]
public class MyController : ControllerBase
{
    private readonly ILogger<MyController> _logger;

    public MyController(ILogger<MyController> logger)
    {
        _logger = logger;
    }


    [HttpGet(Name = "ReceiveData")]
    public string Get(string un, string pw)
    {
        Console.WriteLine("called func", un, pw);
        try 
            { 
                string connString = "server=localhost;user=root;database=sys;port=3306;password=my_password2";
         
                using (MySqlConnection connection = new MySqlConnection(connString))
                {
                    
                    connection.Open();


                    String sql = "SELECT un, pw FROM APP_USERS WHERE un ='" + un + "';";



                    MySqlCommand cmd = new MySqlCommand(sql, connection);
                    MySqlDataReader reader = cmd.ExecuteReader();
                    
                    while (reader.Read()){
                        Console.WriteLine(reader["un"] + " " + reader["pw"]);
                    }

                    return "s";

                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                return "error";
            }
            return "just in case";
        //Debug.WriteLine("f2");
    }
}
