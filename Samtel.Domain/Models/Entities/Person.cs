﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Samtel.Domain.Models.Base;

namespace Samtel.Domain.Models.Entities
{
    public class Person : Entity
    {
        public string name { get; set; }
        public string surname { get; set; }
    }
}
