using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace demo1
{
    internal class ChooseOne:Question
    {
        //hold answerlist
        string[] Chooses;
        public string CorrectAnswer { get; set; }

        public ChooseOne(string h, string b, int m, string[] _choose, string _answer) : base(h, b, m)
        {
            Chooses = _choose;
            CorrectAnswer = _answer;

        }

        public override string getAnswer()
        {
            return CorrectAnswer;
        }

        public override string ToString()
        {
            return $"{base.ToString()}\n=> Answers: \n - {string.Join("\n - ", Chooses)}";
        }

       
    }
}
