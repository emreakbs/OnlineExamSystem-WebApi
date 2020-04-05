using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Core.Model;
using Data.Enums;

namespace Data.Model.AdminModels
{
    public class AdminModel : BaseModel
    {
        [Required(ErrorMessage = "İsim alanı zorunludur.")]
        public string AdminName { get; set; }

        public string AdminMediumName { get; set; }

        [Required(ErrorMessage = "Soyisim alanı zorunludur.")]
        public string AdminSurname { get; set; }

        [Required(ErrorMessage = "E-Mail alanı zorunludur.")]
        public string AdminEMail { get; set; }

        [Required(ErrorMessage = "Şifre alanları zorunlur.")]
        public string AdminPassword { get; set; }

        [Required(ErrorMessage = "Yetki alanı zorunludur.")]
        public UserLevel UserLevel { get; set; }

    }
}
