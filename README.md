# MarsApp-Net6

 

**Bu proje .NET 6 Framework kullanılarak geliştirilmiştir.**

Test için Swagger kullanılabilir, Swagger otomatik yüklü olarak gelmiştir. 
Veriler örnekte verildiği gibi aralarında boşluk bırakılarak girilmelidir. 
Komutlar da aynı şekilde girilebilir ancak komutlar için boşluk bırakılsa da bırakılmasa da kontrol sağlanmıştır. 
Verilen komutlar neticesinde, sınır dışına çıkılması durumu da kontrol edilmiştir. 
(0,0) noktasından aşağı ya da verilen sağ üst noktadan dışarı çıkılırsa hata mesajı döndürülmüştür. 

 
**Endpoint**
*https://localhost:7261/api/Home*

**Input Example** 
> { "upperRightCoordinates": "5 5", "roversPosition": "1 2 N", "instructions": "LMLMLMLMM" } 
