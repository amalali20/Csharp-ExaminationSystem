using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace demo1
{
    internal class Question
    {
        public string Body { get; set; }  //body of question
        public int Mark { get; set; }     //Mark of question
        public string Header { get; set; }//Header of question

        public Question(string _header, string _body, int _mark)
        {
            Body = _body;
            Mark = _mark;
            Header = _header;
        }

        // return correct answer
        public virtual string getAnswer() { return ""; }

        public override string ToString()
        {
            return $"{Header}: {Body}   ({Mark}) Mark";
        }

        
    }
}
