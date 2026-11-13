public class Course // Beskriver en kurs och dess studerande.
{
    public string Name; // Sparar kursens namn.
    public int MaxSeats; // Sparar det största tillåtna antalet studerande.
    public List<Student> Students = new List<Student>(); // Skapar kursens lista med studerande.

    public Course(string name, int maxSeats) // Körs när en ny kurs skapas.
    {
        Name = name; // Sparar namnet som skickades till konstruktorn.
        MaxSeats = maxSeats; // Sparar hur många platser kursen har.
    }

    public void Enroll(Student student) // Anmäler en studerande om reglerna tillåter det.
    {
        if (Students.Contains(student)) // Kontrollerar om samma studerande redan finns i kursen.
        {
            Console.WriteLine($"{student.Name} är redan anmäld till {Name}."); // Förklarar varför ingen läggs till.
            return; // Avslutar metoden så att en dubblett inte skapas.
        }

        if (Students.Count >= MaxSeats) // Kontrollerar om alla platser redan är upptagna.
        {
            Console.WriteLine($"Kursen {Name} är full."); // Meddelar att det inte finns plats.
            return; // Avslutar metoden utan att ändra någon lista.
        }

        Students.Add(student); // Lägger till den studerande i kursens lista.
        student.Courses.Add(this); // Lägger till den här kursen i den studerandes lista.
        Console.WriteLine($"{student.Name} anmäldes till {Name}."); // Bekräftar anmälan.
    }

    public void Remove(Student student) // Tar bort en studerande från kursen.
    {
        if (!Students.Contains(student)) // Kontrollerar om den studerande saknas i kursen.
        {
            Console.WriteLine($"{student.Name} är inte anmäld till {Name}."); // Förklarar varför ingen tas bort.
            return; // Avslutar metoden utan att krascha.
        }

        Students.Remove(student); // Tar bort den studerande ur kursens lista.
        student.Courses.Remove(this); // Tar också bort kursen ur den studerandes lista.
        Console.WriteLine($"{student.Name} togs bort från {Name}."); // Bekräftar borttagningen.
    }

    public void RollCall() // Skriver ut kursens studerande.
    {
        Console.WriteLine($"\nUpprop: {this}"); // Använder ToString för att visa kursnamn och platser.

        if (Students.Count == 0) // Kontrollerar om kursen saknar studerande.
        {
            Console.WriteLine("Inga studerande är anmälda."); // Visar att listan är tom.
        }

        foreach (Student student in Students) // Går igenom varje studerande i listan.
        {
            Console.WriteLine($"- {student}"); // Använder den studerandes ToString för att visa namnet.
        }
    }

    public override string ToString() // Bestämmer hur kursen visas som text.
    {
        return $"{Name} ({Students.Count}/{MaxSeats} platser)"; // Returnerar namn samt upptagna och totala platser.
    }
}
