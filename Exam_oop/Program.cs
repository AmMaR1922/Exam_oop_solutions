using Exam_oop;
using System.Diagnostics;

namespace Exam_oop
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Prompting for subject details
            Console.WriteLine("Enter Subject Id:");
            int subjectId = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter Subject Name:");
            string subjectName = Console.ReadLine();

            // Creating a subject
            Subject subject = new Subject(subjectId, subjectName);

            // Prompting for exam details
            Console.WriteLine("Please enter the type of exam (1 for Practical | 2 for Final):");
            int examType = int.Parse(Console.ReadLine());

            Console.WriteLine("Please enter the time of exam (30 min to 180 min):");
            int examDuration = int.Parse(Console.ReadLine());

            Console.WriteLine("Please enter the number of questions:");
            int numOfQuestions = int.Parse(Console.ReadLine());

            Exam exam = null;
            if (examType == 1)
            {
                exam = new PracticalExam("Practical Exam", DateTime.Now.AddMinutes(examDuration));
            }
            else if (examType == 2)
            {
                exam = new FinalExam("Final Exam", DateTime.Now.AddMinutes(examDuration));
            }

            for (int i = 0; i < numOfQuestions; i++)
            {
                if (examType == 2)
                {
                    Console.WriteLine("Please enter type of question (1 for MCQ | 2 for True/False):");
                    int questionType = int.Parse(Console.ReadLine());

                    if (questionType == 1)
                    {
                        AddMCQQuestion(exam);
                    }
                    else if (questionType == 2)
                    {
                        AddTrueFalseQuestion(exam);
                    }
                }
                else if (examType == 1)
                {
                    AddMCQQuestion(exam);
                }
                Console.Clear();
            }
            Console.Clear();

            subject.CreateExam(exam);

            // Starting the exam
            Console.WriteLine("Do you want to start the exam? (1-yes | 2-no):");
            int startExam = int.Parse(Console.ReadLine());
            if (startExam == 1)
            {
                Stopwatch stopwatch = new Stopwatch();
                stopwatch.Start();

                foreach (var question in subject.Exam.Questions)
                {
                    Console.WriteLine($"Question: {question.Body}");
                    foreach (var answer in question.AnswerList)
                    {
                        Console.WriteLine($"Answer ID: {answer.AnswerId}, Answer: {answer.AnswerText}");
                    }
                    Console.WriteLine("Enter your answer ID:");
                    int userAnswerId = int.Parse(Console.ReadLine());

                    question.UserAnswer = Array.Find(question.AnswerList, a => a.AnswerId == userAnswerId);
                }

                stopwatch.Stop();
                TimeSpan timeTaken = stopwatch.Elapsed;
                double totalGrade = subject.Exam.Questions.Sum(q => q.Mark);
                double userGrade = subject.Exam.Questions.Count(q => q.UserAnswer == q.CorrectAnswer) / (double)subject.Exam.Questions.Count * totalGrade;

                Console.WriteLine($"Time taken to complete the exam: {timeTaken.TotalSeconds} seconds ({timeTaken.TotalMinutes} minutes, {timeTaken.TotalHours} hours)");
                Console.Clear();
                subject.Exam.ShowResults();
                Console.Clear();
                Console.WriteLine("Detailed Answers:\n");
                foreach (var question in subject.Exam.Questions)
                {
                    Console.WriteLine($"Question: {question.Body}");
                    Console.WriteLine($"Your Answer: {question.UserAnswer.AnswerText}");
                    Console.WriteLine($"Correct Answer: {question.CorrectAnswer.AnswerText}");
                    Console.WriteLine();
                }

                Console.WriteLine($"Your grade is {userGrade} out of {totalGrade}");
                Console.WriteLine(" \n thank youuu");
            }
            else
            {
                Console.WriteLine("Exam not started.");
            }
        }

        static void AddMCQQuestion(Exam exam)
        {
            Console.WriteLine("Enter MCQ Question Body:");
            string questionBody = Console.ReadLine();

            Console.WriteLine("Enter Question Mark:");
            int questionMark = int.Parse(Console.ReadLine());

            List<Answer> mcqAnswers = new List<Answer>();
            for (int j = 0; j < 4; j++)
            {
                Console.WriteLine($"Enter choice {j + 1}:");
                mcqAnswers.Add(new Answer { AnswerId = j + 1, AnswerText = Console.ReadLine() });
            }

            Console.WriteLine("Enter the correct choice number:");
            int correctChoice = int.Parse(Console.ReadLine());

            Answer correctAnswer = mcqAnswers[correctChoice - 1];

            if (exam is FinalExam finalExam)
            {
                finalExam.AddMCQQuestion("MCQ Question", questionBody, questionMark, mcqAnswers.ToArray(), correctAnswer);
            }
            else if (exam is PracticalExam practicalExam)
            {
                practicalExam.AddMCQQuestion("MCQ Question", questionBody, questionMark, mcqAnswers.ToArray(), correctAnswer);
            }
        }

        static void AddTrueFalseQuestion(Exam exam)
        {
            Console.WriteLine("Enter True/False Question Body:");
            string questionBody = Console.ReadLine();

            Console.WriteLine("Enter Question Mark:");
            int questionMark = int.Parse(Console.ReadLine());

            Answer[] trueFalseAnswers = new Answer[]
            {
            new Answer { AnswerId = 1, AnswerText = "True" },
            new Answer { AnswerId = 2, AnswerText = "False" }
            };

            Console.WriteLine("Enter the correct answer (1 for True | 2 for False):");
            int correctChoice = int.Parse(Console.ReadLine());

            Answer correctAnswer = trueFalseAnswers[correctChoice - 1];

            if (exam is FinalExam finalExam)
            {
                finalExam.AddTrueFalseQuestion("True/False Question", questionBody, questionMark, trueFalseAnswers, correctAnswer);
            }
        }
    }
}
 

