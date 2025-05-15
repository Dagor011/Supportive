using System;


public abstract class Employee
{
    public string Name { get; set; }
    public decimal Salary { get; set; }

    
    public abstract void Work();
}


public interface IReportable
{
    string GenerateReport();
}


public class Manager : Employee, IReportable
{
    public override void Work()
    {
        Console.WriteLine("Менеджмент, управление командой");
    }

    public string GenerateReport() => "Отчет о деятельности команды";
}


public class Developer : Employee
{
    public override void Work()
    {
        Console.WriteLine(" Написание программного кода");
    }
}


public class Tester : Employee
{
    public override void Work()
    {
        Console.WriteLine("Тестирование приложения");
    }
}

class Program
{
    static void Main(string[] args)
    {
        var employees = new Employee[]
        {
            new Manager { Name = "Иван Иванов", Salary = 80_000m },
            new Developer { Name = "Алексей Петров", Salary = 70_000m },
            new Tester { Name = "Анна Смирнова", Salary = 60_000m }
        };

        foreach (var employee in employees)
        {
            employee.Work(); 

            if (employee is IReportable reportableEmployee)
                Console.WriteLine(reportableEmployee.GenerateReport()); 
        }
    }
}