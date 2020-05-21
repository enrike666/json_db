using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace JsonDB
{
    public class JsonConnection
    {
        public String _jsonName;

        public JsonConnection (String jsonName)
        {
            _jsonName = jsonName;
        }

        public List<Employee> GetEmployeeList()
        {
            string json = File.ReadAllText(_jsonName);
            List<Employee> list = JsonConvert.DeserializeObject<List<Employee>>(json);
            return list;
        }

        public void SetEmployeeList(List<Employee> list)
        {
            String json = JsonConvert.SerializeObject(list);
            File.WriteAllText(_jsonName, json);
        }
    }
}
