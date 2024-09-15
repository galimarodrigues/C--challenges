using System.Globalization;

class Employee
{
    public int Id { get; private set; }
    public string Name { get; set; }
    private double Salary { get; set; }

    public Employee(int id, string name, double salary)
    {
        Id = id;
        Name = name;
        Salary = salary;
    }

    public void IncreaseSalary(double percentage)
    {
        Salary += Salary * (percentage / 100);
    }

    public override string ToString()
    {
        return Id + ", " + Name + ", " + Salary.ToString("F2", CultureInfo.InvariantCulture);
    }
}