using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Core.Model;
using Data.Model.ExamModels;
using Newtonsoft.Json;

namespace Data.Model.TeacherModels
{
    public class TeacherModel : BaseModel
    {
        /// <summary>
        /// adı
        /// </summary>
        [Required(ErrorMessage = "İsim alanı zorunludur.")]
        public string TeacherFirstName { get; set; }

        /// <summary>
        /// ikinci adı
        /// </summary>
        public string TeacherMediumName { get; set; }

        /// <summary>
        /// Soyadı
        /// </summary>
        [Required(ErrorMessage = "Soyisim alanı zorunludur.")]
        public string TeacherLastName { get; set; }

        /// <summary>
        /// mail adresi
        /// </summary>
        [Required(ErrorMessage = "E-Mail alanı zorunludur.")]
        public string TeacherMail { get; set; }

        /// <summary>
        /// kullanıcı adı
        /// </summary>
        [Required(ErrorMessage = "Kullanıcı adı alanı zorunludur.")]
        public string TeacherUserName { get; set; }

        /// <summary>
        /// şirfesi
        /// </summary>
        [Required(ErrorMessage = "Şifre alanı zorunludur.")]
        public string TeacherPassword { get; set; }

        /// <summary>
        /// aktiflik durumu
        /// </summary>
        public bool TeacherStatus { get; set; }

        /// <summary>
        /// yetki
        /// </summary>
        [Required(ErrorMessage = "Yetki alanı zorunludur.")]
        public int PositionId { get; set; } 

        /// <summary>
        /// Uzmanlık alanı - Dal
        /// aynı branştaki diğer öğretmenlerin de sorularını görebilmek için
        /// </summary>
        [Required(ErrorMessage = "Branş alanı zorunludur.")]
        public int BranchId { get; set; }

        /// <summary>
        /// Okuldaki bölüm
        /// </summary>
        [Required(ErrorMessage = "Bölüm alanı zorunludur.")]
        public int DepartmentId { get; set; }

        public DepartmentModel Department { get; set; }

        public BranchModel Branch { get; set; }

        public PositionModel Position { get; set; }
        

       [JsonIgnore] public virtual ICollection<QuestionModel> Questions { get; set; }
       [JsonIgnore] public virtual ICollection<TestModel> Tests { get; set; }
       [JsonIgnore] public virtual ICollection<ExamModel> Exams { get; set; }
    }
}
