# Kunskapskontroll 1 - Del B: Kurser och studerande

Ett konsolprojekt i C# med klasserna `Course` och `Student` i varsin fil. En kurs kan ha flera studerande och en studerande kan gå i flera kurser. Koden har svenska kommentarer bredvid kodraderna.

## Min beskrivning

I del B har jag gjort ett litet konsolprogram i C# med klasserna Course och Student. En kurs kan ha flera studerande, och en studerande kan gå i flera kurser.

Jag vill förstå innan jag bygger. Därför har jag jobbat i korta, koncentrerade pass där jag studsat idéer med AI tills jag kände att jag hade grepp om det – och sen kodade jag.

Tidigare fick jag feedback på ett blackjack-spel. Det ledde till att jag lärde mig GitHub och versionshantering, och att jag började rita upp data och arbetsflöde enklare, med flödesscheman. Det är därför det finns ett klickbart flödesschema till den här delen.

### Vad programmet gör

Programmet skapar två kurser och tre studerande och visar hur man anmäler och tar bort personer från båda hållen. Det nekar dubbletter, nekar när en kurs är full, och kraschar inte om man försöker ta bort någon som inte är anmäld.

### Så kör du det

Du behöver .NET 10 SDK. Öppna en terminal i mappen del-b och kör:

```console
dotnet run
```

### Flödesschema

Klicka dig igenom rutorna här: https://aliteex55-bit.github.io/mai26-kunskapskontroll-1-del-a/del-b/flodesschema.html

### Del B – block för block

Här är de 28 rutorna i samma ordning som på den publicerade sidan. Klicka på rutan i flödesschemat om du vill se koden samtidigt.

#### 1. Programmet startar i Program.cs

Kod: Program.cs:1

Här börjar programmet. Det finns ingen Main-metod i Program.cs; raderna körs uppifrån och ner. Första raden skapar matematikkursen.

#### 2. Skapa två kurser

Kod: Program.cs:1–2

Två Course-objekt skapas med new Course. Matematik får bara två platser, just så att man senare kan visa att en tredje anmälan blir nekad. Programmering får tre platser.

#### 3. Skapa tre studerande

Kod: Program.cs:4–6

Här skapas Anna, Erik och Sara. Varje Student får ett namn och en tom lista med kurser.

#### 4. Anmäl från båda hållen

Kod: Program.cs:8–12

Först anmäls folk både via kursen (Enroll) och via den studerande (Join). Anna anmäls till matematik via kursen, Erik via Join, sen går Anna även med i programmering, och Sara anmäls till programmering. Båda sätten slutar i samma metod: Enroll i Course.cs.

#### 5. Visa att båda hållen stämmer

Kod: Program.cs:14–18

RollCall skriver ut vilka som går i varje kurs, och Schedule vilka kurser varje person har. Samma koppling ska synas från båda hållen: Anna och Erik i matematik, och matematik hos Anna och Erik.

#### 6. Prova reglerna

Kod: Program.cs:20–24

Nu testas två regler: samma person anmäls igen, och Sara försöker komma in i matematik som redan är full. Båda ska nekas, oavsett om man kör Enroll eller Join. Listorna ska inte ändras.

#### 7. Visa att inget ändrades

Kod: Program.cs:26–29

Uppropet och schemana skrivs ut igen. Matematik har fortfarande bara Anna och Erik, en gång var, och Sara kom inte in.

#### 8. Ta bort från båda hållen

Kod: Program.cs:31–35

Anna tas bort via Remove och Erik via Leave. Sen testas att ta bort Sara, som inte är anmäld – både via kursen och via Leave. Det ska ge ett meddelande, inte krascha.

#### 9. Visa slutläget

Kod: Program.cs:37–41

Nu är matematik tom, och kursen är borta ur Annas och Eriks scheman. Programmering är orörd: Anna och Sara går kvar där.

#### 10. Programmet tar slut

Kod: Program.cs:41

När sista raden, Saras schema, är klar finns det inget mer att köra. Programmet avslutas.

#### 11. Klassen Course

Kod: Course.cs:1–11

Course är ritningen för en kurs. Varje kurs har ett namn, ett maxantal platser och en lista med studerande. Konstruktorn körs när man skriver new Course och sparar namn och platser.

#### 12. Klassen Student

Kod: Student.cs:1–9

Student är ritningen för en studerande. Varje person har ett namn och en lista med sina kurser. Tillsammans med Course blir det en koppling åt båda hållen: kursen vet vilka som går där, och den studerande vet vilka kurser hen går i.

#### 13. Join: gå med i en kurs

Kod: Student.cs:11–14

Join gör inget eget jobb. Den anropar bara course.Enroll(this), alltså “anmäl mig själv”. Då ligger alla regler på ett ställe.

#### 14. Enroll: anmäl en studerande

Kod: Course.cs:13–30

All anmälan går genom Enroll. Först kollas om personen redan är anmäld, sen om kursen är full. Bara om båda kontrollerna går igenom läggs kopplingen till åt båda hållen.

#### 15. Är den studerande redan anmäld?

Kod: Course.cs:15–19

Contains kollar om samma objekt redan finns i listan. Om ja, hoppar metoden ut med return så att ingen dubblett skapas.

#### 16. Redan anmäld

Kod: Course.cs:17–18

Här skrivs ett meddelande ut, till exempel att Anna redan är anmäld, och sen avslutas metoden. Inget läggs till i någon lista.

#### 17. Är kursen full?

Kod: Course.cs:21–25

Här jämförs hur många som redan är i listan med MaxSeats. Om antalet är lika stort eller större finns ingen plats kvar.

#### 18. Kursen är full

Kod: Course.cs:23–24

Programmet skriver att kursen är full och gör return. Listorna lämnas orörda.

#### 19. Koppla ihop åt båda hållen

Kod: Course.cs:27–29

Om kontrollerna gick igenom läggs den studerande i kursens lista, och kursen i den studerandes lista. this är kursen själv. Sen skrivs en bekräftelse.

#### 20. Leave: lämna en kurs

Kod: Student.cs:16–19

Leave fungerar som Join, fast åt andra hållet: den skickar vidare till kursens Remove, så att samma regler gäller från båda hållen.

#### 21. Remove: ta bort en studerande

Kod: Course.cs:32–43

All borttagning går genom Remove. Först kollas att personen faktiskt är anmäld. Är hen det, tas kopplingen bort åt båda hållen.

#### 22. Är den studerande anmäld?

Kod: Course.cs:34–38

Utropstecknet betyder “inte”. Om personen inte finns i kursen avbryts metoden med return, så programmet inte kraschar.

#### 23. Inte anmäld

Kod: Course.cs:36–37

Programmet skriver att personen inte är anmäld och avslutar metoden. Inget tas bort.

#### 24. Ta bort kopplingen åt båda hållen

Kod: Course.cs:40–42

Den studerande tas ur kursens lista, och kursen tas ur den studerandes lista, i samma metod. Sen kommer en bekräftelse.

#### 25. RollCall: kursens upprop

Kod: Course.cs:45–58

RollCall är kursens upprop. Först skrivs kursen ut med ToString, till exempel namn och platser. Är listan tom står det det, annars skrivs varje studerande på en egen rad med foreach.

#### 26. Schedule: den studerandes schema

Kod: Student.cs:21–34

Schedule är den studerandes schema. Samma upplägg som RollCall, men åt andra hållet: namnet först, sen varje kurs, eller “Inga kurser” om listan är tom.

#### 27. Hur en kurs visas som text

Kod: Course.cs:60–63

ToString bestämmer hur en kurs ser ut när den skrivs ut, till exempel “Matematik (2/2 platser)”. override betyder att den ersätter standardtexten, som annars bara hade blivit klassnamnet.

#### 28. Hur en studerande visas som text

Kod: Student.cs:36–39

En studerande visas bara med sitt namn. När RollCall skriver ut en student används den här ToString.

## Kör programmet

Du behöver .NET 10 SDK. Öppna en terminal i den här mappen och kör:

```console
dotnet run
```

## Filer

- `Course.cs`: fälten `Name`, `MaxSeats` och `Students`, samt metoderna `Enroll`, `Remove`, `RollCall` och `ToString`.
- `Student.cs`: fälten `Name` och `Courses`, samt metoderna `Join`, `Leave`, `Schedule` och `ToString`.
- `Program.cs`: skapar två kurser och tre studerande och demonstrerar reglerna.
- `DelB-KurserOchStuderande.csproj`: körbar projektfil för .NET 10.
- `.gitignore`: undantar `bin/` och `obj/`.

## Regler och demonstration

`Join` anropar kursens `Enroll` och `Leave` anropar kursens `Remove`. Kursens metoder uppdaterar båda listorna, så samma regler gäller från båda hållen.

Provkörningen visar:

1. Anmälan via både kursen och den studerande.
2. En studerande som går i flera kurser.
3. Upprepade anmälningar som inte skapar dubletter.
4. En full kurs som avvisar fler studerande.
5. Borttagning via båda klasserna.
6. Borttagning av någon som inte är anmäld, utan krasch.

`RollCall()` och `Schedule()` visar innehållet efter varje del av provkörningen. Använd anmälnings- och borttagningsmetoderna när kopplingarna ska ändras.

## Kontrollerat

Projektet har byggts utan varningar eller fel. Demonstrationen och separata kontroller av kopplingarna åt båda hållen, dubletter, kapacitet, borttagning, flera kurser, lediga platser och `ToString()` har passerat.
