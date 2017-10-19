using System;

namespace TahsilatEntegrasyon
{
	public class EntegrasyonParametreler
	{
		public EntegrasyonParametreler(DateTime tarihBaslangic, DateTime tarihBitis, bool temizlikYap)
		{
			TarihBaslangic = tarihBaslangic;
			TarihBitis = tarihBitis;
			TemizlikYap = temizlikYap;
		}

		public DateTime TarihBaslangic { get; set; }
		public DateTime TarihBitis { get; set; }
		public bool TemizlikYap { get; set; }
	}
}