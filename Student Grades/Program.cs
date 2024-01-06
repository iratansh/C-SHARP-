using System.Linq;
Console.Clear();
#nullable disable

var random = new Random();
int[] studentGrades = new int[35];
for (int i = 0; i < studentGrades.Length; i++) {
    int num = random.Next(101);
    studentGrades[i] = num;
}

// Main Programming Loop
bool loop = true;
while (loop) {
    // Print Main Menu
    Console.WriteLine("Main Menu");
    Console.WriteLine("\n1: Display all Grades");
    Console.WriteLine("2. Display Honors");
    Console.WriteLine("3. Stats");
    Console.WriteLine("4. Randomize Grades");
    Console.WriteLine("5. Exit");
    Console.WriteLine("\nEnter selection (1-5): ");
    string selection = Console.ReadLine();

    if (selection == "1") {
        Console.WriteLine("All Grades");
        for (int i = 0; i < studentGrades.Length; i++) {
            Console.WriteLine(studentGrades[i] + "%");
        }
    } else if (selection == "2") {
        var nHonors = 0;
        for (int i = 0; i < studentGrades.Length; i++) {
            if (studentGrades[i] >= 80) {
                Console.WriteLine($"{studentGrades[i]}%");
                nHonors += 1;
            }
        }
        Console.WriteLine($"Number of Honors: {nHonors}");
    } else if (selection == "3") {
        Console.WriteLine("Stats");
            var hGrade = studentGrades.Max();
            Console.WriteLine("Highest Grade " + hGrade + "%");
            var lGrade = studentGrades.Min();
            Console.WriteLine("Lowest Grade " + lGrade + "%");
            var avg = studentGrades.Sum() / studentGrades.Length;
            Console.WriteLine("Average " + avg + "%");
    } else if (selection == "4") {
        Console.WriteLine("New random Grade for each student: ");
        Array.Clear(studentGrades);
        for (int i = 0; i < studentGrades.Length; i++) {
            int num = random.Next(101);
            studentGrades[i] = num;
            Console.WriteLine(studentGrades[i] + "%");
        }
    } else if (selection == "5") {
        Console.WriteLine("Option 5");
        loop = false;
    }

}