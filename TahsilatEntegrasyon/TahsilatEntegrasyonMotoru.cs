using System;

namespace TahsilatEntegrasyon
{
	public class TahsilatEntegrasyonMotoru
	{
		private readonly IAyAcikKontrolcu _ayAcikKontrolcusu;
		private IYetkiKontrolcusu _yetkiKontrolcusu;

		public TahsilatEntegrasyonMotoru(IAyAcikKontrolcu ayAcikKontrolcusu, IYetkiKontrolcusu yetkiKontrolcusu)
		{
			_ayAcikKontrolcusu = ayAcikKontrolcusu;
			_yetkiKontrolcusu = yetkiKontrolcusu;
		}

		public EntegrasyonSonuc EntegrasyonYap(DateTime tarihBaslangic, DateTime tarihBitis)
		{
			if (!_yetkiKontrolcusu.TahsilatEntegrasyonYetkisiVarMi())
				return new EntegrasyonSonuc(SonucTip.KullaniciIslemYapmayaYetkiliDegil);


			if (!_ayAcikKontrolcusu.AyAcikMi(tarihBaslangic))
				return new EntegrasyonSonuc(SonucTip.SadeceAcikAyIcinEntegrasyonYapilabilir);

			return new EntegrasyonSonuc(SonucTip.SadeceTekBirAyIcinIslemYapilabilir);
		}
	}
}