using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JsonDB
{
    public class Repository
    {
        JsonConnection _connection;

        public Repository (JsonConnection connection)
        {
            _connection = connection;
        }

        public void Add(Employee empl) {
            List<Employee> list = _connection.GetEmployeeList();
            int lastId;
            if (list.Count != 0)
            {
               lastId = list.Max(i => i.Id);
            } else
            {
                lastId = 0; 
            }            
            empl.Id = lastId + 1;
            list.Add(empl);
            _connection.SetEmployeeList(list);
        }
        
        public void Update(int id, string newName)
        {
            List<Employee> list = _connection.GetEmployeeList();
            var empl = list.Where(e => e.Id == id).FirstOrDefault();
            if (empl == null)           
                throw new Exception("Сотрудника с таким id не существует");
            
            list.Remove(empl);
            empl.FirstName = newName;
            list.Add(empl);
            _connection.SetEmployeeList(list);
        }

        public Employee Get(int id)
        {
            List<Employee> list = _connection.GetEmployeeList();
            var empl = list.Where(e => e.Id == id).FirstOrDefault();
            if (empl == null)
                throw new Exception("Сотрудника с таким id не существует");
            return empl;
        }

        public void Delete(int id)
        {
            List<Employee> list = _connection.GetEmployeeList();
            var empl = list.Where(e => e.Id == id).FirstOrDefault();
            if (empl == null)
                throw new Exception("Сотрудника с таким id не существует");
            list.Remove(empl);            
            _connection.SetEmployeeList(list);
        }

        public List<Employee> GetAll()
        {
            return _connection.GetEmployeeList();
        }
    }
}
