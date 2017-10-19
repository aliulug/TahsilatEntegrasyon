using System;

namespace TahsilatEntegrasyon
{
	public class TahsilatEntegrasyonMotoru
	{
		private readonly IAyAcikKontrolcu _ayAcikKontrolcusu;
		private readonly IYetkiKontrolcusu _yetkiKontrolcusu;
		private readonly ITahsilatEntegrasyonVeritabaniVekili _veritabaniVekili;

		public TahsilatEntegrasyonMotoru(IAyAcikKontrolcu ayAcikKontrolcusu, IYetkiKontrolcusu yetkiKontrolcusu, ITahsilatEntegrasyonVeritabaniVekili veritabaniVekili)
		{
			_ayAcikKontrolcusu = ayAcikKontrolcusu;
			_yetkiKontrolcusu = yetkiKontrolcusu;
			_veritabaniVekili = veritabaniVekili;
		}

		public EntegrasyonSonuc EntegrasyonYap(EntegrasyonParametreler parametreler)
		{
			if (!_yetkiKontrolcusu.TahsilatEntegrasyonYetkisiVarMi())
				return new EntegrasyonSonuc(SonucTip.KullaniciIslemYapmayaYetkiliDegil);

			if (!_ayAcikKontrolcusu.AyAcikMi(parametreler.TarihBaslangic))
				return new EntegrasyonSonuc(SonucTip.SadeceAcikAyIcinEntegrasyonYapilabilir);

			if (parametreler.TarihBaslangic.Month != parametreler.TarihBitis.Month || parametreler.TarihBaslangic.Year != parametreler.TarihBitis.Year)
				return new EntegrasyonSonuc(SonucTip.SadeceTekBirAyIcinIslemYapilabilir);

			_veritabaniVekili.OncedenYaratilmisEntegrasyonFisleriniTemizle(parametreler.TarihBaslangic,parametreler.TarihBitis);
			_veritabaniVekili.EntegreEdilecekTahsilatlariAl(parametreler.TarihBaslangic, parametreler.TarihBitis);

			return new EntegrasyonSonuc(SonucTip.EntegrasyonTamamlandi);
		}
	}
}