#:property PublishAot=false
// Inställningen ovan gör att filen kan köras direkt med dotnet utan extra AOT-paket.

using System; // Gör att vi kan använda Console.
using System.Collections.Generic; // Gör att vi kan använda List.

List<string> names = new List<string>(); // Sparar varornas namn.
List<int> prices = new List<int>(); // Sparar priserna på samma index som namnen.

while (true) // Upprepar programmet tills användaren avslutar.
{
    Console.WriteLine("\nInköpslista:"); // Visar en rubrik före listan.
    long total = 0; // Börjar summan på noll. long rymmer summan av många stora priser.

    for (int i = 0; i < names.Count; i++) // Går igenom alla varor i listan.
    {
        Console.WriteLine($"{i + 1}. {names[i]} - {prices[i]} kr"); // Visar nummer, namn och pris.
        total += prices[i]; // Lägger varans pris till totalsumman.
    }

    Console.WriteLine($"Totalt: {total} kr"); // Visar summan av alla priser.
    Console.Write("Skriv en vara, ett nummer för att ta bort eller avsluta: "); // Ber om ett val.
    string? input = Console.ReadLine(); // Läser användarens text. ? tillåter null om inmatningen tar slut.

    if (input == null || input == "avsluta") // Kontrollerar om programmet ska avslutas.
    {
        break; // Avslutar loopen.
    }

    if (string.IsNullOrWhiteSpace(input)) // Kontrollerar om användaren skrev en tom rad eller bara mellanslag.
    {
        Console.WriteLine("Skriv ett varunamn eller ett nummer."); // Ber användaren skriva något.
        continue; // Börjar nästa varv i loopen.
    }

    string numberText = input.Trim(); // Tar bort mellanslag runt ett möjligt nummer.

    if (numberText.StartsWith("+") || numberText.StartsWith("-")) // Ett heltal kan börja med plus eller minus.
    {
        numberText = numberText.Substring(1); // Tar bort tecknet inför kontrollen av siffrorna.
    }

    bool isNumber = numberText.Length > 0; // Ett nummer måste innehålla minst en siffra.

    foreach (char character in numberText) // Kontrollerar varje tecken, även i mycket stora nummer.
    {
        if (character < '0' || character > '9') // Kontrollerar om tecknet inte är en siffra.
        {
            isNumber = false; // Text med andra tecken behandlas som ett varunamn.
        }
    }

    if (isNumber) // Heltalstext används för borttagning, även om talet är för stort för int.
    {
        if (int.TryParse(input, out int number) && number >= 1 && number <= names.Count) // Numret måste rymmas i int och finnas i listan.
        {
            int index = number - 1; // Listans index börjar på 0, men numreringen börjar på 1.
            names.RemoveAt(index); // Tar bort varans namn.
            prices.RemoveAt(index); // Tar bort priset på samma plats så att listorna stämmer.
        }
        else // Körs om numret inte finns i listan.
        {
            Console.WriteLine("Det numret finns inte i listan."); // Visar ett felmeddelande.
        }
    }
    else // Text som inte är ett heltal behandlas som ett varunamn.
    {
        Console.Write("Ange pris i hela kronor: "); // Frågar efter varans pris.

        if (int.TryParse(Console.ReadLine(), out int price)) // Kontrollerar att priset är ett heltal.
        {
            names.Add(input); // Lägger namnet sist i namnlistan.
            prices.Add(price); // Lägger priset sist i prislistan.
        }
        else // Körs om priset inte går att läsa som ett heltal.
        {
            Console.WriteLine("Priset måste vara ett heltal. Varan lades inte till."); // Förklarar felet.
        }
    }
}
