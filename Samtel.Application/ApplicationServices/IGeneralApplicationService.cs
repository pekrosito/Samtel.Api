﻿using Samtel.Application.ApplicationServices.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Samtel.Application.ApplicationServices
{
    public interface IGeneralApplicationService
    {
        List<GeneralDTO> getIdentification();
        List<GeneralDTO> getOcupations();
    }
}
