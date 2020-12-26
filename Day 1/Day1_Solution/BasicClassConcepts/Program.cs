using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace BasicClassConcepts
{
    class Program
    {
       static void Main()
        {
            //Class1 o;
            //o = new Class1();
            Class1 o = new Class1();
            o.Display();
            o.Display("Pratik");

            //Positional Parameters
            Console.WriteLine(o.Add(10, 20, 30, 40));
            Console.WriteLine(o.Add(10, 20, 30));
            Console.WriteLine(o.Add(10, 20));
            Console.WriteLine(o.Add(10));
            Console.WriteLine(o.Add());

            //Named Parameters
            Console.ReadLine();
        }
    }

    

    public class Class1
    {
        public void Display ()
        {
            Console.WriteLine("Display");
        }

        //Function Overloading
        public void Display(string s)
        {
            Console.WriteLine("Display" + " " + s);
        }

        //Optional Parameters With Default Values
        public int Add ( int a = 0 , int b = 0 , int c = 0 , int d = 0 )
        {
            return a + b + c + d;
        }

        /*public int Add(int a, int b, int c)
        {
            return a + b + c;
        }

        public int Add(int a, int b)
        {
            return a + b;
        }*/
    }

    class Class2
    {

    }
}

namespace n2
{
    class c3
    {
        
    }
    class Class2
    {

    }
    namespace n3
    {
        class Class4
        {

        }
    }

}
