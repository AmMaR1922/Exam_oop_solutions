using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam_oop
{
    public class Question
    {
        public string Header { get; set; }
        public string Body { get; set; }
        public int Mark { get; set; }
        public Answer[] AnswerList { get; set; }
        public Answer CorrectAnswer { get; set; }
        public Answer UserAnswer { get; set; } // Add this property to store the user's answer

        public Question(string header, string body, int mark, Answer[] answerList, Answer correctAnswer)
        {
            Header = header;
            Body = body;
            Mark = mark;
            AnswerList = answerList;
            CorrectAnswer = correctAnswer;
        }
    }
}
