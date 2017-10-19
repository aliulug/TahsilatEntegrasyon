﻿using System;
using NSubstitute;
using NUnit.Framework;

namespace TahsilatEntegrasyon
{
	[TestFixture]
	public class TahsilatEntegrasyonMotoruTest
	{
		private TahsilatEntegrasyonMotoru _motor;
		private IAyAcikKontrolcu _ayAcikKontrolcusu;
		private IYetkiKontrolcusu _yetkiKontrolcusu;
		private ITahsilatEntegrasyonVeritabaniVekili _veritabaniVekili;

		[SetUp]
		public void ilk_ayarlar()
		{
			_ayAcikKontrolcusu = Substitute.For<IAyAcikKontrolcu>();
			_yetkiKontrolcusu = Substitute.For<IYetkiKontrolcusu>();
			_veritabaniVekili = Substitute.For<ITahsilatEntegrasyonVeritabaniVekili>();
			_motor = new TahsilatEntegrasyonMotoru(_ayAcikKontrolcusu, _yetkiKontrolcusu, _veritabaniVekili);
		}

		[Test]
		public void farkli_aylara_islem_yapilmak_istenilirse_hata_doner()
		{
			ortamAyarla(true, true);
			EntegrasyonParametreler parametreler = new EntegrasyonParametreler
			{
				TarihBaslangic = DateTime.Today,
				TarihBitis = DateTime.Today.AddMonths(2),
				TemizlikYap = false
			};
			var sonuc = _motor.EntegrasyonYap(parametreler);
			Assert.AreEqual(SonucTip.SadeceTekBirAyIcinIslemYapilabilir, sonuc.Tip);
		}

		[Test]
		public void islem_yapilan_ay_acik_olmali()
		{
			ortamAyarla(false, true);

			EntegrasyonParametreler parametreler = new EntegrasyonParametreler
			{
				TarihBaslangic = DateTime.Today,
				TarihBitis = DateTime.Today.AddDays(1),
				TemizlikYap = false
			};
			var sonuc = _motor.EntegrasyonYap(parametreler);

			Assert.AreEqual(SonucTip.SadeceAcikAyIcinEntegrasyonYapilabilir, sonuc.Tip);
		}

		[Test]
		public void islemi_sadece_yetkili_kullanicilar_yapabilir()
		{
			ortamAyarla(true, false);
			EntegrasyonParametreler parametreler = new EntegrasyonParametreler
			{
				TarihBaslangic = DateTime.Today,
				TarihBitis = DateTime.Today.AddDays(1),
				TemizlikYap = false
			};
			var sonuc = _motor.EntegrasyonYap(parametreler);

			Assert.AreEqual(SonucTip.KullaniciIslemYapmayaYetkiliDegil, sonuc.Tip);
		}

		[Test]
		public void islem_oncesi_temizlik_yapilir()
		{
			ortamAyarla(true, true);

			EntegrasyonParametreler parametreler = new EntegrasyonParametreler
			{
				TarihBaslangic = DateTime.Today,
				TarihBitis = DateTime.Today.AddDays(1),
				TemizlikYap = true
			};
			var sonuc = _motor.EntegrasyonYap(parametreler);

			_veritabaniVekili.Received(1).OncedenYaratilmisEntegrasyonFisleriniTemizle(parametreler.TarihBaslangic, parametreler.TarihBitis);

			Assert.AreEqual(SonucTip.EntegrasyonTamamlandi, sonuc.Tip);
		}

		private void ortamAyarla(bool ayAcik, bool yetkiVar)
		{
			_ayAcikKontrolcusu.AyAcikMi(DateTime.Today).Returns(ayAcik);
			_yetkiKontrolcusu.TahsilatEntegrasyonYetkisiVarMi().Returns(yetkiVar);
		}
	}
}