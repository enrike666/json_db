using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace JsonDB
{
    class Program
    {
        static void Main(string[] args)
        {
            JsonConnection connection = new JsonConnection("db.json");
            Repository repository = new Repository(connection);

            var typeCommand = args[0].Substring(1, args[0].Length - 1);
            Dictionary<string, string> parametrs;

            if (typeCommand != "getall")            
                parametrs = CommandParser.ParseParams(args);            
            else
                parametrs = null;
            

            switch (typeCommand)
            {
                case "add":                    
                    var empl = new Employee
                    {                        
                        FirstName = parametrs["FirstName"],
                        LastName = parametrs["LastName"],
                        SalaryPerHour = decimal.Parse(parametrs["Salary"])
                    };
                    repository.Add(empl);                    
                    break;

                case "update":
                    try
                    {
                        repository.Update(Int32.Parse(parametrs["Id"]), parametrs["FirstName"]);
                        break;
                    } catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                        Console.ReadKey();
                        break;
                    }
                    
                case "get":
                    try
                    {
                        var employee = repository.Get(Int32.Parse(parametrs["Id"]));
                        Console.WriteLine(employee.ToString());
                        Console.ReadKey();
                        break;
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                        Console.ReadKey();
                        break;
                    }                    
                case "delete":
                    try
                    {
                        repository.Delete(Int32.Parse(parametrs["Id"]));
                        break;
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                        Console.ReadKey();
                        break;
                    }                   
                case "getall":
                    var list = repository.GetAll();
                    foreach (Employee e in list)
                    {
                        Console.WriteLine(e.ToString());
                    }
                    Console.ReadKey();
                    break;
            }
            
        }     
    }
}
