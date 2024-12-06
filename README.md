# FlightInfo
## MEMBRI DEL GRUPPO
- [Giulia Balestra](https://github.com/Giulieen)
- [Giulia Trozzi](https://github.com/GiuliaTrz)
- [Francesco Valentini](https://github.com/FrancescoValentini)
## DESCRIZIONE DEL PROGETTO
- [Specifiche del Docente](Documentazione/SpecificheDocente.md)
- [Specifiche API](Documentazione/DocumentazioneAPI.md)

FlightInfo consente di ottenere le informazioni di un aeromobile in volo effettuando la ricerca attraverso il callsign o il suo codice ICAO.

**FlightInfo non raccoglie direttamente i dati** ma fornisce una interfaccia grafica e user friendly per interagire con il servizio https://airplanes.live che mette a disposizione le informazioni raccolte dai suoi utenti volontari 'feeder' mediante interfaccia REST senza necessità di autenticazione o pagamenti (ma con limitazioni), inoltre per gli sviluppatori FlightInfo consente l'accesso alle proprie funzionalità di ricerca anche tramite un servizio SOAP agendo quindi da "traduttore" REST < -- > SOAP.

> [!NOTE]
> **Provenienza delle informazioni**
> 
> Le informazioni provengono da una rete di volontari che installano ricevitori per la ricezione del segnale ADS-B o la multilaterazione. Questi volontari, chiamati 'feeder', inviano alla piattaforma, che funge da 'concentratore', le informazioni raccolte con i loro apparati.

## L'ICAO
L'ICAO (International Civil Aviation Organization) è un'agenzia autonoma delle Nazioni Unite incaricata di sviluppare i principi e le tecniche della navigazione aerea internazionale, delle rotte e degli aeroporti e promuovere la progettazione e lo sviluppo del trasporto aereo internazionale rendendolo più sicuro e ordinato.

### IL CODICE ICAO
Il codice ICAO è un identificatore univoco a 24 bit assegnato a ciascun aeromobile registrato a livello globale. Questo codice, rappresentato in formato esadecimale per comodità, è parte integrante del sistema di identificazione aerea e viene trasmesso automaticamente dai transponder ADS-B degli aeromobili.

## IL SISTEMA ADS-B
Il sistema ADS-B (Automatic Dependent Surveillance-Broadcast) è una tecnologia di sorveglianza aerea che consente agli aeromobili di trasmettere automaticamente la loro posizione e altri dati di volo in tempo reale.

ADS-B è un sistema "automatico" che non richiede l'interazione del pilota o di altri attori esterni per attivare la trasmissione ma è considerato "dipendente" in quanto dipende dai dati provenienti dai sistemi di navigazione del velivolo che vengono inclusi nel pacchetto ADS-B per poi essere trasmessi, i dati vengono inviati in broadcast, il trasmettitore invia i pacchetti senza sapere chi li riceverà o se arriveranno integri.

**Frequenze utilizzate da ADS-B:** 
- **1090 MHz:** Utilizzata dalla maggior parte degli aeromobili commerciali e internazionali.
- **978 MHz (UAT):** Usata principalmente negli Stati Uniti.

### CIFRATURA
Esiste una modalità riservata esclusivamente per le Forze Armate degli Stati Uniti e della NATO chiamata "Mode 5". Questa modalità è una versione cifrata del "Mode S" civile. Mode 5 utilizza algoritmi di crittografia avanzata per proteggere i dati trasmessi, che includono identificazioni e informazioni operative sensibili. A differenza del Mode S civile, le trasmissioni in Mode 5 possono essere ricevute ma non decodificate, garantendo così una maggiore sicurezza. Solo dispositivi militari autorizzati (configurati con le variabili crittografiche corrette) possono interagire con queste trasmissioni.

L'ADS-B utilizzato in ambito civile non è cifrato, questo ne consente la decodifica non solo da appassionati ma anche dai piloti stessi migliorando la sicurezza in volo.

### Ricevere il segnale ADS-B
Ricevere le trasmissioni ADS-B è un’operazione semplice ed economica. Uno dei metodi più comuni è l’utilizzo di chiavette USB SDR (Software Defined Radio), come le popolari RTL-SDR. Questi dispositivi, originariamente progettati per ricevere segnali DVB-T o FM, possono essere configurati per ricevere e decodificare i segnali ADS-B grazie al loro ampio intervallo di frequenze supportate (inclusa quella di 1090 MHz).

Dopo aver acquistato una chiavetta compatibile, è necessario installare i driver, posizionare l'antenna e utilizzare software open-source come dump1090. Questo software sintonizza il ricevitore sulla frequenza corretta, demodula il segnale e decodifica i pacchetti ADS-B, rendendo disponibili le informazioni via interfaccia web o in formato JSON.

### Differenze tra ADS-B e MLAT (Multilaterazione)
La principale differenza tra ADS-B e MLAT (Multilaterazione) risiede nel modo in cui vengono determinate le informazioni sulla posizione dell’aeromobile:

- **ADS-B:** Gli aeromobili trasmettono direttamente la propria posizione, velocità e altitudine grazie a dati GPS integrati. Questi dati sono estremamente precisi e possono essere ricevuti anche da un singolo ricevitore.
- **MLAT:** La posizione dell’aeromobile viene calcolata tramite la sincronizzazione temporale dei segnali ricevuti da una rete di almeno quattro ricevitori. Questo metodo è utilizzato principalmente per tracciare velivoli privi di transponder ADS-B o con transponder in modalità base (Mode A/C). La precisione di MLAT dipende dalla qualità e densità dei ricevitori nella regione.

ADS-B è più preciso e non richiede un’infrastruttura complessa, mentre MLAT può essere meno affidabile in aree con pochi ricevitori sincronizzati.
## TECNOLOGIE UTILIZZATE
- [ASP.NET Core MVC](https://dotnet.microsoft.com/it-it/apps/aspnet)
- [Microsoft Visual Studio](https://visualstudio.microsoft.com/it/)
- [JetBrains Rider](https://www.jetbrains.com/rider/)
- [Microsoft Visual studio Code](https://code.visualstudio.com/)
- [Docker](https://www.docker.com/)