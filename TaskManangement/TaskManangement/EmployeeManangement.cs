using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManangement
{
    class EmployeeManangement : ITaskService
    {
        private static List<Employee> employees = new();
        private static List<Task> tasks = new();
        private static int _id = 0;
        public void AddEmployee(string name, int salary)
        {
            var employee = new Employee(name, salary, ++_id);
            if (employees.Any(item=>item.Name==name))
            {
                throw new Exception("name should be unique");
            }
            employees.Add(employee);
            employee.PrintDetail(employee.Name, employee.ID, employee.Salary);
        }

        public void AddEmployeeTask(string employeeName, string taskTitle)
        {
            var employee = employees.Find(item=>item.Name==employeeName);
            if(employee is null)
            {
                throw new Exception("employee not found");
            }
            var task = tasks.Find(item=>item.Title==taskTitle);
            if (task is null)
            {
                throw new Exception("task not found");
            }
            employee.EmployeeTasks.Add(task);
        }

        public void AddMananger(string name, int salary, string departmentName)
        {
            var manager = new Manager(name, salary, ++_id, departmentName);
            if (employees.Any(item => item.Name == name))
            {
                throw new Exception("name should be unique");
            }
            employees.Add(manager);
            manager.PrintDetail(manager.Name, manager.ID, manager.Salary);
        }

        public void AddTask(string taskTitle, string taskDescription, DateTime taskDeadLine, Priority priority)
        {
            var task = new Task(taskTitle, taskDescription, taskDeadLine, priority);
            if (tasks.Any(item => item.Title == taskTitle))
            {
                throw new Exception("title should be unique");
            }
            tasks.Add(task);
        }

        public void ShowEmployeeTask()
        {
            foreach (var employee in employees)
            {
                Console.WriteLine($"{employee.Name} has ");
                foreach(var task in employee.EmployeeTasks)
                {
                    Console.WriteLine($"{task.Priority} => {task.Title} to do {task.Description} until {task.DeadLine} ");
                }
            }
        }
    }
}
