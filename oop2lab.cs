using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyProject
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //EX: [single line comment ]
            /*[double line comment symbole ]**/
            //ex01
            //string courseName = "OO Programming2";
            //Console.WriteLine("The name of this  Course is :" + courseName);//output[+concat]

            //ex1
            //string name1 = "\"Programming\"";
            //Console.WriteLine("The name is:"+name1);

            //ex1
            //Console.WriteLine("\n Enter your name :");
            //string name2 = Console.ReadLine();//[inpute name and enter the name then it is finished as a output will be slow the name is : Jenifa]
            //Console.WriteLine("The name is :"+name2);

            //ex2
            //Console.WriteLine(" Enter your first name :");
            //string firstname = Console.ReadLine();//manually input nibe
            //Console.WriteLine(" Enter your last name :");
            //string lastname = Console.ReadLine();
            //Console.WriteLine("Your name is {0} {1}", firstname, lastname); //index are define 0,1 for name 


            //ex3
            //try
            //{

            //    Console.WriteLine(" Enter your first number :");
            //    int firstnumber = int.Parse(Console.ReadLine());
            //    Console.WriteLine(" Enter your second number :");
            //    int secondnumber = int.Parse(Console.ReadLine());
            //    int sum = firstnumber + secondnumber;
            //    Console.WriteLine("The sum of {0} and  {1} is {2}", firstnumber, secondnumber,sum);

            //}
            //catch (Exception e) {
            //    string msg = e.Message;
            //    Console.WriteLine("Error :" + msg);
            //}
            //ex4
            // Console.WriteLine(" Enter your first number :");
            //int firstnumber = int.Parse (Console.ReadLine());//manually input nibe
            //Console.WriteLine(" Enter your second number :");

            //int secondnumber = int.Parse(Console.ReadLine());//string ke cast korar jonno int.parse use kora hoi
            //int sum = firstnumber + secondnumber;
            //Console.WriteLine("The sum of {0} and  {1} is {2}", firstnumber, secondnumber,sum);
            //EX5 

            //bool x = true;
            //double y = 3.14;
            //int a = (int)y;
            //Console.WriteLine(a);

            //ex6 explicit conversion
            //bool x = true;
            //int a = Convert.ToInt32(x);
            //Console.WriteLine(a);
            //ex7
            //int x;
            //Console.WriteLine("Minmum in range :" + int.MinValue);
            //Console.WriteLine("Maxmum in range :" + int.MaxValue);
            try
            {
                Console.WriteLine(" Enter your first number :");
                int firstnumber = int.Parse(Console.ReadLine());
                Console.WriteLine(" Enter your second number :");
                int secondnumber = int.Parse(Console.ReadLine());
                int sum = firstnumber + secondnumber;
                int sub = firstnumber - secondnumber;
                int multi = firstnumber * secondnumber;
                int div = firstnumber / secondnumber;

                Console.WriteLine("The number is sum :" + sum);
                Console.WriteLine("The number is sub :" + sub);
                Console.WriteLine("The number is Multi : " + multi);
                Console.WriteLine("The number is Div:" + div);
            }
            catch (Exception e) {
                string msg = e.ToString();
                Console.WriteLine("Error:" + msg);
            }
            Console.ReadKey(); //[hold on and wait for input ]



        }
    }
}
