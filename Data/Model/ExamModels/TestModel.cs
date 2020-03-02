using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Core.Model;
using Data.Model.StudentModels;
using Data.Model.TeacherModels;
using Newtonsoft.Json;

namespace Data.Model.ExamModels
{
    /// <summary>
    /// Test ile ilgili işlemler yer alır.
    /// </summary>
    public class TestModel : BaseModel
    {
        /// <summary>
        /// Test süresini belirtir.
        /// </summary>
        public string TestTime { get; set; }
        /// <summary>
        /// Testin oluşturulma zamanını belirtir.
        /// </summary>
        public DateTime TestCreateTime { get; set; }
        /// <summary>
        /// Hangi ders için hazırlandığını belirtir.
        /// </summary>
        [Required(ErrorMessage = "Sınıf alanı zorunludur.")]
        public int LessonId { get; set; }
        /// <summary>
        /// Hangi sorulardan oluşacağını belirtir.
        /// </summary>
        [Required(ErrorMessage = "Soru alanı zorunludur.")]
        public int QuestionId { get; set; }
        /// <summary>
        /// Hangi öğretmenin oluşturduğunu belirtir.
        /// </summary>
        public int TeacherId { get; set; }
        public LessonModel Lesson { get; set; }
        public QuestionModel Question { get; set; }
        public TeacherModel Teacher { get; set; }

        [JsonIgnore] public virtual ICollection<ExamModel> Exams { get; set; }
        [JsonIgnore] public virtual ICollection<StudentAnswerModel> StudentAnswers { get; set; }
    }
}
