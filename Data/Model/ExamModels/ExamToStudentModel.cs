using System;
using System.Collections.Generic;
using System.Text;
using Core.Model;
using Data.Model.StudentModels;

namespace Data.Model.ExamModels
{
    /// <summary>
    /// Hangi öğrencinin hangi sınava girdiğini belirtmek için kullanılır.
    /// </summary>
    public class ExamToStudentModel:BaseModel
    {
        /// <summary>
        /// Sınava giren öğrencileri belirtir.
        /// </summary>
        public int StudentId { get; set; }
        /// <summary>
        /// Hangi sınava girildiğini belirtir.
        /// </summary>
        public int ExamId { get; set; }

        public StudentModel Student { get; set; }
        public ExamModel Exam { get; set; }
    }
}
