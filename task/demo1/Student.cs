using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace demo1
{
    internal class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Subject SubjectName { get; set; }

        public Student(int _id, string _name, Subject _subjectName)
        {
            Id = _id;
            Name = _name;
            SubjectName = _subjectName;
        }

        public void AddExam(Exam e)
        {
            if (SubjectName == e.SubjectName)
            {
                e.delStartExam = Notifiy;  // registration
            }
            else
            {
                Console.WriteLine($"{this} hasn't Exam in {e.SubjectName}\n");
            }
        }

        public void Notifiy(Exam e)
        {
            Console.WriteLine($"{this} is notified that {e.ToString()} of {e.SubjectName} is started\n");
        }

        public override string ToString()
        {
            return $"Name: {Name}, Id: {Id} ";
        }

    }
}
