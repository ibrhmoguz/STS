﻿using STS.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STS.Domain.Abstract
{
    public interface IGrupIzinRepo
    {
        IEnumerable<GrupIzin> GrupIzinler { get; }
        void GrupIzinKaydet(GrupIzin g);
        string GrupIzinSilGrupIdIle(int grupId);
        bool GrupIzinSilIzinIdVeGrupIdIle(int izinId, int grupId);
    }
}
