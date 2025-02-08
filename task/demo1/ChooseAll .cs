using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace demo1
{
    internal class ChooseAll:Question
    {

        //hold answerlist
        string[] Chooses;

        string[] CorrectAnswer;
        public ChooseAll(string h, string b, int m, string[] _choose, string[] _Correctchoose) : base(h, b, m)
        {
            Chooses = _choose;
            CorrectAnswer = _Correctchoose;
        }

        public override string getAnswer() { return $"{string.Join(",", CorrectAnswer)}"; }

        public override string ToString()
        {
            return $"{base.ToString()}\n=> Answers: \n - {string.Join("\n - ", Chooses)}";
        }
    }
}
