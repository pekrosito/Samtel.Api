﻿using Samtel.Domain.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Samtel.Application.BusinessService
{
    public interface IPersonRepository
    {
        Person getPersons();
    }
}
