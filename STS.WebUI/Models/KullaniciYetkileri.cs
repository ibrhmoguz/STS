using STS.Domain.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace STS.WebUI.Models
{

    public class KullaniciYetkileri
    {
        public bool Sorgulama { get; private set; }
        public bool CiktiAlma { get; private set; }
        public bool RaporKaydetme { get; private set; }
        public bool KullaniciEkleme { get; private set; }
        public bool KullaniciSilme { get; private set; }
        public bool KullaniciDegistirme { get; private set; }
        public bool KullaniciListeleme { get; private set; }
        public bool PersonelEkleme { get; private set; }
        public bool PersonelSilme { get; private set; }
        public bool PersonelDegistirme { get; private set; }
        public bool PersonelListeleme { get; private set; }
        public bool GrupIzinAyarlama { get; private set; }
        public bool SilahEkleme { get; private set; }
        public bool SilahSilme { get; private set; }
        public bool SilahDegistirme { get; private set; }
        public bool SilahListeleme { get; private set; }
        public bool SilahGirisCikis { get; private set; }

        public KullaniciYetkileri(IEnumerable<string> yetkiListesi)
        {
            foreach (var yetki in yetkiListesi)
            {
                switch (yetki)
                {
                    case "Sorgulama":
                        this.Sorgulama = true;
                        break;
                    case "Çıktı Alma":
                        this.CiktiAlma = true;
                        break;
                    case "Rapor Kaydetme":
                        this.RaporKaydetme = true;
                        break;
                    case "Kullanıcı Ekleme":
                        this.KullaniciEkleme = true;
                        break;
                    case "Kullanıcı Silme":
                        this.KullaniciSilme = true;
                        break;
                    case "Kullanıcı Değiştirme":
                        this.KullaniciDegistirme = true;
                        break;
                    case "Kullanıcı Listeleme":
                        this.KullaniciListeleme = true;
                        break;
                    case "Personel Ekleme":
                        this.PersonelEkleme = true;
                        break;
                    case "Personel Silme":
                        this.PersonelSilme = true;
                        break;
                    case "Personel Değiştirme":
                        this.PersonelDegistirme = true;
                        break;
                    case "Personel Listeleme":
                        this.PersonelListeleme = true;
                        break;
                    case "Grup ve İzin ayarlama":
                        this.GrupIzinAyarlama = true;
                        break;
                    case "Silah Ekleme":
                        this.SilahEkleme = true;
                        break;
                    case "Silah Silme":
                        this.SilahSilme = true;
                        break;
                    case "Silah Değiştirme":
                        this.SilahDegistirme = true;
                        break;
                    case "Silah Listeleme":
                        this.SilahListeleme = true;
                        break;
                    case "Silah Giriş Çıkış":
                        this.SilahGirisCikis = true;
                        break;
                    default:
                        break;
                }
            }
        }
    }
}