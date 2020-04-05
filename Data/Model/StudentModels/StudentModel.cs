using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Core.Model;
using Data.Enums;
using Data.Model.ExamModels;
using Newtonsoft.Json;

namespace Data.Model.StudentModels
{
    /// <summary>
    /// Öğrenci ile ilgili işlemler için kullanılır.
    /// </summary>
    public class StudentModel : BaseModel
    {
        /// <summary>
        /// Öğrencinin ilk adını belirtir.
        /// </summary>
        [Required(ErrorMessage = "Isim alanı zorunludur.")]
        public string StudentFirstName { get; set; }
        /// <summary>
        /// Örencinin ikinci adını belirtir.
        /// </summary>
        public string StudentMediumName { get; set; }
        /// <summary>
        /// Öğrencinin soyadını belirtir.
        /// </summary>
        public string StudentLastName { get; set; }
        /// <summary>
        /// Öğrencinin mail adresini belirtir.
        /// </summary>
        public string StudentMail { get; set; }
        /// <summary>
        /// Öğrencinin kullanıcı adını belirtir.
        /// </summary>
        public string StudentNickName { get; set; }
        /// <summary>
        /// Öğrencinin şifrelenmiş şifresini tutar.
        /// </summary>
        public string StudentHashPassword { get; set; }
        /// <summary>
        /// Öğrencinin hangi sınıfta oldupunu belirtir.
        /// </summary>
        public int ClassId { get; set; }

        public ClassModel Classes { get; set; }

        [JsonIgnore] public virtual ICollection<StudentAnswerModel> StudentAnswers { get; set; }
        [JsonIgnore] public virtual ICollection<ExamToStudentModel> ExamToStudents{ get; set; }

    }
}
