using System.Linq;
Console.Clear();
#nullable disable

string[] nicknames = {"the boss", "the great", "the guy", "the cool guy", "the monster", "the boulder"};
Console.WriteLine("Enter your first name: ");
var fInput = Console.ReadLine(); 
Console.WriteLine("Enter your last name: ");
var lInput = Console.ReadLine();
var random = new Random();

// Main Programming Loop
bool loop = true;
while (loop) {
    // Print Main Menu
    Console.WriteLine("Main Menu");
    Console.WriteLine("\n1: Change Name");
    Console.WriteLine("2. Display a Random Nickname");
    Console.WriteLine("3. Display all Nicknames");
    Console.WriteLine("4. Add a Nickname");
    Console.WriteLine("5. Remove a Nickname");
    Console.WriteLine("6. Exit");
    Console.WriteLine("\nEnter selection (1-6): ");
    string selection = Console.ReadLine();

    if (selection == "1") {
        Console.WriteLine("Enter your first name: ");
        fInput = Console.ReadLine(); 
        Console.WriteLine("Enter your last name: ");
        lInput = Console.ReadLine();
    } else if (selection == "2") {
       Console.WriteLine("Random Nickname: " + fInput + " " + nicknames[random.Next(0, nicknames.Length)] + " " + lInput);
    } else if (selection == "3") {
        for (int i = 0; i < nicknames.Length; i++) {
            Console.WriteLine("\n" + fInput + " " + nicknames[i] + " " +lInput);
        }       
    } else if (selection == "4") {
        Console.WriteLine("Enter a new nickname: ");
        var newNick = Console.ReadLine();
        Array.Resize(ref nicknames, nicknames.Length + 1);
        nicknames[nicknames.Length - 1] = newNick;
        Console.WriteLine(newNick + " has been added");
    } else if (selection == "5") {
        Console.WriteLine("Enter the nickname to remove: ");
        var removeNick = Console.ReadLine();
        var indexToRemove = Array.IndexOf(nicknames, removeNick);
        if (indexToRemove >= 0) {
            for (int i = indexToRemove; i < nicknames.Length - 1; i++) {
                    nicknames[i] = nicknames[i + 1];
                }
            Array.Resize(ref nicknames, nicknames.Length - 1);
        }
        Console.WriteLine(removeNick + " has been removed");
    } 
    else if (selection == "6") {
        Console.WriteLine("Option 6");
        loop = false;
    }
}