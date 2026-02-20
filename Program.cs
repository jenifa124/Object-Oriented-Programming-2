using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Runtime.ExceptionServices;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Services;
using System.Text;
using System.Threading.Tasks;

namespace oop2lab1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //try
            //{


            //    Console.WriteLine("Enter the first number:");
            //    int firstnumber = int.Parse(Console.ReadLine());
            //    Console.WriteLine("Enter the second number:");
            //    int secondnumber = int.Parse(Console.ReadLine());
            //    int sum = firstnumber + secondnumber;
            //    int sub = firstnumber - secondnumber;
            //    int multiply = firstnumber * secondnumber;
            //    int div = firstnumber / secondnumber;
            //    Console.WriteLine("This number is sum:" + sum);
            //    Console.WriteLine("This number is sub:" + sub);
            //    Console.WriteLine("This number is mulityply:" + multiply);
            //    Console.WriteLine("This number is div:" + div);
            //}
            //catch (Exception e)
            //{
            //    String msg = e.ToString();

            //    Console.WriteLine("Error:" + msg);


            //}
            Console.WriteLine("Enter the  number1:");
            int num1 = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter the number2:");
            int num2 = int.Parse(Console.ReadLine());
            if (num1 < num2)
            {

                Console.WriteLine("the num2 is gether then num1");
                
            } else if (num1 == num2)
            {
                Console.WriteLine("The number are equal");
            }
            else {
                Console.WriteLine("the num2 is not gether then num1");
            } 
            
        }
    }
}
