using System;

namespace demo1
{
    internal class Program
    {
        static QuestionList ReadQuestion(string filePath)
        {
            QuestionList questionList = new QuestionList();

            // hold Answers of chooseAll question
            string[] AnswersALL ;
            string[] correct ; //correct

            // hold Answers of chooseOne question
            string[] AnswersOne ;
            

            TrueFalse trueFalses ;
            ChooseAll chooseAlls ;
            ChooseOne chooseOnes ;

           
            if (File.Exists(filePath))
            {
                string[] lines = File.ReadAllLines(filePath);

                foreach (string line in lines)
                {
                   if(line.StartsWith("ChooseAll"))
                   {
                        AnswersALL = line.Split(":")[2].Split(", ");
                        
                        correct=line.Split(":")[4].Split(", ");
                       
                        chooseAlls = new ChooseAll(line.Split(":")[0], line.Split(":")[1], int.Parse(line.Split(":")[3]), AnswersALL, correct);

                        questionList.Add(chooseAlls);

                   }

                   else if (line.StartsWith("ChooseOne"))
                   {
                        AnswersOne =line.Split(":")[2].Split(", ");
                        chooseOnes = new ChooseOne(line.Split(":")[0], line.Split(":")[1], int.Parse(line.Split(":")[3]), AnswersOne, line.Split(":")[4]);
                        questionList.Add(chooseOnes);
                   }
                   else if (line.StartsWith("True/False"))
                   {
                        trueFalses = new TrueFalse(line.Split(":")[0], line.Split(":")[1], int.Parse(line.Split(":")[3]), line.Split(":")[4]);
                        questionList.Add(trueFalses);
                   }
                }
            }

            return questionList;
        }

        static void Main(string[] args)
        {
            // object of subject
            Subject sub1 = new Subject("C#");
            Subject sub2 = new Subject("Math");

            //object of Student
            Student s = new Student(1, "amal", sub1);

            // read from file
            QuestionList qq = ReadQuestion("Questions.txt");

            // object of PracticeExam and add Question from file
            PracticeExam p1 = new PracticeExam(4, sub1, "PracticeExam_1.txt");
            p1.AddQuestion(qq[0]);
            p1.AddQuestion(qq[1]);
            p1.AddQuestion(qq[2]);
            p1.AddQuestion(qq[4]);



            //object from each Question type
            TrueFalse q1 = new TrueFalse("True/False", "The 'var' keyword in C# allows implicit typing.", 2,  "true");
            TrueFalse q11 = new TrueFalse("True/False", "C# is a case-sensitive programming language.", 2, "true");

            ChooseOne c1 = new ChooseOne("ChooseOne" , "Which loop is used when the number of iterations is known in advance?", 1, ["foreach", "while", "for", "do-while"], "for");
            ChooseOne c11 = new ChooseOne("ChooseOne", "Which of the following is NOT a valid access modifier in C#?", 2, ["private", "protected", "internal", "external"], "external");

            ChooseAll c2 = new ChooseAll("ChooseAll", "Which of the following are value types in C#?", 4, ["string", "int", "bool", "object"], ["int", "bool"]);
            ChooseAll c21 = new ChooseAll("ChooseAll", "Which of the following are reference  types in C#?", 4, ["string", "int", "bool", "Array"], ["string", "array"]);



            // object of FinalExam and add Question from object
            FinalExam F1 = new FinalExam(6, sub1, "FinalExam_1.txt");
            F1.AddQuestion(q1);
            F1.AddQuestion(q11);
            F1.AddQuestion(c1);
            F1.AddQuestion(c11);
            F1.AddQuestion(c2);
            F1.AddQuestion(c21);


            //use select  exam
            Console.Write("Select 1 for PracticeExam or  2 for FinalExam: ");
            int choice = int.Parse(Console.ReadLine());
            Console.WriteLine();
            if (choice == 1)
            {
                s.AddExam(p1);    // add exam to student
                p1.ExamStart();   // start
                
                p1.ShowExam();    // show
            }
            else if (choice == 2)
            {
                s.AddExam(F1);
                F1.ExamStart();
                
                
                F1.ShowExam();
            }
            else
            {
                Console.WriteLine("Invalid Selection !!!!!!!!!!!!!!!");
            }



            //Console.WriteLine("\n-----------------------------------------------------");
            //// Testing ICloneable
            //var clonedExam = (Exam)p1.Clone();
            //Console.WriteLine($"Cloned Exam: {clonedExam}");
            //clonedExam.NumOfQuestions = 5;
            //clonedExam.AddQuestion(c2);

            ////clonedExam.ExamStart();
            ////clonedExam.ShowExam();


            //Console.WriteLine("\n-----------------------------------------------------");
            //// Testing IComparable
            //PracticeExam p2 = new PracticeExam(7, sub2, "PracticeExam2.txt");
            //                                     // 3   7   4
            //List<Exam>  examList = new List<Exam> { p1, p2, F1 };
            //examList.Sort(); // Sorts based on NumOfQuestions
            //Console.WriteLine("Exams sorted by NumOfQuestions:");
            //foreach (var exam in examList)
            //{
            //    Console.WriteLine(exam);
            //}




        }
    }
}
