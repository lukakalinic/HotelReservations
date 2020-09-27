# HotelReservations
Kvalifikacioni zadatak za SAP

## Uvod
Zamislimo da posedujemo hotel sa određenim brojem soba iste veličine.
Naši klijenti bi želeli da rezervišu neku od soba: npr. klijent nas pozove i pita nas 
da li može da rezerviše sobu u određenom vremenskom periodu koji je predstavljen
parom *(startDate, endDate)*. Program proverava da li ima slobodnih soba u datom
vremenskom periodu i ukoliko ima, izvrši rezervaciju. U pitanju je *console* aplikacija
koja na izlazu ispisuje rešenja test primera datih u HotelReservations.pdf-u.

## Program
Za implementaciju datog problema korišćen je programski jezik *C#*. Samo rešenje (solution)
sastoji se iz dva projekta i jednog unit test projekta koji testira osnovne funkcionalnosti
programa. 

### CommonUtility projekat
Sadrži statičku klasu **ErrorMessage** koja se sastoji isključivo od *public string konstanti* koje 
se koriste za ispisivanje odgovarajućih grešaka.

### HotelReservations projekat
Sadrži tri klase:
1. **Booking** klasu koja predstavlja uređeni par *(startDate, endDate)* i koja ima
jednu Validate metodu koja proverava da li je dati booking tj. uređeni par u ispravnom obliku.

2. **Hotel** klasu koja kao public property ima matricu *Rooms* koja čuva informacije o tome 
od kad do kad je koja soba rezervisana. Redovi matrice su brojevi soba dok su kolone matrice
dani iz intervala [0, 365]. 

3. **Program** klasa sadrži *Main* metodu u kojoj su implementirani test primeri navedeni u HotelReservations.pdf-u.

## Kako pokrenuti test primere:
U *bin/Debug* folderu pokrenuti **HotelReservations.exe**.

