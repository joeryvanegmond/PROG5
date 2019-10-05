using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.Domain;

namespace Entities.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            
            using (var context = new Entities.Domain.Entities())
            {
                List<Workshop> workshops = context.Workshop.Include("Teacher").ToList();

                System.Console.WriteLine("Workshop");
                foreach (var workshop in workshops)
                {
                    System.Console.WriteLine(String.Format("# {0} - by {1}", workshop.Name, workshop.Teacher.Name));
                }
                System.Console.WriteLine(" ");


                List<Teacher> teachers = context.Teacher.Include("Workshop").ToList();

                System.Console.WriteLine("Teacher");
                foreach (var t in teachers)
                {
                    System.Console.Write(String.Format("# {0}  - ", t.Name));
                    t.Workshop.ToList().ForEach(w => System.Console.Write("{0},", w.Name));
                    Console.WriteLine("--------");

                }
                System.Console.WriteLine(" ");

                List<Student> students = context.Student.ToList();

                System.Console.WriteLine("Student");
                foreach (var s in students)
                {
                    Console.WriteLine(String.Format("# {0} - {1}", s.Name, s.Leeftijd));
                }

                Console.ReadLine();
            }
        }
    }
}
