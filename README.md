# Worker-Service
Net Core 5 Worker Service ile Windows Service uygulması

## Windows servis olarak bilgisayara kurmak için: 
1. Konsole Uygulasını yönetici olarak başlatın
2. Uygulamayı windows hizmetlerine eklemek için aşağıdaki komotu konsola yazın
```
sc.exe create [Servis Adı] binpath="[Tam dosya yolu]\VeriketService\VeriketService\bin\Release\net5.0\win-x64\publish\VeriketService.exe"
```
3. Servisi başlatmak için:
```
sc.exe start [Servis Adı]
```


> Uygulamanın görünümü:
![App's view](https://github.com/FatihDumlupinar/Worker-Service/blob/master/Dosyalar/1.png?raw=true)

> AppData klasoru
![App's view](https://github.com/FatihDumlupinar/Worker-Service/blob/master/Dosyalar/2.png?raw=true)

> Text belgesine kaydedilen kayıt
![App's view](https://github.com/FatihDumlupinar/Worker-Service/blob/master/Dosyalar/3.png?raw=true)
