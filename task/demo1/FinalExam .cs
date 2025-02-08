using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace demo1
{
    internal class FinalExam: Exam
    {
        public string Path;
        public FinalExam(int n, Subject s, string _path) : base(n, s)
        {
            Path = _path;
            File.WriteAllText(Path, string.Empty); // Clear file 
        }

        public override string ToString()
        {
            return "FinalExam";
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

            int i = 0; //  index for the list
            int totalScore = 0;
            int yourScore = 0;
            foreach (KeyValuePair<Question, string> q in QuestionAnswer)
            {
                totalScore += q.Key.Mark;

                if (YourAnswer[i].UserAnswer == q.Value)
                {

                    yourScore += q.Key.Mark;
                }

                i++; // Move to the next list element
            }
            Console.WriteLine($"======================== Exam is {Mode} ========================");
            if(yourScore > totalScore/2)
            {
                Console.WriteLine("Congratulations, you passed the exam successfully");
                Console.WriteLine($"Your Scorere is {yourScore} / {totalScore}");
            }
            else
            {
                Console.WriteLine("Unfortunately, you didn't passed the exam");
            }
            
            Console.WriteLine("Thanks for your Respond\n\n\n");


        }

    }
}
