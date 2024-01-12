using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManangement
{
    class Employee
    {
        public Employee(string name, int salary, int id)
        {
            Name = name;
            ID = id;
            Salary = salary;
            EmployeeTasks = new();
        }
        public List<Task> EmployeeTasks { get; set; }
        public string Name { get; set; }
        public int ID { get; set; }
        public int Salary { get; set; }
      
        public virtual void PrintDetail(string name, int id, int salary)
        {
            Console.WriteLine($"user id => {id} : {name}  salary=>{salary}");
        }
    }
    class Manager : Employee
    {
        public Manager(string name, int salary, int id, string departmentName) : base(name, salary, id)
        {
            DepartmentName = departmentName;
        }
        public string DepartmentName { get; set; }

        public override void PrintDetail(string name, int id, int salary)
        {

            base.PrintDetail(name, id, salary);
            Console.WriteLine($"manager of {DepartmentName}");

        }
    }
    class Task
    {
        public Task(string taskTitle,string taskDescription,DateTime taskDeadLine,Priority priority)
        {
           Title = taskTitle;
           Description = taskDescription;
            DeadLine = taskDeadLine;
            Priority = priority;
        }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime DeadLine { get; set; }
        public Priority Priority { get; set; }

    }
    enum Priority
    {
        low,
        mid,
        high
    }
}
