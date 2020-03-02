using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Core.Model;
using MySqlX.XDevAPI.Common;
using Newtonsoft.Json;

namespace Data.Model.ExamModels
{
    /// <summary>
    /// Soru tipleri ile ilgili model
    /// </summary>
    public class QuestionTypeModel : BaseModel
    {
        /// <summary>
        /// Sorunun hangi tipte olacağını belirtir. Örn; Çoktan seçmeli, doğru-yanlış..
        /// </summary>
        [Required (ErrorMessage = "Soru tipi alanı zorunludur.")]
        public string QuestionTypeText { get; set; }
        /// <summary>
        /// Soru tipinin açıklaması
        /// </summary>
        [Required(ErrorMessage = "Açıklama alanı zorunludur.")]
        public string QuestionTypeDescription { get; set; }
        [JsonIgnore] public virtual ICollection<QuestionModel> Questions { get; set; }
    }
}
