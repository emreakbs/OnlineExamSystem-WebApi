using System;
using System.Collections.Generic;
using System.Text;
using Core.Model;
using Data.Model.SchoolModels;
using Data.Model.TeacherModels;
using Newtonsoft.Json;

namespace Data.Model
{
    /// <summary>
    /// Okul içerisindeki bölüm işlemleri yapılır.
    /// </summary>
    public class DepartmentModel : BaseModel
    {
        /// <summary>
        /// Depatman adını belirtir.
        /// </summary>
        public string DepartmentName { get; set; }
        /// <summary>
        /// Hangi okulun departmanı olduğunu belirtir.
        /// </summary>
        public int SchoolId { get; set; }

        public SchoolModel School { get; set; }
        [JsonIgnore] public virtual ICollection<TeacherModel> Teachers { get; set; }
    }
}
