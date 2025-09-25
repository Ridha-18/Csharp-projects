using System;
using System.Linq;

// ---OOP Concepts 
namespace OOPDemo
{
    // 1. Encapsulation 
    class Student
    {
        private string name;
        private int marks;

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public int Marks
        {
            get { return marks; }
            set
            {
                if (value >= 0 && value <= 100)
                    marks = value;
                else
                    Console.WriteLine("Invalid marks!");
            }
        }

        public void ShowInfo()
        {
            Console.WriteLine("Encapsulation");
            Console.WriteLine($"Student: {Name}, Marks: {Marks}");
        }
    }

    // 2. Inheritance (Teacher inherits Person)
    class Person
    {
        public string FullName { get; set; }
        public virtual void Display()
        {
            Console.WriteLine($"Person: {FullName}");
        }
    }

    class Teacher : Person
    {
        public string Subject { get; set; }

        // 3. Polymorphism 
        public override void Display()
        {
            Console.WriteLine("Inheritance + Polymorphism");
            Console.WriteLine($"Teacher: {FullName}, Subject: {Subject}");
        }
    }

    // 4. Abstraction 
    abstract class Shape
    {
        public abstract void Draw();  // must be implemented
    }

    class Circle : Shape //circle inherits shape
    {
        public override void Draw()
        {
            Console.WriteLine("Abstraction");
            Console.WriteLine("Drawing a Circle");
        }
    }

    // -----Arrays 
    class ArrayExamples
    {
        public void DemoArrays()
        {
            // 1D Array
            int[] numbers = { 1, 2, 3, 4, 5 };
            Console.WriteLine("1D Array Elements:");
            foreach (int n in numbers)
            {
                Console.Write(n + " ");
            }
            Console.WriteLine();

            //sum
            int sum = 0;
            for (int i = 0; i < numbers.Length; i++)
            {
                sum += numbers[i];
            }
            Console.WriteLine("Sum of array elements: " + sum);

            // Average
            double average = (double)sum / numbers.Length;
            Console.WriteLine("Average of array elements: " + average);

            // Maximum element
            int max = numbers[0];
            for (int i = 1; i < numbers.Length; i++)
            {
                if (numbers[i] > max)
                    max = numbers[i];
            }
            Console.WriteLine("Maximum element in array: " + max);

            // LINQ operations
            Console.WriteLine("LINQ Basic operations");
            Console.WriteLine("Sum: " + numbers.Sum());
            Console.WriteLine("Max: " + numbers.Max());
            Console.WriteLine("Min: " + numbers.Min());
            Console.WriteLine("Average: " + numbers.Average());

            Console.WriteLine("LINQ operations (Filtering)");
            var evens = numbers.Where(n => n % 2 == 0); // even numbers
            foreach (var n in evens) Console.Write(n + " ");
            Console.WriteLine("");

            Console.WriteLine("LINQ operations (sorting)");
            var ascending = numbers.OrderBy(n => n);
            var descending = numbers.OrderByDescending(n => n);
            Console.WriteLine("");

            Console.WriteLine(string.Join(", ", ascending));
            Console.WriteLine(string.Join(", ", descending));

            // 2D Array (matrix)

            int[,] matrix = {
            { 1, 2, 3 },
            { 4, 5, 6 },
            { 7, 8, 9 }
            };


            Console.WriteLine("2D Array Elements");
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    Console.Write(matrix[i, j] + " ");
                }
                Console.WriteLine();
            }

            int totalSum = 0;

            // Sum of 3x3 matrix elements
            for (int i = 0; i < 3; i++) // rows
            {
                for (int j = 0; j < 3; j++) // columns
                {
                    totalSum += matrix[i, j];
                }
            }
            Console.WriteLine("Sum of all elements in 3x3 matrix: " + totalSum);

            // Row-wise sum
            Console.WriteLine("Row-wise sum:");
            for (int i = 0; i < 3; i++)
            {
                int rowSum = 0;
                for (int j = 0; j < 3; j++)
                {
                    rowSum += matrix[i, j];
                }
                Console.WriteLine("Row " + (i + 1) + ": " + rowSum);
            }

            // Column-wise sum
            Console.WriteLine("Column-wise sum:");
            for (int j = 0; j < 3; j++)
            {
                int colSum = 0;
                for (int i = 0; i < 3; i++)
                {
                    colSum += matrix[i, j];
                }
                Console.WriteLine("Column " + (j + 1) + ": " + colSum);
            }




            // Jagged Array
            int[][] jagged = new int[2][];
            jagged[0] = new int[] { 1, 2, 3 };
            jagged[1] = new int[] { 4, 5 };

            Console.WriteLine("Jagged Array Elements:");
            for (int i = 0; i < jagged.Length; i++)
            {
                for (int j = 0; j < jagged[i].Length; j++)
                {
                    Console.Write(jagged[i][j] + " ");
                }
                Console.WriteLine();
            }
        }

    }


    // - Main Program --
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("OOP Demo");

            // Encapsulation
            Student s = new Student();
            s.Name = "Ridha";
            s.Marks = 85;
            s.ShowInfo();

            // Inheritance + Polymorphism
            Teacher t = new Teacher { FullName = "Mr. Smith", Subject = "Math" };
            t.Display(); // overridden method

            // Abstraction
            Shape shape = new Circle();
            shape.Draw();

            Console.WriteLine("\nArray Demo");
            ArrayExamples arr = new ArrayExamples();
            arr.DemoArrays();

            Console.WriteLine("\nPress any key to exit...");
            Console.ReadKey();


        }

    }
}


