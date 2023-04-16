using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

using System.Collections.Generic;
using System.Data;
using System.Linq;

using MySqlConnector;
using Dapper;

using backend.Models;
using backend.Data;

namespace backend.Controllers;

[ApiController]
[Route("[controller]")]
public class SecureController : ControllerBase
{
    private readonly ILogger<SecureController> _logger;
    private string _connString = "server=localhost;user=root;database=sys;port=3306;password=my_password2";

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
                using var connection = new MySqlConnection(_connString);
                connection.Open();
                var parameters = new { Username = username};
                var entities = connection.Query<MyEntity>("SELECT un FROM APP_USERS WHERE un=@Username;", parameters).ToArray();
                string[] queryResults = new string[10];
                int i = 0;
                foreach(MyEntity entity in entities){
                    queryResults[i] = entity.un;
                    i += 1;
                }

                connection.Close();
                return queryResults;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                string[] r = {"error"};
                return r;
            }
    }
}
