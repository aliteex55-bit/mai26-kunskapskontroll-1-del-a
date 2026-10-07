# Kunskapskontroll 1 - Del A: Inköpslistan

Ett konsolprogram i C# som sparar varunamn i `List<string>` och priser i `List<int>`. Samma index i de två listorna hör till samma vara. Lösningen finns i en enda källfil, `Inkopslista.cs`, med svenska kommentarer bredvid koden.

## Kör programmet

Du behöver .NET 10 SDK. Öppna en terminal i den här mappen och kör:

```console
dotnet Inkopslista.cs
```

Raden `#:property PublishAot=false` är en bygginställning som gör att filen kan köras utan extra AOT-paket. Den påverkar inte inköpslistans funktioner.

## Användning

- Skriv ett varunamn och därefter ett heltalspris för att lägga till varan sist.
- Skriv varans nummer för att ta bort både namn och pris.
- Skriv `avsluta` för att avsluta programmet.
- Listan visas numrerad med totalsumma efter varje val.
- Ett ogiltigt pris lägger inte till någon vara.
- Ett nummer som inte finns ger ett felmeddelande, även om numret är mycket stort.

Exempel: lägg till Mjölk för 15 kr, Bröd för 32 kr och Ost för 89 kr. Summan blir 136 kr. Skriv `2` för att ta bort Bröd. Ost får då nummer 2 och summan blir 104 kr.

De frivilliga funktionerna för dyraste vara och sortering ingår inte.

## Kontrollerat

Tillägg, ordningsföljd, numrering, totalsumma, synkron borttagning, felaktiga priser, nummer utanför listan och mycket stora nummer har provkörts.
