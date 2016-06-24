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
  `SilahNo` varchar(45) CHARACTER SET utf8 NOT NULL,
  `Durumu` varchar(45) COLLATE utf8_unicode_ci DEFAULT NULL,
  `BakimZamani` datetime DEFAULT NULL,
  `Aciklama` varchar(45) COLLATE utf8_unicode_ci DEFAULT NULL,
  `KayitTarihi` datetime DEFAULT NULL,
  `Marka` varchar(45) COLLATE utf8_unicode_ci DEFAULT NULL,
  `Model` varchar(45) COLLATE utf8_unicode_ci DEFAULT NULL,
  PRIMARY KEY (`SilahId`),
  UNIQUE KEY `SilahNo_UNIQUE` (`SilahNo`)
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

CREATE TABLE `grup` (
  `GrupId` int(11) NOT NULL AUTO_INCREMENT,
  `GrupAdi` varchar(45) COLLATE utf8_turkish_ci NOT NULL,
  PRIMARY KEY (`GrupId`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_turkish_ci;

CREATE TABLE `grupkullanici` (
  `GrupKullaniciId` int(11) NOT NULL AUTO_INCREMENT,
  `GrupId` int(11) NOT NULL,
  `KullaniciId` int(11) NOT NULL,
  PRIMARY KEY (`GrupKullaniciId`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_turkish_ci;

CREATE TABLE `grupizin` (
  `GrupIzinId` int(11) NOT NULL AUTO_INCREMENT,
  `GrupId` int(11) NOT NULL,
  `IzinId` int(11) NOT NULL,
  PRIMARY KEY (`GrupIzinId`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_turkish_ci;

CREATE TABLE `izin` (
  `IzinId` int(11) NOT NULL AUTO_INCREMENT,
  `IzinAdi` varchar(45) COLLATE utf8_turkish_ci NOT NULL,
  PRIMARY KEY (`IzinId`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_turkish_ci;


INSERT INTO `sts`.`izin` (`IzinAdi`) VALUES ('Sorgulama');
INSERT INTO `sts`.`izin` (`IzinAdi`) VALUES ('Çıktı Alma');
INSERT INTO `sts`.`izin` (`IzinAdi`) VALUES ('Rapor Kaydetme');
INSERT INTO `sts`.`izin` (`IzinAdi`) VALUES ('Kullanıcı Ekleme');
INSERT INTO `sts`.`izin` (`IzinAdi`) VALUES ('Kullanıcı Silme');
INSERT INTO `sts`.`izin` (`IzinAdi`) VALUES ('Kullanıcı Değiştirme');
INSERT INTO `sts`.`izin` (`IzinAdi`) VALUES ('Kullanıcı Listeleme');
INSERT INTO `sts`.`izin` (`IzinAdi`) VALUES ('Grup ve İzin ayarlama');
INSERT INTO `sts`.`izin` (`IzinAdi`) VALUES ('Personel Ekleme');
INSERT INTO `sts`.`izin` (`IzinAdi`) VALUES ('Personel Silme');
INSERT INTO `sts`.`izin` (`IzinAdi`) VALUES ('Personel Değiştirme');
INSERT INTO `sts`.`izin` (`IzinAdi`) VALUES ('Personel Listeleme');
INSERT INTO `sts`.`izin` (`IzinAdi`) VALUES ('Silah Ekleme');
INSERT INTO `sts`.`izin` (`IzinAdi`) VALUES ('Silah Silme');
INSERT INTO `sts`.`izin` (`IzinAdi`) VALUES ('Silah Değiştirme');
INSERT INTO `sts`.`izin` (`IzinAdi`) VALUES ('Silah Listeleme');
INSERT INTO `sts`.`izin` (`IzinAdi`) VALUES ('Silah Giriş Çıkış');


