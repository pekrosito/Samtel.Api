﻿using Samtel.Domain.Models.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Samtel.Domain.Models.Entities
{
    public class Identification: Entity
    {
        public int id { get; set; }
        public string identification { get; set; }
    }
}

