namespace TahsilatEntegrasyon
{
	public class EntegrasyonSonuc
	{
		public EntegrasyonSonuc(SonucTip sadeceAcikAyIcinEntegrasyonYapilabilir)
		{
			Tip = sadeceAcikAyIcinEntegrasyonYapilabilir;
		}

		public SonucTip Tip { get; set; }
	}

	public enum SonucTip
	{
		SadeceTekBirAyIcinIslemYapilabilir,
		SadeceAcikAyIcinEntegrasyonYapilabilir,
		KullaniciIslemYapmayaYetkiliDegil
	}
}