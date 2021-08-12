using System;
using System.Linq;
using System.Xml.Linq;

namespace LinqXML
{
    class Program
    {
        static void Main(string[] args)
        {
            
            string studentsXML =
            @"<Students>
                    <Student>
                        <Name>Olly</Name>
                        <Age>21</Age>
                        <University>Techy</University>
                    </Student>
                    <Student>
                        <Name>Carl</Name>
                        <Age>44</Age>
                        <University>Techy</University>
                    </Student>
                    <Student>
                        <Name>Jolly</Name>
                        <Age>27</Age>
                        <University>Yale</University>
                    </Student>
                </Students>";


            XDocument studentsXdocument = new XDocument();
            studentsXdocument = XDocument.Parse(studentsXML);

            var students = from work1 in studentsXdocument.Descendants("Student")
                           select new
                           {
                               Name = work1.Element("Name").Value,
                               Age = work1.Element("Age").Value,
                               University = work1.Element("University").Value

                           };

            foreach (var work in students)
            {
                Console.WriteLine("Student {0} with Age {1} from University {2}", work.Name, work.Age, work.University);


            }


            var sortedStudents = from work1 in students
                                 orderby work1.Age
                                 select work1;

            foreach (var work in sortedStudents)
            {
                Console.WriteLine("Student {0} with Age {1} from University {2}", work.Name, work.Age, work.University);


            }












            Console.WriteLine("The end");
            Console.ReadKey();



        }
    }
}
