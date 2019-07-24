using Abastible.Sge.Application.Model.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Samtel.Domain.Models.Base
{
    public class error : Entity
    {
        public bool success { get; set; }
        public int errorCode { get; set; }
        public string message { get; set; }
    }
}
