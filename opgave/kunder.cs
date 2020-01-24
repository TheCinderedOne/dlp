using System;

namespace opgave
{

	public class Kunder
	{
		
		public string navn;
		public string addr;
		public string cpr;
		public string kundeNr;

		// Constructor
		public Kunder()
		{
			this.navn = "";
			this.addr = "";
			this.cpr = "";
			this.kundeNr = "";
		}

		// Setters
		public void setNavn(string navn)
		{
			this.navn = navn;
		}
		public void setAddr(string addr)
		{
			this.addr = addr;
		}
		public void setCpr(string cpr)
		{
			this.cpr = cpr;
		}
		public void setKundeNr(string kundeNr)
		{
			this.kundeNr = kundeNr;
		}

		// Getters
		public string getNavn()
		{
			return this.navn;
		}
		public string getAddr()
		{
			return this.addr;
		}
		public string getCpr()
		{
			return this.cpr;
		}
		public string getKundeNr()
		{
			return this.kundeNr;
		}
	}
}
