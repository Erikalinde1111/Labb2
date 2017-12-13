using System;
using SQLite;


namespace Labb2
{
	public class Entry
	{
		[PrimaryKey, AutoIncrement]
		public int Id { get; private set; }
		public int idMoneyAccount { get; set; }
		public int idTypeAccount { get; set;}
		public int idTaxrate { get; set;}
		public double TaxRate { get; set; }
		public bool isIncome { get; set;}
		public string date { get; set;}
		public string desciption { get; set;}
		public int total { get; set;}
	}
}
