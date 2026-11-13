# Kunskapskontroll 1 - Del A: Inköpslistan

Ett konsolprogram i C# som sparar varunamn i `List<string>` och priser i `List<int>`. Samma index i de två listorna hör till samma vara. Lösningen finns i en enda källfil, `Inkopslista.cs`, med kommentarer bredvid koden: svenska i grundprogrammet och engelska i extrafunktionerna `dyrast` och `sortera`.

**Flödesschema:** [öppna det klickbara flödesschemat](https://aliteex55-bit.github.io/mai26-kunskapskontroll-1-del-a/flodesschema.html). Klicka på ett steg för att se koden bakom det, med en enkel förklaring.

## Min beskrivning

I del A har jag gjort ett konsolprogram i C# som är en inköpslista. Varunamn ligger i en lista och priser i en annan. Samma plats i båda listorna hör till samma vara. Allt ligger i en fil, Inkopslista.cs.

Jag vill förstå innan jag bygger. Därför har jag jobbat i korta, koncentrerade pass där jag studsat idéer med AI tills jag kände att jag hade grepp om det – och sen kodade jag.

Tidigare fick jag feedback på ett blackjack-spel. Det ledde till att jag lärde mig GitHub och versionshantering, och att jag började rita upp data och arbetsflöde enklare, med flödesscheman. Det är därför det finns ett klickbart flödesschema till den här delen.

### Vad programmet gör

Programmet visar en numrerad inköpslista med totalsumma. Man kan lägga till en vara med pris, ta bort en vara med dess nummer, skriva dyrast för att se den dyraste varan, skriva sortera för att sortera billigast först, eller skriva avsluta. Namn och pris hålls alltid ihop. Ett ogiltigt pris eller ett nummer som inte finns ger ett meddelande, och programmet kraschar inte.

### Så kör du det

Du behöver .NET 10 SDK. Öppna en terminal i projektets rotmapp, där Inkopslista.cs ligger, och kör:

```console
dotnet Inkopslista.cs
```

Raden #:property PublishAot=false högst upp i filen är en bygginställning så att filen kan köras utan extra AOT-paket. Den ändrar inte hur inköpslistan fungerar.

### Flödesschema

Klicka dig igenom rutorna här: https://aliteex55-bit.github.io/mai26-kunskapskontroll-1-del-a/flodesschema.html

### Del A – block för block

Här är de 21 rutorna i samma ordning som på den publicerade sidan. Till varje ruta: namn, fil och rader, och en kort förklaring du kan säga högt på kunskapskontrollen. Klicka på rutan i flödesschemat om du vill se koden samtidigt.

#### 1. Start: två tomma listor

Kod: Inkopslista.cs:7–8

Programmet börjar med två tomma listor: names för varunamn och prices för priser. Samma index i båda listorna hör till samma vara, till exempel names[0] och prices[0].

#### 2. Visa listan och totalsumman

Kod: Inkopslista.cs:12–21

Varje varv i loopen börjar med att hela listan skrivs ut, numrerad från 1, och sist totalsumman. En for-loop går igenom alla varor och räknar ihop priserna samtidigt. Summan sparas i en long så att den inte blir för stor.

#### 3. Läs inmatningen

Kod: Inkopslista.cs:22–23

Programmet frågar vad användaren vill göra och läser en rad text med Console.ReadLine. Allt som händer sedan beror på vad som skrevs. Frågetecknet i string? betyder att värdet kan vara null om inmatningen tar slut.

#### 4. Ska programmet avslutas?

Kod: Inkopslista.cs:25–28

Om användaren skriver avsluta, eller om inmatningen tar slut (null), lämnar programmet loopen med break. || betyder “eller”: det räcker att ett av villkoren stämmer.

#### 5. Programmet avslutas

Kod: Inkopslista.cs:27

När loopen är bruten finns ingen mer kod att köra efter den sista måsvingen, och programmet tar slut.

#### 6. Skrev användaren ingenting?

Kod: Inkopslista.cs:30

IsNullOrWhiteSpace är sant om raden är tom eller bara innehåller mellanslag. Då är det varken en vara eller ett nummer, så programmet ska inte lägga till en tom vara.

#### 7. Be om något att göra

Kod: Inkopslista.cs:32–33

Programmet ber användaren skriva ett varunamn eller ett nummer. continue hoppar till nästa varv i loopen, så listan visas igen.

#### 8. Skrev användaren dyrast?

Kod: Inkopslista.cs:36

Det här är en extrafunktion. Ordet dyrast är ett kommando, inte en vara. Trim tar bort mellanslag och ToLower gör bokstäverna små, så även “DYRAST” och “ dyrast ” fungerar.

#### 9. Hitta den dyraste varan

Kod: Inkopslista.cs:38–57

Om listan är tom skrivs det ut, så programmet inte kraschar. Annars antar det först att den första varan är dyrast och jämför sedan med resten. När en dyrare vara hittas sparas dess plats, och till sist skrivs namn och pris från samma index. continue gör att ordet dyrast inte läggs till som en vara.

#### 10. Skrev användaren sortera?

Kod: Inkopslista.cs:60

Också en extrafunktion. Ordet sortera är ett kommando, inte en vara. Samma teknik som för dyrast: Trim och ToLower, så det inte spelar roll hur ordet skrivs.

#### 11. Sortera listan efter pris

Kod: Inkopslista.cs:62–84

För varje plats letar programmet upp den billigaste av de varor som är kvar och byter plats med den. Namnen byts på exakt samma sätt som priserna, så listorna hålls ihop. Sen skrivs en bekräftelse, och continue visar listan i den nya ordningen utan att lägga till ordet sortera som vara.

#### 12. Är det ett nummer?

Kod: Inkopslista.cs:87–102

Programmet tittar på varje tecken efter att ha tagit bort mellanslag. Ett valfritt plus eller minus först är tillåtet, sen måste resten vara siffror. Annars räknas texten som ett varunamn. Kontrollen fungerar även för mycket stora nummer som inte ryms i en int.

#### 13. Nummer eller vara?

Kod: Inkopslista.cs:104

Här delar sig flödet. Om isNumber är sant ska en vara tas bort, annars ska en ny vara läggas till.

#### 14. Finns numret i listan?

Kod: Inkopslista.cs:106

int.TryParse försöker göra om texten till en int utan att krascha. Numret måste dessutom ligga mellan 1 och antalet varor. && betyder “och”: alla tre villkoren måste stämma.

#### 15. Ta bort varan

Kod: Inkopslista.cs:108–110

Användaren ser nummer från 1, men listan räknar från 0, så index blir number minus 1. Namnet och priset tas bort på samma plats, så listorna inte hamnar i otakt.

#### 16. Numret finns inte

Kod: Inkopslista.cs:112–115

Om numret inte finns i listan, eller är för stort för en int, skrivs ett felmeddelande. Programmet kraschar inte, och listan visas sedan igen.

#### 17. Fråga efter priset

Kod: Inkopslista.cs:119

Texten var inte ett nummer, så den räknas som namnet på en ny vara. Programmet frågar efter priset i hela kronor.

#### 18. Är priset ett heltal?

Kod: Inkopslista.cs:121

int.TryParse läser svaret och kollar att det är ett heltal, i samma rad. Lyckas det hamnar värdet i price, annars går programmet till felmeddelandet.

#### 19. Lägg till varan

Kod: Inkopslista.cs:123–124

Namnet läggs sist i namnlistan och priset sist i prislistan. Eftersom båda läggs sist hamnar de på samma index och hör ihop.

#### 20. Priset var inte ett heltal

Kod: Inkopslista.cs:126–129

Varan läggs inte till i någon lista, och programmet förklarar att priset måste vara ett heltal. Listorna förblir lika långa, och ingenting kraschar.

#### 21. Loopen börjar om

Kod: Inkopslista.cs:10–11 och Inkopslista.cs:131

Allt ligger i en while (true)-loop, som upprepas för alltid. Den enda vägen ut är break när användaren skriver avsluta. När ett varv når den sista måsvingen hoppar körningen tillbaka och listan visas igen.

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

## Del B i mappen del-b

Mappen `del-b` innehåller del B, kurser och studerande, med sin historik. Kör den så här:

```console
cd del-b
dotnet run
```

**Flödesschema för del B:** [öppna det klickbara flödesschemat](https://aliteex55-bit.github.io/mai26-kunskapskontroll-1-del-a/del-b/flodesschema.html). Det visar provkörningen i `Program.cs` och vad som händer inuti `Enroll`, `Join`, `Remove` och `Leave`, med koden bakom varje steg.

Del B finns också som eget repo: [mai26-kunskapskontroll-1-del-b](https://github.com/aliteex55-bit/mai26-kunskapskontroll-1-del-b).

## Kontrollerat

Tillägg, ordningsföljd, numrering, totalsumma, synkron borttagning, felaktiga priser, nummer utanför listan och mycket stora nummer har provkörts. Extrafunktionerna `dyrast` och `sortera` är provkörda på tom lista, på lika priser och med borttagning efter sortering.
