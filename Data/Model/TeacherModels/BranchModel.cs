using System;
using System.Collections.Generic;
using System.Text;
using Core.Model;
using Newtonsoft.Json;

namespace Data.Model.TeacherModels
{
    /// <summary>
    /// Öretmenin uzmanlık alanını belirtir
    /// </summary>
    public class BranchModel : BaseModel
    {
        /// <summary>
        /// Alan adını belirtir.
        /// </summary>
        public string BranchName { get; set; }
        [JsonIgnore] public virtual ICollection<TeacherModel> Teachers { get; set; }
    }
}
