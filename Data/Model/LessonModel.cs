using System;
using System.Collections.Generic;
using System.Text;
using Core.Model;
using Data.Model.ExamModels;
using Newtonsoft.Json;

namespace Data.Model
{
    /// <summary>
    /// Dersi işlemlerinin yapılmasını sağlar.
    /// </summary>
    public class LessonModel : BaseModel
    {
        /// <summary>
        /// Ders adını belirtir.
        /// </summary>
        public string LessonName { get; set; }
        [JsonIgnore] public virtual ICollection<SubjectModel> Subjects { get; set; }
        [JsonIgnore] public virtual ICollection<QuestionModel> Questions { get; set; }
        [JsonIgnore] public virtual ICollection<TestModel> Tests { get; set; }
    }
}
