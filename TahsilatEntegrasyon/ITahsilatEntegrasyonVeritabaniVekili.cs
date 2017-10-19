using System;

namespace TahsilatEntegrasyon
{
	public interface ITahsilatEntegrasyonVeritabaniVekili
	{
		void OncedenYaratilmisEntegrasyonFisleriniTemizle(DateTime tarihBaslangic, DateTime tarihBitis);
		void EntegreEdilecekTahsilatlariAl(DateTime tarihBaslangic, DateTime tarihBitis);
	}
}