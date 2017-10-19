using System;
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

		[SetUp]
		public void ilk_ayarlar()
		{
			_ayAcikKontrolcusu = Substitute.For<IAyAcikKontrolcu>();
			_yetkiKontrolcusu = Substitute.For<IYetkiKontrolcusu>();
			_motor = new TahsilatEntegrasyonMotoru(_ayAcikKontrolcusu, _yetkiKontrolcusu);
		}

		[Test]
		public void farkli_aylara_islem_yapilmak_istenilirse_hata_doner()
		{
			_ayAcikKontrolcusu.AyAcikMi(Arg.Any<DateTime>()).Returns(true);
			_yetkiKontrolcusu.TahsilatEntegrasyonYetkisiVarMi().Returns(true);

			var sonuc = _motor.EntegrasyonYap(DateTime.Today, DateTime.Today.AddMonths(2));

			Assert.AreEqual(SonucTip.SadeceTekBirAyIcinIslemYapilabilir, sonuc.Tip);
		}

		[Test]
		public void islem_yapilan_ay_acik_olmali()
		{
			_ayAcikKontrolcusu.AyAcikMi(DateTime.Today).Returns(false);
			_yetkiKontrolcusu.TahsilatEntegrasyonYetkisiVarMi().Returns(true);


			var sonuc = _motor.EntegrasyonYap(DateTime.Today, DateTime.Today.AddDays(1));

			Assert.AreEqual(SonucTip.SadeceAcikAyIcinEntegrasyonYapilabilir, sonuc.Tip);
		}

		[Test]
		public void islemi_sadece_yetkili_kullanicilar_yapabilir()
		{
			_ayAcikKontrolcusu.AyAcikMi(DateTime.Today).Returns(true);
			_yetkiKontrolcusu.TahsilatEntegrasyonYetkisiVarMi().Returns(false);
			
			var sonuc = _motor.EntegrasyonYap(DateTime.Today, DateTime.Today.AddDays(1));

			Assert.AreEqual(SonucTip.KullaniciIslemYapmayaYetkiliDegil, sonuc.Tip);
		}
	}

	public interface IYetkiKontrolcusu
	{
		bool TahsilatEntegrasyonYetkisiVarMi();
	}
}
