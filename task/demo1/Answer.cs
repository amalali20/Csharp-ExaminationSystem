using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace demo1
{
    internal class Answer
    {
        public string UserAnswer { get; set; }

        public Answer(string _userAnswer)
        {

            UserAnswer = _userAnswer;
        }

        public override string ToString()
        {
            return UserAnswer;
        }
    }
}
