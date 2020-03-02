using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Core.Model;
using Newtonsoft.Json;

namespace Data.Model.ExamModels
{
    /// <summary>
    /// Sorunun hangi konuya ait olduğu u belirten işlemler.
    /// </summary>
    public class SubjectModel : BaseModel
    {
        /// <summary>
        /// Konu başlığını belirtir. Örn; Üslü sayılar...
        /// </summary>
        [Required(ErrorMessage = "Konu alanı zorunludur.")]
        public string SubjectName { get; set; }
        /// <summary>
        /// Hangi dersin konusu olduğunu belirtmek için kullanılır.
        /// </summary>
        [Required(ErrorMessage = "Sınıf alanı zorunludur.")]
        public int LessonId { get; set; }
        public LessonModel Lesson { get; set; }
        [JsonIgnore] public virtual ICollection<QuestionModel> Questions { get; set; }
    }
}
