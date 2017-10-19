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

		[SetUp]
		public void ilk_ayarlar()
		{
			_ayAcikKontrolcusu = Substitute.For<IAyAcikKontrolcu>();
			_motor = new TahsilatEntegrasyonMotoru(_ayAcikKontrolcusu);
		}

		[Test]
		public void farkli_aylara_islem_yapilmak_istenilirse_hata_doner()
		{
			_ayAcikKontrolcusu.AyAcikMi(Arg.Any<DateTime>()).Returns(true);

			var sonuc = _motor.EntegrasyonYap(DateTime.Today, DateTime.Today.AddMonths(2));

			Assert.AreEqual(SonucTip.SadeceTekBirAyIcinIslemYapilabilir, sonuc.Tip);
		}

		[Test]
		public void islem_yapilan_ay_acik_olmali()
		{
			_ayAcikKontrolcusu.AyAcikMi(DateTime.Today).Returns(false);

			var sonuc = _motor.EntegrasyonYap(DateTime.Today, DateTime.Today.AddDays(1));

			Assert.AreEqual(SonucTip.SadeceAcikAyIcinEntegrasyonYapilabilir, sonuc.Tip);
		}
	}
}
