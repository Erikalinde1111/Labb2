using System;
using SQLite;


namespace Labb2
{
	public class Account : Java.Lang.Object
	{

		public string typeOfAccount { get; set;}
		[PrimaryKey, AutoIncrement]
		public int Id { get; private set;}
		public string Name { get; set;}

		public override string ToString()
		{
			return Name;
		}
	}
}
