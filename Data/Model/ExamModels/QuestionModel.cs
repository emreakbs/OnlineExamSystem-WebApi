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
    /// Soru ile ilgili işlemler için kullanılır.
    /// </summary>
    public class QuestionModel : BaseModel
    {
        /// <summary>
        /// Soru metnini belirtir.
        /// </summary>
        [Required(ErrorMessage = "Soru alanı zorunludur.")]
        public string QuestionText { get; set; }

        /// <summary>
        /// [Sorunun puanını belirtir.]
        /// </summary>
        public decimal? QuestionPoint { get; set; }

        /// <summary>
        /// Oluşturulma tarihini belirtir.
        /// </summary>
        public DateTime QuestionCreateTime { get; set; }

        /// <summary>
        /// Oluşturan öğretmeni belirtir.
        /// </summary>
        public int TeacherId { get; set; }

        /// <summary>
        /// Sorunun konusunu belirtir. Örn: "Üslü sayılar"
        /// </summary>
        [Required(ErrorMessage = "Konu alanı zorunludur.")]
        public int SubjectId { get; set; }

        /// <summary>
        /// Soru tipini belirtir. Örn: "Çoktan seçmeli, Doğru yanlış"
        /// </summary>
        [Required(ErrorMessage = "Soru tipi alanı zorunludur.")]
        public int QuestionTypeId { get; set; }

        /// <summary>
        /// Kaçıncı sınıfla ilgili olduğunu belirtir.
        /// </summary>
        [Required(ErrorMessage = "Sınıf alanı zorunludur.")]
        public int ClassId { get; set; }

        /// <summary>
        /// Hangi dersle ilgili olduğunu belirtir.
        /// </summary>
        [Required(ErrorMessage = "Ders alanı zorunludur.")]
        public int LessonId { get; set; }

        public TeacherModel Teacher { get; set; }
        public SubjectModel Subject { get; set; }
        public QuestionTypeModel QuestionType { get; set; }
        public ClassModel Classes { get; set; }
        public LessonModel Lesson { get; set; }

        [JsonIgnore] public virtual ICollection<QuestionAnswerModel> QuestionAnswers { get; set; }
        [JsonIgnore] public virtual ICollection<TestModel> Tests { get; set; }
        [JsonIgnore] public virtual ICollection<StudentAnswerModel> StudentAnswers { get; set; }
    }
}
