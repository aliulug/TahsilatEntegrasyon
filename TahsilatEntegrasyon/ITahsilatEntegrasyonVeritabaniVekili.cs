using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace TahsilatEntegrasyon
{
	public interface ITahsilatEntegrasyonVeritabaniVekili
	{
		void OncedenYaratilmisEntegrasyonFisleriniTemizle(DateTime tarihBaslangic, DateTime tarihBitis);
		List<Tahsilat> EntegreEdilecekTahsilatlariAl(DateTime tarihBaslangic, DateTime tarihBitis);
		void YeniEntegrasyonFisiGir();
		void EntegrasyonFisineSatirlariEkle(List<Tahsilat> tahsilatlar);
	}
}