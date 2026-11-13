Course matematik = new Course("Matematik", 2); // Skapar en kurs med två platser.
Course programmering = new Course("Programmering", 3); // Skapar en kurs med tre platser.

Student anna = new Student("Anna"); // Skapar en studerande som heter Anna.
Student erik = new Student("Erik"); // Skapar en studerande som heter Erik.
Student sara = new Student("Sara"); // Skapar en studerande som heter Sara.

Console.WriteLine("ANMÄLAN FRÅN BÅDA HÅLLEN"); // Visar vad som testas.
matematik.Enroll(anna); // Anmäler Anna genom kursens metod.
erik.Join(matematik); // Anmäler Erik genom den studerandes metod.
anna.Join(programmering); // Anna går nu i två kurser.
programmering.Enroll(sara); // Anmäler Sara till programmering.

matematik.RollCall(); // Visar att Anna och Erik finns i matematik.
programmering.RollCall(); // Visar att Anna och Sara finns i programmering.
anna.Schedule(); // Visar Annas båda kurser.
erik.Schedule(); // Visar Eriks kurs.
sara.Schedule(); // Visar Saras kurs.

Console.WriteLine("\nDUBBELANMÄLAN OCH FULL KURS"); // Börjar nästa del av provkörningen.
matematik.Enroll(anna); // Försöker anmäla Anna igen genom kursen.
erik.Join(matematik); // Försöker anmäla Erik igen genom den studerande.
matematik.Enroll(sara); // Försöker lägga till Sara när kursens två platser är upptagna.
sara.Join(matematik); // Testar att samma platsgräns gäller genom Join.

matematik.RollCall(); // Visar att kursen fortfarande bara har Anna och Erik, en gång var.
anna.Schedule(); // Visar att Annas kurser inte har fått någon dubblett.
erik.Schedule(); // Visar att Eriks kurs inte har fått någon dubblett.
sara.Schedule(); // Visar att Sara inte lades till i den fulla kursen.

Console.WriteLine("\nBORTTAGNING FRÅN BÅDA HÅLLEN"); // Börjar sista delen av provkörningen.
matematik.Remove(anna); // Tar bort Anna genom kursens metod.
erik.Leave(matematik); // Tar bort Erik genom den studerandes metod.
matematik.Remove(sara); // Testar att ta bort någon som inte är anmäld.
sara.Leave(matematik); // Testar samma sak genom Leave utan att programmet kraschar.

matematik.RollCall(); // Visar att matematikkursen nu är tom.
programmering.RollCall(); // Visar att Anna och Sara fortfarande går i programmering.
anna.Schedule(); // Visar att matematik är borta ur Annas kurser.
erik.Schedule(); // Visar att Erik inte längre går i någon kurs.
sara.Schedule(); // Visar att Saras programmeringskurs finns kvar.
