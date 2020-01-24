using System;
using System.Data.SqlClient;

namespace opgave
{

	public class Bank
	{

		// Arrays
		public Kunder[] Kunde = new Kunder[100];
		public Konti[] Konto = new Konti[100];

		// Method to highlight output
		private void HighLightOutput(string output)
		{
			Console.Write("\n");
			Console.ForegroundColor = ConsoleColor.Green;
			Console.WriteLine(output);
			Console.ResetColor();
			Console.Write("\n");
		}

		// Contructor
		public Bank()
		{

		}

		// ========== Kunder og relateret methods starter her ==========
		public void addKunde(string navn, string addr, string cpr, string kundeNr, string Konto_NR)
		{
			int saldo_start = 0;
			string DatabaseConnectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\MU8 Guest\Documents\Bank_Database.mdf;Integrated Security=True;";
			SqlConnection conn = new SqlConnection(DatabaseConnectionString);

			conn.Open();
			
			SqlCommand sqlcmd = new SqlCommand("INSERT INTO Kunder (Navn, adresse, CPR, Konto_NR) VALUES (@var1, @var2, @var3, @var4)", conn);

			SqlCommand sqlcmd_Konto = new SqlCommand("INSERT INTO Konti (Kunde_CPR, Konto_NR, Saldo) VALUES (@var5, @var6, @var7)", conn);

			sqlcmd.Parameters.AddWithValue("@var1", navn);
			sqlcmd.Parameters.AddWithValue("@var2", addr);
			sqlcmd.Parameters.AddWithValue("@var3", cpr);
			sqlcmd.Parameters.AddWithValue("@var4", kundeNr);

			sqlcmd_Konto.Parameters.AddWithValue("@var5", cpr);
			sqlcmd_Konto.Parameters.AddWithValue("@var6", Konto_NR);
			sqlcmd_Konto.Parameters.AddWithValue("@var7", saldo_start);

			sqlcmd.ExecuteNonQuery();
			sqlcmd_Konto.ExecuteNonQuery();
		}

		public void deleteKunde(string kundeCPR)
		{
			string DatabaseConnectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\MU8 Guest\Documents\Bank_Database.mdf;Integrated Security=True;";
			SqlConnection conn = new SqlConnection(DatabaseConnectionString);

			conn.Open();

			SqlCommand sqlcmd = new SqlCommand("DELETE FROM Kunder WHERE CPR=@CPR", conn);

			SqlCommand sqlcmd_Konti = new SqlCommand("DELETE FROM Konti WHERE Kunde_CPR=@kundeCPR", conn);

			sqlcmd.Parameters.AddWithValue("@CPR", kundeCPR);

			sqlcmd_Konti.Parameters.AddWithValue("@kundeCPR", kundeCPR);

			sqlcmd.ExecuteNonQuery();

			sqlcmd_Konti.ExecuteNonQuery();
		}
		// ========== Kunder og relateret methods ender her ==========

		// ========== Konti og relateret methods starter her ==========
		public void addKonto(string CPR, string Konto_NR, int Saldo)
		{
			string DatabaseConnectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\MU8 Guest\Documents\Bank_Database.mdf;Integrated Security=True;";
			SqlConnection conn = new SqlConnection(DatabaseConnectionString);

			conn.Open();

			SqlCommand sqlcmd = new SqlCommand("INSERT INTO Konti (Kunde_CPR, Konto_NR, Saldo) VALUES (@var1, @var2, @var3)", conn);

			sqlcmd.Parameters.AddWithValue("@var1", CPR);
			sqlcmd.Parameters.AddWithValue("@var2", Konto_NR);
			sqlcmd.Parameters.AddWithValue("@var3", Saldo);

			sqlcmd.ExecuteNonQuery();
		}

		public void VisKundesKonti()
		{
			string DatabaseConnectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\MU8 Guest\Documents\Bank_Database.mdf;Integrated Security=True;";
			SqlConnection conn = new SqlConnection(DatabaseConnectionString);

			conn.Open();

			SqlCommand sqlcmd = new SqlCommand("SELECT * FROM Kunder", conn);

			using (SqlDataReader rdr = sqlcmd.ExecuteReader())
			{
				while (rdr.Read())
				{
					Console.WriteLine("ID: {0}", rdr.GetInt32(0));
					Console.WriteLine("Navn: {0}", rdr.GetString(1));
					Console.WriteLine("Adresse: {0}", rdr.GetString(2));
					Console.WriteLine("CPR: {0}", rdr.GetString(3));
					Console.WriteLine("KontoNR: {0}", rdr.GetString(4));
					Console.WriteLine("");

					//Console.WriteLine("{0}", rdr.GetInt32(0));
					//show_saldo = rdr.GetInt32(0);
				}
			}
			sqlcmd.ExecuteNonQuery();

			Console.Write("\n");
			Console.WriteLine("Se bestemt konto");
			Console.WriteLine("Tilbage");
			Console.WriteLine("---------------" + "\n\n");
			Console.Write("Choose Option: ");

			string NytValg = Console.ReadLine();
			
			switch (NytValg)
			{
				case "Se bestemt konto":
					string Kunde_CPR;
					Console.Write("Indtast CPR: ");
					Kunde_CPR =Console.ReadLine();
					Console.WriteLine("\n\n");

					SqlCommand sqlcmdkonto = new SqlCommand("SELECT * FROM Konti WHERE Kunde_CPR=@CPR", conn);
					
					sqlcmdkonto.Parameters.AddWithValue("@CPR", Kunde_CPR);
					using (SqlDataReader kontordr = sqlcmdkonto.ExecuteReader())
					{
						while (kontordr.Read())
						{
							Console.WriteLine("ID: {0}", kontordr.GetInt32(0));
							Console.WriteLine("Kunde CPR: {0}", kontordr.GetString(1));
							Console.WriteLine("Konto Nummer: {0}", kontordr.GetString(2));
							Console.WriteLine("Saldo: {0}", kontordr.GetInt32(3));
							Console.WriteLine("Rentesats: {0}", ( kontordr.GetInt32(3) * 0.0025 ) );
							Console.WriteLine("");
						}
					}
					sqlcmdkonto.ExecuteNonQuery();

					break;

				case "Tilbage":
					break;

				default:
					Console.WriteLine("\n\n");
					break;
			}

		}

		public void changeSaldo(int Konto_NR)
		{
			int show_saldo = 0;
			

			string DatabaseConnectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\MU8 Guest\Documents\Bank_Database.mdf;Integrated Security=True;";
			SqlConnection conn = new SqlConnection(DatabaseConnectionString);

			conn.Open();

			SqlCommand sqlcmd = new SqlCommand("SELECT Saldo FROM Konti WHERE Konto_NR=@kontoNR", conn);

			sqlcmd.Parameters.AddWithValue("@kontoNR", Konto_NR);
			//sqlcmd.Parameters.AddWithValue(show_saldo, "Saldo");

			using (SqlDataReader rdr = sqlcmd.ExecuteReader())
			{
				while (rdr.Read()){
					//Console.WriteLine("{0}", rdr.GetInt32(0));
					show_saldo = rdr.GetInt32(0);
				}
			}

			sqlcmd.ExecuteNonQuery();

			Console.WriteLine("Konto: " + Konto_NR + " og kontos Saldo er: " + show_saldo);

			Console.WriteLine("Vælg hvor meget skal lægges til eller trækkes fra " + Konto_NR + " Saldo");

			int saldo_change = Convert.ToInt32(Console.ReadLine());

			int sum = show_saldo + saldo_change;

			Console.WriteLine("Konto: " + Konto_NR + " Nye saldo er: " + sum);

			SqlCommand sqlcmdsaldo = new SqlCommand("UPDATE Konti SET Saldo=@var1 WHERE Konto_NR=@kontoNR", conn);

			sqlcmdsaldo.Parameters.AddWithValue("@kontoNR", Konto_NR);

			sqlcmdsaldo.Parameters.AddWithValue("@var1", sum);

			sqlcmdsaldo.ExecuteNonQuery();

		}

		public void Samlet_konti_udregning()
		{

			string[] saldoArray = new string[100];
			int samlet_saldo = 0;

			string DatabaseConnectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\MU8 Guest\Documents\Bank_Database.mdf;Integrated Security=True;";
			SqlConnection conn = new SqlConnection(DatabaseConnectionString);

			conn.Open();

			SqlCommand sqlcmd = new SqlCommand("SELECT Saldo FROM Konti", conn);
		
			using (SqlDataReader alle_konti_rdr = sqlcmd.ExecuteReader())
			{
				while (alle_konti_rdr.Read())
				{
					samlet_saldo += alle_konti_rdr.GetInt32(0);
				}
			}
			sqlcmd.ExecuteNonQuery();
			HighLightOutput(Convert.ToString(samlet_saldo));
		}


		// ========== Konti og relateret methods ender her ==========

		// ========== Institut og relateret methods starter her ==========
		public void BanksInstitutInformation()
		{
			string[] InstitutInformation = {"Det Lille PengeInstitut", "+45 98 76 54 58", "Munkebjergvej 120", "dlp@dlp.dk"};
			int counter;

			for (counter = 0; counter < InstitutInformation.Length; counter++)
			{
				HighLightOutput(InstitutInformation[counter]);
			} 
		}
		// ========== Institut og relateret methods ender her ==========
		
	}
}
