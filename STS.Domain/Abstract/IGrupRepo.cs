﻿using STS.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STS.Domain.Abstract
{
    public interface IGrupRepo
    {
        IEnumerable<Grup> Gruplar { get; }
        void GrupKaydet(Grup g);
        string GrupSil(int Id);
    }
}
