using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Reflection.Metadata;
using System.Text.Json;
#nullable disable
class User {
    public string password { get; set; }
    public List<string> cart { get; set; } = new List<string>();
}
class Program {
    static Dictionary<string, User> users = new Dictionary<string, User>();
    static IDictionary<string, string[]> products = new Dictionary<string, string[]>() {
        {"carrots", new string[] {"regular carrots", "$5", "food"}},
        {"chedder cheese", new string[] {"regular cheddar cheese", "$8", "food"}},
        {"television", new string[] {"40in. flat screen television", "$40", "technology"}},
        {"chair", new string[] {"small wooden chair", "$25", "furniture"}}
    };

    static void Main(string[] args) {
        loadUsers("users.txt");
        
        while (true) {
            Console.WriteLine();
            Console.WriteLine("MENU");
            Console.WriteLine("1. REGISTRATION");
            Console.WriteLine("2. LOGIN");
            Console.WriteLine("3. EXIT");
            var input = Console.ReadLine();

            if (input == "1") {
                Console.WriteLine("REGISTRATION SYSTEM");
                Console.WriteLine("USERNAME: ");
                var newUsername = Console.ReadLine();
                if (users.ContainsKey(newUsername)) {
                    Console.WriteLine("USERNAME ALREADY TAKEN");
                } else {
                    Console.WriteLine("PASSWORD: ");
                    var newPassword = Console.ReadLine();
                    users.Add(newUsername, new User {password = newPassword, cart = {}});
                    saveUsers("users.txt");
                    mainProgram(newUsername);
                }
            }   
            
            else if (input == "2") {
                Console.WriteLine("USER LOGIN SYSTEM");
                Console.WriteLine("USERNAME: ");
                var usernameIdentification = Console.ReadLine();
                Console.WriteLine("PASSWORD: ");
                var passwordIdentification = Console.ReadLine();

                if (users.ContainsKey(usernameIdentification)) {
                    if (users[usernameIdentification].password == passwordIdentification) {
                        Console.WriteLine("LOGIN SUCCESSFULL");
                        mainProgram(usernameIdentification);
                    } else {
                        Console.WriteLine("INCORRECT PASSWORD");
                    } 
                } else {
                    Console.WriteLine("USERNAME INVALID");
                }
            }

            else if (input == "3") {
                Console.WriteLine();
                Console.WriteLine("EXITING SYSTEM");
                return;
            }
        }
    }
    static void loadUsers(string filename) {
        string json = File.ReadAllText(filename);
        users = JsonSerializer.Deserialize<Dictionary<string, User>>(json);
    }

    static void saveUsers(string filename) {
        string json = JsonSerializer.Serialize(users, new JsonSerializerOptions { WriteIndented = true });
        File.WriteAllText(filename, json);
    }

    static void mainProgram(string username) {
        while (true) {
            int selection = getMenuSelection();

            switch (selection) {
                case 1:
                    displayAllProducts();
                    break;
                case 2:
                    Console.WriteLine("ENTER A CATEGORY TO FILTER BY: ");
                    string category = Console.ReadLine().ToLower();
                    filterCategories(category);
                    break;
                case 3:
                    Console.WriteLine("SORT BY PRICE");
                    bubbleSort();
                    break;
                case 4:
                    addtoCart(username);
                    break;
                case 5:
                    removefromCart(username);
                    break;
                case 6:
                    showCart(username);
                    break;
                case 7:
                    Console.WriteLine("EXIT");
                    return;
                default:
                    Console.WriteLine("Invalid selection. Please choose a number between 1 and 7.");
                    break;
            }
        }   
    }
    static int getMenuSelection() {
        Console.WriteLine();
        Console.WriteLine("SHOPPING SIMULATOR");
        Console.WriteLine("1: DISPLAY ALL PRODUCTS");
        Console.WriteLine("2: FILTER PRODUCTS");
        Console.WriteLine("3: SORT PRODUCTS");
        Console.WriteLine("4: ADD TO CART");
        Console.WriteLine("5: REMOVE FROM CART");
        Console.WriteLine("6: SHOW CART");
        Console.WriteLine("7: EXIT");
        Console.Write("Selection (1-7): ");
        
        int selection;
        while (!int.TryParse(Console.ReadLine(), out selection) || selection < 1 || selection > 7) {
            Console.WriteLine("Invalid input. Please enter a valid number between 1 and 7.");
            Console.Write("Selection (1-7): ");
        }

        return selection;
    }

    static void displayAllProducts() {
        Console.WriteLine();
        foreach (var product in products) {
            Console.WriteLine("PRODUCT: {0}", product.Key);
            Console.WriteLine("DESCRIPTION: {0}", product.Value[0]);
            Console.WriteLine("PRICE: {0}", product.Value[1]);
            Console.WriteLine("CATEGORY: {0}", product.Value[2]);
            Console.WriteLine();
        }   
    }
    
    static void filterCategories(string category) {
        Console.WriteLine();
        foreach (var product in products) {
            if (category == product.Value[2]) {  
                Console.WriteLine("PRODUCT: {0}", product.Key);
                Console.WriteLine("DESCRIPTION: {0}", product.Value[0]);
                Console.WriteLine("PRICE: {0}", product.Value[1]);
                Console.WriteLine("CATEGORY: {0}", product.Value[2]);
                Console.WriteLine();
            } 
        }
    }

    static void bubbleSort() {
        var productsList = products.ToList();
        for (int i = 0; i < productsList.Count; i++) {
            for (int j = 0; j < productsList.Count - i - 1; j++) {
                decimal price1 = decimal.Parse(productsList[j].Value[1].Substring(1)); 
                decimal price2 = decimal.Parse(productsList[j + 1].Value[1].Substring(1));

                if (price1 > price2) {
                    var temp = productsList[j];
                    productsList[j] = productsList[j + 1];
                    productsList[j + 1] = temp;
                }
            }
        }

        foreach (var product in productsList) {
            Console.WriteLine("PRODUCT: {0}", product.Key);
            Console.WriteLine("DESCRIPTION: {0}", product.Value[0]);
            Console.WriteLine("PRICE: {0}", product.Value[1]);
            Console.WriteLine("CATEGORY: {0}", product.Value[2]);
            Console.WriteLine();
        }
    }

    static void addtoCart(string username) {
        Console.WriteLine("ADD ITEM TO CART: ");
        string cartItem = Console.ReadLine().ToLower();
        var productsList = products.ToList();
        if (products.ContainsKey(cartItem)) {
            if (users[username].cart.Contains(cartItem)) {
                Console.WriteLine("PRODUCT ALREADY IN CART");
            } else {
                foreach (var product in productsList) {
                    if (cartItem == product.Key) {
                        users[username].cart.Add(cartItem);
                        Console.WriteLine("PRODUCT ADDED TO CART");
                        saveUsers("users.txt");
                    }
                }
            }
        } else {
            Console.WriteLine("PRODUCT DOES NOT EXIST");
        }
    }

    static void removefromCart(string username) {
        Console.WriteLine("REMOVE ITEM FROM CART: ");
        string cartItem = Console.ReadLine().ToLower();
        if (users[username].cart.Contains(cartItem)) {
            users[username].cart.Remove(cartItem);
            Console.WriteLine("PRODUCT REMOVED FROM CART");
            saveUsers("users.txt");
        } else {
            Console.WriteLine("PRODUCT NOT IN CART");
        }
    }

    static void showCart(string username) {
        Console.WriteLine();
        foreach (var product in users[username].cart) {
            Console.WriteLine(product);
        }
    }

}




