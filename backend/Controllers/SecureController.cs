using Microsoft.AspNetCore.Mvc;

using System.Collections.Generic;
using System.Data;
using System.Linq;

using MySql.Data.MySqlClient;
//using LinqToDB;
//using LinqToDB.DataProvider.MySql;
//    <PackageReference Include="Microsoft.AspNet.WebApi.Cors" Version="5.2.9" />

using backend.Models;
using backend.Data;

namespace backend.Controllers;

[ApiController]
[Route("[controller]")]
public class SecureController : ControllerBase
{
    private readonly ILogger<SecureController> _logger;
    private string _connString = "server=localhost;user=root;database=sys;port=3306;password=my_password2";
    private readonly MyDbContext _context;

    public SecureController(ILogger<SecureController> logger, MyDbContext context)
    {
        _logger = logger;
        _context = context;
    }

    [HttpGet(Name = "Secure")]
    public string[] Secure(string username)
    {
        Console.WriteLine("called secure func");
        Console.WriteLine(username);
        try 
            { 
                /*
                var usernames = _context.MyEntities
                    .Where(e => e.un == username)
                    .Select(e => e.un)
                    .ToArray();

                if (usernames == null || usernames.Length == 0)
                {
                    Console.WriteLine($"No entities found with username {username}");
                    //return NotFound();
                }

                return usernames;
                */
                string[] r = {"s"};
                return r;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                string[] r = {"error"};
                return r;
            }
    }
}
