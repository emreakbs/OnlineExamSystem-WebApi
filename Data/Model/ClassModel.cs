using System;
using System.Collections.Generic;
using System.Text;
using Core.Model;
using Data.Model.ExamModels;
using Data.Model.SchoolModels;
using Data.Model.StudentModels;
using Newtonsoft.Json;

namespace Data.Model
{
    /// <summary>
    /// Sınıf işlemlerini kontrol etmemizi sağlar.
    /// </summary>
    public class ClassModel : BaseModel
    {
        /// <summary>
        /// Sınıfın adını belirtir.
        /// </summary>
        public string ClassName { get; set; }
        /// <summary>
        /// Hangi okulun sınıfı olsuğunu belirtir.
        /// </summary>
        public int SchoolId { get; set; }
        public SchoolModel School { get; set; }
        [JsonIgnore] public virtual ICollection<StudentModel> Students { get; set; }
        [JsonIgnore] public virtual ICollection<QuestionModel> Questions { get; set; }
    }
}
