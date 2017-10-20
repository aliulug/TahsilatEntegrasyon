Proje yaratıldıktan sonra NSubstitute.dll referans olarak eklenmeli.
NuGet package manager içinden "install-package nunit" komutu çalıştırılmalı

tahsilat - muhasebe entegrasyonu
-----------------------------------------
tahsilat kayıtlarını alıp bunlarla ilişkili muhasebe kayıtlarını yaratacak bir uygulama yazılacak.

istenilen tarih aralığındaki, veritabanındaki tahsilat kayıtlarını okuyup, bunlarla ilişkili muhasebe fişlerinin oluşturulması isteniyor. işlemin 30 dakika gibi düzenli aralıklarla çalıştırılması planlanıyor. aynı zamanda toplu olarak belli bir tarih aralığı içinde çalıştırılabilmeli. 


gereksinimler
-----------------------------------------
entegrasyon parametreleri kurallara uygun olmazsa işlem başlatılmaz
 - işlem sadece aynı ay içindeki iki gün arasındaki tahsilatlar için yapılabilir
 - işlem yapılan ay açık olmalı
 - işlemi sadece yetkili bir kullanıcı yapabilir
 
entegrasyon öncesi temizlik yapılır - önceden oluşturulmuş ilgili fişler silinir

her bir tahsilat kaydı için bir borç bir alacak olmak üzere iki satır yaratılır. bir entegrasyon fişinde en fazla 1000 satır olabilir. 

entegrasyonu yapılan her bir tahsilatın üzerine, oluşturulan fişin bilgisi yazılır

entegrasyon öncesi temizlik opsiyoneldir









