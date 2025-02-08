using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace demo1
{
    internal class PracticeExam: Exam
    {
        public string Path;
        public PracticeExam(int n, Subject s, string _path) : base(n, s)
        {
            Path = _path;
            File.WriteAllText(Path, string.Empty); // Clear file 
        }

        public override string ToString()
        {
            return "PracticeExam";
        }

        public void AddQuestion(Question question)
        {
            base.AddQuestion(question);

            using (StreamWriter writer = new StreamWriter(Path, append: true))
            {
                writer.WriteLine($"{question.ToString()}\n=> CorrectAnswer: {question.getAnswer()}\n=> Mark: {question.Mark}\n");
            }


        }

        //hold user Answer for all questions
        public AnswerList YourAnswer = new AnswerList();

        // for each answer
        Answer ans;



        public override void ShowExam()
        {
            int i = 1;
            foreach (KeyValuePair<Question, string> q in QuestionAnswer)
            {
                // print type question
                Console.WriteLine($"{i}- {q.Key.ToString()}");
                i++;

                // take answer from user
                Console.Write("Your Answer: ");
                string Yanswer = Console.ReadLine();

                //for each question
                ans = new Answer(Yanswer);

                //add all Answer in AnswerList
                YourAnswer.Add(ans); 

                Console.WriteLine();

            }

            checkReslute();
        }

        public override void checkReslute()
        {
            Mode = ExamMode.Finished;
            Console.WriteLine($"Exam is {Mode}\n");

            Console.WriteLine("================== Check Your Answers ==========================\n");
            int i = 0; //  the index for the list

            foreach (KeyValuePair<Question, string> q in QuestionAnswer)
            {
                if (YourAnswer[i].UserAnswer == q.Value)
                {
                    Console.WriteLine($"qestion {i+1} => Your Answer is Correct");

                }
                else
                {
                    Console.WriteLine($"qestion {i + 1} =>Correct Answer is {q.Value}");
                }

                i++; // Move to the next list element
            }
            Console.WriteLine();
            Console.WriteLine();
        }

    }
}
