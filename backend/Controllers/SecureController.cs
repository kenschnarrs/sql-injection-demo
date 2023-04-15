using Microsoft.AspNetCore.Mvc;
using System.Data;
using MySql.Data.MySqlClient;

namespace backend.Controllers;

[ApiController]
[Route("[controller]")]
public class SecureController : ControllerBase
{
    private readonly ILogger<SecureController> _logger;

    public SecureController(ILogger<SecureController> logger)
    {
        _logger = logger;
    }


    [HttpGet(Name = "Secure")]
    public string[] Secure(string username)
    {
        Console.WriteLine("called secure func");
        Console.WriteLine(username);
        try 
            { 

                /*
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
                */
                using (MyDataContext context = new MyDataContext())
                {
                    var results = from s in context.APP_USERS
                                  where s.un = username
                                  select s;

                    return results.ToList();
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
