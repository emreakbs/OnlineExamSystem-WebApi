using System;
using System.Collections.Generic;
using System.Text;
using Core.Model;
using Data.Model.AdminModels;
using Data.Model.TeacherModels;
using Newtonsoft.Json;

namespace Data.Model
{
    /// <summary>
    /// Yetkilendirme ile ilgili işlemler için kullanılır.
    /// </summary>
    public class PositionModel : BaseModel
    {
        /// <summary>
        /// Yetki seviyesinin adını belirtir.
        /// </summary>
        public string PositionName { get; set; }
        [JsonIgnore] public virtual ICollection<TeacherModel> Teachers{ get; set; }
        [JsonIgnore] public virtual ICollection<AdminModel> Admins { get; set; }

    }
}
