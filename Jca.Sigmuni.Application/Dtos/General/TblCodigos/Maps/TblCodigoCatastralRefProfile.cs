﻿using AutoMapper;
using Jca.Sigmuni.Domain.General;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jca.Sigmuni.Application.Dtos.General.TblCodigos.Maps
{
    public class TblCodigoCatastralRefProfile : Profile
    {
        public TblCodigoCatastralRefProfile()
        {
            CreateMap<TblCodigo, TblCodigoCatastralRefDto>();
        }
    }
}
