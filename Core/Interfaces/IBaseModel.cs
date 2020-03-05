using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Core.Interfaces
{
    public interface IBaseModel
    {
        [Key]
        int Id { get; set; }
        bool Status { get; set; }
    }
}
