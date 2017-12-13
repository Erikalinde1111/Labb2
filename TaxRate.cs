using System;
using SQLite;

namespace Labb2
{
	public class TaxRate : Java.Lang.Object
	{
		//fyll taxratesspinnern med taxrases såsom accounts
		[PrimaryKey, AutoIncrement]
		public int Id { get; private set; }
		public double Moms { get; set; }


		public override string ToString()
		{
			return 100*Moms+" %";
		} 
	}
}
