public class Student // Beskriver en studerande och dennes kurser.
{
    public string Name; // Sparar den studerandes namn.
    public List<Course> Courses = new List<Course>(); // Skapar den studerandes lista med kurser.

    public Student(string name) // Körs när en ny studerande skapas.
    {
        Name = name; // Sparar namnet som skickades till konstruktorn.
    }

    public void Join(Course course) // Anmäler den studerande till en kurs.
    {
        course.Enroll(this); // Låter kursen kontrollera reglerna och uppdatera båda listorna.
    }

    public void Leave(Course course) // Avanmäler den studerande från en kurs.
    {
        course.Remove(this); // Låter kursen ta bort kopplingen ur båda listorna.
    }

    public void Schedule() // Skriver ut den studerandes kurser.
    {
        Console.WriteLine($"\nKurser för {this}:"); // Använder ToString för att visa den studerandes namn.

        if (Courses.Count == 0) // Kontrollerar om den studerande saknar kurser.
        {
            Console.WriteLine("Inga kurser."); // Visar att listan är tom.
        }

        foreach (Course course in Courses) // Går igenom varje kurs i listan.
        {
            Console.WriteLine($"- {course}"); // Använder kursens ToString för att visa namn och platser.
        }
    }

    public override string ToString() // Bestämmer hur den studerande visas som text.
    {
        return Name; // Returnerar den studerandes namn.
    }
}
