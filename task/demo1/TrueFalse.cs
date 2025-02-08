using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;

namespace demo1
{
    internal class TrueFalse: Question
    {
        public string CorrectAnswer { get; set; }
        public TrueFalse(string h, string b, int m, string _answer) : base(h, b, m)
        {
            CorrectAnswer = _answer;
        }

        public override string getAnswer()
        { return CorrectAnswer; }

        public override string ToString()
        {
            return $"{base.ToString()}\n";
        }


    }
}
