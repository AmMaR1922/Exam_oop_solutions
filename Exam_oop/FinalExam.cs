using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam_oop
{
    public class FinalExam : Exam
    {
        public FinalExam(string examName, DateTime examTime)
            : base(examName, examTime)
        {
        }

        public void AddMCQQuestion(string header, string body, int mark, Answer[] answers, Answer correctAnswer)
        {
            Questions.Add(new Question(header, body, mark, answers, correctAnswer));
        }

        public void AddTrueFalseQuestion(string header, string body, int mark, Answer[] answers, Answer correctAnswer)
        {
            Questions.Add(new Question(header, body, mark, answers, correctAnswer));
        }

        public override void ShowResults()
        {
            Console.WriteLine($"Final Exam: {ExamName}");
            Console.WriteLine($"Time: {ExamTime}");
            Console.WriteLine($"Number of Questions: {Questions.Count}");
            int totalGrade = 0;
            foreach (var question in Questions)
            {
                Console.WriteLine($"Question: {question.Body}");
                foreach (var answer in question.AnswerList)
                {
                    Console.WriteLine($"Answer: {answer.AnswerText}");
                }
                totalGrade += question.Mark;
            }
            Console.WriteLine($"Total Grade: {totalGrade}");
        }
    }
}
