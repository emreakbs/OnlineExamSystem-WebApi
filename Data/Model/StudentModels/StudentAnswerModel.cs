using System;
using System.Collections.Generic;
using System.Text;
using Core.Model;
using Data.Model.ExamModels;

namespace Data.Model.StudentModels
{
    /// <summary>
    /// Öğrencilerin sorulara verdiği cevapları
    /// </summary>
    public class StudentAnswerModel : BaseModel
    {
        /// <summary>
        ///Öğrencinin verdiği cevabı belirtir. 
        /// </summary>
        public string StudentAnswerText { get; set; }
        /// <summary>
        /// cevabın doğru ,yanlış veya boş olduğunu belirtmek için kullanılır.
        /// </summary>
        public bool StudentAnswerStatus { get; set; }
        /// <summary>
        /// Hangi test olduğunu belirtir.
        /// </summary>
        public int TestId { get; set; }
        /// <summary>
        /// Hangi sorunun cevabı olduğunu belirtir.
        /// </summary>
        public int QuestionId { get; set; }
        /// <summary>
        /// Hangi öğrencinin cevabı olduğunu belirtir.
        /// </summary>
        public int StudentId { get; set; }
        public TestModel Test { get; set; }
        public QuestionModel Question { get; set; }
        public StudentModel Student { get; set; }
    }
}
