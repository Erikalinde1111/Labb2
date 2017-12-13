﻿
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
	[Activity(Label = "TaxRateActivity")]
	public class TaxRateActivity : Activity
	{
		protected override void OnCreate(Bundle savedInstanceState)
		{
			SetContentView(Resource.Layout.TaxRateRapport);
			base.OnCreate(savedInstanceState);

			TextView tvRapport = FindViewById<TextView>(Resource.Id.rapport_utskrift);
			tvRapport.Text = BookkeeperManager.Instance.GetTaxReport();
			// Create your application here
		}
	}
}