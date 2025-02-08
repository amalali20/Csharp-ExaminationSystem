using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace demo1
{
    internal class Subject
    {

        public string SubjectName { get; set; }

        public Subject(string name)
        {
            SubjectName = name;
        }


        public override string ToString()
        {
            return $"{SubjectName}";
        }
    }
}
