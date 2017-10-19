using System;

namespace TahsilatEntegrasyon
{
	public class TahsilatEntegrasyonMotoru
	{
		private readonly IAyAcikKontrolcu _ayAcikKontrolcusu;

		public TahsilatEntegrasyonMotoru(IAyAcikKontrolcu ayAcikKontrolcusu)
		{
			_ayAcikKontrolcusu = ayAcikKontrolcusu;
		}

		public EntegrasyonSonuc EntegrasyonYap(DateTime tarihBaslangic, DateTime tarihBitis)
		{
			if (!_ayAcikKontrolcusu.AyAcikMi(tarihBaslangic))
				return new EntegrasyonSonuc(SonucTip.SadeceAcikAyIcinEntegrasyonYapilabilir);

			return new EntegrasyonSonuc(SonucTip.SadeceTekBirAyIcinIslemYapilabilir);
		}
	}
}