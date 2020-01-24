using System;

namespace opgave
{

    class Program
    {

        // Main program, entry for program executor
        static void Main(string[] args)
        {

            // Classes and variables
            string Line_Breaker = "\n";
            string inputUsername, inputPassword;
            bool main_go;

            Users thisUser = new Users();
            Structure structureVar = new Structure();

            // Welcome msg
            Console.WriteLine("Velkommen til Det Lille PengeInstitut");
            Console.WriteLine("Indtast username og password for at logge ind.");
            Console.Write("\n");

            // Asking for username
            Console.Write("Username: ");
            inputUsername = Console.ReadLine();

            // Asking for password
            Console.Write("Password: ");
            inputPassword = Console.ReadLine();

            // Call login method with added parameters
            thisUser.Login(inputUsername, inputPassword);

            // Check returned result from login method and set value of main_go
            if (thisUser.Login(inputUsername, inputPassword) == true)
            {
                main_go = true;
            } else
            {
                main_go = false;
            }

            // Check main_go value and take action accordingly
            if (main_go == true)
            {
                Console.Write("\n");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Login Successfull");
                Console.ResetColor();
                Console.Write("\n");

                // While value of main_go remains true
                while (main_go == true)
                {
                    string command = "";
                    string menu_title = "Main Menu";

                    structureVar.the_menu_title(menu_title);

                    Console.WriteLine("Kunder");
                    Console.WriteLine("Konti");
                    Console.WriteLine("Institut");
                    Console.WriteLine("Exit");

                    Console.WriteLine("---------------" + Line_Breaker);
                    Console.Write("Choose Option: ");

                    // Get user input
                    command = Console.ReadLine();
                    Console.WriteLine("---------------" + Line_Breaker);

                    // Take action accordingly to user input
                    switch (command)
                    {
                        case "Kunder":
                            structureVar.Kunder();
                            break;
                    
                        case "Konti":
                            structureVar.Konti();
                            break;
                    
                        case "Institut":
                            structureVar.Institut();
                            break;

                        case "Exit":
                            main_go = thisUser.Logout();
                            break;
                    
                        default:
                            structureVar.the_default();
                            break;
                    }     
                }

                // If value of main_go is false 
                // NOTE: reset and try again??? 
            }
            else
            {
                Console.Write("\n");
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Login Failed");
                Console.ResetColor();
            }

        }
    }
}
