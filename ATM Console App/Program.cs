using System;
using System.Runtime.Intrinsics.Arm;

#nullable disable

public class CardHolder 
{
    String cardnum;
    int pin;
    String fname;
    String lname;
    double balance;

    public CardHolder(String cardnum, int pin, String fname, String lname, double balance) 
    {
        this.cardnum = cardnum;
        this.pin = pin;
        this.fname = fname;
        this.lname = lname;
        this.balance = balance;
    }

    public String getCardnum()
    {
        return cardnum;
    }

    public int getPin()
    {
        return pin;
    }

    public String getFname()
    {
        return fname;
    }

    public String getLname()
    {
        return lname;
    }

    public double getBalance()
    {
        return balance;
    }

    public void setCardnum(String newCardNum)
    {
        cardnum = newCardNum;
    }

    public void setPin(int newPin)
    {
        pin = newPin;
    }

    public void setFname(String newFname)
    {
        fname = newFname;
    }

    public void setLname(String newLname)
    {
        lname = newLname;
    }

    public void setBalance(double newBalance)
    {
        balance = newBalance;
    }

    public static void Main(String[] args)
    {
        void printOptions()
        {
            Console.WriteLine("Choose from the following options:");
            Console.WriteLine("1. Cash Deposit");
            Console.WriteLine("2. Cash Withdrawal");
            Console.WriteLine("3. Balance Enquiry");
            Console.WriteLine("4. Exit");
        }

        void deposit(CardHolder currentUser)
        {
            try {
                Console.WriteLine("Enter the amount to deposit: ");
                double depositAmount = Double.Parse(Console.ReadLine());
                currentUser.setBalance(currentUser.getBalance() + depositAmount);
                Console.WriteLine("Your new balance is: $" + currentUser.getBalance());
            } 
            catch (Exception e) {
                Console.WriteLine("Error: " + e);
            }
        }

        void withdraw(CardHolder currentUser)
        {
            try {
                Console.WriteLine("Enter the amount to withdraw: ");
                double withdrawAmount = Double.Parse(Console.ReadLine());
                if (withdrawAmount > currentUser.getBalance()) {
                    Console.WriteLine("Insufficient funds!");
                } 
                else {
                    currentUser.setBalance(currentUser.getBalance() - withdrawAmount);
                    Console.WriteLine("Your new balance is: $" + currentUser.getBalance());
                }
            } 
            catch (Exception e) {
                Console.WriteLine("Error: " + e);
            }
        }

        void balanceEnquiry(CardHolder currentUser)
        {
            Console.WriteLine("Your current balance is: $" + currentUser.getBalance());
        }  
        
        List<CardHolder> cardHolders = new List<CardHolder>();
        cardHolders.Add(new CardHolder("123456789", 1234, "Ishaan", "Ratanshi", 1000.00));
        cardHolders.Add(new CardHolder("234567890", 1234, "Jatin", "Patel", 2000.00));
        cardHolders.Add(new CardHolder("345678901", 1234, "Mohit", "Gupta", 9800.00));
        cardHolders.Add(new CardHolder("456789012", 1234, "Ankit", "Kumar", 5000.00));

        Console.WriteLine("Welcome to the ATM!");
        Console.WriteLine("Enter your card number: ");
        String debitCardNum = "";
        CardHolder currentUser;

        while (true) 
        {
            try
            {
                debitCardNum = Console.ReadLine();
                currentUser = cardHolders.FirstOrDefault(a => a.cardnum == debitCardNum);
                if (currentUser != null) 
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Wrong card number. Please try again.");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: " + e);
                Console.WriteLine("Please try again.");
            }  
        }

        Console.Clear();
        Console.WriteLine("Enter your pin: ");
        int userPin = 0;
        while (true) 
        {
            try
            {
                userPin = int.Parse(Console.ReadLine());
                if (currentUser.getPin() == userPin) 
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Wrong pin. Please try again.");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: " + e);
                Console.WriteLine("Please try again.");
            }
        }

        Console.Clear();
        Console.WriteLine("Welcome " + currentUser.getFname() + "!");
        int option = 0;
        do 
        {
            printOptions();
            try
            {
                option = int.Parse(Console.ReadLine());
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: " + e);
                Console.WriteLine("Please try again.");
            }

            switch (option)
            {
                case 1:
                    deposit(currentUser);
                    break;
                case 2:
                    withdraw(currentUser);
                    break;
                case 3:
                    balanceEnquiry(currentUser);
                    break;
                case 4:
                    Console.WriteLine("Thank you for using the ATM. Goodbye!");
                    break;
                default:
                    Console.WriteLine("Invalid option. Please try again.");
                    break;
            }

        }
        while (option != 4);
    }
}