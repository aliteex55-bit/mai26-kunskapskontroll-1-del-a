# Kunskapskontroll 1 - Del A: Inköpslistan

Ett konsolprogram i C# som sparar varunamn i `List<string>` och priser i `List<int>`. Samma index i de två listorna hör till samma vara. Lösningen finns i en enda källfil, `Inkopslista.cs`, med svenska kommentarer bredvid koden.

**Flödesschema:** [öppna det klickbara flödesschemat](https://aliteex55-bit.github.io/mai26-kunskapskontroll-1-del-a/flodesschema.html). Klicka på ett steg för att se koden bakom det, med en enkel förklaring.

## Kör programmet

Du behöver .NET 10 SDK. Öppna en terminal i den här mappen och kör:

```console
dotnet Inkopslista.cs
```

Raden `#:property PublishAot=false` är en bygginställning som gör att filen kan köras utan extra AOT-paket. Den påverkar inte inköpslistans funktioner.

## Användning

- Skriv ett varunamn och därefter ett heltalspris för att lägga till varan sist.
- Skriv varans nummer för att ta bort både namn och pris.
- Skriv `dyrast` för att se vilken vara som är dyrast (frivillig extrafunktion).
- Skriv `sortera` för att sortera listan efter pris, billigast först (frivillig extrafunktion). Namn och pris flyttas tillsammans, så listorna hålls i synk.
- Skriv `avsluta` för att avsluta programmet.
- Listan visas numrerad med totalsumma efter varje val.
- Ett ogiltigt pris lägger inte till någon vara.
- Ett nummer som inte finns ger ett felmeddelande, även om numret är mycket stort.

Exempel: lägg till Mjölk för 15 kr, Bröd för 32 kr och Ost för 89 kr. Summan blir 136 kr. Skriv `2` för att ta bort Bröd. Ost får då nummer 2 och summan blir 104 kr.

## Flödesschema

`flodesschema.html` är ett klickbart flödesschema över programmet. Klicka på ett steg för att se koden i `Inkopslista.cs` som utför det, med en enkel förklaring.
Öppna det på [GitHub Pages](https://aliteex55-bit.github.io/mai26-kunskapskontroll-1-del-a/flodesschema.html), eller öppna filen i en webbläsare.

## Kontrollerat

Tillägg, ordningsföljd, numrering, totalsumma, synkron borttagning, felaktiga priser, nummer utanför listan och mycket stora nummer har provkörts. Extrafunktionerna `dyrast` och `sortera` är provkörda på tom lista, på lika priser och med borttagning efter sortering.
