using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

#nullable disable

namespace Calculator {
    class Program {
        static void Main(string[] args) {
            Console.WriteLine("Calculator Program:");
            Console.WriteLine("-----------------");
            Console.WriteLine("Enter exit to exit the program.");
                
            int num1; 
            int num2;
            int result;

            Console.WriteLine("Enter first number: ");
            num1 = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Enter second number: ");
            num2 = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Enter operator: ");
            Console.WriteLine("1. +");
            Console.WriteLine("2. -");
            Console.WriteLine("3. *");
            Console.WriteLine("4. /");

            var ans = Console.ReadLine();

            switch (ans) {
                case "1":
                    result = num1 + num2;
                    break;
                case "2":
                    result = num1 - num2;
                    break;
                case "3":
                    result = num1 * num2;
                    break;
                case "4":
                    result = num1 / num2;
                    break;
                default:
                    Console.WriteLine("Invalid input");
                    return;
            }
            Console.WriteLine("Result: " + result);
            Console.WriteLine("Goodbye!" );
        }
    }
}