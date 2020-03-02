using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Core.Model;
using Newtonsoft.Json;

namespace Data.Model.SchoolModels
{
    /// <summary>
    /// Okul ile ilgili işlemler için kullanılır.
    /// </summary>
    public class SchoolModel : BaseModel
    {
        /// <summary>
        /// Okul adını belirtir.
        /// </summary>
        [Required(ErrorMessage = "Okul adı alanı zorunludur.")]
        public string SchoolName { get; set; }
        /// <summary>
        /// Okul web sitesini belirtir.
        /// </summary>
        public string SchoolWebSite { get; set; }

        [JsonIgnore] public virtual ICollection<DepartmentModel> Departments { get; set; }
        [JsonIgnore] public virtual ICollection<ClassModel> Classes { get; set; }
    }
}

