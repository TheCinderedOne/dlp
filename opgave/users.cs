using System;
using System.Data.SqlClient;

namespace opgave
{

	public class Users
	{

		// Method for login
		public bool Login(string username, string password)
		{
			bool loginCorrect = false;

			// Connect to database
			string DatabaseConnectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\MU8 Guest\Documents\Bank_Database.mdf;Integrated Security=True;";
			SqlConnection conn = new SqlConnection(DatabaseConnectionString);

			// SQL statement
			SqlCommand sqlcmd = new SqlCommand("SELECT COUNT(*) FROM Brugere WHERE username = " + "'" + username + "'" + " AND password = " + "'" + password + "'", conn);

			conn.Open();

			// Returning an int containing value of entries in database that match 
			int result = (int)sqlcmd.ExecuteScalar(); 
			
			// Check number of matches
			if (result > 0)
			{
				loginCorrect = true;
			} else
			{
				loginCorrect = false;
			}

			// Returning bool depening on result of number check
			return loginCorrect; 
		}
		
		// Method for logout
		public bool Logout()
		{
			Console.ForegroundColor = ConsoleColor.Yellow;
			Console.WriteLine("Du er logget ud");
			Console.ResetColor();

			// Returning false to break while loop
			return false;
		}
		

	}
}