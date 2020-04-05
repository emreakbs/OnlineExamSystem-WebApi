using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using Core.Interfaces;

namespace Core.Model
{
    /// <summary>
    /// Tüm modellerde kullanılacak field'lar
    /// </summary>
    public abstract class BaseModel : IBaseModel
    {
        public int Id { get; set; }
        /// <summary>
        /// Aktiflik durumunu belirtir.
        /// </summary>
        public bool Status { get; set; }
    }

}
