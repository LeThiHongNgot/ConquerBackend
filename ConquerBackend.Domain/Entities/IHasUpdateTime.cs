﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConquerBackend.Domain.Entities
{
    public interface IHasUpdateTime
    {
       DateTime? ModifiedAt { get; set; }
    }
}
