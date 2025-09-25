using System;
using System.Linq;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

class Student
{
    public int StudentID { get; set; }
    public int StudentAge { get; set; }
    public string StudentName { get; set; }

}

class Department
{
    public int DeptID { get; set; }
    public string DeptName { get; set; }

}
class Program
    {
        static void Main()
        {
            String[] names = { "Alice", "Bob", "Ben", "Eela" };
            var MyLinq = from name in names
                         where name.ToLower().Contains("a")
                         select name;

        Console.WriteLine("To select a name that contaions a particular letter using LINQ"); 
        foreach (var name in MyLinq)
            {
            Console.WriteLine(name, " ");
            }

           IList<Student> StudentList=new List <Student>()
            {
                new Student(){ StudentID = 1, StudentAge = 23, StudentName="Ridha"},
                new Student(){ StudentID = 2, StudentAge = 22, StudentName="Tiya"},
                new Student(){ StudentID = 3, StudentAge = 23, StudentName="John"},
                new Student(){ StudentID = 4, StudentAge = 25, StudentName="Bob"},
                new Student(){ StudentID = 5, StudentAge = 21, StudentName="Rahul"}
            };

        IList<Department> DepartmentList = new List<Department>()
        { 
          new Department() {DeptID=1,DeptName="Science"},
          new Department() {DeptID=2,DeptName="Commerce"},
          new Department() {DeptID=3,DeptName="Arts"},
        };
        //where 
        var teenager = from std in StudentList
                       where std.StudentAge < 25
                       select std.StudentName;

        Console.WriteLine("Student age less than 25 (using where)");
        foreach (var std in teenager)
        {
            Console.WriteLine(std + " ");
        }

        //orderby
        var ordered = from std in StudentList
                      orderby std.StudentName
                      select std;
        Console.WriteLine("Orderby student name");
        foreach (var std in ordered)
        { 
        Console.WriteLine($"{std.StudentName} (Age : {std.StudentAge})");
        }

        //groupby
        var groupbyage = from std in StudentList
                         group std by std.StudentAge into ageGroup
                         select ageGroup;
        Console.WriteLine("Groupby student Age");
        foreach (var grp in groupbyage)
        {
            Console.WriteLine($"Age {grp.Key} : ");
            foreach(var std in grp)
            {
                Console.WriteLine($"{std.StudentName} ,(ID : {std.StudentAge})");
            }
        }


        // Join (flat list of pairs)
        var joinQuery = from std in StudentList
                        join dept in DepartmentList on std.StudentID equals dept.DeptID
                        select new { std.StudentName, dept.DeptName };

        Console.WriteLine("Inner Join (Student and  Department by ID):");
        foreach (var item in joinQuery)
        {
            Console.WriteLine($"{item.StudentName} - {item.DeptName}");
        }


        // GroupJoin (returns one row per department)
        var groupJoinQuery = from dept in DepartmentList
                             join std in StudentList on dept.DeptID equals std.StudentID into stdGroup
                             select new { dept.DeptName, Students = stdGroup };

        Console.WriteLine("\nGroup Join (Department → Students):");
        foreach (var dept in groupJoinQuery)
        {
            Console.WriteLine(dept.DeptName);
            foreach (var s in dept.Students)
                Console.WriteLine("   " + s.StudentName);
        }

    }

}



    
