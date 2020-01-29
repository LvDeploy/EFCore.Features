using System;
using System.Collections.Generic;
using System.Text;

namespace EFCore.Model
{
    public class BaseModel
    {
        public BaseModel()
        {
            if (Id == Guid.Empty)
                Id = Guid.NewGuid();
        }

        public Guid Id { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateUpdated { get; set; }
    }
}
