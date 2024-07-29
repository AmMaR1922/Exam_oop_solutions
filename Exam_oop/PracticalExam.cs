using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam_oop
{
    public class PracticalExam : Exam
    {
        public PracticalExam(string examName, DateTime examTime)
            : base(examName, examTime)
        {
        }

        public void AddMCQQuestion(string header, string body, int mark, Answer[] answers, Answer correctAnswer)
        {
            Questions.Add(new Question(header, body, mark, answers, correctAnswer));
        }

        public override void ShowResults()
        {
            Console.WriteLine($"Practical Exam: {ExamName}");
            Console.WriteLine($"Time: {ExamTime}");
            Console.WriteLine($"Number of Questions: {Questions.Count}");
            foreach (var question in Questions)
            {
                Console.WriteLine($"Question: {question.Body}");
                Console.WriteLine($"Correct Answer: {question.CorrectAnswer.AnswerText}");
            }
        }
    }
}
