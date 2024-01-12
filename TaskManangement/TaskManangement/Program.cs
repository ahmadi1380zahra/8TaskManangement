using System;
using System.Globalization;

namespace TaskManangement
{
    class Program
    {
        static ITaskService EmployeeManangement = new EmployeeManangement();
        static void Main(string[] args)
        {
            while (true)
            {
                try
                {
                    Run();
                }
                catch (Exception exception)
                {
                    Console.WriteLine(exception.Message);
                }
            }

        }
        static void Run()
        {
            var option = GetInt("1.add employee \n 2.add Task \n 3.add employee task \n 4.show employee task");
            switch (option)
            {
                case 1:
                    {
                        string department = null;
                        var name = GetString("Enter Employe Name");
                        var salary = GetInt("Enter Employe salary");
                        var employeType = GetInt("1.simple employee 2.manager");
                        if (employeType != 2 & employeType != 1)
                        {
                            throw new Exception("No valid Type");
                        }
                        if (employeType == 2)
                        {
                            department = GetString("Enter department Name");
                            EmployeeManangement.AddMananger(name,salary,department);
                        }
                        if (employeType == 1)
                        {
                            EmployeeManangement.AddEmployee(name, salary);
                        }
                        
                        break;
                    }
                case 2:
                    {
                        var title = GetString("Enter task title");
                        var description = GetString("Enter task description");
                        DateTime deadLine;
                        string pattern = "MM/dd/yyyy";
                        bool IsValid = false;
                        do
                        {
                            Console.WriteLine("Enter date that you give back the book?(MM/dd/yyyy)");
                            IsValid = DateTime.TryParseExact(Console.ReadLine(), pattern,
                            CultureInfo.InvariantCulture, DateTimeStyles.None, out deadLine);

                        } while (!IsValid);
                        var priorityOption = GetInt("1.low 2.mid 3.high");
                        EmployeeManangement.AddTask(title,description,deadLine,
                            (priorityOption == 1?Priority.low 
                            :priorityOption==2? Priority.mid 
                            :priorityOption==3?Priority.high :throw new Exception("not valid option") ));
                        break;
                    }
                case 3:
                    {
                        var nameEmployee = GetString("Enter Employe Name");
                        var title = GetString("Enter task title");
                        EmployeeManangement.AddEmployeeTask(nameEmployee,title);
                        break;
                    }
                case 4:
                    {
                        EmployeeManangement.ShowEmployeeTask();
                        break;
                    }
            }
        }
        static string GetString(string message)
        {
            Console.WriteLine(message);
            string value = Console.ReadLine()!;
            return value;
        }

        static int GetInt(string message)
        {
            Console.WriteLine(message);
            int value = int.Parse(Console.ReadLine()!);
            return value;
        }
    }
}
