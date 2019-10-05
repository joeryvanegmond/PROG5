using Entities.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace Etities.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            //Summary van alle workshops
            using (var context = new Entities.Domain.MyEntities())
            {
                //Niet vergeten de 'teacher' ook op te vragen!
                List<Workshop> workshops = context.Workshops.Include("Teacher").ToList();

                System.Console.WriteLine("Workshops");
                foreach(var workshop in workshops)
                {
                    System.Console.WriteLine(String.Format("# {0} - by {1}", workshop.Name, workshop.Teacher.Name));
                }
                System.Console.WriteLine(" ");


                List<Teacher> teachers = context.Teachers.Include("Workshops").ToList();

                System.Console.WriteLine("Teachers");
                foreach (var t in teachers)
                {
                    System.Console.Write(String.Format("# {0}  - ", t.Name));
                    t.Workshops.ToList().ForEach(w => System.Console.Write("{0},", w.Name));
                    Console.WriteLine("--------");
                   
                }
                System.Console.WriteLine(" ");

                //Niet vergeten de 'teacher' ook op te vragen!         
                System.Console.WriteLine("Students");
                foreach (var s in context.Students.Include("Workshops"))
                {
                    System.Console.WriteLine(String.Format("# {0}  - ", s.Name));
                    s.Workshops.ToList().ForEach(w => System.Console.Write("{0},", w.Name));

                }
                System.Console.WriteLine(" ");

                //Invoer uitwerking niet beschikbaar



            }

            System.Console.ReadLine();
        }
    }
}
