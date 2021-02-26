# AliniyorApi

+Data dosyaları wwwroot klasörünün içindedir.

+Hangi Servis'i(XmlService,CsvService) çalıştırmak istediğinize start-up dosyasındaki 21.satırda bulunan
 
"services.AddTransient<IServiceData, CsvService>();" kod satırındaki CsvService yerine XmlService yazdığınızda XmlService 

çalışacaktır.Eğer değiştirmezseniz CsvService çalışacaktır.Uygulamaya yeni bir service entegre edeceğimiz zaman 

servisimizi IServiceData interface'sinden inherit ettiğimiz takdirde herhangi bir source koda dokunmadan yeni

servisimizi entegre edebiliriz.




+uygulamayı çalıştırdıktan sonra apiyi görmek için controllerdaki routeları girmek yeterlidir.


+http://Yourlocalhost/api/Cities/GetCitiesAsc
	Şehir isimlerini A dan Z ye sıralayarak gösterir

http://Yourlocalhost/api/Cities/GetCitiesDesc
	Şehir isimlerini Z den A ya sıralayarak gösterir

http://Yourlocalhost/api/Cities/GetCity/{CityName}
	Girilen Şehir isminin verilerini döndürür.

http://Yourlocalhost/api/Cities/GetDistirict/{DistrictName}
	Girilen İlçe isminin bulunduğu şehrin ilçelerini döndürür.


