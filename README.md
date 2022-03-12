# Worker-Service
Net Core 5 Worker Service ile Windows Service uygulması

## Windows kurumlumu için
1. Exe Dosyasını <a id="raw-url" href="https://github.com/FatihDumlupinar/Worker-Service/raw/master/Dosyalar/VeriketService.exe" download>İndir</a>
2. Windows Hizmetlere eklemek için : 
   - Komut istemini(Cmd) Yönetici olarak açın.
   - Aşağıdaki kodu yazın 
    ```
    sc create WorkerService BinPath=[Exe nin Tam dosya yolu]
     ```
    - Hizmeti başlatmak için
    ```
    sc start WorkerService
    ```
  
## Uygulamının görüntüleri

> Uygulamanın görünümü:
![App's view](https://github.com/FatihDumlupinar/Worker-Service/blob/master/Dosyalar/1.png?raw=true)

> AppData klasoru
![App's view](https://github.com/FatihDumlupinar/Worker-Service/blob/master/Dosyalar/2.png?raw=true)

> Text belgesine kaydedilen kayıt
![App's view](https://github.com/FatihDumlupinar/Worker-Service/blob/master/Dosyalar/3.png?raw=true)
