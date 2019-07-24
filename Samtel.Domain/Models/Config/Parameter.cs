using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Samtel.Domain.Models.Base;

namespace Samtel.Domain.Models.Config
{
    public class Parameter : Entity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Value { get; set; }
    }
}
