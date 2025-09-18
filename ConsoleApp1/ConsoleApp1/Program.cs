// See https://aka.ms/new-console-template for more information

using System;
using System.Globalization;
using System.Runtime.InteropServices;

    class program
        {

        static void Main(string[] args)
        {
            //(1)Display Hello Message
            Console.WriteLine("Hello, World!");

            //(2)Display result of Addition , subtraction , product , quotient of two numbers
            int a = 20;
            int b = 10;
            Console.WriteLine($"Addition : {a + b}");
            Console.WriteLine($"subtraction : {a - b}");
            Console.WriteLine($"product : {a * b}");
            Console.WriteLine($"quotient : {a / b}");


            //(3)Display result of Addition , subtraction , product , quotient of two numbers depending upon choice (using if else / switch)
            Console.WriteLine("Enter a choice : 1)ADDITION 2)SUBTRACTION 3)PRODUCT 4)QUOTIENT");
            int choice = Convert.ToInt32(Console.ReadLine());
            if (choice == 1)
            {
                Console.WriteLine($"Addition : {a + b}");
            }
            else if (choice == 2)
            {
                Console.WriteLine($"subtraction : {a - b}");
            }
            else if (choice == 3)
            {
                Console.WriteLine($"product : {a * b}");
            }
            else if (choice == 4)
            {
                Console.WriteLine($"quotient : {a / b}");
            }
            else
            {
                Console.WriteLine("Invalid Choice");
            }



            //(4)display your name 10 times
            Console.WriteLine("Displaying name 10 times");
            for (int i=1; i<=10; i++)
            {
            Console.WriteLine(i + ". Ridha Hakeem");
            }



            //(5)display all even numbers by using do while,while and for loop
            //forloop
            Console.WriteLine("Displaying even numbers using for loop");
            for (int i = 2; i <= 20; i += 2)
            {
             Console.WriteLine(i);
            }
            //do while
            Console.WriteLine("Displaying even numbers using do while");
            int k = 2;
            do

            {
               Console.WriteLine(k);
               k += 2;

            } while (k <= 20);
            //while
            Console.WriteLine("Displaying even numbers using while");
            int j = 2;
            while ( j <= 20){

            Console.WriteLine(j);
            j += 2;

            }




            //(6)display all odd numbers by using do while,while and for loop
            //forloop
            Console.WriteLine("Displaying odd numbers using for loop");
            for (int d = 1; d <= 20; d += 2)
            {
                Console.WriteLine(d);
            }
            //do while
            Console.WriteLine("Displaying odd numbers using do while");
            int e = 1;
            do

            {
                Console.WriteLine(e);
                e += 2;
            } while (e <= 20);
            //while
            Console.WriteLine("Displaying odd numbers using while");
            int f = 1;
            while (f <= 20)
            {
                Console.WriteLine(f);
                f += 2;
            }


            //(7)Display table of a number using all loops
            //for loop
            Console.Write("Multiplication table using for loop");
            Console.WriteLine("Enter a number");
            int num1=Convert.ToInt32(Console.ReadLine());
            for (int g = 1; g <= 10; g++)
            {
                Console.WriteLine($"{num1} x {g} = {num1 * g}");
            }
            //do while loop
            Console.Write("Multiplication table using do while loop");
            Console.WriteLine("Enter a number");
            int num2 = Convert.ToInt32(Console.ReadLine());
            int h = 1;
            do
            {
                Console.WriteLine($"{num2} x {h} = {num2 * h}");
                h++;
            } while(h<=10);
            //while loop
            Console.Write("Multiplication table using while loop");
            Console.WriteLine("Enter a number");
            int num3 = Convert.ToInt32(Console.ReadLine());
            int m = 1;
            while (m <= 10)
            {
                Console.WriteLine($"{num3} x {m} = {num3 * m}");
                m++;
            }




            //(8)Display numbers from 100 to 5 with a gap of 3
            Console.WriteLine("Displaying numbers from 100 to 5 with a gap of 3");
            for (int n=100;n<=5;n-=3)
            {
                Console.WriteLine(n);
            }



            //(9)Declare some integer variables, assign them some values and display them in one line
            Console.WriteLine("Declare some integer variables, assign them some values");
            int p = 10, q= 20, r = 30;
            Console.WriteLine($"Values: {p}, {q}, {r}");



            //(10)Integers in separate lines
            Console.WriteLine("Integers in separate lines");
            int x = 10, y = 20, z = 30;
            Console.WriteLine($"x = {x}");
            Console.WriteLine($"y = {y}");
            Console.WriteLine($"z = {z}");
















    }
}