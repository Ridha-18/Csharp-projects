// See https://aka.ms/new-console-template for more information
using Task17.DataContext;
using Microsoft.EntityFrameworkCore;

Console.WriteLine("Hello, World!");
var ConnectionString = "Server=localhost;Port=3306;Database=StudentPortal;Uid=root;Pwd=root;";
try
{
    var optionsBuilder = new DbContextOptionsBuilder<StudentDataContext>();
    optionsBuilder.UseMySql(ConnectionString, ServerVersion.AutoDetect(ConnectionString));

    using (var context = new StudentDataContext(optionsBuilder.Options))
    {
        var students = context.students.ToList();
        foreach (var student in students)
        {
            Console.WriteLine($"ID: {student.id}, Name: {student.name}, Email: {student.email}");
        }
    }
}
catch (Exception ex)
{
    Console.WriteLine(ex.Message);
}

Console.WriteLine("\nPress any key to exit...");
Console.ReadKey();
