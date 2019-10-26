using System;
using System.Collections.Generic;
using System.Text;

namespace Contas.Domain.Models
{
    public abstract class BaseModel
    {
        
        public int Id { get; protected set; }
    }
}
