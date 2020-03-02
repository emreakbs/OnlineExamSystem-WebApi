using System;
using System.Collections.Generic;
using System.Text;
using Core.Interfaces;

namespace Core.Model
{
    public abstract class BaseModel:IBaseModel
    {
        public int Id { get; set; }
    }
}
