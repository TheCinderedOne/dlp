using System;
using System.Data.SqlClient;

namespace opgave
{

    public class Structure
    {
        
        // Variables and others

        // Method for handling menu title
        public void the_menu_title(string menu_title_string)
        {
            Console.Write("\n");
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("=|======= " + menu_title_string + " =======|=");
            Console.ResetColor();
            Console.Write("\n");
        }

        // Method for handling unknown input
        public void the_default()
        {
            string U_K = "=|======= UKENDT KOMMANDO =======|=\n";
            
            Console.Write("\n");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(U_K);
            Console.ResetColor();
        }

        // Line breaker variable
        string Line_Breaker = "\n\n";

        // ========== KUNDER og relateret methods starter her ==========
        public void Kunder()
        {
            bool kunder_go = true;

            while (kunder_go == true)
            {
                string command_kunder = "";
                string menu_title = "Kunder";

                the_menu_title(menu_title);

                Console.WriteLine("Opret");
                //Console.WriteLine("Rediger");
                Console.WriteLine("Slet");
                Console.WriteLine("Tilbage");
                Console.WriteLine("---------------" + Line_Breaker);
                Console.Write("Choose Option: ");
                command_kunder = Console.ReadLine();

                switch (command_kunder)
                {
                    case "Opret":
                        string undermenu_opret = "Opret";

                        the_menu_title(menu_title + ": " + undermenu_opret);
                        Kunde_Opret();
                        Console.WriteLine("---------------" + Line_Breaker);
                        break;
                    /*
                    case "Rediger":
                        // Fjern??
                        break;
                    */
                    case "Slet":
                        string undermenu_slet = "Slet";

                        the_menu_title(menu_title + ": " + undermenu_slet);
                        Kunde_Slet();
                        Console.WriteLine("---------------" + Line_Breaker);
                        break;

                    case "Tilbage": // tilbage til "main menu"
                        kunder_go = false;
                        break;

                    default:
                        the_default();
                        break;
                }
            }
        }

        private void Kunde_Opret()
        {
            Bank minbank = new Bank();

            string opretKunde_Navn;
            string opretKunde_Addr;
            string opretKunde_Cpr;
            string opretKunde_KundeNr;
            string Konto_NR;

            int opretKunde_Cpr_length;

            Console.Write("Indtast kunde navn: ");
            opretKunde_Navn = Console.ReadLine();

            Console.Write("Indtast kunde addr: ");
            opretKunde_Addr = Console.ReadLine();

            Console.Write("Indtast kunde CPR: ");
            opretKunde_Cpr = Console.ReadLine();

            Console.Write("Indtast kunde nr: ");
            opretKunde_KundeNr = Console.ReadLine();

            Console.Write("Indtast konto nr: ");
            Konto_NR = Console.ReadLine();

            opretKunde_Cpr_length = opretKunde_Cpr.Length;

            if (opretKunde_Cpr_length == 11)
            {
                minbank.addKunde(opretKunde_Navn, opretKunde_Addr, opretKunde_Cpr, opretKunde_KundeNr, Konto_NR);
            } else
            {
                Console.Write("\n");
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Kunde CPR skal være 11 tegn langt.");
                Console.ResetColor();
                Kunde_Opret();
            }

            
  
        }

        private void Kunde_Slet()
        {
            
            Bank minbank = new Bank();

            string deleteKunde_by_cpr;

            Console.Write("Indtast CPR nummer på kunden du vil slette: ");

            deleteKunde_by_cpr = Console.ReadLine();

            minbank.deleteKunde(deleteKunde_by_cpr);
            
        }
        // ========== KUNDER og relateret methods ender her ==========

        // ========== KONTI og relateret methods starter her ==========
        public void Konti()
        {
            bool konti_go = true;
            string menu_title = "Konti";

            the_menu_title(menu_title);

            while (konti_go == true)
            {

                string commmand_konti = "";

                Console.Write("\n");
                Console.WriteLine("Se bestemt konto");
                Console.WriteLine("Opret konto");
                Console.WriteLine("Penge handling");
                Console.WriteLine("Tilbage");
                Console.WriteLine("---------------" + Line_Breaker);
                Console.Write("Choose Option: ");
                commmand_konti = Console.ReadLine();

                switch (commmand_konti)
                {
                    case "Se bestemt konto":
                        string undermenu_se_bestment_konto = "Se bestemt konto";

                        the_menu_title(menu_title + ": " + undermenu_se_bestment_konto);
                        Se_bestemt_konto();
                        break;

                    case "Opret konto":
                        string undermenu_opret_konto = "Opret konto";

                        the_menu_title(menu_title + ": " + undermenu_opret_konto);
                        Opret_konto();
                        break;

                    case "Penge handling":
                        string undermenu_penge_handling = "Penge handling";

                        the_menu_title(menu_title + ": " + undermenu_penge_handling);
                        Penge_Handling();
                        break;

                    case "Tilbage": // tilbage til "main menu"
                        konti_go = false;
                        break;

                    default:
                        the_default();
                        break;
                }
            }
        }

        private void Se_bestemt_konto() // på vente liste, ikke et must!
        {
            bool se_bestemt_konto_go = true;

            while (se_bestemt_konto_go == true)
            {

                string command_se_bestemt_konto = "";

                Console.WriteLine("Se alle kunder");
                Console.WriteLine("Tilbage");
                Console.WriteLine("---------------" + Line_Breaker);
                Console.Write("Choose Option: ");
                command_se_bestemt_konto = Console.ReadLine();

                switch (command_se_bestemt_konto)
                {
                    case "Se alle kunder":
                        Bank minbank = new Bank();

                        minbank.VisKundesKonti();
                        break;

                    case "Tilbage": // tilbage til "main menu"
                        se_bestemt_konto_go = false;
                        break;

                    default:
                        the_default();
                        break;
                }
            }
        }

        private void Opret_konto()
        {
            Bank minbank = new Bank();

            string Kunde_CPR;
            string Konto_NR;
            int Saldo = 0;

            Console.Write("Indtast kunde CPR: ");
            Kunde_CPR = Console.ReadLine();

            Console.Write("Indtast Konto Nummer: ");
            Konto_NR = Console.ReadLine();

            minbank.addKonto(Kunde_CPR, Konto_NR, Saldo);
        }

        private void Penge_Handling()
        {

            Bank minbank = new Bank();
            bool penge_handling_go = true;

            while (penge_handling_go == true)
            {

                string command_penge_handling = "";

                Console.WriteLine("Rediger saldo");
                Console.WriteLine("Tilbage");
                Console.WriteLine("---------------" + Line_Breaker);
                Console.Write("Choose Option: ");
                command_penge_handling = Console.ReadLine();

                switch (command_penge_handling)
                {
                    case "Rediger saldo":

                        int search_for_konto_nr;

                        Console.Write("Indtast konto NR: ");
                        search_for_konto_nr = Convert.ToInt32(Console.ReadLine());

                        minbank.changeSaldo(search_for_konto_nr);
                        break;

                    case "Tilbage": // tilbage til "main menu"
                        penge_handling_go = false;
                        break;

                    default:
                        the_default();
                        break;
                }
            }
        }
        // ========== KONTI og relateret methods ender her ==========

        // ========== INSTITUT og relateret methods starter her ==========
        public void Institut()
        {
            bool institut_go = true;
            string menu_title = "Institut";

            the_menu_title(menu_title);

            while (institut_go == true)
            {

                string command_institut = "";

                Console.WriteLine("Se samlet konti værdi");
                Console.WriteLine("Se antal konti");
                Console.WriteLine("Se antal kunder");
                Console.WriteLine("Se institut information");
                Console.WriteLine("Tilbage");
                Console.WriteLine("---------------" + Line_Breaker);
                Console.Write("Choose Option: ");
                command_institut = Console.ReadLine();

                switch (command_institut)
                {
                    case "Se samlet konti værdi":
                        string undermenu_se_samlet_konti_vaerdi = "Se samlet konti værdi";

                        the_menu_title(menu_title + ": " + undermenu_se_samlet_konti_vaerdi);
                        Samlet_konti_vaerdi();
                        break;

                    case "Se antal konti":
                        string undermenu_se_antal_konti = "Se antal konti";

                        the_menu_title(menu_title + ": " + undermenu_se_antal_konti);
                        Samlet_antal_konti();
                        break;

                    case "Se antal kunder":
                        string undermenu_se_antal_kunder = "Se antal kunder";

                        the_menu_title(menu_title + ": " + undermenu_se_antal_kunder);
                        Samlet_antal_kunder();
                        break;

                    case "Se institut information":
                        string undermenu_institut_information = "Se institut information";

                        the_menu_title(menu_title + ": " + undermenu_institut_information);
                        Institut_information();
                        break;

                    case "Tilbage":
                        institut_go = false;
                        break;

                    default:
                        the_default();
                        break;
                }
            }
        }

        private void Samlet_konti_vaerdi()
        {
            Bank minbank = new Bank();

            minbank.Samlet_konti_udregning();
        }

        private void Samlet_antal_konti()
        {
            // Connect to database
            string DatabaseConnectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\MU8 Guest\Documents\Bank_Database.mdf;Integrated Security=True;";
            SqlConnection conn = new SqlConnection(DatabaseConnectionString);

            // SQL statement
            SqlCommand sqlcmd = new SqlCommand("SELECT COUNT(*) FROM Konti", conn);

            conn.Open();

            // Returning an int containing value of entries in database
            int result = (int)sqlcmd.ExecuteScalar();

            Console.WriteLine("Samlet antal konti er: " + result);
            Console.Write("\n");
        }

        private void Samlet_antal_kunder()
        {
            // Connect to database
            string DatabaseConnectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\MU8 Guest\Documents\Bank_Database.mdf;Integrated Security=True;";
            SqlConnection conn = new SqlConnection(DatabaseConnectionString);

            // SQL statement
            SqlCommand sqlcmd = new SqlCommand("SELECT COUNT(*) FROM Kunder", conn);

            conn.Open();

            // Returning an int containing value of entries in database
            int result = (int)sqlcmd.ExecuteScalar();

            Console.WriteLine("Samlet antal kunder er: " + result);
            Console.Write("\n");
        }

        private void Institut_information()
        {
            Bank minbank = new Bank();

            minbank.BanksInstitutInformation();
        }
        // ========== INSTITUT og relateret methods ender her ==========


    }

}
