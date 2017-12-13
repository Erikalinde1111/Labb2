
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace Labb2
{
	[Activity(Label = "Entries")]
	public class Entries : Activity
	{
		private ListView entrieList;
		protected override void OnCreate(Bundle savedInstanceState)
		{
			BookkeeperManager.Instance.getEntryList();
			//Denna xml skall ha en listview som skall lista alla entries borde kunna göra något liknande som nedan:
			base.OnCreate(savedInstanceState);
			SetContentView(Resource.Layout.Entries);
			entrieList = FindViewById<ListView>(Resource.Id.entries_list);
			entrieList.Adapter = new EntryAdapter(this, BookkeeperManager.Instance.Entries);
		}
	}
}
