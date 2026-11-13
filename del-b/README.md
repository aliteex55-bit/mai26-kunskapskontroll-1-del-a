# Kunskapskontroll 1 - Del B: Kurser och studerande

Ett konsolprojekt i C# med klasserna `Course` och `Student` i varsin fil. En kurs kan ha flera studerande och en studerande kan gå i flera kurser. Koden har svenska kommentarer bredvid kodraderna.

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
