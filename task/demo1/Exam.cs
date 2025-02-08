using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace demo1
{
    enum ExamMode
    {
        Starting, Queued, Finished
    }

    internal class Exam :ICloneable, IComparable<Exam>
    {
        // define delegate 
        public Action<Exam> delStartExam;

        public int NumOfQuestions { get; set; }

        public DateTime Time { get; set; }

        public ExamMode Mode { get; set; }

        public Subject SubjectName { get; set; }

        //hold question and correct answer
        public Dictionary<Question, string> QuestionAnswer;

        // constructor
        public Exam(int _number, Subject _subjectName)
        {

            Mode = ExamMode.Queued;
            SubjectName = _subjectName;
            NumOfQuestions = _number;
            QuestionAnswer = new Dictionary<Question, string>();
        }

        //override tostring
        public override string ToString()
        {
            return $"NumberOfQuestion: {NumOfQuestions}, Time: {Time}, SubjectName: {SubjectName}";
        }



        // AddQuestion
        public void AddQuestion(Question question)
        {

            if (NumOfQuestions > 0)
            {

                QuestionAnswer.Add(question, question.getAnswer());
                NumOfQuestions--;

            }
            else
            {
                Console.WriteLine("questions is compeleted");
            }

        }



        public void ExamStart()
        {
            Time = DateTime.Now;
            Mode = ExamMode.Starting;
            delStartExam?.Invoke(this);  // invocke delegate
        }


        public virtual void ShowExam() { }

        public virtual void checkReslute() { }

        public object Clone() => MemberwiseClone();


        // compare by NumOfQuestions
        public int CompareTo(Exam other) => NumOfQuestions.CompareTo(other.NumOfQuestions);

    }
}
