using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Core.Model;
using Data.Model.TeacherModels;
using Newtonsoft.Json;

namespace Data.Model.ExamModels
{
    /// <summary>
    /// Sınav ile ilgili bilgiler için kullanılır.
    /// </summary>
    public class ExamModel : BaseModel
    {
        /// <summary>
        /// Geçerlilik durumu belirtir.
        /// </summary>
        public string ExamStatus { get; set; }
        /// <summary>
        /// Oluşturulma tarihini belirtir.
        /// </summary>
        public DateTime ExamCreateTime { get; set; }
        /// <summary>
        /// Oluşturan öğretmeni belirtir.
        /// </summary>
        public int TeacherId { get; set; }
        /// <summary>
        /// Içerisinde bulunan testleri belitir.
        /// </summary>
        [Required(ErrorMessage = "En az bir test seçilmelidir.")]
        public int TestId { get; set; }
        public TeacherModel Teacher { get; set; }
        public TestModel Test { get; set; }

        [JsonIgnore] public virtual ICollection<ExamToStudentModel> ExamToStudents{ get; set; }

    }
}
