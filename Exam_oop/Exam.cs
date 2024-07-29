using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam_oop
{
   
        public abstract class Exam
        {
            public string ExamName { get; set; }
            public DateTime ExamTime { get; set; }
            public List<Question> Questions { get; set; }

            public Exam(string examName, DateTime examTime)
            {
                ExamName = examName;
                ExamTime = examTime;
                Questions = new List<Question>();
            }

            public abstract void ShowResults();
        }
    
}
