# airplanes.live API
## Descrizione
La API consente di ottenere informazioni LIVE di un aeromobile attualmente in volo, tra le informazioni ci sono: modello, proprietario, velocità, latitudine e longitudine.

Le informazioni provengono da una rete di volontari che installano ricevitori per la ricezione del segnale ADS-B o la multilaterazione. questi volontari, chiamati 'feeder', inviano alla piattaforma, che funge da 'concentratore', le informazioni raccolte con i loro apparati.

> [!NOTE]
> La API non restituisce alcun risultato se:
> - L'aeromobile non è attualmente in volo
> - Nessun ricevitore ha ancora ricevuto pacchetti dall'aeromobile o se la multilaterazione è fallita
> - L'aeromobile ha il trasponder spento o in Modo 5 (versione cifrata di ADS-B utilizzata per scopi militari)

## LIMITI DELLA API
La API non richiede autenticazione o pagamento per essere utilizzata, ha però un limite di una richiesta per secondo

## URL BASE
L'URL base della API è `https://api.airplanes.live/v2/` , da qui vengono poi specificati i vari endpoint per effettuare la ricerca con il parametro desiderato. 

La documentazione completa è disponibile presso `https://airplanes.live/api-guide/` , in questo documento vengono riportati solamente gli endpoint utilizzati nel progetto

## ENDPOINT: `/callsign/[callsign]`

**Descrizione:** Consente di effettuare una ricerca attraverso il callsign di un aeromobile.

**Metodo:** GET

**Esempio:** `curl https://api.airplanes.live/v2/callsign/RCH4525`

**Esempio di risposta JSON:** 
```json
{
    "ac": [
        {
            "hex": "ae4f14",
            "type": "adsb_icao",
            "flight": "RCH4525 ",
            "r": "10-0220",
            "t": "C17",
            "dbFlags": 1,
            "desc": "Boeing C-17A Globemaster III",
            "ownOp": "United States Air Force",
            "alt_baro": 31000,
            "alt_geom": 30700,
            "gs": 448.0,
            "track": 58.51,
            "geom_rate": -64,
            "squawk": "3506",
            "emergency": "none",
            "category": "A5",
            "nav_qnh": 1013.6,
            "nav_altitude_mcp": 31008,
            "nav_heading": 350.86,
            "nav_modes": [
                "althold",
                "tcas"
            ],
            "lat": 54.567032,
            "lon": -107.970159,
            "nic": 10,
            "rc": 25,
            "seen_pos": 0.321,
            "recentReceiverIds": [
                "892c9171-8682-486b",
                "840b0976-a658-42e1"
            ],
            "version": 2,
            "nic_baro": 1,
            "nac_p": 10,
            "nac_v": 2,
            "sil": 3,
            "sil_type": "perhour",
            "gva": 2,
            "sda": 2,
            "alert": 0,
            "spi": 0,
            "mlat": [],
            "tisb": [],
            "messages": 22546,
            "seen": 0.3,
            "rssi": -16.7
        }
    ],
    "msg": "No error",
    "now": 1733386938001,
    "total": 1,
    "ctime": 1733386938001,
    "ptime": 0
}
```

## ENDPOINT: `/hex/[hex]`

**Descrizione:** Consente di effettuare una ricerca attraverso il codice ICAO da 24 bit di un aeromobile che deve essere specificato in formato esadecimale (hex).

**Metodo:** GET

**Esempio:** `curl https://api.airplanes.live/v2/hex/ae4f14`

**Esempio di risposta JSON:** 
```json
{
    "ac": [
        {
            "hex": "ae4f14",
            "type": "adsb_icao",
            "flight": "RCH4525 ",
            "r": "10-0220",
            "t": "C17",
            "dbFlags": 1,
            "desc": "Boeing C-17A Globemaster III",
            "ownOp": "United States Air Force",
            "alt_baro": 31000,
            "alt_geom": 30625,
            "gs": 454.0,
            "track": 58.97,
            "geom_rate": -64,
            "squawk": "3506",
            "emergency": "none",
            "category": "A5",
            "nav_qnh": 1013.6,
            "nav_altitude_mcp": 31008,
            "nav_heading": 350.16,
            "nav_modes": [
                "althold",
                "tcas"
            ],
            "lat": 54.784815,
            "lon": -107.352239,
            "nic": 10,
            "rc": 25,
            "seen_pos": 0.590,
            "recentReceiverIds": [
                "892c9171-8682-486b",
                "840b0976-a658-42e1"
            ],
            "version": 2,
            "nic_baro": 1,
            "nac_p": 10,
            "nac_v": 2,
            "sil": 3,
            "sil_type": "perhour",
            "gva": 2,
            "sda": 2,
            "alert": 0,
            "spi": 0,
            "mlat": [],
            "tisb": [],
            "messages": 23427,
            "seen": 0.3,
            "rssi": -15.1
        }
    ],
    "msg": "No error",
    "now": 1733387141002,
    "total": 1,
    "ctime": 1733387141002,
    "ptime": 0
}
```