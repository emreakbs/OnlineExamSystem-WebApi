using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Core.Model;

namespace Data.Model.ExamModels
{
    /// <summary>
    /// Sınav sorusu cevapları için kullanılır.
    /// </summary>
    public class QuestionAnswerModel : BaseModel
    {
        /// <summary>
        /// Hangi sorunun cevapları olacağını belirtir. 
        /// </summary>
        public int QuestionId { get; set; }

        /// <summary>
        /// Sorunun yanıtını belirtir.
        /// </summary>
        [Required(ErrorMessage = "Yanıt alanı zorunludur.")]
        public string QuestionAnswerText { get; set; }

        /// <summary>
        /// Cevabın doğru veya yanlış olduğunu belirtir.
        /// </summary>
        [Required(ErrorMessage = "Yanıt tipi zorunludur.")]
        public bool QuestionAnswerType { get; set; }
        public QuestionModel Question { get; set; }
    }
}
