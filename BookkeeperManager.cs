using System;
using System.Collections.Generic;
using System.Linq;
using SQLite;

namespace Labb2
{
	public class BookkeeperManager
	{

		private static BookkeeperManager instance;
		private static string dbPath;
		private List<Account> outcomeAccounts;
		private List<Account> incomeAccounts;
		//private List<String> outcomeAccountsNames;
		//private List<string> incomeAccountsNames;
		private SQLiteConnection db;
		//private List<string> moneyAccountsNames;
		private List<Account> moneyAccounts;
		private List<TaxRate> taxrates;
		public List<Entry> entries;

		public static BookkeeperManager Instance
		{
			get
			{
				if (instance == null)
				{
					instance = new BookkeeperManager();
				}
				return instance;
			}

		}


		public List<Account> OutcomeAccounts { get { return outcomeAccounts;} }
		public List<Account> IncomeAccounts{ get { return incomeAccounts; } }
		//public List<string> OutcomeAccountsNames { get { return outcomeAccountsNames;} }
		//public List<string> IncomeAccountsNames{ get { return incomeAccountsNames; } }
		public List<Account> MoneyAccounts { get { return moneyAccounts;} }
		//public List<string> MoneyAccountsNames { get { return moneyAccountsNames;} }
		public List<TaxRate> Taxrates { get { return taxrates;} }
		public List<Entry> Entries { get { return entries; } }

		private BookkeeperManager()
		{
			//skapa databaskoppling i konstruktorn
			dbPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
			dbPath += "\\database.db";
			db = new SQLiteConnection(dbPath);
			//skapa tabellen Account
			 db.CreateTable<Account>();
			//entries = new List<Entry>();
			//Entries.Add(new Entry() { Id = 10 });
			db.DeleteAll<Account>();

			Account a1 = new Account() { Name = "Lön (3000)", typeOfAccount = "Income" };
			Account a2 = new Account() { Name = "PRintäkter (2001)", typeOfAccount = "Income" };
			Account a3 = new Account() { Name = "Underhåll (4000)", typeOfAccount = "Outcome" };
			Account a4 = new Account() { Name = "Kassa (5000)", typeOfAccount = "Money" };
			db.Insert(a1);
			db.Insert(a2);
			db.Insert(a3);
			db.Insert(a4);

			outcomeAccounts = db.Table<Account>().Where(a => a.typeOfAccount == "Outcome").ToList();
			incomeAccounts = db.Table<Account>().Where(a => a.typeOfAccount == "Income").ToList();
			moneyAccounts = db.Table<Account>().Where(a => a.typeOfAccount == "Money").ToList();

			db.Close();


			db = new SQLiteConnection(dbPath);
			db.CreateTable<TaxRate>();
			db.DeleteAll<TaxRate>();

			TaxRate t1 = new TaxRate() { Moms = 0.05 };
			TaxRate t2 = new TaxRate() { Moms = 0.25 };
			TaxRate t3 = new TaxRate() { Moms = 0.50 };
			db.Insert(t1);
			db.Insert(t2);
			db.Insert(t3);

			taxrates = db.Table<TaxRate>().ToList();
			db.Close();

			db = new SQLiteConnection(dbPath);
			db.CreateTable<Entry>();
			entries = db.Table<Entry>().ToList();
			db.Close();

		}

		public void AddEntry(Entry e)
		{
			//du skall inserta e till Entry table
			//entries.Add(e);
			//entryt läggs till i entries
			//Console.WriteLine(entries.Count);
			db = new SQLiteConnection(dbPath);
			db.Insert(e);
			db.Close();
		}

		public void getEntryList()
		{
			db = new SQLiteConnection(dbPath);

			entries = db.Table<Entry>().ToList();
			db.Close();

		}

		public string GetTaxReport() 
		{
			string report = "";
			foreach (Entry entry in entries)
			{
				if (entry.isIncome)
				{
					report += entry.desciption + ": " + entry.total * entry.TaxRate + " kr" + "\n";
				}
				else {
					double sum = -entry.total;
					report += entry.desciption + ": " + sum * entry.TaxRate + " kr" + "\n";                  
				}

				/*Console.WriteLine(entry.idTaxrate);
				foreach (TaxRate taxrate in taxrates)
				{
					Console.WriteLine(taxrate.Id+(" ID för detta taxrate"));
				}*/



			}

			return report;
		}


	}
}
