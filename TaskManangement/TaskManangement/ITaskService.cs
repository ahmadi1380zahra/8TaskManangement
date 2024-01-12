using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManangement
{
    interface ITaskService
    {
        void AddEmployee(string name,int salary);
        void AddMananger(string name, int salary,string departmentName);
        void AddTask(string taskTitle, string taskDescription, DateTime taskDeadLine, Priority priority);
        void AddEmployeeTask(string employeeName,string taskTitle);
        void ShowEmployeeTask();
    }
}
