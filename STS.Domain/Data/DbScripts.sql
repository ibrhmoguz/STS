CREATE TABLE `pers` (
  `Persid` int(11) NOT NULL AUTO_INCREMENT,
  `PersAd` varchar(45) COLLATE utf8_unicode_ci DEFAULT NULL,
  `PersSoyad` varchar(45) COLLATE utf8_unicode_ci DEFAULT NULL,
  `PersTcNo` varchar(45) COLLATE utf8_unicode_ci DEFAULT NULL,
  `PersKartId` varchar(45) COLLATE utf8_unicode_ci DEFAULT NULL,
  `PersKartSeriNo` varchar(45) COLLATE utf8_unicode_ci DEFAULT NULL,
  `PersBirlikAdi` varchar(45) COLLATE utf8_unicode_ci DEFAULT NULL,
  `PersKayitTarihi` datetime DEFAULT NULL,
  `FotoData` mediumblob,
  `FotoMimeType` varchar(45) COLLATE utf8_unicode_ci DEFAULT NULL,
  PRIMARY KEY (`Persid`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;

CREATE TABLE `silah` (
  `SilahId` int(11) NOT NULL AUTO_INCREMENT,
  `SilahNo` varchar(45) COLLATE utf8_unicode_ci DEFAULT NULL,
  `Durumu` varchar(45) COLLATE utf8_unicode_ci DEFAULT NULL,
  `BakimZamani` datetime DEFAULT NULL,
  `Aciklama` varchar(45) COLLATE utf8_unicode_ci DEFAULT NULL,
  PRIMARY KEY (`SilahId`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;

CREATE TABLE `kullanici` (
  `KullaniciId` int(11) NOT NULL AUTO_INCREMENT,
  `KullaniciAdi` varchar(50) COLLATE utf8_unicode_ci DEFAULT NULL,
  `Sifre` varchar(50) COLLATE utf8_unicode_ci DEFAULT NULL,
  `FotoData` mediumblob,
  `FotoMimeType` varchar(45) COLLATE utf8_unicode_ci DEFAULT NULL,
  `Adi` varchar(45) COLLATE utf8_unicode_ci DEFAULT NULL,
  `Soyadi` varchar(45) COLLATE utf8_unicode_ci DEFAULT NULL,
  `KayitTarihi` datetime DEFAULT NULL,
  PRIMARY KEY (`KullaniciId`)
) ENGINE=InnoDB AUTO_INCREMENT=13 DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;
