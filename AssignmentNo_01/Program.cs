using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssignmentNo_01
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello world");
            Employee o1 = new Employee("Amol", 123465, 10);
            Employee o2 = new Employee("Amol", 123465);
            Employee o3 = new Employee("Amol");
            Employee o4 = new Employee();

            Console.WriteLine(o1.getNetSalary());

            Console.WriteLine(o1.EmpNo);
            Console.WriteLine(o2.EmpNo);
            Console.WriteLine(o3.EmpNo);

            Console.WriteLine(o3.EmpNo);
            Console.WriteLine(o2.EmpNo);
            Console.WriteLine(o1.EmpNo);

            Console.ReadLine();
        }
    }

    class Employee
    {
        private string empName;
        //private int empNo;
        private decimal basicSalary;
        private short deptNo;
        static int id = 0;


        static Employee()
        {
            //empNo = 0;
        }

        /*
        public Employee(string empName = "null1", decimal basicSalary = 0, short deptNo = 0)
        {
            id++;
            this.empName = empName;
            this.EmpName = EmpName;
            this.basicSalary = basicSalary;
            this.deptNo = deptNo;
            this.BasicSalary = basicSalary;
            this.DeptNo = deptNo;
            this.empNo = id;
        }
        */

        public Employee()
        {

        }
        public Employee(string empName, decimal basicSalary, short deptNo)
        {
            id++;
            this.EmpNo = id;
            this.EmpName = empName;
            this.BasicSalary = basicSalary;
            this.DeptNo = deptNo;
        }
        public Employee(string empName, decimal basicSalary)
        {
            id++;
            this.EmpNo = id;
            this.EmpName = empName;
            this.BasicSalary = basicSalary;

        }

        public Employee(string empName)
        {
            id++;
            this.EmpNo = id;
            this.EmpName = empName;
        }


        public string EmpName
        {
            get { return empName; }
            set
            {
                if (value == null)
                {
                    // Console.WriteLine("NOt Invalid Name !!");
                    empName = value;
                }
                else
                    Console.WriteLine("Invalid Name !!");


            }
        }
        public int EmpNo
        {
            get;
        }

        public decimal BasicSalary
        {
            get { return basicSalary; }
            set
            {
                if (value > 1000 && value < 1000000)
                    basicSalary = value;
                else
                    Console.WriteLine("Invalid salary !!");
            }
        }
        public short DeptNo
        {
            get { return deptNo; }
            set
            {
                if (value > 0)
                    deptNo = value;
                else
                    Console.WriteLine("Invalid Depatment Number !!");
            }
        }

        public decimal getNetSalary()
        {
            double deduction = 1000;
            decimal salary = basicSalary - (decimal)deduction;
            return salary;
        }
    }
}
